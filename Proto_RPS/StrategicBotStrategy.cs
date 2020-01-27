using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS
{
    class StrategicBotStrategy : IBotStrategy
    {
        bool IsFirstTurn = true;

        RoundResult PreviousRoundResults;

        public IPlayerObject RunBotStrategy()
        {

            //First choice is random.


            //bot then assesses results.





            throw new NotImplementedException();
        }

        public void ViewResults(RoundResult result)
        {
            PreviousRoundResults = result;
        }
    }
}
