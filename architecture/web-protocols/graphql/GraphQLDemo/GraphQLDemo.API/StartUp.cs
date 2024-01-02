using GraphQLDemo.API.DataLoaders;
using GraphQLDemo.API.DTOs;
using GraphQLDemo.API.Schema.Mutations;
using GraphQLDemo.API.Schema.Queries;
using GraphQLDemo.API.Schema.Subscriptions;
using GraphQLDemo.API.Services;
using GraphQLDemo.API.Services.Courses;
using GraphQLDemo.API.Services.Instructor;
using GraphQLDemo.API.Services.Student;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API
{
    public class Startup
    {
        readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = configuration.GetConnectionString("default");
            services.AddPooledDbContextFactory<SchoolDbContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<CoursesRepository>();
            services.AddScoped<InstructorRepository>();
            services.AddScoped<StudentRepository>();

            services.AddScoped<InstructorDataLoader>();

            services.AddGraphQLServer()
                .AddInMemorySubscriptions() // This is in-memory but in a more distributed system we need to use redis to store our subscriptions.
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>() // this uses web sockets
                .AddFiltering()
                .AddSorting()
                .AddProjections(); 

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            // For GQL Subscriptions
            app.UseWebSockets();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
