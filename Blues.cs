using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MusicPlayer1
{
    [Serializable]
    class Blues : Song
    {
        private string guitar = "Guitar is wheeping";
        private string drums = "Drums are drumming";
        private string bass = "Bassssss";
        private string vocals = "Singiiinnnnn'";

        public string Guitar
        {
            get
            {
                return guitar;
            }

            set
            {
                guitar = value;
            }
        }
        public string Drums
        {
            get
            {
                return drums;
            }

            set
            {
                drums = value;
            }
        }
        public string Bass
        {
            get
            {
                return bass;
            }

            set
            {
                bass = value;
            }
        }
        public string Vocals
        {
            get
            {
                return vocals;
            }

            set
            {
                vocals = value;
            }
        }

        public Blues (string Band, string Titel, string Genre) : base(Band, Titel, Genre)
        {
            this.Guitar = Guitar;
            this.Drums = Drums;
            this.Bass = Bass;
            this.Vocals = Vocals;
        }

        public override void Play()
        {
            Console.WriteLine();
            Console.Write(Guitar);
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(200);
                Console.Write(".");
            }
            Console.Write(Drums);
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(100);
                Console.Write(".");
            }
            Console.Write(Bass);
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(100);
                Console.Write(".");
            }
            Console.Write(Vocals);
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(100);
                Console.Write(".");
            }
        }
    }
}
