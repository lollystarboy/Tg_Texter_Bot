using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tg_Texter_Bot.models;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Collections.Concurrent;
using Tg_Texter_Bot.models;

namespace Tg_Texter_Bot.Services
{
    public interface IStorage
    {
        /// <summary>
        /// Получение сессии пользователя по идентификатору
        /// </summary>
        Session GetSession(long chatId);


    }
}

