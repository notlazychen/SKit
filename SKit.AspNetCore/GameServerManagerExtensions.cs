using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SKit.Common;
using System;

namespace SKit.AspNetCore
{
    public static class GameServerManagerExtensions
    {
        public static IServiceCollection AddSKit<TSerializable>(this IServiceCollection services) 
            where TSerializable : Serializer
            //where TSPackager :  Packager
        {
            //services.AddTransient<Packager, TSPackager>();
            services.AddTransient<Serializer, TSerializable>();

            var provider = services.BuildServiceProvider();
            var config = provider.GetService<IConfiguration>();
            services.Configure<SKitConfig>(config.GetSection("skit"));
            services.AddSingleton(new GameServer(services));
            return services;
        }

        public static IApplicationBuilder UseSKit(this IApplicationBuilder builder)
        {
            var lifetime = builder.ApplicationServices.GetService<IApplicationLifetime>();
            lifetime.ApplicationStarted.Register(OnApplicationStarted, builder.ApplicationServices);
            lifetime.ApplicationStopping.Register(OnApplicationStopping, builder.ApplicationServices);
            return builder;//builder.UseMiddleware<RequestIPMiddleware>();
        }

        private static void OnApplicationStopping(Object state)
        {
            (state as IServiceProvider)?.GetService<GameServer>()?.Stop();
        }

        private static void OnApplicationStarted(Object state)
        {
            (state as IServiceProvider)?.GetService<GameServer>()?.Start();
        }

        //public static void SetSKitComponents<TSPackager, TSerializable>(this IServiceCollection services)
        //    where TSerializable : Serializer
        //    where TSPackager :  Packager
        //{
        //    services.AddTransient<Packager, TSPackager>();
        //    services.AddTransient<Serializer, TSerializable>();
        //}
    }
}
