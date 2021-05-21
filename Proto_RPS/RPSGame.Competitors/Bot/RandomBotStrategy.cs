using Proto_RPS.RPSGame.Game;
using Proto_RPS.RPSGame.ShootObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS.RPSGame.Competitors.Bot
{
    public class RandomBotStrategy : IBotStrategy
    {
        public IPlayerObject RunBotStrategy()
        {
            var botReserved = 1;
            var availPlayerObj = Enum.GetValues(typeof(PlayerObject));
            var random = new Random();

            var randomBar =
                (PlayerObject)availPlayerObj.GetValue(random.Next(availPlayerObj.Length - botReserved));

            var rndObj = PlayerObjectFactory.SelectPlayerObject(randomBar);

            return rndObj;

        }

        public void ViewResults(RoundResult result)
        {
            //Random Bot doesn't need to read results at this time.
        }
    }
}
