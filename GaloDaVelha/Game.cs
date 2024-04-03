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
        public int roundCounter = 0;
        public Pieces mypiece = 0;

        public bool isRunning;

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
            PrintBoard(board);
            Console.WriteLine("Welcome to Galo da velha here are the rules:");
            //Write Rules (maybe even a show rules method)
            
            SetDefaultBoard(board);
            //SetBoardTest(board);

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


            //PrintBoard(board);
            GameLoop();
            
            
        }

        /// <summary>
        /// Sets the board array to 0 which means no piece
        /// </summary>
        /// <param name="board">Array containing the values of the board</param>
        /// <returns>Array containing the values of the board</returns>
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
        /// This functions tests the board layout
        /// </summary>
        /// <param name="board">Array containing the values of the board</param>
        /// <returns>Array containing the values of the board</returns>
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
        /// <param name="pieceInt">This is the int that decides the char</param>
        /// <returns>The piece returns a char corresponding to the pieceInt</returns>
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

        public void GameLoop()

        {   
            //[Col, Row]
            int[] placement;
            string playerIn;
            int tmpN;
            int roundCounter = 0;
            bool player1Turn = true;

            /*Console.WriteLine("");
            Console.WriteLine($"ROUND {roundCounter}:");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("");*/

            while(roundCounter <3)//mudar para 16
            {
                if(player1Turn == true)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"ROUND {roundCounter}:");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Player 1, Pick player 2s Piece:");
                    

                    playerIn = Console.ReadLine();
                    tmpN = PiecePickerInputChecker(playerIn);
                    //Console.WriteLine(SetPiece(tmpN));
                    Console.WriteLine("");
                    Console.WriteLine(
                    "Player 2, Place your piece using this format: 'column row':");
                    playerIn = Console.ReadLine();
                    placement = BoardPlaceInputChecker(playerIn);
                    board[placement[1],placement[0]] = tmpN;

                    Console.WriteLine("");
                    PrintBoard(board);

                    player1Turn =TurnSwitcher(player1Turn);


                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine($"ROUND {roundCounter}:");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Player 2, Pick player 1s Piece:");
                    

                    playerIn = Console.ReadLine();
                    tmpN = PiecePickerInputChecker(playerIn);
                    //Console.WriteLine(SetPiece(tmpN));
                    Console.WriteLine("");
                    Console.WriteLine(
                    "Player 2, Place your piece using this format: 'column row':");
                    playerIn = Console.ReadLine();
                    placement = BoardPlaceInputChecker(playerIn);
                    board[placement[1],placement[0]] = tmpN;

                    Console.WriteLine("");
                    PrintBoard(board);

                    player1Turn =TurnSwitcher(player1Turn);

                }



                roundCounter++;
            }



            
            

            //roundCounter++;
        }


        /// <summary>
        /// Recursive Method to make sure the player that picks a piece makes 
        /// a valid input
        /// </summary>
        /// <param name="playerIn">This is a string with the players input</param>
        /// <returns>An int that represents a piece</returns>
        public static int PiecePickerInputChecker(string playerIn)
        {
            int testint;
            int ret;
            string tmpString;
            bool playerInpValid = true;

            

            //list of conditions
            if(playerIn.Length > 1){playerInpValid = false;}
            
            if(int.TryParse(playerIn, out ret) == false){playerInpValid =false;}
        
            //consequence
            if(playerInpValid == false)
            {
                Console.WriteLine("Please insert a valid Piece: (1-8)");
                tmpString = Console.ReadLine();
                //recurring method to make sure it works
                PiecePickerInputChecker(tmpString);
            }
            else
            {
                ret = int.Parse(playerIn);
            }
            //Console.WriteLine(ret);
            return ret;

            
        }
        
        /// <summary>
        /// Recursive Method to make sure the player makes a valid placement 
        /// </summary>
        /// <param name="playerIn">This is a string with the players input</param>
        /// <returns>Returns an Array with the xy coordinates needed</returns>
        public static int[] BoardPlaceInputChecker(string playerIn)
        {
            int outInt = 0;
            char[] charLim = {'A','B','C','D'};
            int[] ret = new int[2];
            bool playerInpValid = true;
            string tmpString;
            string tryStr = "";

            if(playerIn.Length > 2){tryStr += playerIn[2];}

            //'A' = 65
            //'D' = 68
            //list of conditions
            //if input length is higher than 3
            if(playerIn.Length > 3 || playerIn.Length < 3)
            {playerInpValid = false;}
            //if it was another char other than ABCD
            if((int)playerIn[0] < 65 || (int)playerIn[0] > 68)
            {playerInpValid = false;}
            //if the number can't be parsed
            if(int.TryParse(tryStr, out outInt) == false)
            {playerInpValid =false;}
            else
            {
                if(int.Parse(tryStr) < 1 || int.Parse(tryStr) >4 )
                {
                    playerInpValid =false;
                }
            }
            
            
            

            //consequence
            if(playerInpValid == false)
            {
                Console.WriteLine("Please insert a valid Postion: 'Char_Int'");
                Console.WriteLine("Please use chars that fit the board");

                tmpString = Console.ReadLine();
                //recurring method to make sure it works
                BoardPlaceInputChecker(tmpString);
            }
            else
            {
                switch(playerIn[0])
                {
                    case 'A':
                        ret[0] = 0;
                        break;
                    case 'B':
                        ret[0] = 1;
                        break;
                    case 'C':
                        ret[0] = 2;
                        break;
                    case 'D':
                        ret[0] = 3;
                        break;
                    default:
                        break;
                }

                ret[1] = int.Parse(tryStr)-1;
            }
            //Console.WriteLine(ret[0],ret[1]);
            return ret;

        }

        public static bool TurnSwitcher(bool player1turn)
        {
            if(player1turn == true)
            {player1turn = false;}
            else{player1turn = true;}

            return player1turn;
        }


        
        /// <summary>
        /// Prints the board using the int values stored in the board array Should be callled after every move
        /// </summary>
        /// <param name="currentBoard">Array containing the values of the board</param>
        public void PrintBoard(int[,] currentBoard)
        {   //Idea For how to print the board
            /*Console.WriteLine($"|  ||  ||  ||  |");
            Console.WriteLine($"--------------");*/

            Console.WriteLine($"   A  B  C  D ");
            Console.WriteLine($"1 |{SetPiece(currentBoard[0,0])}||{SetPiece(currentBoard[0,1])}||{SetPiece(currentBoard[0,2])}||{SetPiece(currentBoard[0,3])}|");
            Console.WriteLine("--------------");
            Console.WriteLine($"2 |{SetPiece(currentBoard[1,0])}||{SetPiece(currentBoard[1,1])}||{SetPiece(currentBoard[1,2])}||{SetPiece(currentBoard[1,3])}|");
            Console.WriteLine("--------------");
            Console.WriteLine($"3 |{SetPiece(currentBoard[2,0])}||{SetPiece(currentBoard[2,1])}||{SetPiece(currentBoard[2,2])}||{SetPiece(currentBoard[2,3])}|");
            Console.WriteLine("--------------");
            Console.WriteLine($"4 |{SetPiece(currentBoard[3,0])}||{SetPiece(currentBoard[3,1])}||{SetPiece(currentBoard[3,2])}||{SetPiece(currentBoard[3,3])}|");
            

    
        }

    }


}