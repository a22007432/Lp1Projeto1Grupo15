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
                
                for(int j = 0; j< 4; j ++)
                {
                    board[i,j] = 0;
                }
            }
            return board;
        }

    }


}