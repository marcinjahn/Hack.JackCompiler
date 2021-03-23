using System.IO;
using Microsoft.Extensions.Options;

namespace Hack.JackCompiler.Lib.Files
{
    public class FileUtilitiesFactory
    {
        public FileLoader GetFileLoader(FileInfo path)
        {
            return new FileLoader(new OptionsWrapper<FileLoaderOptions>(
                new FileLoaderOptions
                {
                    Path = path
                }));
        }
        
        public DirectoryFilesLoader GetDirectoryFilesLoader(DirectoryInfo path)
        {
            return new DirectoryFilesLoader(new OptionsWrapper<DirectoryFilesLoaderOptions>(
                new DirectoryFilesLoaderOptions()
                {
                    Path = path
                }));
        }
    }
}