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
                       
            /* Begin round  */
            //players pick
            game.PlayerOnePickObject(PlayerObject.Scissors);

            game.PlayerTwoPickObject(PlayerObject.Bot);



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


            //Round Result


            


            

                                                  

            //assign object ot player one
            //player.SelectObject(playerObject);




            //player one "plays" their object
            //Console.WriteLine($"Player One has: {player.Shoot()}");
                                                     




            ////Player Two
            //var playerTwo = new Player();

            //playerTwo.SetPlayerName("Alex");

            //var playerTwoObject = PlayerObjectFactory.SelectPlayerObject(PlayerObject.Paper);

            //playerTwo.SelectObject(playerTwoObject);

            //Console.WriteLine($"Player Two has: {playerTwo.Shoot()}");
            
            //var result = false;

            //if (player.Shoot().Equals(playerTwo.Weakness())) 
            //{
            //    Console.WriteLine($"Player One's {player.Shoot()} defeats Player Two's {playerTwo.Shoot()}");

            //    Console.WriteLine("Player One Wins");
            //    result = true;
            //}

            //if (playerTwo.Shoot().Equals(player.Weakness())) 
            //{
            //    Console.WriteLine($"Player Two's {playerTwo.Shoot()} defeats Player One's {player.Shoot()}");

            //    Console.WriteLine("Player Two Wins");
            //    result = true;
            //}

            //if (!result) 
            //{
            //    Console.WriteLine("Draw!");
            //}


        }
    }
}
