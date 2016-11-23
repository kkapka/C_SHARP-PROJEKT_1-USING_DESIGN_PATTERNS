using System;
using System.Collections.Generic;

namespace MovieRental.rental_management_system
{
    partial class RentalManagementSystem
    {
        private List<MovieCategory> movieCategoryList;
        private List<Movie> movieList;
        private List<Customer> customerList;
        private List<MovieRental> movieRentalList;

        public RentalManagementSystem()
        {
            movieCategoryList = new List<MovieCategory>();
            movieList = new List<Movie>();
            customerList = new List<Customer>();
            movieRentalList = new List<MovieRental>();
        }
        
        private void addMovieCategory(string name,int price)
        {
            MovieCategory movieCategory = new MovieCategory(name,price);
            movieCategoryList.Add(movieCategory);
        }

        private MovieCategory getMovieCategory(int id)
        {
            return movieCategoryList[id];
        }

        private void addMovie(string title,int category)
        {
            Movie movie = new Movie(title, getMovieCategory(category));
            movieList.Add(movie);
        }

        private void addCustomer(string name,string surname)
        {
            Customer customer = new Customer(name, surname);
            customerList.Add(customer);
        }

        private Movie getMovie(int id)
        {
            return movieList[id];
        }

        public Customer getCustomer(int id)
        {
            return customerList[id];
        }

        public List<MovieRental> getMovieRentalList()
        {
            return movieRentalList;
        }

        private void addMovieRental(int customerId,int movieId,int rentLength)
        {
            Customer customer = getCustomer(customerId);
            Movie movie = getMovie(movieId);
            DateTime rentDate = DateTime.Now;
            DateTime returnDate = DateTime.Now.AddDays(rentLength);
            MovieRental movieRental = new MovieRental(customer,movie,rentDate,returnDate);

            // counting loyalty points strategy
            LoyaltyPointsCountContext lcontext = new LoyaltyPointsCountContext(new LoyaltyPointsCountA());
            lcontext.executeStrategy(movieRental);

            movieRentalList.Add(movieRental);
        }

        public void init()
        {
            addMovieCategory("Normal",1);
            addMovieCategory("Kids",2);
            addMovieCategory("New",3);
            addMovieCategory("Western",4);

            addMovie("Animals", 0);
            addMovie("Shrek 3", 1);
            addMovie("Now you see me 2", 2);
            addMovie("Cheyenne", 3);

            addCustomer("Kamil","Kapka");
            addCustomer("Joanna", "Tokarska");

            addMovieRental(0, 2, 7);

        }
    }
}
