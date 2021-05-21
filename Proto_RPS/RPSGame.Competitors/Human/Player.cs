using Proto_RPS.RPSGame.Competitors.Bot;
using Proto_RPS.RPSGame.Game;
using Proto_RPS.RPSGame.ShootObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS.RPSGame.Competitors.Human
{

    //TODO: 004 Refactor to include player object as a ValueObject.
    public class Player
    {
        private string _name;

        private IPlayerObject _playerObject;

        private IBotStrategy _botStrategy;

        public Player()
        {
        }

        public Player(string name)
        {
            _name = name;
        }

        public Player(string name, IBotStrategy botStrategy)
        {
            _name = name;
            _botStrategy = botStrategy;
        }

        public void SetPlayerName(string playerName)
        {
            _name = playerName;
        }

        public void SelectObject(IPlayerObject playerObject)
        {
            _playerObject = playerObject;
        }


        public string Shoot()
        {
            return _playerObject.GetType().Name;
        }

        public string Weakness()
        {
            return _playerObject.ShowWeakness();
        }

        public string GetPlayerName()
        {
            return _name;
        }

        public void SelectObject()
        {
            _playerObject = _botStrategy.RunBotStrategy();
        }


        public void ViewResult(RoundResult result)
        {
            if (_botStrategy != null)
            {
                _botStrategy.ViewResults(result);
            }
        }

        public bool IsBot()
        {
            if (_botStrategy is null)
            {
                return false;
            }

            return true;
        }
    }
}
