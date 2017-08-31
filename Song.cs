using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MusicPlayer1
{
    [Serializable]
    class Song
    {
        private string band;
        private string titel;
        private string genre;

        public string Band
        {
            get
            {
                return band;
            }

            set
            {
                band = value;
            }
        }
        public string Titel
        {
            get
            {
                return titel;
            }

            set
            {
                titel = value;
            }
        }
        public string Genre
        {
            get
            {
                return genre;
            }

            set
            {
                genre = value;
            }
        }

        public Song(string Band, string Titel, string Genre)
        {
            this.Band = Band;
            this.Titel = Titel;
            this.Genre = Genre;
        }

        public virtual void Play()
        {
            Console.Write("Loading music file");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }
        }
    }
}
