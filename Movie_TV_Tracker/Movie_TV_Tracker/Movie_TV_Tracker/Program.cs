using ConsoleTables;
using System;
using System.Collections.Generic;
using System.IO;

namespace Movie_TV_Tracker
{
    class Program
    {
        static List<Movie> movieList = new List<Movie>();
        static string selected;
        static void Main(string[] args)
        {
            Intro();
        }

        public static void Intro()
        {
            // Variables
            Console.WriteLine("Hi there! Welcome to the movie tracker program");
            Console.WriteLine("\nWould you like to view the movies you've seen(v), Add a movie to the list(a) or Exit the application(x)");
            selected = Console.ReadLine();
            Selections(selected);
        }

        public static void Selections(string selected)
        {
            if (selected == "v" || selected == "V")
            {
                View();
            }
            else if (selected == "a" || selected == "A")
            {
                Add();
            }
            else if (selected == "x" || selected == "X")
            {
                Exit();
            }
            else
            {
                Console.WriteLine("Not a valid command\n");
                Intro();
            }
        }

        public static void View()
        {
            ReadTextFile();
            Console.WriteLine("\nPlease make a new choice");
            Console.WriteLine("\nWould you like to add a movie(a) or exit the application(x)");
            selected = Console.ReadLine();
            Selections(selected);
        }

        public static void Add()
        {
            Movie newMovie;
            DateTime today = new DateTime();

            string _movieTitle;
            int _movieRating;
            string _movieViewed = Convert.ToDateTime(today).ToShortDateString();

            Console.WriteLine("\nMovie Title: ");
            _movieTitle = Console.ReadLine();
            Console.WriteLine("\nYour rating: ");
            _movieRating = Convert.ToInt32(Console.ReadLine());

            newMovie = new Movie(_movieTitle, _movieRating, _movieViewed);

            movieList.Add(newMovie);

            WriteTextFile();

            Console.WriteLine("\nWould you like to add another movie(a), view your movie collection(v) or exit the application(x)");
            selected = Console.ReadLine();
            Selections(selected);
        }

        public static void Exit()
        {
            WriteTextFile();
            Environment.Exit(0);
        }

        public static void ReadTextFile()
        {
            Movie movie;

            FileStream fs = new FileStream("Movie_List.txt", FileMode.OpenOrCreate);
            
            using (StreamReader sr = new StreamReader(fs))
            {
                string line;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    string[] col = line.Split(';');

                    string _title = col[0];
                    int _rating = Convert.ToInt32(col[1]);
                    string _watchDate = Convert.ToDateTime(col[2]).ToShortDateString();

                    movie = new Movie(_title, _rating, _watchDate);

                    movieList.Add(movie);

                    ConsoleTable.From<Movie>(movieList).Write();

                }
            }
        }

        public static void WriteTextFile()
        {
            FileStream fs = new FileStream("Movie_List.txt", FileMode.Create);

            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach (Movie movie in movieList)
                {
                    sw.Write(movie.Title + ";" + movie.Rating + ";" + movie.Viewed + "\n");
                }
            }
        }

    }
}
