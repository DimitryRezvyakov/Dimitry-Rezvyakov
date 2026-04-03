using ChainOfResponsibility.Example.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.Example
{
    internal class Chain
    {
        public void CreateChain()
        {
            var chain = new ChatBotHandler()
                .SetNext(new FirstLineOperatorHandler())
                .SetNext(new SeniorOperatorHandler())
                .SetNext(new EngineerHandler());
        }
    }
}
