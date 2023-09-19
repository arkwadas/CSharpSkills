using Debtor.Core;
using System;

namespace Debtor
{
    public class DebtorApp
    {
        public BorrowerManager BorrowerManager { get; set; } = new BorrowerManager();
        public void IntroduceDeptorApp()
        {
            Console.WriteLine("Witaj w aplikacji Dłużnik");
        }
        public void AddBorrower()
        {
            Console.WriteLine("Podaj nazwe dłużnika, którego chcesz dodać do listy");
            var userName = Console.ReadLine();

            Console.WriteLine("Podaj kwote długu");
            var userAmount = Console.ReadLine();

            if (decimal.TryParse(userAmount, out var ammountInDecimal))
            {
                BorrowerManager.AddBorrower(userName, ammountInDecimal);
            }
        }

        public void DeleteBorrowe()
        {
            Console.WriteLine("Podaj nazwe dłużnika, którego chcesz usunąć z listy");
            var userName = Console.ReadLine();

           
           BorrowerManager.DeleteBorrower(userName);
            Console.WriteLine("Użytkownik usunięty");
        }

        public void ListBorrowers()
        {
            Console.WriteLine("Oto lista Twoich dłużników");
            foreach (var borrower in BorrowerManager.ListBorrowers())
            {
                Console.WriteLine(borrower);
            }
        }

        public void AskForAction()
        {
            Console.WriteLine("Podaj czynność, którą chcesz wykonać:");

            var userInput = default(string);
            while (/*userInput != "exit"*/ true)
            {
                Console.WriteLine("add - Dodawanie użytkownika");
                Console.WriteLine("del - Usuwanie użytkownika");
                Console.WriteLine("list - Wypisywanie listy dłużnika");
                Console.WriteLine("exit - wyjście z programu");
            }

            userInput = Console.ReadLine();
            userInput = userInput.ToLower(); //userInput na poczatku inaczej bedzie kopiowało

            switch (userInput)
            {
                case "add":
                    AddBorrower();
                    break;
                case "del":
                    DeleteBorrowe();
                    break;
                case "list":
                    ListBorrowers();
                    break;
                case "exit":
                    return;
                    default:
                    Console.WriteLine("Podano złą wartość");
                    break;
            }

        }

    }

    
}
