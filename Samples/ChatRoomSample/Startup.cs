using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SKit;
using SKit.Base;
using SKit.Base.Packagers;
using SKit.Base.Serialization;

namespace ChatRoomSample
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
            services.Configure<SKitConfig>(Configuration.GetSection("game"));
            services.AddTransient<ISPackager, StringMessagePackager>();
            services.AddTransient<ISerializable, StringSerializer>();

            //services.AddSingleton(services);

            //var provider = services.BuildServiceProvider();
            // 输出singletone1的Guid
            var server = new GameServer(services);
            services.AddSingleton(server);
            server.Start();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
