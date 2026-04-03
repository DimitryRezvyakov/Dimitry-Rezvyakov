using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.Example.Handlers
{
    public class ChatBotHandler : SupportHandler
    {
        public ChatBotHandler() : base("Чат-бот", 2) { }

        protected override void HandleRequest(Ticket ticket)
        {
            Console.WriteLine($"  ✅ {_name} решил проблему!");
            Console.WriteLine($"     Ответ: 'Здравствуйте! Попробуйте перезагрузить приложение. Это решает 90% проблем.'");
            Console.WriteLine($"     Тикет #{ticket.Id} закрыт.");
        }

        protected override bool CanHandle(Ticket ticket)
        {
            return base.CanHandle(ticket) && ticket.Category != "финансовая";
        }
    }
}
