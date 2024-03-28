using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GaloDaVelha
{
    /// <summary>
    /// This class controls the game.
    /// </summary>
    public class Game
    {
        //Circle CHars
        public char cLargeHole = '\u25CE';
        public char cSmallHole = '\u2609';
        public char cLarge = '\u25CB';
        public char cSmall = '\u25E6';
        
        //Square chars (large with hole might need a better 1)
        public char sLargeHole = '\u2612';
        public char sSmallHole = '\u25C8';
        public char sLarge = '\u2610';
        public char sSmall = '\u25C7';
        

        //Array to hold the board values
        static int[,] board = new int [4,4]; 



        
        //Possible method to start the game
        public void StartGame()
        {
            SetBoard(board);

            Console.WriteLine(cLargeHole);
            Console.WriteLine(cSmallHole);
            Console.WriteLine(cSmall);
            Console.WriteLine(cLarge);
            Console.WriteLine(sSmallHole);
            Console.WriteLine(sLargeHole);
            Console.WriteLine(sSmall);
            Console.WriteLine(sLarge);


            //test code for array
            /*for(int i= 0; i < 4; i++)
            {
                for(int j = 0; j< 4; j ++)
                {
                    Console.WriteLine(board[i,j]);
                }
            }*/
            
        }

        //Sets the array of the board
        public static int[,] SetBoard(int[,] board)
        {
            for(int i= 0; i < 4; i++)
            {
                
                for(int j = 0; j< 4; j ++)
                {
                    board[i,j] = 0;
                }
            }
            return board;
        }

    }


}