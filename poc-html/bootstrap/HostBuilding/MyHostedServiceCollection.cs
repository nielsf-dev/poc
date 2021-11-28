using System.Collections;
using Microsoft.Extensions.Hosting;

namespace HostBuilding;

public class MyHostedServiceCollection : List<IHostedService>
{
    public MyHostedServiceCollection()
    {
        this.Add(new MyHostedService());
    }

    public MyHostedServiceCollection(IEnumerable<IHostedService> collection) : base(collection)
    {
        this.Add(new MyHostedService());
    }

    public MyHostedServiceCollection(int capacity) : base(capacity)
    {
        this.Add(new MyHostedService());
    }
}