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
        public Pieces mypiece = 0;

        public int tmpN;

        //public char tmpPiece;

        //Circle CHars
        /*public char cLargeHole = '\u25CE';
        public char cSmallHole = '\u2609';
        public char cLarge = '\u25CB';
        public char cSmall = '\u25E6';
        */
        
        //Square chars (large with hole might need a better 1)
        /*public char sLargeHole = '\u2612';
        public char sSmallHole = '\u25C8';
        public char sLarge = '\u2610';
        public char sSmall = '\u25C7';
        */
        

        //Array to hold the board values
        static int[,] board = new int [4,4]; 



        
        //Possible method to start the game
        public void StartGame()
        {
            
            
            SetDefaultBoard(board);
            SetBoardTest(board);

            //testcode for chars
            /*Console.WriteLine(cLargeHole);
            Console.WriteLine(cSmallHole);
            Console.WriteLine(cSmall);
            Console.WriteLine(cLarge);
            Console.WriteLine(sSmallHole);
            Console.WriteLine(sLargeHole);
            Console.WriteLine(sSmall);
            Console.WriteLine(sLarge);*/

            //test code for array
            /*for(int i= 0; i < 4; i++)
            {
                for(int j = 0; j< 4; j ++)
                {
                    Console.WriteLine(board[i,j]);
                }
            }*/

            // test code for SetPiece()
            /*Console.WriteLine("pls insert an int");
            tmpN = int.Parse(Console.ReadLine());
            
            Console.WriteLine(SetPiece(tmpN))*/

            PrintBoard(board);
            
            
        }

        /// <summary>
        /// Sets the board array to 0 which means no piece
        /// </summary>
        /// <param name="board"><Array containing the values of the board>
        /// <returns><Array containing the values of the board>
        public static int[,] SetDefaultBoard(int[,] board)  
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

        /// <summary>
        /// This functions tests the board 
        /// </summary>
        /// <param name="board"><Array containing the values of the board>
        /// <returns><Array containing the values of the board>
        public static int[,] SetBoardTest(int[,] board)  
        {
            for(int i= 0; i < 4; i++)
            {
                if (i < 2)
                {
                    for(int j = 0; j< 4; j ++)
                    {
                        if (i == 0){board[i,j] = j+1;}
                        else{board[i,j] = 5+j;}
                    }
                }
                else
                {
                    for(int j = 0; j< 4; j ++)
                    {
                        if (i == 2){board[i,j] = j+1;}
                        else{board[i,j] = 5+j;}
                    }
                }

            }
            return board; 
        }

        /// <summary>
        /// This method returns a char from an Enum using an int as reference
        /// </summary>
        /// <param name="pieceInt"><This is the int that decides the piece char>
        /// <returns><The piece returns a char corresponding to the piecIint>
        public char SetPiece(int pieceInt)
        {
       
            char tmpPiece = '\0';
            switch(pieceInt)
            {
                 //This case might work better as default 
                case 0:
                    tmpPiece = (char) Pieces.Null; //X
                    break;
                case 1:
                    tmpPiece = (char) Pieces.BigSquare;//☐
                    break;
                case 2:
                    tmpPiece = (char) Pieces.SmallSquare;//◇
                    break;
                case 3:
                    tmpPiece = (char) Pieces.BigSquareH;//☒ 
                    break;
                case 4:
                    tmpPiece = (char) Pieces.SmallSquareH;//◈
                    break;
                case 5:
                    tmpPiece = (char) Pieces.BigCircle;//○
                    break;
                case 6:
                    tmpPiece = (char) Pieces.SmallCircle;//◦
                    break;
                case 7:
                    tmpPiece = (char) Pieces.BigCircleH;//◎
                    break;
                case 8:
                    tmpPiece = (char) Pieces.SmallCircleH;//☉
                    break;
                

                default:
                    break;
            }

            //Console.WriteLine(tmpPiece);
            return tmpPiece;
        }

        /// <summary>
        /// Prints the board using the int values stored in the board array
        /// Should be callled after every move
        /// </summary>
        ///<param name="currentBoard"><Array containing the values of the board>
        public void PrintBoard(int[,] currentBoard)
        {   //Idea For how to print the board
            /*Console.WriteLine($"|  ||  ||  ||  |");
            Console.WriteLine($"--------------");*/

            
            Console.WriteLine($"|{SetPiece(currentBoard[0,0])}||{SetPiece(currentBoard[0,1])}||{SetPiece(currentBoard[0,2])}||{SetPiece(currentBoard[0,3])}|");
            Console.WriteLine("--------------");
            Console.WriteLine($"|{SetPiece(currentBoard[1,0])}||{SetPiece(currentBoard[1,1])}||{SetPiece(currentBoard[1,2])}||{SetPiece(currentBoard[1,3])}|");
            Console.WriteLine("--------------");
            Console.WriteLine($"|{SetPiece(currentBoard[2,0])}||{SetPiece(currentBoard[2,1])}||{SetPiece(currentBoard[2,2])}||{SetPiece(currentBoard[2,3])}|");
            Console.WriteLine("--------------");
            Console.WriteLine($"|{SetPiece(currentBoard[3,0])}||{SetPiece(currentBoard[3,1])}||{SetPiece(currentBoard[3,2])}||{SetPiece(currentBoard[3,3])}|");
            

    
        }

    }


}