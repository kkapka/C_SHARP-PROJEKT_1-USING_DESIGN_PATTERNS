using MovieRental.Strategy_print_confirmation;
using MovieRental.rental_management_system;
using System;

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