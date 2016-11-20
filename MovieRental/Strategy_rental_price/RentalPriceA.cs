namespace MovieRental
{
    class RentalPriceA : RentalPriceStrategy
    {
        public decimal count(MovieRental rental)
        {
            int daysCount = (int)(rental.ReturnDate - rental.RentDate).TotalDays;
            string categoryName = rental.Movie.Category.Name;
            decimal totalPrice=daysCount*1;
            int pricePerDay = rental.Movie.Category.Price;

            return totalPrice*pricePerDay;
        }
    }
}
