using System;

namespace Proto_RPS
{
    class Program
    {
        static void Main(string[] args)
        {
            //Player One
            var player = new Player();

            //set player name
            player.SetPlayerName("John");

            //Plyaer one picks their object
            var playerObject = PlayerObjectFactory.GetPlayerObject(PlayerObject.Rock);

            //assign object ot player one
            player.SelectObject(playerObject);

            //player one "plays" their object
            Console.WriteLine($"Player One has: {player.Shoot()}");
                                                     




            //Player Two
            var playerTwo = new Player();

            playerTwo.SetPlayerName("Alex");

            var playerTwoObject = PlayerObjectFactory.GetPlayerObject(PlayerObject.Paper);

            playerTwo.SelectObject(playerTwoObject);

            Console.WriteLine($"Player Two has: {playerTwo.Shoot()}");
            
            var result = false;

            if (player.Shoot().Equals(playerTwo.Weakness())) 
            {
                Console.WriteLine($"Player One's {player.Shoot()} defeats Player Two's {playerTwo.Shoot()}");

                Console.WriteLine("Player One Wins");
                result = true;
            }

            if (playerTwo.Shoot().Equals(player.Weakness())) 
            {
                Console.WriteLine($"Player Two's {playerTwo.Shoot()} defeats Player One's {player.Shoot()}");

                Console.WriteLine("Player Two Wins");
                result = true;
            }

            if (!result) 
            {
                Console.WriteLine("Draw!");
            }


        }
    }
}
