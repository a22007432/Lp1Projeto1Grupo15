﻿using System;
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
            //Print Main Menu Text
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
            
            //Print Options
            Console.WriteLine("\n[1] Start game");
            Console.WriteLine("[2] Rules");
            Console.WriteLine("[3] Quit");
            Console.Write("\nPlease choose one of the options: ");

            playerInput = int.Parse(Console.ReadLine());

            Console.Clear();

            //Read input and choose option
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

        //Rules Menu
        private static void GameRules()
        {
            int playerInput = 0;
            
            //Print Rules
            Console.WriteLine("The game consists of a single board 4x4 and 16 pieces.");
            Console.WriteLine("These pieces are combinations of the following atributes: Size, Color, Form and Hole");
            Console.WriteLine("The players takes rounds while playing, each choosing a piece to put on the board.");
            Console.WriteLine("Once played, the pieces can't be moved again.");
            Console.WriteLine("Your adversary chooses which piece you play and you choose where to put it.");
            Console.WriteLine("Repeat the cycle, alternating between players until either player forms a line of four pieces containing one atribute in common or the borad is full, resulting in a tie.");
            Console.WriteLine("The line can be horizontal, vertical or diagonal. First person to form the line wins.");
            Console.WriteLine("Example of the board and pieces: ")

            //Go back to the Main Menu
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
