using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tg_Texter_Bot.Configuration;
using Tg_Texter_Bot;

namespace Tg_Texter_Bot.Services
{
    
        public interface IFileHandler
        {
            Task Download(string fileId, CancellationToken ct);
            string Process(string param);
        }
    
}
