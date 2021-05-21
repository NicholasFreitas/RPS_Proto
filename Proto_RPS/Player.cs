using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS
{

    //TODO: 004 Refactor to include player object as a ValueObject.
    public class Player
    {
        string Name;

        IPlayerObject PlayerObject;

        IBotStrategy BotStrategy;
         
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

        public string GetPlayerName() 
        {
            return Name;
        }


        //Bot Method
        public void SelectObject()
        {
            PlayerObject = BotStrategy.RunBotStrategy();
        }

        //Bot Method
        public void ViewResult(RoundResult result) 
        {
            if(BotStrategy != null)
                BotStrategy.ViewResults(result);
        }

        //Bot Method
        public bool IsBot() 
        {
            if (BotStrategy == null)
                return false;

            return true;
        }
    }
}
