using Microsoft.Extensions.DependencyInjection;

namespace HostBuilding;


public interface IMyServiceFactoryAdapter
{
    object CreateBuilder(IServiceCollection services);

    IServiceProvider CreateServiceProvider(object containerBuilder);
}