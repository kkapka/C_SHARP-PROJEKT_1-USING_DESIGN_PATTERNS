namespace MovieRental.Strategy_print_confirmation
{
    class PrintConfirmationContext
    {
        PrintConfirmationStrategy strategy;

        public PrintConfirmationContext(PrintConfirmationStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void executeStrategy(MovieRental rental)
        {
            strategy.print(rental);
        }
    }
}
