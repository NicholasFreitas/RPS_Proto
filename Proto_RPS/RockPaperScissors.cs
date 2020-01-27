using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS
{


    public class RockPaperScissors : IGameRockPaperScissors
    {
        public Configuration GameConfig {get;set;}

        private Player PlayerOne { get; set; }

        private Player PlayerTwo { get; set; }

        GameResult GameResult { get; set; }

        int POneScore = 0;
        int PTwoScore = 0;
        
        public bool AllBots = false;

        public RockPaperScissors()
        {
            GameResult = new GameResult();
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

        public void CreatePlayerOneBot(BotType botType)
        {

            var botStrat = BotStrategyFactory.GetBot(botType);

            var botName = $"{botType.ToString()}_bot";


            PlayerOne = new Player(botName, botStrat);

        }

        public void CreatePlayerTwoBot(BotType botType)
        {

            var botStrat = BotStrategyFactory.GetBot(botType);

            var botName = $"{botType.ToString()}_bot";


            PlayerTwo = new Player(botName,botStrat);
           
        }

        public void PlayerOnePickObject(PlayerObject playerObject)
        {

            if (playerObject.Equals(PlayerObject.Bot))
            {
                PlayerOne.SelectObject();
                return;
            }

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

        public string GetPlayerOneName() 
        {
           return PlayerOne.GetPlayerName();
        }

        public string GetPlayerTwoName()
        {
            return PlayerTwo.GetPlayerName();
        }

        public bool IsPlayerTwoBot() 
        {
            return PlayerTwo.IsBot();
        }

        /// <summary>
        /// Compares the player objects against their weaknesses
        /// </summary>
        /// <returns>All round information for display</returns>
        public RoundResult SHOOT()
        {
            //used for showing results
            var result = new RoundResult();
                        
            result.POneShot = PlayerOne.Shoot();
            result.PTwoShot = PlayerTwo.Shoot();

            result.POneWeak = PlayerOne.Weakness();
            result.PTwoWeak = PlayerTwo.Weakness();
                       

            if (PlayerOne.Shoot().Equals(PlayerTwo.Weakness()))
            {
                POneScore++;
                
                result.Winner = PlayerOne.GetPlayerName();
                               
                result.Loser = PlayerTwo.GetPlayerName();
            
            }
            else if (PlayerTwo.Shoot().Equals(PlayerOne.Weakness()))
            {
                PTwoScore++;

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

        public void BotViewResults(RoundResult result) 
        {
                PlayerTwo.ViewResult(result);
  
                PlayerOne.ViewResult(result);
        }

        public string ViewCurrentScore() 
        {
            return $"Player One[{PlayerOne.GetPlayerName()}]:{POneScore} --- Player Two[{PlayerTwo.GetPlayerName()}]:{PTwoScore}";
        }

        public bool IsGameComplete() 
        {
            if (POneScore == GameConfig.FirstToIntWins) 
            {

                GameResult.GameWinner = PlayerOne.GetPlayerName();
                GameResult.GameLoser = PlayerTwo.GetPlayerName();

                return true;
            }


            if (PTwoScore == GameConfig.FirstToIntWins) 
            {

                GameResult.GameWinner = PlayerTwo.GetPlayerName();
                GameResult.GameLoser = PlayerOne.GetPlayerName();

                return true;
            }
            

            return false;
        }

        public GameResult GameResults() 
        {
            return GameResult;
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

    public class GameResult 
    {
        public string GameWinner { get; set; }
        public string GameLoser { get; set; }
        
        public string FinalScore { get; set; }
    }


}
