using System.IO;

namespace Hack.JackCompiler.Lib.Files
{
    public class DirectoryFilesLoaderOptions
    {
        public DirectoryInfo Path { get; set; }
        public string SearchPattern { get; set; } = "*.jack";
    }
}