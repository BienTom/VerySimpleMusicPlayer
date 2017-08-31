using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MusicPlayer1
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p = new Player();
            Console.WriteLine("Provisional Music Player \n");
            Thread.Sleep(1000);
            p.Menu();
        }
    }
}
