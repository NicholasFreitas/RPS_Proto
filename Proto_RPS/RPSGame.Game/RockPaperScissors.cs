using Proto_RPS.RPSGame.Competitors.Bot;
using Proto_RPS.RPSGame.Competitors.Human;
using Proto_RPS.RPSGame.Configurations;
using Proto_RPS.RPSGame.ShootObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS.RPSGame.Game
{

    //TODO: 005 This class isn't cohesive. It's responsible for too much. It holds the game flow, configs and creates players. Too many responsibilities that don't delong to it.
    public class RockPaperScissors : IGameRockPaperScissors
    {
        public Configuration GameConfig { get; set; }

        private Player _playerOne { get; set; }

        private Player _playerTwo { get; set; }

        private GameResult _gameResult { get; set; }

        private int _playerOneScore = 0;
        private int _playerTwoScore = 0;

        public bool _allBots = false;

        public RockPaperScissors()
        {
            _gameResult = new GameResult();
            GameConfig = new Configuration();
            GameConfig.FirstToRoundWins = 3;
        }

        public void CreatePlayerOne(string name)
        {
            _playerOne = new Player(name);
        }

        public void CreatePlayerTwo(string name)
        {
            _playerTwo = new Player(name);
        }

        public void CreatePlayerOneBot(BotType botType)
        {

            var botStrat = BotStrategyFactory.GetBot(botType);

            var botName = $"{botType.ToString()}_bot";


            _playerOne = new Player(botName, botStrat);

        }

        public void CreatePlayerTwoBot(BotType botType)
        {

            var botStrat = BotStrategyFactory.GetBot(botType);

            var botName = $"{botType.ToString()}_bot";


            _playerTwo = new Player(botName, botStrat);

        }

        public void PlayerOnePickObject(PlayerObject playerObject)
        {

            if (playerObject.Equals(PlayerObject.Bot))
            {
                _playerOne.SelectObject();
                return;
            }

            _playerOne.SelectObject(PlayerObjectFactory.SelectPlayerObject(playerObject));

        }

        public void PlayerTwoPickObject(PlayerObject playerObject)
        {

            if (playerObject.Equals(PlayerObject.Bot))
            {
                _playerTwo.SelectObject();
                return;
            }

            _playerTwo.SelectObject(PlayerObjectFactory.SelectPlayerObject(playerObject));
        }

        public string GetPlayerOneName()
        {
            return _playerOne.GetPlayerName();
        }

        public string GetPlayerTwoName()
        {
            return _playerTwo.GetPlayerName();
        }

        public bool IsPlayerTwoBot()
        {
            return _playerTwo.IsBot();
        }

        /// <summary>
        /// Compares the player objects against their weaknesses
        /// </summary>
        /// <returns>All round information for display</returns>
        public RoundResult SHOOT()
        {
            var result = new RoundResult();

            result.POneShot = _playerOne.Shoot();
            result.PTwoShot = _playerTwo.Shoot();

            result.POneWeak = _playerOne.Weakness();
            result.PTwoWeak = _playerTwo.Weakness();


            if (_playerOne.Shoot().Equals(_playerTwo.Weakness()))
            {
                _playerOneScore++;

                result.Winner = _playerOne.GetPlayerName();

                result.Loser = _playerTwo.GetPlayerName();

            }
            else if (_playerTwo.Shoot().Equals(_playerOne.Weakness()))
            {
                _playerTwoScore++;

                result.Winner = _playerTwo.GetPlayerName();

                result.Loser = _playerOne.GetPlayerName();

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
            _playerTwo.ViewResult(result);

            _playerOne.ViewResult(result);
        }

        public string ViewCurrentScore()
        {
            return $"Player One[{_playerOne.GetPlayerName()}]:{_playerOneScore} --- Player Two[{_playerTwo.GetPlayerName()}]:{_playerTwoScore}";
        }

        public bool IsGameComplete()
        {
            if (_playerOneScore == GameConfig.FirstToRoundWins)
            {

                _gameResult.GameWinner = _playerOne.GetPlayerName();
                _gameResult.GameLoser = _playerTwo.GetPlayerName();

                return true;
            }


            if (_playerTwoScore == GameConfig.FirstToRoundWins)
            {

                _gameResult.GameWinner = _playerTwo.GetPlayerName();
                _gameResult.GameLoser = _playerOne.GetPlayerName();

                return true;
            }


            return false;
        }

        public GameResult GameResults()
        {
            return _gameResult;
        }

    }

}
