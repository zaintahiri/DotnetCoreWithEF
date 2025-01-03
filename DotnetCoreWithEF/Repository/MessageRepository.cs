using DotnetCoreWithEF.Models;
using Microsoft.Extensions.Options;

namespace DotnetCoreWithEF.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private NewBookAlertConfig _alertConfig;
        //public MessageRepository(IOptionsMonitor<NewBookAlertConfig> alertConfig)
        //{
        //    _alertConfig = alertConfig.CurrentValue;
        //}

        public MessageRepository(IOptionsMonitor<NewBookAlertConfig> alertConfig)
        {
            _alertConfig = alertConfig.CurrentValue;
            // if you change on run time this will give you updated value of the configuration
            alertConfig.OnChange(config =>
            {
                _alertConfig=config;
            });
        }

        public string GetName()
        {
            return _alertConfig.BookName;
        }
    }
}
