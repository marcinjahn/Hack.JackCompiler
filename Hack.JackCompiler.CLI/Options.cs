using System;
using System.IO;

namespace Hack.JackCompiler.CLI
{
    public class Options
    {
        public Options(FileSystemInfo inputPath, FileInfo outputFile)
        {
            InputPath = inputPath ?? throw new ArgumentNullException(nameof(inputPath));
            OutputFile = outputFile ?? throw new ArgumentNullException(nameof(outputFile));
        }

        public FileSystemInfo InputPath { get; set; }
        public FileInfo OutputFile { get; set; }
    }
}