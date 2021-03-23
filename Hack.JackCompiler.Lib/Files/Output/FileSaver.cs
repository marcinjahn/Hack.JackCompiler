using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Hack.VMTranslator.Lib.Output
{
    public class FileSaver
    {
        public async Task Save(IEnumerable<string> lines, string path, CancellationToken cancellationToken)
        {
            await File.WriteAllLinesAsync(path, lines, cancellationToken);
        }
    }

}