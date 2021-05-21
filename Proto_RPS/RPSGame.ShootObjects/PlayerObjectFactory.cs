using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS.RPSGame.ShootObjects
{

    class PlayerObjectFactory
    {
        public static IPlayerObject SelectPlayerObject(PlayerObject playerObject)
        {
            return playerObject switch
            {
                PlayerObject.Rock => new Rock(),
                PlayerObject.Paper => new Paper(),
                PlayerObject.Scissors => new Scissors(),
                _ => null,
            };
        }
    }
}
