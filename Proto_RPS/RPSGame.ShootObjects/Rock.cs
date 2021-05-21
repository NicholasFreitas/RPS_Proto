using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS.RPSGame.ShootObjects
{
    public class Rock : IPlayerObject
    {
        private PlayerObject _weakness = PlayerObject.Paper;

        public string ShowWeakness()
        {
            return _weakness.ToString();
        }

    }
}
