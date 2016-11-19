using MovieRental.Strategy_print_confirmation;
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

            PrintConfirmationContext pcontext = new PrintConfirmationContext(new PrintConfirmationStandard());
            pcontext.executeStrategy(mr);

            PrintConfirmationContext pcontext2 = new PrintConfirmationContext(new PrintConfirmationHTML());
            pcontext2.executeStrategy(mr);

            Console.ReadLine();
        }
    }
}