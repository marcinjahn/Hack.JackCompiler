using System;
using System.IO;

namespace Hack.VMTranslator.Lib.Output
{
    public static class OutputUtilities
    {
        public static FileInfo GetOutputFileInfo(FileSystemInfo inputPath)
        {
            if (File.Exists(inputPath.FullName))
            {
                return new FileInfo(inputPath.FullName.Replace(".vm", ".asm"));
            }
            else if (Directory.Exists(inputPath.FullName))
            {
                return new FileInfo(Path.Join(inputPath.FullName, inputPath.Name + ".asm"));
            }
            else
            {
                throw new ArgumentException("Provided input path does not exist", nameof(inputPath));
            }
        }
    }
}