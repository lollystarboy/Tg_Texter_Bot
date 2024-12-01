using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Tg_Texter_Bot.Services;
using VoiceTexterBot.Services;

namespace Tg_Texter_Bot.Controllers
{
    internal class inlineKeyboardController
    {
        private readonly IStorage _memoryStorage;
        private readonly ITelegramBotClient _telegramClient;

        public inlineKeyboardController(ITelegramBotClient telegramBotClient, IStorage memoryStorage)
        { 
            _telegramClient = telegramBotClient;
            _memoryStorage = memoryStorage;
        }

        public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
        {
            if (callbackQuery?.Data == null)
                return;
            //обновление пользовательской сесси новыми данными
            _memoryStorage.GetSession(callbackQuery.From.Id).LanguageCode = callbackQuery.Data;
            //создаем информац сообщение 
            string languageText = callbackQuery.Data switch
            {
                "ru" => "Русский",

                "en" => "Английский",
                _ => String.Empty
            };
            //отправляем уведомление о выборе
            await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id,
                $"<b> - {languageText}.{Environment.NewLine}</b>" +
                $"{Environment.NewLine}", cancellationToken: ct, parseMode: ParseMode.Html);
           
        }
    }
}
