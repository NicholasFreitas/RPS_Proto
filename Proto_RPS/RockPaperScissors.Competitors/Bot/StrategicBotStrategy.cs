using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS
{
    public class StrategicBotStrategy : IBotStrategy
    {
        bool IsFirstTurn = true;

        IPlayerObject PreviousPick;

        RoundResult PreviousRoundResults;

        public IPlayerObject RunBotStrategy()
        {

            Console.WriteLine("DEBUG STRAT BOT CALLED");

            //First choice is random.
            if (IsFirstTurn) 
            {

                FirstTurn();
                
                IsFirstTurn = false;
            
            }

            //Get the weakness of the previously played object, and play it.
            var stratObj = PlayerObjectFactory.SelectPlayerObject((PlayerObject)Enum.Parse(typeof(PlayerObject),PreviousPick.ShowWeakness()));

            PreviousPick = stratObj;

            return stratObj;
        }

        public void ViewResults(RoundResult result)
        {
            PreviousRoundResults = result;
        }

        private IPlayerObject FirstTurn() 
        {
            //We trim the last entry, reserved for bot object selection.
            int botReserved = 1;


            var availPlayerObj = Enum.GetValues(typeof(PlayerObject));

            //Randomize the available enums for play
            Random random = new Random();

            PlayerObject randomBar =
                (PlayerObject)availPlayerObj.GetValue(
                        random.Next(availPlayerObj.Length - botReserved)
                );

            //Pick object for player based on randomization
            var rndObj = PlayerObjectFactory.SelectPlayerObject(randomBar);

            //Remember the last choice
            PreviousPick = rndObj;

            return rndObj;
        }
    }
}
