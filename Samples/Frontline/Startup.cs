using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frontline.Common;
using Frontline.Common.Network;
using Frontline.Data;
using Frontline.GameDesign;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SKit.AspNetCore;

namespace Frontline
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
            var connectionData = Configuration.GetConnectionString("mysql-data");
            services.AddDbContext<DataContext>(options => options.UseMySql(connectionData, builder =>
            {
                builder.EnableRetryOnFailure(
                    5,
                    TimeSpan.FromSeconds(5),
                    new int[] { 2 });
            }), ServiceLifetime.Singleton);//游戏逻辑并不会多线程处理

            var connectionDesign = Configuration.GetConnectionString("mysql-design");
            services.AddDbContext<GameDesignContext>(options => options.UseMySql(connectionDesign, builder =>
            {
                builder.EnableRetryOnFailure(
                    5,
                    TimeSpan.FromSeconds(10),
                    new int[] { 2 });
            }));

            services.Configure<GameConfig>(Configuration.GetSection("game"));
            services.AddSKit<VerintHeadPackager, ProtoBufSerializer>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSKit();
            app.UseMvcWithDefaultRoute();
            //app.UseMvc();
        }
    }
}
