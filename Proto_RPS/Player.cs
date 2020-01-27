using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS
{
    public class Player
    {
        string Name;

        IPlayerObject PlayerObject;

        IBotStrategy BotStrategy;

        int Wins = 0;

        public Player()
        {
        }

        public Player(string name)
        {
            Name = name;
        }

        public Player(string name, IBotStrategy botStrategy)
        {
            Name = name;
            BotStrategy = botStrategy;
        }

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

        public void HasWon() 
        {
            Wins++;
        }

    }
}
