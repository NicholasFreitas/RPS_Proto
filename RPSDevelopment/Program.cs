using Proto_RPS.RPSGame.UI;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace RPSDevelopment
{
    class Program
    {
        static async Task Main()
        {
            var guiService = new DisplayGameUserInterfaceConsole();
            string playerName;
            var botName = "";

            guiService.DisplayTitleScreen();

            Console.ReadKey();

            guiService.BotSelectionScreen();


            var botType = System.Console.ReadKey();

            if (botType.Key == ConsoleKey.R)
            {
                botName = "RandoTheBot";
            }

            if (botType.Key == ConsoleKey.S)
            {
                botName = "StrattyTheBot";
            }


            guiService.RegisterPlayerScreen();
            playerName = Console.ReadLine();

            guiService.ShowPlayers(playerName, botName);

            Console.ReadLine();

            guiService.SelectYouWeapon();

            var weaponSelect = System.Console.ReadKey();

            var weaponType = "";

            if (weaponSelect.Key is ConsoleKey.R)
            {
                weaponType = ConsoleKey.R.ToString();
            }

            if (weaponSelect.Key is ConsoleKey.P)
            {
                weaponType = ConsoleKey.P.ToString();
            }

            if (weaponSelect.Key is ConsoleKey.S)
            {
                weaponType = ConsoleKey.S.ToString();
            }
            

            guiService.ShowSelectedWeapon(weaponType);
            Console.ReadKey();
            guiService.ShowWeapons("TESTING001","TESTING002");
            Console.ReadKey();
            guiService.ShowWinner("TESTING PLAYER");
            Console.ReadKey();

        }
    }
}
