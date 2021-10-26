namespace Microsoft.Extensions.DependencyInjection
{
    public static class DomainServicesCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            //services.AddScoped<PostService, PostService>();

            return services;
        }
    }
}