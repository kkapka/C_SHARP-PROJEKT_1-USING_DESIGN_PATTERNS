using System;

namespace MovieRental
{
    class MovieRental
    {
        Customer customer;
        Movie movie;
        DateTime rentDate;
        DateTime returnDate;

        public MovieRental(Customer customer, Movie movie, DateTime rentDate, DateTime returnDate)
        {
            this.customer = customer;
            this.movie = movie;
            this.rentDate = rentDate;
            this.returnDate = returnDate;
        }

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public Movie Movie
        {
            get { return movie; }
            set { movie = value; }
        }

        public DateTime RentDate
        {
            get { return rentDate; }
            set { returnDate = value; }
        }

        public DateTime ReturnDate
        {
            get { return returnDate; }
            set { returnDate = value; }
        }
    }
}
