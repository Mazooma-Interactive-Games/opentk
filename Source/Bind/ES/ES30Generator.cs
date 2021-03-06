﻿using System;
using System.IO;
using Bind.GL2;

namespace Bind.ES
{
    // Generation implementation for OpenGL ES 3.0
    class ES30Generator : Generator
    {
        public ES30Generator(Settings settings, string dirName)
            : base(settings, dirName)
        {
            Settings.DefaultOutputPath = String.Format(
                Settings.DefaultOutputPath, "Graphics", "ES30");
            Settings.DefaultOutputNamespace = "OpenTK.Graphics.ES30";
            Settings.DefaultEnumsFile = "ES30Enums.cs";
            Settings.DefaultWrappersFile = "ES30.cs";
            Settings.DefaultClassesFile = "ES30.Extensions.cs";
            Settings.DefaultDocPath = Path.Combine(
                Settings.DefaultDocPath, "ES30");

            Profile = "gles2"; // The 3.0 spec reuses the gles2 apiname
            Version = "2.0|3.0";

            // For compatibility with OpenTK 1.0 and Xamarin, generate
            // overloads using the "All" enum in addition to strongly-typed enums.
            // This can be disabled by passing "-o:-keep_untyped_enums" as a cmdline parameter.
            Settings.DefaultCompatibility |= Settings.Legacy.KeepUntypedEnums;
            Settings.DefaultCompatibility |=
                Settings.Legacy.KeepStringArrayOverloads;
        }
    }
}
