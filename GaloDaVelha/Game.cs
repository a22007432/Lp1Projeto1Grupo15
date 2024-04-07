using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace GaloDaVelha
{
    /// <summary>
    /// This class controls the game.
    /// </summary>
    public class Game
    {
        //Array to hold the board values
        static int[,] board = new int [4,4]; 
        
        /// <summary>
        /// Array that holds ints that represent conditions (square, circle, hole, no hole, big, small, white, black)
        /// </summary>
        /// <value></value>
        static int[] conditions = {0,0,0,0,0,0,0,0};

        //Method to start the game
        public void StartGame()
        {
            PrintBoard(board);
            
            SetDefaultBoard(board);
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
            return tmpPiece;
        }

        /// <summary>
        /// The game loop where it decides the player turn and calls the functions to decide who wins
        /// </summary>
        /// <param name="placement">The placement of the piece according to the playerIN</param>
        /// <param name="playerIn">The player input</param>
        /// <param name="tmpN">The variable used to check a valid input of the piece</param>
        /// <param name="roundCounter">An int for the number of rounds</param>
        /// <param name="player1Turn">Boolean that decides the player turn</param>
        public void GameLoop()
        {   
            int[] placement;
            string playerIn;
            int tmpN;
            int roundCounter = 1;
            bool player1Turn = true;

            //While there is still space in the board to play pieces 
            while(roundCounter < 17)
            {
                if(player1Turn == true)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"ROUND {roundCounter}:");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Player 1, Pick player 2s Piece (You can use 'F' to forfeit):");
                    
                    playerIn = Console.ReadLine();
                    
                    if(playerIn == "F")
                    {
                        GameResult("F1");
                        break;
                    }
                    else if(playerIn == "")
                    {
                        break;
                    }
                    else
                    {
                        tmpN = PiecePickerInputChecker(playerIn, "2");

                        Console.WriteLine("");
                        Console.WriteLine(
                        "Player 2, Place your piece using this format: 'column row':");
                        playerIn = Console.ReadLine();
                        placement = BoardPlaceInputChecker(playerIn);
                        board[placement[1],placement[0]] = tmpN;

                        Console.Clear();
                        Console.WriteLine("");
                        PrintBoard(board);

                        player1Turn = TurnSwitcher(player1Turn);
                    }
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine($"ROUND {roundCounter}:");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Player 2, Pick player 1s Piece (You can use 'F' to forfeit):");
                    
                    playerIn = Console.ReadLine();
                    
                    if(playerIn == "F")
                    {
                        GameResult("F2");
                        break;
                    }
                    else
                    {
                        tmpN = PiecePickerInputChecker(playerIn, "1");
                        Console.WriteLine("");
                        Console.WriteLine(
                        "Player 1, Place your piece using this format: 'column row':");
                        playerIn = Console.ReadLine();
                        placement = BoardPlaceInputChecker(playerIn);
                        
                        board[placement[1],placement[0]] = tmpN;

                        Console.Clear();
                        Console.WriteLine("");
                        PrintBoard(board);

                        player1Turn =TurnSwitcher(player1Turn);
                    }
                }
                
                roundCounter++;

                if(WinCondition(board,placement,conditions))
                {
                    if (player1Turn)
                    {
                        GameResult("1");
                        break;
                    }
                    if (!player1Turn)
                    {
                        GameResult("2");
                        break;
                    }
                }
            }

            if (roundCounter > 16)
            {
                GameResult("D");
            }

        }

        /// <summary>
        /// Recursive Method to make sure the player that picks a piece makes 
        /// a valid input
        /// </summary>
        /// <param name="playerIn">This is a string with the players input</param>
        /// <param name="player">This is a string that says which player played, in case of forfeit</param>
        /// <param name="ret">This is a secondary int that retains the player input</param>
        /// <param name="tmpString">This is a temporary string with the players input for checking the validity</param>
        /// <param name="playerInpValid">This is a bool that says if the player input was valid or not</param>
        /// <returns>An int that represents a piece</returns>
        public static int PiecePickerInputChecker(string playerIn, string player)
        {
            int ret;
            string tmpString;
            bool playerInpValid = true;


            //List of conditions
            if(playerIn.Length != 1)
                playerInpValid = false;
            
            if(int.TryParse(playerIn, out ret) == false)
                playerInpValid =false;

            //Consequence
            if(playerInpValid == false)
            {
                Console.WriteLine("Please insert a valid Piece: (1-8)");
                tmpString = Console.ReadLine();
                //recurring method to make sure it works
                return PiecePickerInputChecker(tmpString, player);
            }
            else
            {
                if (player == "1")
                {
                    ret = int.Parse(playerIn);
                    
                    foreach (int value in board)
                    {
                        if (value == ret)
                        {
                            Console.WriteLine("That piece was already used.");
                            Console.WriteLine("Please insert a valid Piece: (1-8)");
                            tmpString = Console.ReadLine();
                            //recurring method to make sure it works
                            return PiecePickerInputChecker(tmpString, player);
                        }
                    }
                }
                else if (player == "2")
                {
                    ret = int.Parse(playerIn);
                    ret += 8;

                    foreach (int value in board)
                    {
                        if (value == ret)
                        {
                            Console.WriteLine("That piece was already used.");
                            Console.WriteLine("Please insert a valid Piece: (1-8)");
                            tmpString = Console.ReadLine();
                            //recurring method to make sure it works
                            return PiecePickerInputChecker(tmpString, player);
                        }
                    }
                }                
                return ret;
            }
        }
        
        /// <summary>
        /// Recursive Method to make sure the player makes a valid placement 
        /// </summary>
        /// <param name="playerIn">This is a string with the players input</param>
        /// <returns>Returns an Array with the xy coordinates needed</returns>
        public static int[] BoardPlaceInputChecker(string playerIn)
        {
            int outInt = 0;
            int[] ret = new int[2];
            int[] tempRet = new int[2];
            bool playerInpValid = true;
            string tmpString;
            string tryStr = "";

            if(playerIn.Length > 2)
            {
                tryStr += playerIn[2];
            }

            //'A' = 65
            //'D' = 68
            //list of conditions
            //if input length is higher than 3
            if(playerIn.Length != 3)
            {
                playerInpValid = false;
            }

            //if it was another char other than ABCD
            if((int)playerIn[0] < 65 || (int)playerIn[0] > 68)
            {
                playerInpValid = false;
            }

            //if the number can't be parsed
            if(int.TryParse(tryStr, out outInt) == false)
            {
                playerInpValid =false;
            }
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
                        tempRet[0] = 0;
                        break;
                    case 'B':
                        tempRet[0] = 1;
                        break;
                    case 'C':
                        tempRet[0] = 2;
                        break;
                    case 'D':
                        tempRet[0] = 3;
                        break;
                    default:
                        break;
                }

                tempRet[1] = int.Parse(tryStr)-1;
            }

            if (board[tempRet[1],tempRet[0]] != 0)
            {
                Console.WriteLine("This spot is already taken");
                Console.WriteLine("Please insert a valid Postion: 'Char_Int'");

                tmpString = Console.ReadLine();

                //recurring method to make sure it works
                return BoardPlaceInputChecker(tmpString);
            }
            else
            {
                ret[0] = tempRet[0];
                ret[1] = tempRet[1];
                return ret;
            }

        }

        public static bool TurnSwitcher(bool player1turn)
        {
            if(player1turn == true){player1turn = false;}
            else{player1turn = true;}

            return player1turn;
        }
        
        /// <summary>
        /// Prints the board using the int values stored in the board array Should be callled after every move
        /// </summary>
        /// <param name="currentBoard">Array containing the values of the board</param>
        public void PrintBoard(int[,] currentBoard)
        {   
            Console.WriteLine($"   A  B  C  D ");

            for(int i = 0; i < 4; i++)
            {
                Console.Write($"{i+1} ");

                for(int j = 0; j < 4; j++)
                {
                    if (currentBoard[i,j] < 9)
                        Console.Write($"|{SetPiece(currentBoard[i,j])}|");
                    
                    else if (currentBoard[i,j] < 17)
                    {
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{SetPiece(currentBoard[i,j] - 8)}");
                        Console.ResetColor();
                        Console.Write ("|");
                    }
                }
                Console.WriteLine("");
                
                if (i <= 2)
                    Console.WriteLine("--------------");
            }
        }

        //position xy 0-3
        private static bool WinCondition(int[,] board, int[] position, int[] conditions)
        {               
            bool winner = false;

            conditions = PieceRunthrough(conditions,position,board);

            //Checks condition
            foreach(int c in conditions)
            {
                if(c >= 4)
                {
                    winner = true;
                }

            }
           return winner;
        }

        //(0square, 1circle, 2hole, 3no hole, 4big, 5small, 6white, 7black)
        /// <summary>
        /// Checks a piece to see what attributes it has
        /// </summary>
        /// <param name="conditions">A static array that holds the winning conditions</param>
        /// <param name="piece">Int that repreents a board piece</param>
        /// <param name="player">The player who placed that piece</param>
        /// <returns></returns>
        public static int[] PieceConditionChecker(int[] conditions, int piece)
        {   
            //Checks conditions for pieces
            switch (piece)
            {
                case 1: //☐ square, no hole, big
                    conditions[0] += 1;
                    conditions[3] += 1;
                    conditions[4] += 1;
                    conditions[6] += 1;
                    break;
                case 2: //◇ square, no hole, small
                    conditions[0] += 1;
                    conditions[3] += 1;
                    conditions[5] += 1;
                    conditions[6] += 1;
                    break;
                case 3: //☒ square,hole,big
                    conditions[0] += 1;
                    conditions[2] += 1;
                    conditions[4] += 1;
                    conditions[6] += 1;
                    break;
                case 4: //◈ square,hole,small
                    conditions[0] += 1;
                    conditions[2] += 1;
                    conditions[5] += 1;
                    conditions[6] += 1;
                    break;
                case 5: //○ circle, no hole, big
                    conditions[1] += 1;
                    conditions[3] += 1;
                    conditions[4] += 1;
                    conditions[6] += 1;
                    break;
                case 6: //◦ circle, no hole, small
                    conditions[1] += 1;
                    conditions[3] += 1;
                    conditions[5] += 1;
                    conditions[6] += 1;
                    break;
                case 7: //◎ circle, hole, big
                    conditions[1] += 1;
                    conditions[2] += 1;
                    conditions[4] += 1;
                    conditions[6] += 1;
                    break;
                case 8: //☉ circle, hole, small
                    conditions[1] += 1;
                    conditions[2] += 1;
                    conditions[5] += 1;
                    conditions[6] += 1;
                    break;
                case 9: //☐ square, no hole, big
                    conditions[0] += 1;
                    conditions[3] += 1;
                    conditions[4] += 1;
                    conditions[7] += 1;
                    break;
                case 10: //◇ square, no hole, small
                    conditions[0] += 1;
                    conditions[3] += 1;
                    conditions[5] += 1;
                    conditions[7] += 1;
                    break;
                case 11: //☒ square,hole,big
                    conditions[0] += 1;
                    conditions[2] += 1;
                    conditions[4] += 1;
                    conditions[7] += 1;
                    break;
                case 12: //◈ square,hole,small
                    conditions[0] += 1;
                    conditions[2] += 1;
                    conditions[5] += 1;
                    conditions[7] += 1;
                    break;
                case 13: //○ circle, no hole, big
                    conditions[1] += 1;
                    conditions[3] += 1;
                    conditions[4] += 1;
                    conditions[7] += 1;
                    break;
                case 14: //◦ circle, no hole, small
                    conditions[1] += 1;
                    conditions[3] += 1;
                    conditions[5] += 1;
                    conditions[7] += 1;
                    break;
                case 15: //◎ circle, hole, big
                    conditions[1] += 1;
                    conditions[2] += 1;
                    conditions[4] += 1;
                    conditions[7] += 1;
                    break;
                case 16: //☉ circle, hole, small
                    conditions[1] += 1;
                    conditions[2] += 1;
                    conditions[5] += 1;
                    conditions[7] += 1;
                    break;
                default:
                    break;
            }
            return conditions;
        }

        //position xy 0-3
        public static int[] PieceRunthrough(int[] conditions, int[] position, int[,] board)
        {   
            int[] pieceLine = new int[4];

            for (int a = 0; a < 4; a++)
            {
                #region horizontal    
                
                //horizontal checker
                for (int i = 0; i < 4; i ++)
                {
                    pieceLine[i] = board[position[1], i];
                }
                
                if (ConditionResult(conditions, pieceLine))
                {
                    return conditions;
                } 
                #endregion

                #region vertical
                
                //vertical checker
                for (int i = 0; i < 4; i ++)
                {
                    pieceLine[i] = board[i, position[0]];
                }
                
                if (ConditionResult(conditions, pieceLine))
                {
                    return conditions;
                } 
                #endregion

                #region diagonal
                //diagonal checker 00,11,22,33
                for(int i = 0; i < 4; i ++)
                {
                    pieceLine[i] = board[i,i];
                }
                
                if (ConditionResult(conditions, pieceLine))
                {
                    return conditions;
                }

                //diagonal checker 03,21,12,30~
                
                pieceLine[0] = board[0,3];
                pieceLine[1] = board[2,1];
                pieceLine[2] = board[1,2];
                pieceLine[3] = board[3,0];

                if (ConditionResult(conditions, pieceLine))
                {
                    return conditions;
                } 

                #endregion
            }
            return conditions;
        }

        private static bool ConditionResult(int[] conditions, int[] pieceLine)
        {            
            for (int j = 0; j < 4; j ++)
            {
                conditions = PieceConditionChecker(conditions,pieceLine[j]);
            }
            
            for (int k = 0; k < conditions.Length; k++)
            {
                if (conditions[k] == 4)
                {
                    return true;
                }
                else
                {
                    conditions[k] = 0;
                }
            }

            return false;
        }

        // Send "F(player number)" for forfeit
        // Send "1" for player 1 win
        // Send "2" for player 2 win
        // Send "D" for draw
        private void GameResult(string result)
        {
            Console.WriteLine();

            switch (result)
            {
                case "F1":
                    Console.WriteLine("Player 1 forfeited the game");
                    break;
                case "F2":
                    Console.WriteLine("Player 2 forfeited the game");
                    break;
                case "1":
                    Console.WriteLine("Player 1 wins");
                    break;
                case "2":
                    Console.WriteLine("Player 2 wins");
                    break;
                case "D":
                    Console.WriteLine("Draw");
                    break;
                default:
                    Console.WriteLine("Invalid result");
                    break;
            }
        }

    }
}