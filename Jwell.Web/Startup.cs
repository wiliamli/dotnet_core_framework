using AspectCore.Extensions.Autofac;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Jwell.Framework.Modules;
using Jwell.Repository.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Jwell.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "1.0.0.0",
                    Title = "JwellAspnetCore",
                    Description = "Jwell ASP.NET Core Web API",
                    TermsOfService = "None",
                    //Contact = new Contact() { Name = "Talking Dotnet", Email = "309910833@qq.com", Url = "www.talkingdotnet.com" }
                });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "JwellWeb.xml");
                c.IncludeXmlComments(xmlPath);
            });

            //Using Autofac Dependency Injection                   
            ContainerBuilder builder = new ContainerBuilder();

            var dataAccess = Assembly.GetEntryAssembly().GetReferencedAssemblies()
                .Select(Assembly.Load)
                .Where(a => a.ExportedTypes.Any(t => typeof(IJwellModule).IsAssignableFrom(t))).ToArray();

            builder.RegisterAssemblyTypes(dataAccess)
                .AsImplementedInterfaces();

            builder.Register(c =>
            {
                var config = c.Resolve<IConfiguration>();
                var opt = new DbContextOptionsBuilder<JwellDbContext>();
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                return new JwellDbContext(opt.Options);
            })
            .AsSelf()
            .As<DbContext>()
            .InstancePerRequest();

            builder.RegisterDynamicProxy();

            builder.Populate(services);

            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jwell Web API");
            });
        }
    }
}
