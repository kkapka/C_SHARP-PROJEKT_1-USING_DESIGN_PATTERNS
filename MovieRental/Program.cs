using MovieRental.rental_management_system;

namespace MovieRental
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalManagementSystem rms = new RentalManagementSystem();
            rms.init();
            rms.start();
        }
    }
}