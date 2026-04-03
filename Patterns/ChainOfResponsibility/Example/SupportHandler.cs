using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ChainOfResponsibility.Example
{
    public abstract class SupportHandler
    {
        protected SupportHandler _nextHandler;
        protected string _name;
        protected int _maxComplexity; 

        protected SupportHandler(string name, int maxComplexity)
        {
            _name = name;
            _maxComplexity = maxComplexity;
        }

        public SupportHandler SetNext(SupportHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public void Handle(Ticket ticket)
        {
            if (CanHandle(ticket))
            {
                HandleRequest(ticket);
            }
            else if (_nextHandler != null)
            {
                Console.WriteLine($"  → {_name} не может решить проблему (сложность {ticket.Complexity}). Передаю дальше...");
                _nextHandler.Handle(ticket);
            }
            else
            {
                Console.WriteLine($"  → ❌ Никто не смог решить проблему! Сложность {ticket.Complexity} слишком высока.");
            }
        }

        protected virtual bool CanHandle(Ticket ticket)
        {
            return ticket.Complexity <= _maxComplexity;
        }

        protected abstract void HandleRequest(Ticket ticket);
    }
}
