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
        
        
        public RockPaperScissors()
        {
            GameConfig = new Configuration();
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

            var botStrat = BotStrategyFactory.GetBot(botType);

            var botName = $"{botType.ToString()}_bot";


            PlayerTwo = new Player(botName,botStrat);
           
        }

        public void PlayerOnePickObject(PlayerObject playerObject)
        {
            PlayerOne.SelectObject(
                PlayerObjectFactory.SelectPlayerObject(playerObject)
            );
        
        }

        public void PlayerTwoPickObject(PlayerObject playerObject)
        {

            if (playerObject.Equals(PlayerObject.Bot)) 
            {
                PlayerTwo.SelectObject();
                return;
            }
            

            PlayerTwo.SelectObject(
                PlayerObjectFactory.SelectPlayerObject(playerObject)
            );
        }


        /// <summary>
        /// Compares the player objects against their weaknesses
        /// </summary>
        /// <returns>All round information for display</returns>
        public RoundResult SHOOT()
        {

            var result = new RoundResult();

            result.POneShot = PlayerOne.Shoot();
            result.PTwoShot = PlayerTwo.Shoot();

            result.POneWeak = PlayerOne.Weakness();
            result.PTwoWeak = PlayerTwo.Weakness();




            if (PlayerOne.Shoot().Equals(PlayerTwo.Weakness()))
            {
                result.Winner = PlayerOne.GetPlayerName();
                result.Loser = PlayerTwo.GetPlayerName();
            }
            else if (PlayerTwo.Shoot().Equals(PlayerOne.Weakness()))
            {
                result.Winner = PlayerTwo.GetPlayerName();
                result.Loser = PlayerOne.GetPlayerName();
            }
            else 
            {
                result.Winner = "Draw";
                result.Loser = "Draw";
            }                

            return result;
        }
    }

    public class RoundResult
    {
        public string Winner { get; set; }
        
        public string Loser { get; set; }

        public string POneShot { get; set; }

        public string PTwoShot { get; set; }

        public string POneWeak { get; set; }

        public string PTwoWeak { get; set; }
    
    }
}
