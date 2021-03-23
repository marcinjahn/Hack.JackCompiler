using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Hack.JackCompiler.Lib.Files
{
    public class FileLoader
    {
        private readonly FileLoaderOptions _options;

        public FileLoader(IOptions<FileLoaderOptions> options)
        {
            _options = options.Value;
        }
        
        public async Task<string> Load(CancellationToken cancellationToken)
        {
            return await File.ReadAllTextAsync(_options.Path.FullName, cancellationToken);
        }
    }
}