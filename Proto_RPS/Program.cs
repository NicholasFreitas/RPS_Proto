using System;

namespace Proto_RPS
{
    class Program
    {
        static void Main(string[] args)
        {

            var game = new RockPaperScissors();
            
            /* Game configs */
            game.GameConfig.FirstToIntWins = 3;

            /* Create players */

            //Player one
            game.CreatePlayerOne("John");

            //player two bot
            game.CreatePlayerTwoBot(BotType.Random);

            //player two non bot
            // game.CreatePlayerTwo("Jane");



            while (!game.IsGameComplete()) 
            {
                string response = "";

                do
                {
                    Console.WriteLine($"{game.GetPlayerOneName()} pick your object:");
                    Console.WriteLine("(R)ock");
                    Console.WriteLine("(P)aper");
                    Console.WriteLine("(S)cissors");
                    Console.WriteLine();
                    response = Console.ReadLine();
                
                } while (!IsValidInput(response));


                Console.WriteLine($"{game.GetPlayerOneName()} has chosen: {response}");
                
                game.PlayerOnePickObject(PickObject(response));


                Console.WriteLine("Bot has Chosen...");
                game.PlayerTwoPickObject(PlayerObject.Bot);

                Console.WriteLine("1... 2... 3... SHOOT!");
                
                //Players Shoot
                var result = game.SHOOT();
                //Show Results to Players
                Console.WriteLine($"Player One Chose: {result.POneShot}");
                Console.WriteLine($"Player One Weak Against: {result.POneWeak}");
                Console.WriteLine($"Player Two Chose: {result.PTwoShot}");
                Console.WriteLine($"Player Two Weak Against: {result.PTwoWeak}");
                Console.WriteLine("===================");
                Console.WriteLine($"Winner: {result.Winner}");
                Console.WriteLine($"Loser: {result.Loser}");


                //Show result to bot
                game.BotViewResults(result);

                Console.WriteLine("===========================================================");
                Console.WriteLine(game.ViewCurrentScore());
                Console.WriteLine("===========================================================");

            }
        }

        public static bool IsValidInput(string inputResponse) 
        {

            inputResponse = inputResponse.ToUpper();

            //if (string.IsNullOrEmpty(inputResponse))
            //    return false;
            //
            //int parseResult = 0;
            //if (int.TryParse(inputResponse[0].ToString(), out parseResult))
            //    return false;

            bool IsValid = false;

            if (inputResponse[0].ToString().Equals("R"))
                IsValid = true;

            if(inputResponse[0].ToString().Equals("P"))
                IsValid = true;

            if (inputResponse[0].ToString().Equals("S"))
                IsValid = true;

            if (inputResponse[0].ToString().Equals("B"))
                IsValid = true;

            if (!IsValid) 
            {
                Console.WriteLine("INVALID INPUT - Please choose one of these value:");
                Console.WriteLine("R , P , S");
            }            

            return IsValid;
        }

        public static PlayerObject PickObject(string pick) 
        {
            switch (pick)
            {
                case "R":
                    return PlayerObject.Rock;

                case "P":
                    return PlayerObject.Paper;

                case "S":
                    return PlayerObject.Scissors;

                case "B":
                    return PlayerObject.Bot;

                default:
                    return PlayerObject.Rock;
                    
            }
        }
    }
}
