using System;
using Onion.Core.Application.Interfaces;

namespace Onion.Infrastructure.StockDispatcher.Email
{
    public class StockDispatcher : IStockDispatcher
    {
        public void SendNotification(string text)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"#################{text}#############################");
            Console.ResetColor();
        }
    }
}
