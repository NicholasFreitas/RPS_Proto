using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS
{


    class RockPaperScissors : IGameRockPaperScissors
    {
        public Configuration GameConfig {get;set;}

        private Player PlayerOne { get; set; }

        private Player PlayerTwo { get; set; }

        public void ConfigureGame(Configuration gameConfig)
        {
            GameConfig = gameConfig;
        }


        /// <summary>
        /// 
        /// </summary>
        public RockPaperScissors()
        {
            GameConfig.FirstToIntWins = 3;
        }


        public void CreatePlayerOne(string name) 
        {
            PlayerOne = new Player(name);        
        }

        public void CreatePlayerTwo(string name) 
        {
            PlayerTwo = new Player(name);
        }

        public void CreatePlayerTwoBot(BotType botType)
        {



            switch (botType)
            {
                case BotType.Random:
                    PlayerTwo = null;
                    break;
                case BotType.Strategic:
                    break;
                default:
                    break;
            }
        }

    }
}
