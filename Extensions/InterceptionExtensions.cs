using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Interceptor.Extensions
{
    public static class InterceptionExtensions
    {
        public static void AddInterceptedSingleton<TInterface, TImplementation, TInterceptor>(this IServiceCollection services)
        where TInterface : class
        where TImplementation : class, TInterface
        where TInterceptor : class, IInterceptor
        {
            services.TryAddSingleton<IProxyGenerator, ProxyGenerator>();
            services.AddSingleton<TImplementation>();
            services.TryAddTransient<TInterceptor>();
            services.AddSingleton(provider =>
            {
                var proxyGenerator = provider.GetRequiredService<IProxyGenerator>();
                var impl = provider.GetRequiredService<TImplementation>();
                var interceptor = provider.GetRequiredService<TInterceptor>();
                return proxyGenerator.CreateInterfaceProxyWithTarget<TInterface>(impl, interceptor);
            });
        }
    }
}