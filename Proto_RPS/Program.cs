﻿using Proto_RPS.RPSGame.Game;
using Proto_RPS.RPSGame.ShootObjects;
using System;

namespace Proto_RPS
{
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
            game.GameConfig.FirstToRoundWins = 3;

            //Sign up each player
            if (!game._allBots)
                RegisterPlayers(game);
            else
                RegisterAllBots(game);

            //TODO: 002 Gameloop -> Need to refactor.
            while (!game.IsGameComplete())
            {
                var pOneResponse = "";
                var pTwoResponse = "";

                //TODO: 006 Bots shouldn't have separate logic. They're players too. Once we configure them they should follow same flow as player.
                if (game._allBots)
                {
                    game.PlayerTwoPickObject(PlayerObject.Bot);
                    game.PlayerOnePickObject(PlayerObject.Bot);

                }

                if (!game._allBots)
                {

                    pOneResponse = PlayerOneSelection(game);

                    pTwoResponse = PlayerTwoSelection(game, pTwoResponse);
                }

                var result = ResolveRound(game);

                if (game._allBots)
                {
                    game.BotViewResults(result);
                }


                if (game.IsPlayerTwoBot())
                {
                    game.BotViewResults(result);
                }


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

            if (game.IsPlayerTwoBot() && !game._allBots)
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
            {
                IsValid = true;
            }

            if (inputResponse[0].ToString().Equals("P"))
            {
                IsValid = true;
            }

            if (inputResponse[0].ToString().Equals("S"))
            {
                IsValid = true;
            }

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

            return choice switch
            {
                "R" => PlayerObject.Rock,
                "P" => PlayerObject.Paper,
                "S" => PlayerObject.Scissors,
                "B" => PlayerObject.Bot,
                _ => PlayerObject.Rock,
            };
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
