using MovieRental.rental_management_system;
using System;
using System.Collections.Generic;
using System.IO;

namespace MovieRental.Strategy_print_confirmation
{
    class PrintConfirmationHTML : PrintConfirmationStrategy
    {
        private RentalPriceContext rcontext;

        private List<MovieRental> findMovieRentals(RentalManagementSystem rentalManagementSystem, List<MovieRental> movieRentalList, int customerId)
        {
            List<MovieRental> list = new List<MovieRental>();
            Customer customer = rentalManagementSystem.getCustomer(customerId);
            foreach (MovieRental movieRental in movieRentalList)
            {
                if (ReferenceEquals(movieRental.Customer, customer))
                {
                    list.Add(movieRental);
                }
            }

            return list;
        }

        private void printMovieRentalDetails(StreamWriter file,MovieRental rental)
        {
            file.WriteLine("<tr><td>Amount of rent days:</td><td>" + (int)(rental.ReturnDate - rental.RentDate).TotalDays+ "</td></tr>");
            file.WriteLine("<tr><td>Genre:</td><td>" + rental.Movie.Category.Name + "</td></tr>");
            file.WriteLine("<tr><td>Title:</td><td>" + rental.Movie.Name + "</td></tr>");
            file.WriteLine("<tr><td>Cost:</td><td>" + rcontext.executeStrategy(rental) + "</td></tr>");
        }

        private void printMovieRentals(StreamWriter file, List<MovieRental> movieRentalList)
        {
            foreach (MovieRental movieRental in movieRentalList)
            {
                file.WriteLine("<tr><td></td><td></td></tr>");
                printMovieRentalDetails(file,movieRental);
                file.WriteLine("<tr><td></td><td></td></tr>");
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
            rcontext = new RentalPriceContext(new RentalPriceA()); ;
            Customer customer = rentalManagementSystem.getCustomer(customerId);
            List<MovieRental> movieRentalList = rentalManagementSystem.getMovieRentalList();
            decimal totalCost = 0;

            string filePath = "rental_confirmation.html";

            using (StreamWriter file = new StreamWriter(filePath))
            {
                file.WriteLine("<!DOCTYPE html>");
                file.WriteLine("<html>");
                file.WriteLine("<head>");
                file.WriteLine("</head>");
                file.WriteLine("<body>");
                file.WriteLine("<table>");
                file.WriteLine("<tr><td>Name: </td><td>" + customer.Name + "</td></tr>");
                file.WriteLine("<tr><td>Surname: </td><td>" + customer.Surname + "</td></tr>");

                movieRentalList = findMovieRentals(rentalManagementSystem, movieRentalList, customerId);

                totalCost = sumAllCustomerRentals(movieRentalList);

                printMovieRentals(file,movieRentalList);

                file.WriteLine("<tr><td>Number of loyalty points: </td><td>" + customer.LoyaltyPoints + "</td></tr>");
                file.WriteLine("<tr><td>Total cost: </td><td>" + totalCost + "</td></tr>");
                file.WriteLine("</table>");
                file.WriteLine("</body>");
                file.WriteLine("</html>");

                file.Close();

                System.Diagnostics.Process.Start(filePath);
            }
        }
    }
}
