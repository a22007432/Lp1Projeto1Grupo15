using System;

namespace GaloDaVelha
{

    /// <summary>
    /// This enumerator contains all the pieces used in the game as chars
    /// Used In SetPiece() method
    /// </summary>
    [Flags]
    public enum Pieces
    {
        //BigSquare = 1 << 0,
        Null = 'X' << 0,

        //Cant left or right chars or theyll break
        BigSquare = '\u2610',  //☐


        //SmallSquare = 1 << 2,
        SmallSquare = '\u25C7', //◇


        //BigSquareH = 1 << 3,
        BigSquareH = '\u2612',  //☒ 

        //SmallSquareH = 1 << 4,
        SmallSquareH ='\u25C8', //◈
        
        //BigCircle = 1 << 5,
        BigCircle = '\u25CB', //○

        //SmallCircle = 1 << 6,
        SmallCircle = '\u25E6', //◦


        //BigCircleH = 1 << 7,
        BigCircleH = '\u25CE', //◎

        //SmallCircleH = 1 << 8,
        SmallCircleH = '\u2609', //☉

    }
}