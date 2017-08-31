using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MusicPlayer1
{
    class Player
    {
        public int _input;
        private int numberOfSongs;
        public int NumberOfSongs
        {
            get
            {
                return numberOfSongs;
            }

            set
            {
                numberOfSongs = value;
            }
        }
        public List<Song> song = new List<Song>();

        static int IntExceptionCatch(string message)
        {
            int result;

            while (true)
            {
                string input;
                Console.WriteLine(message);

                try
                {
                    input = Console.ReadLine();
                }
                catch (OutOfMemoryException e)
                {
                    Console.WriteLine("No operational memory.\nProgram will be terminated.");
                    throw e;
                }
                try
                {
                    result = int.Parse(input);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong number format entered.");
                }
                Console.WriteLine("\aWrong data entered, please enter the data again.");
            }
            return result;
        }

        static string StringExceptionCatch(string message)
        {
            string result;
            Console.WriteLine(message);
            result = Console.ReadLine();
            while (string.IsNullOrEmpty(result))
            {
                Console.WriteLine("Empty string entered, try again.");
                result = Console.ReadLine();
            }
            return result;
        }

        public int EmptyStringVerificationMenu(string input)
        {
            while (!Int32.TryParse(input, out _input))
            {
                Console.WriteLine("Wrong format of entry, please try again.");
                Console.ReadKey();
                Menu();
            }
            return _input;
        }

        public void Add()
        {
            Console.Clear();
            string inputBand = StringExceptionCatch("Enter name of the band: ");
            string inputTitel = StringExceptionCatch("Enter song title: ");
            
            bool state = true;

            while (state) {
                string inputGenre = StringExceptionCatch("Enter genre, choose from one of the available: Blues, Jazz, Metal, Rock, Synthwave: ");
                switch (inputGenre.ToUpper())
                {
                    case "METAL":
                        Metal m = new Metal(inputBand, inputTitel, inputGenre);
                        song.Add(m);
                        state = false;
                        break;
                    case "BLUES":
                        Blues b = new Blues(inputBand, inputTitel, inputGenre);
                        song.Add(b);
                        state = false;
                        break;
                    case "JAZZ":
                        Jazz j = new Jazz(inputBand, inputTitel, inputGenre);
                        song.Add(j);
                        state = false;
                        break;
                    case "ROCK":
                        Rock r = new Rock(inputBand, inputTitel, inputGenre);
                        song.Add(r);
                        state = false;
                        break;
                    case "SYNTHWAVE":
                        SynthWave w = new SynthWave(inputBand, inputTitel, inputGenre);
                        song.Add(w);
                        state = false;
                        break;
                    default:
                        Console.WriteLine("Enter only genres you can see in description.");  
                        break;
                }
                NumberOfSongs = song.Count;
            }     
            Console.WriteLine("Added! Press a button to go back to menu.");
            Console.ReadKey();
        }

        public void Remove()
        {
            Console.Clear();
            DisplaySongs();
            Console.WriteLine("Enter number of song you want to delete: ");
            int number = IntExceptionCatch("Enter a number: ");
            while (number >= NumberOfSongs)
            {
                Console.WriteLine("There is no song with this number in the playlist.");
                number = IntExceptionCatch("Enter a number: ");
            }
            song.RemoveAt(number);

            Console.WriteLine("Deleted! Press a button to go back to menu.");
            Console.ReadKey();
        }

        public void DisplaySongs()
        {
            Console.Clear();
            int index = song.FindIndex(s => s.Titel == s.Titel);
            foreach (Song s in song)
            {
                Console.WriteLine(index++ + ". "+"Artist: "+ s.Band+ "; title: " +s.Titel+"; genre: " +s.Genre+".");
            }
        }

        public void SaveToFile()
        {
            string dir = @"D:\";
            string serializationFile = Path.Combine(dir, "songlist.bin");

            using (Stream stream = File.Open(serializationFile, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                try {
                    bformatter.Serialize(stream, this.song);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Error: " + e.Message);
                    throw;
                }
                finally
                {
                    stream.Close();
                }

                Console.WriteLine("Saved to file in partition D.");
                Console.ReadLine();
            }
        }
        
        public void LoadFromFile()
        {
            string dir = @"D:\";
            string serializationFile = Path.Combine(dir, "songlist.bin");

            var bformatter = new BinaryFormatter();
            Stream stream = new FileStream(serializationFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            try {
                Song song = (Song)bformatter.Deserialize(stream);//TODO InvalidCastException
                Console.WriteLine("List of songs loaded!");
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("TODO Working on it.");
            }
            finally
            {
                stream.Close();
            }
            Console.ReadLine();
        }

        public void PlayerMode()
        {
            Console.WriteLine("Which song do you want to play?");
            DisplaySongs();
            int number = IntExceptionCatch("Enter a number: ");
            while (number >= NumberOfSongs)
            {
                Console.WriteLine("There is no song with this number in the playlist.");
                number = IntExceptionCatch("Enter a number: ");
            } 
            song.ElementAt(number).Play();
            Console.WriteLine("\n\nPress a key to go back to menu.");
            Console.ReadKey();
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Add song");
            Console.WriteLine("2. Delete song");
            Console.WriteLine("3. Display songs in stock");
            Console.WriteLine("4. Play song");
            Console.WriteLine("5. Save song list to file");
            Console.WriteLine("6. Load song list from file");
            Console.WriteLine("7. Exit\n");
            Console.WriteLine("Enter a number");

            string input = Console.ReadLine();

            EmptyStringVerificationMenu(input);
            
            switch (_input)
                    {
                        case 1:
                            Add();
                            Menu();
                            break;
                        case 2:
                            Remove();
                            Menu();
                            break;
                        case 3:
                            DisplaySongs();
                            Console.WriteLine("Press button to go to menu.");
                            Console.ReadKey();
                            Menu();
                            break;
                        case 4:
                            PlayerMode();
                            Menu();
                            break;
                        case 5:
                            SaveToFile();
                            Menu();
                            break;
                        case 6:
                            LoadFromFile();
                            Menu();
                        break;
                        case 7:
                            Environment.Exit(0);
                            break;
                            default:
                            Console.WriteLine("You entered number out of range.");
                            Console.ReadKey();
                            Menu();
                            break;
                    }     
        }   
    }
}
