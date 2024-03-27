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
        private int[,] board = new int [4,4]; 


        
        //Possible method to start the game
        public void StartGame()
        {
            SetBoard(board);
            for(int i= 0; i < 4; i++)
            {
                for(int j = 0; j< 4; j ++)
                {
                    Console.WriteLine(board[i,j]);
                }
            }
            
        }

        //Sets the array of the board
        public static int[,] SetBoard(int[,] board)
        {
            for(int i= 0; i < 4; i++)
            {
                //rows should be all 0 but for testing they go from 1 to 4
                for(int j = 0; j< 4; j ++)
                {
                    board[i,j] = j +1;
                }
            }
            return board;
        }

    }


}