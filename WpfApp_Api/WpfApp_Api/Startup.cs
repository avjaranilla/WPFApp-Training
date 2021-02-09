using Entities.Interface;
using Infra.Context;
using Infra.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using MediatR;
using Services.Queries.ListQueries;
using Services.Commands.ListCommands;
using Services.Queries.ItemQueries;
using Services.Commands.ItemCommands;

namespace WpfApp_Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WpfAppApiContext>(options => options.UseSqlite(Configuration.GetConnectionString("Sqlite")));

            services.AddScoped<IListPropertyRepository, ListPropertyRepository>();
            services.AddScoped<IItemPropertyRepository, ItemPropertyRepository>();


            services.AddMediatR(typeof(GetListQueryHandler));
            services.AddMediatR(typeof(InsertListCommandHandler));
            services.AddMediatR(typeof(UpdateListCommandHandler));
            services.AddMediatR(typeof(DeleteListCommandHandler));

            services.AddMediatR(typeof(GetItemQueryHandler));
            services.AddMediatR(typeof(InsertItemCommandHandler));
            services.AddMediatR(typeof(UpdateItemCommandHander));
            services.AddMediatR(typeof(DeleteItemByItemIDCommandHandler));
            services.AddMediatR(typeof(DeleteItemByListIDCommandHandler));

            services.AddMvc();
            //services.AddControllersWithViews();

            services.AddControllers();
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WpfApp_Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                    c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "WpfApp_Api v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
