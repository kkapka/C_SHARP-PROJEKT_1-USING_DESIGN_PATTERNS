using System;
using System.IO;

namespace MovieRental.Strategy_print_confirmation
{
    class PrintConfirmationHTML:PrintConfirmationStrategy
    {
        public void print(MovieRental rental)
        {
            RentalPriceContext rcontext = new RentalPriceContext(new RentalPriceA());
            string filePath = "rental_confirmation.html";

            using (StreamWriter file=new StreamWriter(filePath))
            {
                file.WriteLine("<!DOCTYPE html>");
                file.WriteLine("<html>");
                file.WriteLine("<head>");
                file.WriteLine("</head>");
                file.WriteLine("<body>");
                file.WriteLine("<table>");
                file.WriteLine("<tr><td>Name: </td><td>" + rental.Customer.Name + "</td></tr>");
                file.WriteLine("<tr><td>Surname: </td><td>" + rental.Customer.Surname + "</td></tr>");
                file.WriteLine("<tr><td>Amount of rent days: </td><td>" + (int)(rental.ReturnDate - rental.RentDate).TotalDays + "</td></tr>");
                file.WriteLine("<tr><td>Genre: </td><td>" + rental.Movie.Category.Name + "</td></tr>");
                file.WriteLine("<tr><td>Title: </td><td>" + rental.Movie.Name + "</td></tr>");
                file.WriteLine("<tr><td>Total cost: </td><td>" + rcontext.executeStrategy(rental) + "</td></tr>");
                file.WriteLine("<tr><td>Number of loyalty points: </td><td>" + rental.Customer.LoyaltyPoints + "</td></tr>");
                file.WriteLine("</table>");
                file.WriteLine("</body>");
                file.WriteLine("</html>");

                file.Close();

                System.Diagnostics.Process.Start(filePath);
            }
        }
    }
}
