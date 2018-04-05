using Frontline.Common;
using Frontline.MQ;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Services
{
    public class MessageBus : ServerBase
    {
        private ILogger _logger;
        public MessageBus(ILogger<MessageBus> logger): base()
        {
            _logger = logger;
            this.CatchUnhandledException += MessageBus_CatchUnhandledException;
        }

        private void MessageBus_CatchUnhandledException(object sender, Exception e)
        {
            _logger.LogError(e, e.Message);
        }
    }
}
