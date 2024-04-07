using System;
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
            Game game = new Game();
            game.StartGame();
        }
    }
}
