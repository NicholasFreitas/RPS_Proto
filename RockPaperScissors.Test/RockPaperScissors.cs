using Proto_RPS.RPSGame.Competitors.Bot;
using Proto_RPS.RPSGame.Game;
using System;
using Xunit;

namespace RockPaperScissors.Test
{
    public class RockPaperScissors
    {

        [Fact]
        public void GameCreation() 
        {
            var game = new Proto_RPS.RPSGame.Game.RockPaperScissors();

            Assert.NotNull(game);
        }

        [Fact]
        public void DefaultConfigConfigured() 
        {
            var game = new Proto_RPS.RPSGame.Game.RockPaperScissors();
                        

            Assert.True(game.GameConfig.FirstToRoundWins == 3, "Default is not set.");

        }

        [Fact]
        public void ValidPlayerCreation() 
        {
            var game = new Proto_RPS.RPSGame.Game.RockPaperScissors();

            game.CreatePlayerOne("TESTING");

            Assert.True(game.GetPlayerOneName() != null, "Player doesn't exists");
            
        }

        [Fact]
        public void ValidateBotFactory() 
        {
            var randBot = BotStrategyFactory.GetBot(BotType.Random);     
            var stratBot = BotStrategyFactory.GetBot(BotType.Strategic);


            Assert.IsType<RandomBotStrategy>(randBot);
            Assert.IsType<StrategicBotStrategy>(stratBot);
        }


        //Much more would be need, cut short for time...

    }
}
