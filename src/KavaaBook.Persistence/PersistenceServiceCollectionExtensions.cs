using KavaaBook.Application.Data;
using KavaaBook.Domain.Entities.MemberAggregate;
using KavaaBook.Domain.Entities.PostAggregate;
using KavaaBook.Domain.Entities.PostCommentAggregate;
using KavaaBook.Domain.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using KavaaBook.Persistence;
using KavaaBook.Persistence.Domain;
using KavaaBook.Persistence.Domain.Members;
using KavaaBook.Persistence.Domain.PostComments;
using KavaaBook.Persistence.Domain.Posts;
using KavaaBook.Persistence.Processing;
using KavaaBook.Persistence.SeedWork;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class PersistenceServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString, string migrationsAssembly = "")
        {
            services.AddScoped<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

            services.AddDbContext<BookContext>(options => options.UseSqlServer(connectionString, sql =>
             {
                 if (!string.IsNullOrEmpty(migrationsAssembly))
                 {
                     sql.MigrationsAssembly(migrationsAssembly);
                 }
                 options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
             })
            ).AddRepositories();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddProcessing();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostCommentRepository, PostCommentRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            return services;
        }

        private static IServiceCollection AddProcessing(this IServiceCollection services)
        {
            services.AddScoped<IDomainEventsAccessor, DomainEventsAccessor>();
            services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>();
            services.Decorate(typeof(INotificationHandler<>), typeof(DomainEventsDispatcherNotificationHandlerDecorator<>));

            return services;
        }

        public static void MigrateAdsDb(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<BookContext>().Database.Migrate();
            }
        }
    }
}