using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Tg_Texter_Bot;
using Tg_Texter_Bot.Configuration;
using Tg_Texter_Bot.Controllers;
using Tg_Texter_Bot.Services;

namespace VoiceTexterBot
{
    public class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            // Объект, отвечающий за постоянный жизненный цикл приложения
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services)) // Задаем конфигурацию
                .UseConsoleLifetime() // Позволяет поддерживать приложение активным в консоли
                .Build(); // Собираем

            Console.WriteLine("Сервис запущен");
            // Запускаем сервис
            await host.RunAsync();
            Console.WriteLine("Сервис остановлен");
        }

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<defaultMessageController>();
            services.AddTransient<VoiceMessageController>();
            services.AddTransient<TextMessageController>();
            services.AddTransient<inlineKeyboardController>();
            services.AddSingleton<IFileHandler, AudioFileHandler>();

            // Регистрируем объект TelegramBotClient c токеном подключения
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient("7714895645:AAGr0kFSaUYnpLLxedYEKXAzUupVD3JjsqI"));
            // Регистрируем постоянно активный сервис бота
            services.AddHostedService<Bot>();
        }
        
        static AppSettings BuildAppSettings()
        {
            return new AppSettings()
            {
                DownloadsFolder = "C:\\Users\\evmor\\Downloads",
                BotToken = "7714895645:AAGr0kFSaUYnpLLxedYEKXAzUupVD3JjsqI",
                AudioFileName = "audio",
                InputAudioFormat = "ogg",
            };
        }
       
    }
}
