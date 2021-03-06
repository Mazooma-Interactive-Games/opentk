﻿using System;
using System.IO;
using Bind.GL2;

namespace Bind.ES
{
    // Generator implementation for OpenGL ES 1.0 and 1.1
    class ES11Generator : Generator
    {
        public ES11Generator(Settings settings, string dirName)
            : base(settings, dirName)
        {
            Settings.DefaultOutputPath = String.Format(
                Settings.DefaultOutputPath, "Graphics", "ES11");
            Settings.DefaultOutputNamespace = "OpenTK.Graphics.ES11";
            Settings.DefaultEnumsFile = "ES11Enums.cs";
            Settings.DefaultWrappersFile = "ES11.cs";
            Settings.DefaultClassesFile = "ES11.Extensions.cs";
            Settings.DefaultDocPath = Path.Combine(
                Settings.DefaultDocPath, "ES20"); // no ES11 docbook sources available

            // Khronos releases a combined 1.0+1.1 specification,
            // so we cannot distinguish between the two.
            // Todo: add support for common and light profiles.
            Profile = "gles1";
            Version = "1.0|1.1";

            // For compatibility with OpenTK 1.0 and Xamarin, generate
            // overloads using the "All" enum in addition to strongly-typed enums.
            // This can be disabled by passing "-o:-keep_untyped_enums" as a cmdline parameter.
            Settings.DefaultCompatibility |= Settings.Legacy.KeepUntypedEnums;
            Settings.DefaultCompatibility |=
                Settings.Legacy.KeepStringArrayOverloads;
        }
    }
}
