﻿using Microsoft.EntityFrameworkCore;
using SHORTURL.Application.Services;
using SHORTURL.Domain.Interfaces;
using SHORTURL.Infrastructure;

namespace SHORTURL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<UrlDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUrlRepository, IUrlRepository>();
            services.AddScoped<UrlService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        { 
            if(env.IsDevelopment()) 
            { 
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
