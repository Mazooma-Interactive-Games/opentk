using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

using Bind.Structures;

namespace Bind
{
    class DocProcessor
    {
        static readonly char[] numbers = "0123456789".ToCharArray();
        static readonly char[] separators =
            new char[] { ',', '*', '\t', '\n', '\r', ' ' };
        static readonly Regex remove_mathml = new Regex(
            @"<(mml:math|inlineequation)[^>]*?>(?:.|\n)*?</\s*\1\s*>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
        static readonly Regex remove_doctype = new Regex(
            @"<!DOCTYPE[^>\[]*(\[.*\])?>", RegexOptions.Compiled | RegexOptions.Multiline);
        static readonly Regex remove_xmlns = new Regex(
            "xmlns=\".+\"", RegexOptions.Compiled);
        static readonly Regex remove_unknown_entities = new Regex(
            "&.+;", RegexOptions.Compiled);

        readonly Dictionary<string, string> DocumentationFiles =
            new Dictionary<string, string>();
        readonly Dictionary<string, Documentation> DocumentationCache =
            new Dictionary<string, Documentation>();

        Documentation Cached;
        string LastFile;

        IBind Generator { get; set; }
        Settings Settings { get { return Generator.Settings; } }

        public DocProcessor(IBind generator)
        {
            if (generator == null)
                throw new ArgumentNullException();

            Generator = generator;
            foreach (string file in Directory.GetFiles(Settings.DocPath).Concat(
                Directory.GetFiles(Settings.FallbackDocPath)))
            {
                var name = Path.GetFileName(file);
                if (!DocumentationFiles.ContainsKey(name))
                {
                    DocumentationFiles.Add(name, file);
                }
            }
        }

        public Documentation Process(Function f, EnumProcessor processor)
        {
            Documentation docs = null;

            if (DocumentationCache.ContainsKey(f.WrappedDelegate.Name))
            {
                return DocumentationCache[f.WrappedDelegate.Name];
            }
            else
            {
                var file = Settings.FunctionPrefix + f.WrappedDelegate.Name + ".xml";
                if (!DocumentationFiles.ContainsKey(file))
                    file = Settings.FunctionPrefix + f.TrimmedName + ".xml";
                if (!DocumentationFiles.ContainsKey(file))
                    file = Settings.FunctionPrefix + f.TrimmedName.TrimEnd(numbers) + ".xml";

                docs = 
                    (DocumentationFiles.ContainsKey(file) ? ProcessFile(DocumentationFiles[file], processor) : null) ??
                    new Documentation
                    {
                        Summary = String.Empty,
                        Parameters = f.Parameters.Select(p =>
                        new DocumentationParameter(p.Name, String.Empty)).ToList()
                    };

                DocumentationCache.Add(f.WrappedDelegate.Name, docs);
            }

            return docs;
        }

        // Strips MathML tags from the source and replaces the equations with the content
        // found in the <!-- eqn: :--> comments in the docs.
        // Todo: Some simple MathML tags do not include comments, find a solution.
        // Todo: Some files include more than 1 function - find a way to map these extra functions.
        Documentation ProcessFile(string file, EnumProcessor processor)
        {
            string text;

            if (LastFile == file)
                return Cached;

            LastFile = file;
            text = File.ReadAllText(file);

            text = text
                .Replace("&epsi;", "ϵ") // Fix mathml entities
                .Replace("&plusmn;", "±")
                .Replace("&infin;", "∞")
                .Replace("&copy;", "©")
                .Replace("&ge;", "≥")
                .Replace("&le;", "≤")
                .Replace("xml:", String.Empty) // Remove namespaces
                .Replace("xlink:", String.Empty);
            text = remove_doctype.Replace(text, String.Empty);
            text = remove_xmlns.Replace(text, String.Empty);
            text = remove_unknown_entities.Replace(text, String.Empty);

            Match m = remove_mathml.Match(text);
            while (m.Length > 0)
            {
                string removed = text.Substring(m.Index, m.Length);

                text = text.Remove(m.Index, m.Length);
                int equation = removed.IndexOf("eqn");
                if (equation > 0)
                {
                    // Find the start and end of the equation string
                    int eqn_start = equation + 4;
                    int eqn_end = removed.IndexOf(":-->") - equation - 4;
                    if (eqn_end < 0)
                    {
                        // Note: a few docs from man4 delimit eqn end with ": -->"
                        eqn_end = removed.IndexOf(": -->") - equation - 4;
                    }
                    if (eqn_end < 0)
                    {
                        Console.WriteLine("[Warning] Failed to find equation for mml.");
                        goto next;
                    }

                    string eqn_substring = removed.Substring(eqn_start, eqn_end);
                    text = text.Insert(m.Index, "<![CDATA[" + eqn_substring + "]]>");
                }
                else
                {
                    string mml = String.Empty;
                    try
                    {
                        removed = removed.Replace("mml:", String.Empty); // avoid undeclared namespace
                        mml = XElement.Parse(removed).Value;
                        text = text.Insert(m.Index, mml);
                    }
                    catch (Exception e)
                    {
                    }
                }

            next:
                m = remove_mathml.Match(text);
            }

            XDocument doc = null;
            try
            {
                var settings = new XmlReaderSettings
                {
                    ProhibitDtd = false,
                    XmlResolver = null,
                    ValidationType = ValidationType.None
                };

                // We need to turn off docbook DTD processing,
                // otherwise this process will never finish
                // (it keeps trying to load the DTD from the server
                // for every single documentation file!)
                // Note: yes, that's what it takes to turn off
                // DTD processing...
                using (var sr = new StringReader(text))
                using (var xml = XmlReader.Create(sr, settings))
                {
                    doc = XDocument.Load(xml);
                }

                Cached = ToInlineDocs(doc, processor);
                return Cached;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine((doc ?? new XDocument()).ToString());
                return null;
            }
        }

        Documentation ToInlineDocs(XDocument doc, EnumProcessor enum_processor)
        {
            if (doc == null || enum_processor == null)
                throw new ArgumentNullException();

            var no_const_processing = Settings.Legacy.NoAdvancedEnumProcessing | Settings.Legacy.ConstIntEnums;
            if (!Generator.Settings.IsEnabled(no_const_processing))
            {
                // Translate all GL_FOO_BAR constants according to EnumProcessor
                foreach (var e in doc.XPathSelectElements("//constant"))
                {
                    var c = e.Value;
                    if (c.StartsWith(Settings.ConstantPrefix))
                    {
                        // Remove "GL_" from the beginning of the string
                        c = c.Replace(Settings.ConstantPrefix, String.Empty);
                    }
                    e.Value = enum_processor.TranslateConstantName(c, false);
                }
            }

            // Create inline documentation
            var inline = new Documentation
            {
                Summary =
                    Cleanup(
                        ((IEnumerable)doc.XPathEvaluate("/refentry/refnamediv/refpurpose"))
                        .Cast<XElement>().First().Value),
                Parameters =
                    ((IEnumerable)doc.XPathEvaluate("/refentry/refsect1[substring(@id, 1, 10)='parameters']/variablelist/varlistentry"))
                        .Cast<XElement>()
                        .SelectMany(plist => plist
                            .XPathSelectElements("term/parameter|term/varname|term")
                            .Select(p =>
                                new DocumentationParameter(
                                    String.Join("", (p ?? new XElement("dummy")).Value.Split(separators, StringSplitOptions.RemoveEmptyEntries)) // Some docs have whitespace characters in their param names
                                        .Replace(' ', '_'), // Some docs also have incorrect param names (e.g. clCreateImage3D.xml -> "image depth" instead of "image_depth"
                                    Cleanup(p.XPathSelectElement("../listitem|../../listitem").Value)))
                            .Distinct())
                    .ToList()
            };

            inline.Summary = Char.ToUpper(inline.Summary[0]) + inline.Summary.Substring(1);
            return inline;
        }

        static readonly char[] newline = new char[] { '\n' };
        static string Cleanup(string text)
        {
            return
                String.Join(" ", text
                    .Replace("\r", "\n")
                    .Split(newline, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim()).ToArray())
                    .Trim();
        }
    }
}
