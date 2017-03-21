using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// creates Video Library entry
    /// </summary>
    public interface Video
    {
        string Title { get; }
    }
    public class Movie : Video
    {
        public string Title { get; }

        private int Watchcount;
        public int Length;
        ///<summary>
        /// Creates a new object
        /// </summary>
        /// <param name="title">Title of the Movie.</param>
        /// <param name="length">Duration of the Movie</param>
        /// <param name="watchcount">Indicates how often I've watched this Movie</param>
        public Movie(string title, int length, int watchcount)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("There must be a title.", nameof(title));
            if (length <= 0) throw new ArgumentException("Duration must be a positive value", nameof(length));
            Title = title;
            Length = length;
            setWatchcount(watchcount);
            ///justWatched();
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
        public int getDuration() => Length;
        public int getWatchcount() => Watchcount;


    }
    public class Tvshow : Video
    {
        public string Title { get; }

        public int Episodes;
        ///<summary>
        /// Creates a new object
        /// </summary>
        /// <param name="title">Title of the Movie.</param>
        /// <param name="episodes">how many episodes does the TV show have</param>
        public Tvshow(string title, int episodes)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("There must be a title.", nameof(title));
            if (episodes <= 0) throw new ArgumentException("there has to be at least one episode", nameof(episodes));
            Title = title;
            Episodes = episodes;

        }
        public virtual string getTitle() => Title;
        public int getEpisodes() => Episodes;
    }
    class Program
    {
        static void Main(string[] args)
        {
        
            Movie m1 = new Movie("Batman", 120, 5);
            Movie m2 = new Movie("Star Wars", 140, 4);
            Movie m3 = new Movie("Aladdin", 90, 7);
            Tvshow s1 = new Tvshow("Lost", 120);
            Tvshow s2 = new Tvshow("Game of Thrones", 50);

            var video = new Video[] { m1, m2, m3};

            foreach (var x in video)
            {
                Console.WriteLine("Titel: " + x.Title);
                Console.WriteLine();
            }
            m1.setWatchcount(7);
            m2.justWatched();
            m3.setWatchcount(6);
            m1.justWatched();
            m3.justWatched();

            Console.WriteLine($"Title: {m1.getTitle()} | Length: {m1.getDuration()} | Watched {m1.getWatchcount()} times ");
            Console.WriteLine($"Title: {m2.getTitle()} | Length: {m2.getDuration()} | Watched {m2.getWatchcount()} times ");
            Console.WriteLine($"Title: {m3.getTitle()} | Length: {m3.getDuration()} | Watched {m3.getWatchcount()} times ");

            Console.WriteLine($"Title: {s1.getTitle()} | Episodes: {s1.getEpisodes()}");
            Console.WriteLine($"Title: {s2.getTitle()} | Episodes: {s2.getEpisodes()}");

            string json = JsonConvert.SerializeObject(video, Formatting.Indented);
            Console.WriteLine(json);
            using (StreamWriter file = File.CreateText(@"C:\Users\johan\oom\tasks\Task4\Task4\movie.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, video);
            }
           
            using (StreamReader file = File.OpenText(@"C:\Users\johan\oom\tasks\Task4\Task4\movie.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                Movie video2 = (Movie)serializer.Deserialize(file, typeof(Movie));
            }
            
        }
    }
}
