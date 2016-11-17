namespace MovieRental
{
    class Movie
    {
        private string name;
        private MovieCategory category;

        public Movie(string name,MovieCategory category)
        {
            this.name = name;
            this.category = category;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public MovieCategory Category
        {
            get { return category; }
            set { category = value; }
        }
    }
}
