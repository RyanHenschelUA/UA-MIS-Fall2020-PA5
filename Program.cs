using System;

namespace PA5
{
    class Program
    {
        static void Main(string[] args)
        {
            Book[] myBooks = BookFile.ReadBookFile();
            Transaction[] myTransaction = TransactionFile.ReadTransactionFile();

            Menu(myBooks, myTransaction);
        }
        public static void Menu(Book[] myBooks, Transaction[] myTransaction)
        {
            Console.WriteLine("Make A Selection:");
            Console.WriteLine("1) Add a Book");
            Console.WriteLine("2) Edit a Book");
            Console.WriteLine("3) Rent a Book");
            Console.WriteLine("4) Return a Book");
            Console.WriteLine("5) Reports");
            Console.WriteLine("6) Exit");

            int choice = int.Parse(Console.ReadLine());

            if (choice==1)
            {
                Book.AddBook(myBooks);
            }
            else if (choice==2)
            {
                Book.EditBook(myBooks);
            }
            else if (choice==3)
            {
                Transaction.RentBook(myBooks, myTransaction);
            }
            else if (choice==4)
            {
                Transaction.ReturnBook(myBooks, myTransaction);
            }
            else if (choice==5)
            {
               Report.RentedByEmail(myBooks, myTransaction); 
            }
            else
            {
                Console.Clear();
            }
        }
    }
}
