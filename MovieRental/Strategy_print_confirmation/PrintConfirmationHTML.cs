using System;
using System.IO;

namespace MovieRental.Strategy_print_confirmation
{
    class PrintConfirmationHTML:PrintConfirmationStrategy
    {
        public void print(MovieRental rental)
        {
            RentalPriceContext rcontext = new RentalPriceContext(new RentalPriceA());
            string fileName = "rental_confirmation.html";

            using (FileStream fileStream=File.Create(fileName))
            {
                using (StreamWriter file=new StreamWriter(fileStream))
                {
                    file.WriteLine("<html>");
                    file.WriteLine("<head>");
                    file.WriteLine("</head>");
                    file.WriteLine("<body>");
                    file.WriteLine("<table>");
                    file.WriteLine("<tr><td>Name: " + rental.Customer.Name + "</td><td>Surname: " + rental.Customer.Surname + "</td></tr>");
                    file.WriteLine("<tr><td>Amount of rent days: " + (int)(rental.ReturnDate - rental.RentDate).TotalDays + "</td></tr>");
                    file.WriteLine("<tr><td>Genre: " + rental.Movie.Category.Name + "</td><td>Title: " + rental.Movie.Name + "</td></tr>");
                    file.WriteLine("<tr><td>Total cost: " + rcontext.executeStrategy(rental) + "</td></tr>");
                    file.WriteLine("<tr><td>Number of loyalty points: " + rental.Customer.LoyaltyPoints + "</td></tr>");
                    file.WriteLine("</table>");
                    file.WriteLine("</body>");
                    file.WriteLine("</html>");

                    file.Close();
                }
            }
        }
    }
}
