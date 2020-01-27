using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS
{
    public interface IBotStrategy
    {
        public IPlayerObject RunBotStrategy();
        public void ViewResults(RoundResult result);

    }
}
