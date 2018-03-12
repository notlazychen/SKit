using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SKit.Base;
using SKit.Base.Packagers;
using SKit.Base.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace SKit.AspNetCore
{
    public static class GameServerManagerExtensions
    {
        public static void AddSKit(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var config = provider.GetService<IConfiguration>();
            services.Configure<SKitConfig>(config.GetSection("skit"));
            services.AddTransient<ISPackager, StringMessagePackager>();
            services.AddTransient<ISerializable, StringSerializer>();
            services.AddSingleton(new GameServer(services));
        }

        public static IApplicationBuilder UserSKit(this IApplicationBuilder builder)
        {
            var lifetime = builder.ApplicationServices.GetService<IApplicationLifetime>();
            lifetime.ApplicationStarted.Register(OnApplicationStarted, builder.ApplicationServices);
            lifetime.ApplicationStopping.Register(OnApplicationStopping, builder.ApplicationServices);
            return builder;//builder.UseMiddleware<RequestIPMiddleware>();
        }

        private static void OnApplicationStopping(Object state)
        {
            (state as IServiceProvider)?.GetService<GameServer>()?.Stop();
            //server.Start();
        }

        private static void OnApplicationStarted(Object state)
        {
            (state as IServiceProvider)?.GetService<GameServer>()?.Start();
        }
    }
}
