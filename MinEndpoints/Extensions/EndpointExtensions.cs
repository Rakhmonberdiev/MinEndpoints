using Microsoft.Extensions.DependencyInjection.Extensions;
using MinEndpoints.Abstractions;
using System.Reflection;

namespace MinEndpoints.Extensions
{
    public static class EndpointExtensions
    {
        public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
        {
            ServiceDescriptor[] serviceDescriptors = assembly
                .GetTypes()
                .Where(type=>type is { IsAbstract:false, IsInterface: false } && type.IsAssignableTo(typeof(IEndpoint)))
                .Select(type=>ServiceDescriptor.Transient(typeof(IEndpoint),type))
                .ToArray();
            services.TryAddEnumerable(serviceDescriptors);


            return services;
        }
    }
}
