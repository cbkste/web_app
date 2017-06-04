using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using web_app.Gateways;
using web_app.Helpers;
using web_app.Config;
using Microsoft.Extensions.Options;
using web_app.Mappers;
using AutoMapper;
using web_app.Gateways.Responses;
using web_app.Services;

namespace web_app
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TheMovieDbApiConfiguration>(Configuration.GetSection("moviedb"));
            services.Configure<TraktApiConfiguration>(Configuration.GetSection("trakt"));
            services.Configure<UrlConfiguration>(Configuration.GetSection("UrlConfiguration"));
            
            var configuration = ConfigureMapper();
            services.AddSingleton(configuration.CreateMapper());

            services.AddSingleton<IMovieDbMapper, MovieDbMapper>();
            services.AddTransient<IHttpClientWrapper>(provider => new HttpClientWrapper(provider.GetService<IOptions<TraktApiConfiguration>>()));
            services.AddTransient<IHttpClientWrap>(provider => new HttpClientWrap());
            services.AddTransient<ITraktGateway>(provider => new TraktGateway(provider.GetService<IHttpClientWrapper>()));
            services.AddTransient<IPreDbGateway>(provider => new PreDbGateway());
            services.AddTransient<ITheMovieDbGateway>(provider => new TheMovieDbGateway(provider.GetService<IOptions<TheMovieDbApiConfiguration>>(), provider.GetService<IOptions<UrlConfiguration>>(), provider.GetService<IHttpClientWrap>()));
            services.AddTransient<ITheMovieDbService>(provider => new TheMovieDbService(provider.GetService<ITheMovieDbGateway>(), provider.GetService<IMovieDbMapper>()));

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public static MapperConfiguration ConfigureMapper()
        {
            var automapperConfig = new AutomapperConfiguration();
            return automapperConfig.Configuration;
        }
    }
}
