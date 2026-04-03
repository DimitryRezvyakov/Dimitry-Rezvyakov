using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.Example.Handlers
{
    public class DeveloperHandler : SupportHandler
    {
        public DeveloperHandler() : base("Разработчик", 10) { }

        protected override void HandleRequest(Ticket ticket)
        {
            Console.WriteLine($"  ✅ {_name} решил проблему!");
            Console.WriteLine($"     Ответ: 'Исправил в коде. Обновление выйдет завтра.'");
            Console.WriteLine($"     Тикет #{ticket.Id} закрыт.");
        }
    }
}
