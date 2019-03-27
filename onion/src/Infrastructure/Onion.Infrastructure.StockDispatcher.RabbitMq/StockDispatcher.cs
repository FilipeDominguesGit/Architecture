using System;
using Onion.Core.Application.Interfaces;

namespace Onion.Infrastructure.StockDispatcher.RabbitMq
{
    public class StockDispatcher : IStockDispatcher
    {
        public void SendNotification(string text)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"******************{text}******************");
            Console.ResetColor();
        }
    }
}
