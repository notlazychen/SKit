using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Frontline.Extensions
{
    public class GameDatabaseLoggerProvider : ILoggerProvider
    {
        readonly List<string> SqlCategories = new List<string> { DbLoggerCategory.Database.Command.Name,
                                                       //DbLoggerCategory.Query.Name,
                                                       DbLoggerCategory.Update.Name };
        ILogger _logger = new NLog.Extensions.Logging.NLogLoggerProvider().CreateLogger("gamedatabase");

        public ILogger CreateLogger(string categoryName)
        {
            if (SqlCategories.Contains(categoryName))
            {
                return _logger;
                //return new EFLogger(categoryName);
            }
            return new NullLogger();
        }
        public void Dispose()
        { }


        private class NullLogger : ILogger
        {
            public bool IsEnabled(LogLevel logLevel)
            {
                return false;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            { }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }
        }

        private class EFLogger : ILogger
        {
            private readonly string categoryName;

            public EFLogger(string categoryName) => this.categoryName = categoryName;

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {

                Debug.WriteLine($"时间:{DateTime.Now.ToString("o")} 日志级别: {logLevel} {eventId.Id} 产生的类{this.categoryName}");
                //DbCommandLogData data = state as DbCommandLogData;
                //Debug.WriteLine($"SQL语句:{data.CommandText},\n 执行消耗时间:{data.ElapsedMilliseconds}");
                //if(l)

            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }
        }
    }
}
