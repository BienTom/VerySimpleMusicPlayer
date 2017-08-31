using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MusicPlayer1
{
    [Serializable]
    class Metal : Blues
    {
        private string distortion = "Wrrrwawaaawwrrrr";

        public string Distortion
        {
            get
            {
                return distortion;
            }

            set
            {
                distortion = value;
            }
        }

        public Metal(string Band, string Titel, string Genre) : base(Band, Titel, Genre)
        {
            this.Distortion = Distortion;
        }

        public override void Play()
        {
            base.Play();

            Console.Write(Distortion);
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(200);
                Console.Write(".");
            }
        }
    }
}
