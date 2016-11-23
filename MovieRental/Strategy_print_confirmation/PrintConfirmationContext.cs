using MovieRental.rental_management_system;

namespace MovieRental.Strategy_print_confirmation
{
    class PrintConfirmationContext
    {
        PrintConfirmationStrategy strategy;

        public PrintConfirmationContext(PrintConfirmationStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void executeStrategy(RentalManagementSystem rentalManagementSystem,int customerId)
        {
            strategy.print(rentalManagementSystem,customerId);
        }
    }
}
