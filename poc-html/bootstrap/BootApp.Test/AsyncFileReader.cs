using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Build.Utilities;

namespace BootApp.Test;

public class AsyncFileReader
{
    private readonly string filePath;

    public AsyncFileReader(string filePath)
    {
        this.filePath = filePath;
    }

    public async Task<string> Read(CancellationToken cancellationTokenSource)
    {
        return await File.ReadAllTextAsync(filePath);
    }
}