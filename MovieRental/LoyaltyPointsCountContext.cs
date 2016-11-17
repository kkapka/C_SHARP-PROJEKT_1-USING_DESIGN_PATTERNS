namespace MovieRental
{
    class LoyaltyPointsCountContext
    {
        private LoyaltyPointsCountStrategy strategy;

        public LoyaltyPointsCountContext(LoyaltyPointsCountStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void executeStrategy(MovieRental rental)
        {
            strategy.count(rental);
        }
    }
}
