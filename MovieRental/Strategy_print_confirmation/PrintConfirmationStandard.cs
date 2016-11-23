using MovieRental.rental_management_system;
using System;
using System.Collections.Generic;

namespace MovieRental.Strategy_print_confirmation
{
    class PrintConfirmationStandard:PrintConfirmationStrategy
    {
        RentalPriceContext rcontext;

        private void println(string text)
        {
            Console.WriteLine(text);
        }

        private List<MovieRental> findMovieRentals(RentalManagementSystem rentalManagementSystem,List<MovieRental> movieRentalList,int customerId)
        {
            List<MovieRental> list = new List<MovieRental>();
            Customer customer = rentalManagementSystem.getCustomer(customerId);
            foreach(MovieRental movieRental in movieRentalList)
            {
                if (ReferenceEquals(movieRental.Customer, customer))
                {
                    list.Add(movieRental);
                }
            }

            return list;
        }

        private void printMovieRentalDetails(MovieRental rental)
        {
            println("Amount of rent days: " + (int)(rental.ReturnDate - rental.RentDate).TotalDays);
            println("Genre: " + rental.Movie.Category.Name);
            println("Title: " + rental.Movie.Name);
            println("Cost: " + rcontext.executeStrategy(rental));
        }

        private void printMovieRentals(List<MovieRental> movieRentalList)
        {
            foreach(MovieRental movieRental in movieRentalList)
            {
                println(" ");
                println("- - - - - - - - - -");
                printMovieRentalDetails(movieRental);
                println("- - - - - - - - - -");
                println(" ");
            }
        }

        private decimal sumAllCustomerRentals(List<MovieRental> movieRentalList)
        {
            decimal sum = 0;

            foreach (MovieRental movieRental in movieRentalList)
            {
                sum += rcontext.executeStrategy(movieRental);
            }

            return sum;
        }

        public void print(RentalManagementSystem rentalManagementSystem, int customerId)
        {
            rcontext = new RentalPriceContext(new RentalPriceA());

            Customer customer = rentalManagementSystem.getCustomer(customerId);
            List<MovieRental> movieRentalList = rentalManagementSystem.getMovieRentalList();
            decimal totalCost = 0;

            println("Name: " + customer.Name);
            println("Surname: " + customer.Surname);

            movieRentalList = findMovieRentals(rentalManagementSystem, movieRentalList, customerId);

            totalCost = sumAllCustomerRentals(movieRentalList);

            printMovieRentals(movieRentalList);

            println("Number of loyalty points: " + customer.LoyaltyPoints);

            println("Total rentals cost: " + totalCost);
        }
    }
}
