using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;

namespace botAssistant
{
    public class TelegramAPI
    {
       
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;

                MessageData messageData = new MessageData(message.Text, message.Chat.Id);
                
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        public static async Task StartTgBot()
        {
            ITelegramBotClient tgbot = new TelegramBotClient(Configuration.BotToken);
            Console.WriteLine("Запущен бот " + tgbot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            tgbot.StartReceiving(
                TelegramAPI.HandleUpdateAsync,
                TelegramAPI.HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );

        }
    }
}
