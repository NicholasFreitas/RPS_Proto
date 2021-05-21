using Proto_RPS.RPSGame.ShootObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS.RPSGame.Game
{
    public interface IGameRockPaperScissors
    {
        public void CreatePlayerOne(string name);

        public void CreatePlayerTwo(string name);

        public void CreatePlayerTwoBot(BotType botType);

        public void PlayerOnePickObject(PlayerObject playerObject);

        public void PlayerTwoPickObject(PlayerObject playerObject);

        public RoundResult SHOOT();
    }
}
