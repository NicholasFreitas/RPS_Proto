using Proto_RPS.RPSGame.Game;
using Proto_RPS.RPSGame.ShootObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS.RPSGame.Competitors.Bot
{
    public interface IBotStrategy
    {
        public IPlayerObject RunBotStrategy();
        public void ViewResults(RoundResult result);

    }
}
