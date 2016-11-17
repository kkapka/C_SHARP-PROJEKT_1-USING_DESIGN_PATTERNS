namespace MovieRental
{
    class Customer
    {
        private string name;
        private string surname;
        private int loyaltyPoints;

        public Customer(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
            loyaltyPoints = 0;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public int LoyaltyPoints
        {
            get { return loyaltyPoints; }
            set { loyaltyPoints = value; }
        }
    }
}
