using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.Example.Handlers
{
    public class EngineerHandler : SupportHandler
    {
        public EngineerHandler() : base("Инженер", 8) { }

        protected override void HandleRequest(Ticket ticket)
        {
            Console.WriteLine($"  ✅ {_name} решил проблему!");
            Console.WriteLine($"     Ответ: 'Это баг в системе. Я создал задачу для разработчиков.'");
            Console.WriteLine($"     Тикет #{ticket.Id} закрыт.");
        }
    }
}
