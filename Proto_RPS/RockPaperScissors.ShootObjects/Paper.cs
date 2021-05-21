using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS
{
    class Paper : IPlayerObject
    {
        private PlayerObject Weakness = PlayerObject.Scissors;


        public string ShowWeakness()
        {
            return Weakness.ToString();
        }

    }
}
