namespace MovieRental
{
    class RentalPriceContext
    {
        private RentalPriceStrategy strategy;

        public RentalPriceContext(RentalPriceStrategy strategy)
        {
            this.strategy = strategy;
        }

        public decimal executeStrategy(MovieRental rental )
        {
            return strategy.count(rental);
        }
    }
}