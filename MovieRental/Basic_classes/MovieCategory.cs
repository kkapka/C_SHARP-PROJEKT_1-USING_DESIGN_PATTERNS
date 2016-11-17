namespace MovieRental
{
    class MovieCategory
    {
        private string name;

        public MovieCategory(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
