using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS
{
    public class Player
    {
        string Name;

        IPlayerObject PlayerObject;

        public void SetPlayerName(string playerName) 
        {
            Name = playerName;
        }

        public void SelectObject(IPlayerObject playerObject) 
        {
            PlayerObject = playerObject;
        }

        public string Shoot() 
        {
            return PlayerObject.GetType().Name;
        }

        public string Weakness() 
        {
            return PlayerObject.ShowWeakness();
        }

    }
}
