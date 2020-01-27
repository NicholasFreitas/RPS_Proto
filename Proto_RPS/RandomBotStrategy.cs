using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS
{
    class RandomBotStrategy : IBotStrategy
    {
        public IPlayerObject RunBotStrategy()
        {
            Console.WriteLine("DEBUG RANDOM BOT CALLED");

            //We trim the last entry, reserved for bot object selection.
            int botReserved = 1;

            
            var availPlayerObj = Enum.GetValues(typeof(PlayerObject));

            //Randomize the available enums for play
            Random random = new Random();

            PlayerObject randomBar =
                (PlayerObject)availPlayerObj.GetValue(
                        random.Next( availPlayerObj.Length - botReserved )
                );
                                 
            //Pick object for player based on randomization
            var rndObj = PlayerObjectFactory.SelectPlayerObject(randomBar);
            

            return rndObj;

        }

        public void ViewResults(RoundResult result)
        {
            //Random Bot doesn't need to read results at this time.
        }
    }
}
