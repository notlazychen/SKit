using Frontline.Common;
using Frontline.Common.Network;
using Frontline.Data;
using Frontline.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Xunit;

namespace Frontline.Test
{
    public class PlayerControllerTest
    {
        IServiceCollection services;
        DataContext db;
        public PlayerControllerTest()
        {
            services = new ServiceCollection();
            var connection = "Server=101.132.118.172;database=frontline;uid=chenrong;pwd=abcd1234;SslMode=None;charset=utf8;pooling=false";
            services.AddDbContextPool<DataContext>(options => options.UseMySql(connection, builder =>
            {
                //builder.EnableRetryOnFailure(
                //    maxRetryCount: 5,
                //    maxRetryDelay: TimeSpan.FromSeconds(30), null);
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(15), new int[] { 1040, 1205, 1213, 1614 });
                //errorNumbersToAdd: new int[] { 1040, 1205, 1213, 1614 }
            }));
            var provider = services.BuildServiceProvider();

            db = provider.GetService<DataContext>();
        }

        [Fact]
        public void Login()
        {
            for (int i = 0; i < 1; i++)
            {
                db.Players.Add(new Domain.Player() { NickName = 1.ToString() });
            }
            db.SaveChanges();
            Assert.True(1 > 0);
        }
    }
}
