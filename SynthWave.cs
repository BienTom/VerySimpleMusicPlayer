using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MusicPlayer1
{
    [Serializable]
    class SynthWave : Rock
    {
        private string synth = "Bzzzziooooooooooouuuuu";

        public string Synth
        {
            get
            {
                return synth;
            }

            set
            {
                synth = value;
            }
        }

        public SynthWave(string Band, string Titel, string Genre) : base(Band, Titel, Genre)
        {
            this.Synth = Synth;
        }

        public override void Play()
        {
            base.Play();

            Console.Write(Synth);
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(200);
                Console.Write(".");
            }
        }
    }
}
