using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MusicPlayer1
{
    [Serializable]
    class Jazz : Blues
    {
        private string trumpet = "Trrrrumpeeet";

        public string Trumpet
        {
            get
            {
                return trumpet;
            }

            set
            {
                trumpet = value;
            }
        }

        public Jazz (string Band, string Titel, string Genre) : base(Band, Titel, Genre)
        {
            this.Trumpet = Trumpet;
        }

        public override void Play() {
            base.Play();

            Console.Write(Trumpet);
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(200);
                Console.Write(".");
            }
        }
    }
}
