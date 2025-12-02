using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.IInfrastructure
{
    public interface ITelegramService
    {
        public Task SendTelegramMessageAsync(string message, int? topicID = null, long? ChatID = null);
        public Task SendTelegramMessageAsync(Exception message, int? topicID = null, long? ChatID = null);
    }
}
