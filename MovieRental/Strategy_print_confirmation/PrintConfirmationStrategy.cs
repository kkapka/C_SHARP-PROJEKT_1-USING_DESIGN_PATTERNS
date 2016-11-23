using MovieRental.rental_management_system;

namespace MovieRental.Strategy_print_confirmation
{
    interface PrintConfirmationStrategy
    {
        void print(RentalManagementSystem rentalManagementSystem,int customerId);
    }
}
