using System;

namespace MovieRental.Strategy_print_confirmation
{
    class PrintConfirmationStandard:PrintConfirmationStrategy
    {
        void println(string text)
        {
            Console.WriteLine(text);
        }
        public void print(MovieRental rental)
        {
            RentalPriceContext rcontext = new RentalPriceContext(new RentalPriceA());
            LoyaltyPointsCountContext lcontext = new LoyaltyPointsCountContext(new LoyaltyPointsCountA());
            lcontext.executeStrategy(rental);

            println("Name: "+ rental.Customer.Name + " Surname: " + rental.Customer.Surname);
            println("Amount of rent days: " + (int)(rental.ReturnDate-rental.RentDate).TotalDays);
            println("Genre: "+rental.Movie.Category.Name+" Title: "+rental.Movie.Name);
            println("Total cost: "+rcontext.executeStrategy(rental));
            println("Number of loyalty points: " + rental.Customer.LoyaltyPoints);
        }
    }
}
