using Microsoft.Extensions.DependencyInjection;
using System;

namespace ExtensionDemo
{
    public static class ExampleServiceCollectionExtensions
    {
        public static IServiceCollection AddExamples(this IServiceCollection services)
            => AddExamples(services, (o) => { });

        public static IServiceCollection AddExamples(this IServiceCollection services, Action<ExampleOptions> configureOptions)
        {
            // create the default options and then perform the configuration
            var options = ExampleOptions.Default;
            configureOptions(options);

            // register services
            services.AddSingleton(options);
            services.AddScoped<IExample, Example>();
            services.AddScoped<IExampleWithOptions, ExampleWithOptions>();

            // return the service collection to allow chaining of methods
            return services;
        }
    }
}
