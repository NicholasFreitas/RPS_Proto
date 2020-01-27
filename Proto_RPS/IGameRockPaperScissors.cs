using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS
{
    public enum BotType
    {
        Random,
        Strategic
    }

    public interface IGameRockPaperScissors
    {
        public void CreatePlayerOne(string name);

        public void CreatePlayerTwo(string name);

        public void CreatePlayerTwoBot(BotType botType);
    }
}
