using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Movie
    {
        private int Watchcount;
        public string Title;
        public int Duration;
        ///<summary>
        /// Creates a new object
        /// </summary>
        /// <param name="title">Title of the Movie.</param>
        /// <param name="duration">Duration of the Movie</param>
        /// <param name="watchcount">Indicates how often I've watched this Movie</param>
        public Movie(string title, int duration,int watchcount)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("There must be a title.", nameof(title));
            if (duration<=0) throw new ArgumentException("Duration must be a positive value", nameof(duration));
            Title = title;
            Duration = duration;
            setWatchcount(watchcount);
            justWatched();
        }
        ///<summary>
        /// Sets a new absolute watchcount for the Movie
        /// </summary>
        /// <param name="watchcount">How often I saw the Movie.</param>
        public void setWatchcount(int watchcount)
        {
            if (watchcount >= 0) Watchcount = watchcount;
            else throw new ArgumentException("Watchcount must be a positive value", nameof(watchcount));
        }
        ///<summary>
        /// This just increments the Watchcount for the specified Movie
        /// </summary>
        public void justWatched()
        {
            Watchcount++;
        }
        public string getTitle() => Title;
        public int getDuration() => Duration;
        public int getWatchcount() => Watchcount;
       
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Movie a = new Movie("Star Wars", 120, 4);
                Movie b = new Movie("Deadpool", 110, 1);
                Movie c = new Movie("Lord of the Rings", 180, 3);
                Movie d = new Movie("Why is there straw anyway", 3, 183);

                Console.WriteLine($"You spent {a.getDuration() * a.getWatchcount()} minutes of your life watching '{a.getTitle()}' for {a.getWatchcount()} times ");
                Console.WriteLine($"You spent {b.getDuration() * b.getWatchcount()} minutes of your life watching '{b.getTitle()}' for {b.getWatchcount()} times ");
                Console.WriteLine($"You spent {c.getDuration() * c.getWatchcount()} minutes of your life watching '{c.getTitle()}' for {c.getWatchcount()} times ");
                Console.WriteLine($"You spent {d.getDuration() * d.getWatchcount()} minutes of your life watching '{d.getTitle()}' for {d.getWatchcount()} times ");

                Console.WriteLine("Let's change some stuff!");

                a.setWatchcount(7);
                b.justWatched();
                c.setWatchcount(6);
                d.justWatched();

                Console.WriteLine($"You spent {a.getDuration() * a.getWatchcount()} minutes of your life watching '{a.getTitle()}' for {a.getWatchcount()} times ");
                Console.WriteLine($"You spent {b.getDuration() * b.getWatchcount()} minutes of your life watching '{b.getTitle()}' for {b.getWatchcount()} times ");
                Console.WriteLine($"You spent {c.getDuration() * c.getWatchcount()} minutes of your life watching '{c.getTitle()}' for {c.getWatchcount()} times ");
                Console.WriteLine($"You spent {d.getDuration() * d.getWatchcount()} minutes of your life watching '{d.getTitle()}' for {d.getWatchcount()} times ");
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }

        }
    }
}
