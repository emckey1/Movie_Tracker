using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_TV_Tracker
{
    class Movie
    {

        private string movieTitle;
        private int movieRating;
        private string watchDate;

        public Movie() { }

        public Movie(string mt, int mr, string wd)
        {
            movieTitle = mt;
            movieRating = mr;
            watchDate = wd;
        }

        public string Title
        {
            get { return movieTitle; }
            set
            {
                movieTitle = value;
            }
        }

        public int Rating
        {
            get { return movieRating; }
            set
            {
                movieRating = value;
            }
        }

        public String Viewed
        {
            get { return watchDate; }
            set
            {
                watchDate = value;
            }
        }

    }
}
