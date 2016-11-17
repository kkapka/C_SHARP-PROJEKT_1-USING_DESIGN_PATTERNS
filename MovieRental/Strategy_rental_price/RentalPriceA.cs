namespace MovieRental
{
    class RentalPriceA : RentalPriceStrategy
    {
        public decimal count(MovieRental rental)
        {
            int daysCount = (int)(rental.ReturnDate - rental.RentDate).TotalDays;
            string categoryName = rental.Movie.Category.Name;
            decimal totalPrice=daysCount*1;

            switch (categoryName)
            {
                case "New":
                    totalPrice *= 2;
                    break;
                case "Normal":
                    totalPrice *= 1;
                    break;
                case "Kids":
                    totalPrice *= 1;
                    break;
            }

            return totalPrice;
        }
    }
}
