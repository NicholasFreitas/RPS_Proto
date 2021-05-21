using Proto_RPS.RPSGame.Game;
using Proto_RPS.RPSGame.ShootObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS.RPSGame.Competitors.Bot
{
    public class StrategicBotStrategy : IBotStrategy
    {
        private bool _isFirstTurn = true;

        private IPlayerObject _previousPick;

        private RoundResult _previoudRoundResult;

        public IPlayerObject RunBotStrategy()
        {
            if (_isFirstTurn)
            {
                FirstTurn();
                _isFirstTurn = false;

            }

            var stratObj = PlayerObjectFactory.SelectPlayerObject((PlayerObject)Enum
                            .Parse(typeof(PlayerObject), _previousPick.ShowWeakness()));

            _previousPick = stratObj;

            return stratObj;
        }

        public void ViewResults(RoundResult result)
        {
            _previoudRoundResult = result;
        }

        private IPlayerObject FirstTurn()
        {
            int botReserved = 1;
            var availPlayerObj = Enum.GetValues(typeof(PlayerObject));
            var random = new Random();

            var randomBar = (PlayerObject)availPlayerObj.GetValue(random.Next(availPlayerObj.Length - botReserved));
            var rndObj = PlayerObjectFactory.SelectPlayerObject(randomBar);

            _previousPick = rndObj;

            return rndObj;
        }
    }
}
