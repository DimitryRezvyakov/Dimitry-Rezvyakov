using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.Example.Handlers
{
    public class SeniorOperatorHandler : SupportHandler
    {
        public SeniorOperatorHandler() : base("Старший оператор", 6) { }

        protected override void HandleRequest(Ticket ticket)
        {
            Console.WriteLine($"  ✅ {_name} решил проблему!");
            Console.WriteLine($"     Ответ: 'Проблема связана с настройками. Я внес изменения.'");
            Console.WriteLine($"     Тикет #{ticket.Id} закрыт.");
        }
    }
}
