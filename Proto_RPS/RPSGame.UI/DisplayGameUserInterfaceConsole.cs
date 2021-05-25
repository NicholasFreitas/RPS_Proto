using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Proto_RPS.RPSGame.UI
{
    public class DisplayGameUserInterfaceConsole : IDisplayGameUserInterface
    {

        private const int _WIDTH = 90;
        private const int _HEIGHT = 30;

        private readonly string _currentDirectory;
        private readonly string _titleScreenPath;
        private readonly string _registerScreenPath;
        private readonly string _botSelectionScreenPath;
        private readonly string _showPlayersScreenPath;
        private readonly string _showWeaponSelectionScreenPath;
        private readonly string _showWeaponSelectedScreenPath;
        private readonly string _showWeaponsScreenPath;
        private readonly string _showWinner;

        public DisplayGameUserInterfaceConsole()
        {
            _currentDirectory = Directory.GetCurrentDirectory();

            _titleScreenPath = $@"{_currentDirectory}\RPSGame.Resources\titleScreen.txt";
            _registerScreenPath = $@"{_currentDirectory}\RPSGame.Resources\registerScreen.txt";
            _botSelectionScreenPath = $@"{_currentDirectory}\RPSGame.Resources\botSelectionScreen.txt";
            _showPlayersScreenPath = $@"{_currentDirectory}\RPSGame.Resources\showPlayersScreen.txt";
            _showWeaponSelectionScreenPath = $@"{_currentDirectory}\RPSGame.Resources\showWeaponSelectionScreen.txt";
            _showWeaponSelectedScreenPath = $@"{_currentDirectory}\RPSGame.Resources\showWeaponSelectedScreen.txt";
            _showWeaponsScreenPath = $@"{_currentDirectory}\RPSGame.Resources\showWeaponsScreen.txt";
            _showWinner = $@"{_currentDirectory}\RPSGame.Resources\showPlayerWinner.txt";


            Console.SetWindowSize(_WIDTH, _HEIGHT);
            Console.BufferHeight = _HEIGHT;
            Console.BufferWidth = _WIDTH;
        }


        public void DisplayTitleScreen()
        {
            Console.Clear();
            Console.WriteLine(File.ReadAllText(_titleScreenPath));
        }

        public void ShowPlayers(string playerOneName, string playerTwo)
        {
            Console.Clear();
            var screenText = File.ReadAllText(_showPlayersScreenPath);
            Console.WriteLine(string.Format(screenText, playerOneName, playerTwo));
        }

        public void BotSelectionScreen()
        {
            Console.Clear();
            Console.WriteLine(File.ReadAllText(_botSelectionScreenPath));
            Console.SetCursorPosition(2, 11);
        }

        public void RegisterPlayerScreen()
        {
            Console.Clear();
            Console.WriteLine(File.ReadAllText(_registerScreenPath));
            Console.SetCursorPosition(3, 3);
        }

        public void SelectYouWeapon()
        {
            Console.Clear();
            Console.WriteLine(File.ReadAllText(_showWeaponSelectionScreenPath));
        }

        public void ShowSelectedWeapon(string selectedWeapon)
        {
            Console.Clear();
            var screenText = File.ReadAllText(_showWeaponSelectedScreenPath);
            Console.WriteLine(string.Format(screenText, selectedWeapon));
        }

        public void ShowWeapons(string playerOneWeapon, string playerTwoWeapon)
        {
            Console.Clear();
            var screenText = File.ReadAllText(_showWeaponsScreenPath);
            Console.WriteLine(string.Format(screenText, playerOneWeapon, playerTwoWeapon));
        }

        public void ShowWinner(string player)
        {
            Console.Clear();
            var screenText = File.ReadAllText(_showWinner);
            Console.WriteLine(string.Format(screenText, player));
        }
    }
}
