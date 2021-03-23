using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Options;

namespace Hack.JackCompiler.Lib.Files
{
    public class DirectoryFilesLoader
    {
        private readonly DirectoryFilesLoaderOptions _options;

        public DirectoryFilesLoader(IOptions<DirectoryFilesLoaderOptions> options)
        {
            _options = options.Value;
        }
        
        public IEnumerable<FileInfo> GetPaths()
        {
            return Directory.GetFiles(_options.Path.FullName, _options.SearchPattern)
                .Select(n => new FileInfo(n));
        }
    }
}