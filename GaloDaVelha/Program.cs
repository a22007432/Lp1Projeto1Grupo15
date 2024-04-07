using System;
using System.Text;


namespace GaloDaVelha
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            Menu();
        }

        private static void Menu()
        {
            Game game = new Game();
            int playerInput;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  /$$$$$$            /$$                 /$$$$$$$                  /$$    /$$          /$$ /$$");
            Console.WriteLine(" /$$__  $$          | $$                | $$__  $$                | $$   | $$         | $$| $$");            
            Console.WriteLine("| $$  \\__/  /$$$$$$ | $$  /$$$$$$       | $$  \\ $$  /$$$$$$       | $$   | $$ /$$$$$$ | $$| $$$$$$$   /$$$$$$");
            Console.WriteLine("| $$ /$$$$ |____  $$| $$ /$$__  $$      | $$  | $$ |____  $$      |  $$ / $$//$$__  $$| $$| $$__  $$ |____  $$");
            Console.WriteLine("| $$|_  $$  /$$$$$$$| $$| $$  \\ $$      | $$  | $$  /$$$$$$$       \\  $$ $$/| $$$$$$$$| $$| $$  \\ $$  /$$$$$$$");
            Console.WriteLine("| $$  \\ $$ /$$__  $$| $$| $$  | $$      | $$  | $$ /$$__  $$        \\  $$$/ | $$_____/| $$| $$  | $$ /$$__  $$");
            Console.WriteLine("|  $$$$$$/|  $$$$$$$| $$|  $$$$$$/      | $$$$$$$/|  $$$$$$$         \\  $/  |  $$$$$$$| $$| $$  | $$|  $$$$$$$");
            Console.WriteLine(" \\______/  \\_______/|__/ \\______/       |_______/  \\_______/          \\_/    \\_______/|__/|__/  |__/ \\_______/");
            
            Console.ResetColor(); 
            
            Console.WriteLine("\n[1] Start game");
            Console.WriteLine("[2] Rules");
            Console.WriteLine("[3] Quit");
            Console.Write("\nPlease choose one of the options: ");

            playerInput = int.Parse(Console.ReadLine());

            Console.Clear();

            if(playerInput == 1)
                game.StartGame();
            else if (playerInput == 2)
            {
                GameRules();
            }
            else if (playerInput == 3)
            {
            }
            else
            {
                Console.WriteLine("Invalid Input");
                Menu();
            }
        }

        private static void GameRules()
        {
            int playerInput = 0;
            
            Console.WriteLine("This is where the rules shall be");

            Console.WriteLine("[1] Go Back");

            playerInput = int.Parse(Console.ReadLine());
            if(playerInput == 1)
            {
                Console.Clear();
                Menu();
            }
            
        }
    }
}
