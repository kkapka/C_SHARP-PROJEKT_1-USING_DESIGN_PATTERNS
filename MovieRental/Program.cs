using System;

namespace MovieRental
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c = new Customer("Kamil", "Kapka");
            MovieCategory mc = new MovieCategory("New");
            Movie m = new Movie("Iluzja 2", mc);
            MovieRental mr = new MovieRental(c, m, DateTime.Now, DateTime.Now.AddDays(7));

            LoyaltyPointsCountContext context = new LoyaltyPointsCountContext(new LoyaltyPointsCountA());
            context.executeStrategy(mr);

            RentalPriceContext rcontext = new RentalPriceContext(new RentalPriceA());
            Console.WriteLine("Total cost: "+rcontext.executeStrategy(mr)+" PLN ");

            Console.WriteLine("Total points: "+mr.Customer.LoyaltyPoints);
            Console.ReadLine();
        }
    }
}