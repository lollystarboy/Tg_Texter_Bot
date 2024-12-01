using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Tg_Texter_Bot.Controllers
{
    internal class defaultMessageController
    {
        private readonly ITelegramBotClient _telegramClient;

        public defaultMessageController(ITelegramBotClient telegramBotClient)
        { _telegramClient = telegramBotClient; }

        public async Task Handle(Message message, CancellationToken ct)
        {
            Console.WriteLine($"Контроллер {GetType().Name} получил сообщение");
            await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Получено сообщение не поддерживаемого формата", cancellationToken: ct);
        }
    }
}
