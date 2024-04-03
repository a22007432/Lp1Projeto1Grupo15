using System;

namespace GaloDaVelha
{

    /// <summary>
    /// This enumerator contains all the pieces used in the game
    /// </summary>
    [Flags]
    public enum Pieces
    {
        //BigSquare = 1 << 0,
        Null = 'X' << 0,
        BigSquare = '\u2610',
        SmallSquare = 1 << 2,

        BigSquareH = 1 << 3,
        SmallSquareH = 1 << 4,

        BigCircle = 1 << 5,
        SmallCircle = 1 << 6,

        BigCircleH = 1 << 7,
        SmallCircleH = 1 << 8,

    }
}