using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS
{
    public enum PlayerObject 
    {
        Rock,
        Paper,
        Scissors,
        Bot     //Should never be an option for a human player
    }

    class PlayerObjectFactory
    {
        public static IPlayerObject SelectPlayerObject(PlayerObject playerObject) 
        {
            switch (playerObject)
            {

                case PlayerObject.Rock:
                    return new Rock();                    

                case PlayerObject.Paper:
                    return new Paper(); 

                case PlayerObject.Scissors:
                    return new Scissors();

                default:
                    return null;
                    
            }
        }

    }
}
