using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Hack.JackCompiler.Lib.Files;
using Hack.JackCompiler.XmlUtilities;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Hack.JackCompiler.CLI
{
    public class HostedService : BackgroundService
    {
        public HostedService(
            JackCompiler.Lib.JackCompiler compiler,
            IOptions<HostedServiceOptions> options, 
            IHostApplicationLifetime applicationLifetime, 
            FileUtilitiesFactory fileUtilsFactory)
        {
            _options = options.Value;
            _compiler = compiler ?? throw new ArgumentNullException(nameof(compiler));
            _applicationLifetime = applicationLifetime ?? throw new ArgumentNullException(nameof(applicationLifetime));
            _fileUtilsFactory = fileUtilsFactory ?? throw new ArgumentNullException(nameof(fileUtilsFactory));
        }

        private readonly Lib.JackCompiler _compiler;
        private readonly FileUtilitiesFactory _fileUtilsFactory;
        private readonly HostedServiceOptions _options;
        private readonly IHostApplicationLifetime _applicationLifetime;
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (File.Exists(_options.InputPath.FullName))
            {
                await HandleSingleFileInput(stoppingToken);
            }
            else
            {
                HandleDirectoryInput(stoppingToken);
            }

            _applicationLifetime.StopApplication();
        }

        private async Task HandleSingleFileInput(CancellationToken stoppingToken)
        {
            var loader = _fileUtilsFactory.GetFileLoader(new FileInfo(_options.InputPath.FullName));
            var input = await loader.Load(stoppingToken);
            var parseTree = _compiler.Compile(input);
            var xml = parseTree.ToXml();
        }

        private void HandleDirectoryInput(CancellationToken stoppingToken)
        {
            var loader = _fileUtilsFactory.GetDirectoryFilesLoader(new DirectoryInfo(_options.InputPath.FullName));
            var files = loader.GetPaths();
            
            //TODO: Finish implementation
            
            // var file = await loader.LoadNextFile(stoppingToken);
            // while (file is not null)
            // {
            //     var code = _translator.Translate(file);
            //     result.AppendCode(code);
            //     file = await loader.LoadNextFile(stoppingToken);
            // }
            // return result;
        }
    }
}