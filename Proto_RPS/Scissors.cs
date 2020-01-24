using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS
{
    class Scissors : IPlayerObject
    {
        private PlayerObject Weakness = PlayerObject.Rock;
        public string ShowWeakness()
        {
            return Weakness.ToString();
        }
    }
}
