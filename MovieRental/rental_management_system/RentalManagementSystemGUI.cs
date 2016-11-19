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
                printMenu();
                optionId=int.Parse(getTextFromConsole());
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
                    break;
                case 3:
                    break;
                case 4:
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
    }
}
