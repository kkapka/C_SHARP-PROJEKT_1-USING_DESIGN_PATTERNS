namespace MovieRental
{
    interface RentalPriceStrategy
    {
        decimal count(MovieRental rental);
    }
}
