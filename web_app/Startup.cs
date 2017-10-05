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
using web_app.Client;
using web_app.Repository;
using web_app.ContentfulFactories;
using web_app.ContentfulModels;
using web_app.Model;
using Microsoft.EntityFrameworkCore;
using web_app.LolEsportsModels;
using web_app.ILolEsportsFactory;
using web_app.LolEsportsFactories;

namespace web_app
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("app-config/appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"app-config/appsettings.{env.EnvironmentName}.json", optional: true)
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
            services.Configure<ContenfulClientConfiguration>(Configuration.GetSection("ContentfulApi"));
            services.Configure<TwitchApiConfiguration>(Configuration.GetSection("twitch"));
            services.Configure<TwitchApiConfiguration>(Configuration.GetSection("localDb"));
            services.Configure<LolEsportsApiConfiguration>(Configuration.GetSection("lolesportsUrlConfiguration"));

            services.AddSingleton<IContentfulFactory<ContentfulFeaturedNews, News>>(new FeaturedNewsFactory());
            services.AddSingleton<IContentfulFactory<ContenfulCarousel, Carousel>>(new CarouselFactory());
            services.AddSingleton<ILolEsportsFactory<LolEsportsTeam, Team>>(new TeamLolEsportsFactory());

            var configuration = ConfigureMapper();
            services.AddSingleton(configuration.CreateMapper());

            services.AddSingleton<IMovieDbMapper, MovieDbMapper>();

            services.AddTransient<IHttpClientWrap>(provider => new HttpClientWrap(provider.GetService<ILogger<HttpClientWrapper>>()));
            services.AddTransient<IHttpClientWrapper>(provider => new HttpClientWrapper(provider.GetService<IOptions<TraktApiConfiguration>>()));
            services.AddTransient<IHttpClientWrapperTwitch>(provider => new HttpClientWrapperTwitch(provider.GetService<IOptions<TwitchApiConfiguration>>()));

            services.AddTransient<ITraktGateway>(provider => new TraktGateway(provider.GetService<IHttpClientWrapper>()));
            services.AddTransient<IPreDbGateway>(provider => new PreDbGateway());
            services.AddTransient<ILolEsportsGateway>(provider => new LolEsportsGateway(provider.GetService<IOptions<LolEsportsApiConfiguration>>(), provider.GetService<IHttpClientWrap>(), provider.GetService<ILolEsportsFactory<LolEsportsTeam, Team>>()));
            services.AddTransient<ITwitchGateway>(provider => new TwitchGateway(provider.GetService<IOptions<UrlConfiguration>>(), provider.GetService<IHttpClientWrapperTwitch>()));
            services.AddTransient<ITheMovieDbGateway>(provider => new TheMovieDbGateway(provider.GetService<IOptions<TheMovieDbApiConfiguration>>(), provider.GetService<IOptions<UrlConfiguration>>(), provider.GetService<IHttpClientWrapper>()));

            services.AddTransient<ITheMovieDbService>(provider => new TheMovieDbService(provider.GetService<ITheMovieDbGateway>()));
            services.AddTransient<HomepageRepository>();


            services.AddSingleton<IContentfulFactory<ContentfulHomepage, Homepage>>(provider => new HomepageContentfulFactory(provider.GetService<IContentfulFactory<ContentfulFeaturedNews, News>>(), provider.GetService<IContentfulFactory<ContenfulCarousel, Carousel>>()));
            services.AddSingleton<IContentfulClientManager>(new ContentfulClientManager(new System.Net.Http.HttpClient()));

            services.AddSingleton<IConnectionHelper, ConnectionHelper>();

            services.AddTransient<ILocalDbRepository>(p => new LocalDbRepository(p.GetService<IDbConnectionProvider>()));

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
