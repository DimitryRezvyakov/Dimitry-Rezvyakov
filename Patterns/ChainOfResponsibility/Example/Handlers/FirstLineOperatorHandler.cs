using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.Example.Handlers
{
    public class FirstLineOperatorHandler : SupportHandler
    {
        public FirstLineOperatorHandler() : base("Оператор первой линии", 4) { }

        protected override void HandleRequest(Ticket ticket)
        {
            Console.WriteLine($"  ✅ {_name} решил проблему!");
            Console.WriteLine($"     Ответ: 'Проверим ваш аккаунт. Пожалуйста, подождите 5 минут.'");
            Console.WriteLine($"     Тикет #{ticket.Id} закрыт.");
        }
    }
}
