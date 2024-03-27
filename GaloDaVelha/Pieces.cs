using System;

namespace GaloDaVelha
{

    /// <summary>
    /// This enumerator contains all the pieces used in the game
    /// </summary>
    [Flags]
    public enum Pieces
    {
        BigSquare = 1 << 0,
        SmallSquare = 1 << 1,

        BigSquareH = 1 << 2,
        SmallSquareH = 1 << 3,

        BigCircle = 1 << 4,
        SmallCircle = 1 << 5,

        BigCircleH = 1 << 6,
        SmallCircleH = 1 << 7,

    }
}