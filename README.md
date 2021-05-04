# Example of extension methods for IAmTimCorey video

Link: [https://www.youtube.com/watch?v=C_1DzspLy4Y](https://www.youtube.com/watch?v=C_1DzspLy4Y)

## Summary
I mentioned in my comment that I frequently add extension methods for the `IServiceCollection` interface within libraries that I create to make injection into the default dependency injection container simpler for consumers of my library. Although I am the normal user of my libraries, it makes maintaining the components of my system easier to maintain.

## Built in example
As part of the webapi default project, the `Startup.ConfigureServices(IServiceCollection services)` allows configuration of the service collection container to be used by the API. This section will show an inbuilt example of an extension for the service collection.

Within the Microsoft.AspNetCore.Authentication dll, the `AuthenticationServiceCollectionExtensions` class contains the extension methods for the service collection for authentication functionality. The primary extension method `AddAuthentication()` adds the core services to have authentication registered with the container. This method also returns an `AuthenticationBuilder` which can be used to provide additional configuration to the services that have been registered.

## Custom library example
The `ExtensionDemo` library contains two primary interfaces that it exports: `IExample` and `IExampleWithOptions`. Each interface has a single implementation, `Example` and `ExampleWithOptions` respectively. The library also exports an `ExampleOptions` class containing options to be consumed by an `IExampleWithOptions` instance. Of note is that neither implementation is exported from the library.

The `ExampleServiceCollectionExtensions` class has two extension methods for the `IServiceCollection` interface (requires dependency on `Microsoft.Extensions.DependencyInjection.Abstractions`). The first, `AddExamples()`, defers to the more complex extension method. The second, `AddExamples(...)`, first creates the default options and configures the options using theprovided configuration delegate method.

    // create the default options and then perform the configuration
    var options = ExampleOptions.Default;
    configureOptions(options);

Then we register the options as a singleton instance as the options do not need more than one instance created. The `Example` and `ExampleWithOptions` are both registered as scoped dependencies against their interface. The decision to register the two dependencies as scoped, rather than transient or singleton, will be based on the particular features of the library.

    // register services
    services.AddSingleton(options);
    services.AddScoped<IExample, Example>();
    services.AddScoped<IExampleWithOptions, ExampleWithOptions>();

Finally, we return the service collection so that methods can be chained together in a fluent-type manner.

    return services;
