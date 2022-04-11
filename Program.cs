using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using System.Collections.Generic;


namespace botAssistant
{

    class Program
    {

        static async Task Main(string[] args)
        {

            Queue<object> messageQueue = new Queue<Object>();
            await TelegramAPI.StartTgBot();
            Console.ReadLine();

        }
    }
}