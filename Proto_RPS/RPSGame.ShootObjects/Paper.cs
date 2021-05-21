using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS.RPSGame.ShootObjects
{
    class Paper : IPlayerObject
    {
        private PlayerObject _weakness = PlayerObject.Scissors;

        public string ShowWeakness()
        {
            return _weakness.ToString();
        }

    }
}
