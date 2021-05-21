using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS
{
    public class Rock : IPlayerObject
    { 
       private PlayerObject Weakness = PlayerObject.Paper;

        public string ShowWeakness()
        {
            return Weakness.ToString();
        }
        
    }
}
