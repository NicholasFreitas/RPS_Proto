using System;

namespace Proto_RPS
{
    //TODO: 000 Large Refactor
    /*I've learned a lot since I've build this project initially. Let's see if we can re-organize this to be... sensible.
      I'm also going to diagram out the game flow. Maybe this will help me with design.
     
     Initial observations.
     - The solution structure is trash, I need to fix that. My objects should have a place to live and be.
     - The Program class is not cohesive, I need to make it more cohesive.
     - I'm really not eager to use any external libraries for visualizing things... but I think I'm going to put the "graphics" in it's own service. I think it'll clean up the code a bit.
     - Code styling defintely needs some clean up. The code is super busy.
     - A lot of config logic should be encapulated in a manager or service or soemthing... it's messy
        
     This is iniital... gonna go through code and make notes.
    - Rock, Paper and Scissors on a second look, seems like they can be turned into value objects. I think this would simplify the game logic... I THINK... :D
    - The strategic bot design is... weird... I mean that AI itself has a logic but I wonder if we could simplify the bot design.
    - Rethink Bot design... maybe rename some of the methods... the design should include a "step" for implementing HOW the bot solves a problem.
    - I definitely don't hate IGameRockPaperScissors. This interface is clear, well to me. It lays out the game "steps" clearly.

    - The unit testing is weird... but to be honest, I don't know enough about testing to say it's poorly done. I'll save it for last and do some reading.

     */

    class Program
    {
        static void Main(string[] args)
        {
            //TODO: 001 Streamline this process. This class is messy.
            Console.WriteLine("Starting Rock, Paper, Scissors...");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            var game = new RockPaperScissors();

            /* Game configs */
            game.GameConfig.FirstToIntWins = 3;

            //Sign up each player
            if (!game.AllBots)
                RegisterPlayers(game);
            else
                RegisterAllBots(game);

            //TODO: 002 Gameloop -> Need to refactor.
            while (!game.IsGameComplete())
            {
                string pOneResponse = "";
                string pTwoResponse = "";

                //TODO: 006 Bots shouldn't have separate logic. They're players too. Once we configure them they should follow same flow as player.
                if (game.AllBots)
                {
                    game.PlayerTwoPickObject(PlayerObject.Bot);
                    game.PlayerOnePickObject(PlayerObject.Bot);

                }

                if (!game.AllBots)
                {

                    pOneResponse = PlayerOneSelection(game);

                    pTwoResponse = PlayerTwoSelection(game, pTwoResponse);
                }

                RoundResult result = ResolveRound(game);


                //Show result to bot if bot(s) need results to determine strategy
                if (game.AllBots)
                    game.BotViewResults(result);

                if (game.IsPlayerTwoBot())
                    game.BotViewResults(result);

                Console.WriteLine("===========================================================");
                Console.WriteLine(game.ViewCurrentScore());
                Console.WriteLine("===========================================================");

            }
        }




        private static string PlayerTwoSelection(RockPaperScissors game, string pTwoResponse)
        {
            if (!game.IsPlayerTwoBot())
            {
                pTwoResponse = PickObjectValidation(game.GetPlayerTwoName());

                Console.WriteLine($"{game.GetPlayerTwoName()} has chosen: {pTwoResponse}");

            }
            else
            {
                Console.WriteLine($"{game.GetPlayerTwoName()} is picking object...");
            }

            if (game.IsPlayerTwoBot() && !game.AllBots)
            {
                game.PlayerTwoPickObject(PlayerObject.Bot);
            }
            else
            {
                game.PlayerTwoPickObject(PickObject(pTwoResponse));
            }

            return pTwoResponse;
        }

        private static string PlayerOneSelection(RockPaperScissors game)
        {
            string pOneResponse = PickObjectValidation(game.GetPlayerOneName());
            Console.WriteLine($"{game.GetPlayerOneName()} has chosen: {pOneResponse}");

            game.PlayerOnePickObject(PickObject(pOneResponse));
            return pOneResponse;
        }

        private static RoundResult ResolveRound(RockPaperScissors game)
        {
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
            return result;
        }

        private static string PickObjectValidation(string playerName)
        {
            string response;
            do
            {
                Console.WriteLine($"{playerName} pick your object:");
                Console.WriteLine("(R)ock");
                Console.WriteLine("(P)aper");
                Console.WriteLine("(S)cissors");
                Console.WriteLine();
                response = Console.ReadLine();

            } while (!IsValidInput(response));

            return response;
        }

        private static void RegisterPlayers(RockPaperScissors game)
        {


            string playerOneName = "";
            string playerTwoName = "";


            do
            {

                Console.WriteLine("Player One... Enter your name:");
                Console.Write("=>");
                playerOneName = Console.ReadLine();


            } while (!NameIsValid(playerOneName));

            game.CreatePlayerOne(playerOneName);



            do
            {
                BotMessage();

                Console.WriteLine("Player Two... Enter your name:");
                Console.Write("=>");

                playerTwoName = Console.ReadLine();


            } while (!NameIsValid(playerTwoName));



            if (playerTwoName.Equals("SBOT"))
            {
                game.CreatePlayerTwoBot(BotType.Random);
                return;
            }



            if (playerTwoName.Equals("RBOT"))
            {
                game.CreatePlayerTwoBot(BotType.Random);
                return;
            }



            game.CreatePlayerTwo(playerTwoName);

        }

        private static void BotMessage()
        {
            Console.WriteLine("//===================================//");
            Console.WriteLine("    To make Player Two a bot type:");
            Console.WriteLine("     SBOT");
            Console.WriteLine("     RBOT");
            Console.WriteLine("//===================================//");
        }

        public static bool IsValidInput(string inputResponse)
        {
            bool IsValid = false;

            if (string.IsNullOrEmpty(inputResponse))
            {
                Console.WriteLine("INVALID INPUT - Please choose one of these value:");
                Console.WriteLine("R , P , S");

                return false;
            }




            inputResponse = inputResponse.ToUpper();

            if (inputResponse[0].ToString().Equals("R"))
                IsValid = true;

            if (inputResponse[0].ToString().Equals("P"))
                IsValid = true;

            if (inputResponse[0].ToString().Equals("S"))
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

            string choice = pick.ToUpper();

            switch (choice)
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

        public static bool NameIsValid(string playerName)
        {
            if (string.IsNullOrEmpty(playerName))
            {
                Console.WriteLine("You must enter something.");
                return false;
            }



            return true;
        }

        public static void RegisterAllBots(RockPaperScissors game)
        {
            game.CreatePlayerOneBot(BotType.Random);
            game.CreatePlayerTwoBot(BotType.Strategic);
        }
    }
}
