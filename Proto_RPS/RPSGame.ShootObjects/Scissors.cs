using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS.RPSGame.ShootObjects
{
    class Scissors : IPlayerObject
    {
        private PlayerObject _weakness = PlayerObject.Rock;
        public string ShowWeakness()
        {
            return _weakness.ToString();
        }
    }
}
