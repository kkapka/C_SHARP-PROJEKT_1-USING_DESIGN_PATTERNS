using MovieRental.Strategy_print_confirmation;
using System;

namespace MovieRental.rental_management_system
{
    partial class RentalManagementSystem
    {
        private void printTextOnConsole(string text)
        {
            Console.WriteLine(text);
        }

        private string getTextFromConsole()
        {
            return Console.ReadLine();
        }
        private void printMenu()
        {
            string optionsList = 
                @"Select option:
                1. Add customer
                2. Add movie
                3. Add rental
                4. Print confirmation
                5. Quit                     
            ";

            printTextOnConsole(optionsList);
        }

        public void start()
        {
            int optionId=-1;

            while (optionId != 5)
            {
                chooseAction(optionId);
                printMenu();
                optionId = int.Parse(getTextFromConsole());
            }
            
        }

        private void chooseAction(int actionId)
        {
            switch (actionId)
            {
                case 1:
                    doCase1();
                    break;
                case 2:
                    doCase2();
                    break;
                case 3:
                    doCase3();
                    break;
                case 4:
                    doCase4();
                    break;
                default:
                    break;
            }
        }

        private void doCase1()
        {
            printTextOnConsole("Write name and surname of the customer");
            string name = getTextFromConsole();
            string surname = getTextFromConsole();

            addCustomer(name, surname);
        }

        private void doCase2()
        {
            printTextOnConsole("Write movie title and movie category id");
            string movieTitle = getTextFromConsole();
            int movieCategoryId = int.Parse(getTextFromConsole());

            addMovie(movieTitle, movieCategoryId);
        }

        private void doCase3()
        {
            printTextOnConsole("Write customer id, movie id and rent length (in days)");
            int customerId = int.Parse(getTextFromConsole());
            int movieId = int.Parse(getTextFromConsole());
            int rentLength = int.Parse(getTextFromConsole());
            addMovieRental(customerId, movieId, rentLength);
        }

        private void doCase4()
        {
            printTextOnConsole("Choose rent: ");
            int rentId = int.Parse(getTextFromConsole());

            printTextOnConsole(
                @"Choose confirmation print format:
                1. Standard
                2. HTML
                ");

            int formatId = int.Parse(getTextFromConsole());

            PrintConfirmationContext context=null;

            switch (formatId)
            {
                case 1:
                    context = new PrintConfirmationContext(new PrintConfirmationStandard());
                    break;
                case 2:
                    context = new PrintConfirmationContext(new PrintConfirmationHTML());
                    break;

            }

            context.executeStrategy(movieRentalList[rentId]);

        }
    }
}
