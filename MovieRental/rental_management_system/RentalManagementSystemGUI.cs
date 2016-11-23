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
                try
                {
                    chooseAction(optionId);
                    printMenu();
                    optionId = int.Parse(getTextFromConsole());
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("You have selected a wrong id ! Try again");
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You didn't write a number! Try again");
                    continue;
                }
                
            }
            
        }

        private void chooseAction(int actionId)
        {
            if(actionId>5 || actionId < -1)
            {
                printTextOnConsole("You have chosen a wrong option number ! Try again");
            }
            else
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
                    case 5:
                        break;
                    default:
                        break;
                }
            }

        }

        private void doCase1()
        {
            printTextOnConsole("Write name");
            string name = getTextFromConsole();

            printTextOnConsole("Write surname");
            string surname = getTextFromConsole();

            addCustomer(name, surname);
        }

        private void doCase2()
        {
            printTextOnConsole("Write movie title");
            string movieTitle = getTextFromConsole();

            printCategories();
            printTextOnConsole("Write movie category id");
            int movieCategoryId = int.Parse(getTextFromConsole());

            addMovie(movieTitle, movieCategoryId);
        }

        private void doCase3()
        {
            printCustomers();
            printTextOnConsole("Write customer id");
            int customerId = int.Parse(getTextFromConsole());

            printMovies();
            printTextOnConsole("Write movie id");
            int movieId = int.Parse(getTextFromConsole());

            printTextOnConsole("Write rent length (in days)");
            int rentLength = int.Parse(getTextFromConsole());

            addMovieRental(customerId, movieId, rentLength);
        }

        private void doCase4()
        {
            printCustomers();
            printTextOnConsole("Choose customer: ");
            int customerId = int.Parse(getTextFromConsole());

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

            context.executeStrategy(this, customerId);

        }

        private void printCustomers()
        {
            printTextOnConsole("");
            printTextOnConsole("Customers:");

            for(int i = 0; i < customerList.Count; i++)
            {
                printTextOnConsole(i+" "+customerList[i].Name+" "+customerList[i].Surname);
            }

            printTextOnConsole("");
        }

        private void printMovies()
        {
            printTextOnConsole("");
            printTextOnConsole("Movies:");

            for (int i = 0; i < movieList.Count; i++)
            {
                printTextOnConsole(i + " " + movieList[i].Name + " " + movieList[i].Category.Name);
            }

            printTextOnConsole("");
        }

        private void printCategories()
        {
            printTextOnConsole("");
            printTextOnConsole("Categories:");

            for (int i = 0; i < movieCategoryList.Count; i++)
            {
                printTextOnConsole(i + " " + movieCategoryList[i].Name);
            }

            printTextOnConsole("");
        }
    }
}