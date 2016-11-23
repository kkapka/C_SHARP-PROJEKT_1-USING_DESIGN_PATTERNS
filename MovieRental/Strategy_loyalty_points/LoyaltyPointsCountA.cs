using System;

namespace MovieRental
{
    class LoyaltyPointsCountA : LoyaltyPointsCountStrategy
    {
        public void count(MovieRental rental)
        {
            int daysCount = (int)(rental.ReturnDate - rental.RentDate).TotalDays;
            int points;
            string categoryName = rental.Movie.Category.Name;

            if (daysCount > 0)
            {
                points = (daysCount - 1) * 1 + 1 * 5;

                if (categoryName == "New")
                {
                    points *= 2;
                }

                rental.Customer.LoyaltyPoints += points;
            }
            else
            {
                Console.WriteLine("Dates difference is negative ! ");
            }
        }
    }
}
