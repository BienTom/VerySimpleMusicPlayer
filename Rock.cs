using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MusicPlayer1
{
    [Serializable]
    class Rock : Jazz
    {
        private string piano = "Plum plum plum";

        public string Piano
        {
            get
            {
                return piano;
            }

            set
            {
                piano = value;
            }
        }

        public Rock(string Band, string Titel, string Genre) : base(Band, Titel, Genre)
        {
            this.Piano = Piano;
        }

        public override void Play()
        {
            base.Play();

            Console.Write(Piano);
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(200);
                Console.Write(".");
            }
        }
    }
}
