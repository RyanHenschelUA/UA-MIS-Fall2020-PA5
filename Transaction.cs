using System;

namespace PA5
{
    class Transaction
    {
        int id;
        string email;
        int isbn;
        string rentalDate;
        string returnDate;
        private static int count;

        public Transaction()
        {

        }
        public Transaction(int id, string email, int isbn, string rentalDate, string returnDate)
        {
            this.id = id;
            this.email = email;
            this.isbn = isbn;
            this.rentalDate = rentalDate;
            this.returnDate = returnDate;
        }
        //declaring setters and getters
        public int GetId()
        {
            return id;
        }
        public void SetId(int id)
        {
            this.id = id;
        }
        public string GetEmail()
        {
            return email;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }
        public int GetIsbn()
        {
            return isbn;
        }
        public void SetIsbn(int isbn)
        {
            this.isbn = isbn;
        }
        public string GetRentalDate()
        {
            return rentalDate;
        }
        public void SetRentalDate(string rentalDate)
        {
            this.rentalDate = rentalDate;
        }
        public string GetReturnDate()
        {
            return returnDate;
        }
        public void SetReturnDate(string returnDate)
        {
            this.returnDate = returnDate;
        }
        public static int GetCount()
        {
            return count;
        }
        public static void SetCount(int count)
        {
            Transaction.count = count;
        }
        public override string ToString()
        {
            return id + "\t" + email + "\t" + isbn + "\t" + rentalDate + "\t" + returnDate;
        }
        public string ToFile()
        {
            return id + "#" + email + "#" + isbn + "#" + rentalDate + "#" + returnDate;
        }
       
        public static void RentBook(Book[] myBooks, Transaction[] myTransaction)
        {

            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter the ISBN of the Book you want to rent:");
            int rentIsbn = int.Parse(Console.ReadLine());
            bool found = false;
            while (found == false)
            {
                for (int i = 0; i < Book.GetCount() && found == false; i++)
                {
                    if (myBooks[i].GetInStock() == true && myBooks[i].GetIsbn() == rentIsbn)
                    {
                        myBooks[i].InStock();
                       
                        found = true;

                    }
                }
                if (found == false)
                {
                    Console.WriteLine("Book not available for rent");

                    Console.WriteLine("Enter the ISBN of the Book you want to rent:");
                    rentIsbn = int.Parse(Console.ReadLine());
                }
            } 
            
            if (found==true)
            {
            
                int newId = myTransaction[Transaction.GetCount() -1].GetId() +1;
                DateTime date = DateTime.Today;
                string dateToday = date.ToString("d");
                string returnDate = "N/A";

                myTransaction[Transaction.GetCount()] = new Transaction(newId, email, rentIsbn, dateToday, returnDate);
                Transaction.SetCount(Transaction.GetCount() + 1);

                TransactionFile.WriteToFile(myTransaction);
                BookFile.WriteToFile(myBooks);
            }


        }
       public static void ReturnBook( Book[] myBooks, Transaction[] myTransaction)
        {
            Console.WriteLine("Enter the email used to rent the book:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter the ISBN of the book you would like to return:");
            int returnId = int.Parse(Console.ReadLine());

            DateTime date = DateTime.Today;
            string dateToday = date.ToString("d");
            bool found = false;
            int index = 0;
            for (int i = 0; i < Book.GetCount() && found == false; i++)
            {
                for (int j = 0; j < Transaction.GetCount() && found == false; j++)
                {
                    if (myTransaction[j].GetIsbn() == returnId && myTransaction[j].GetEmail() == email && myBooks[i].GetIsbn()==returnId)
                    {
                        found = true;
                        myTransaction[j].SetReturnDate(dateToday);

                        myBooks[i].InStock();
                        index = i;


                    }
                }
            }
           
            if (found == true )
            {
                Console.WriteLine("You have returned "+myBooks[index].GetTitle());
                TransactionFile.WriteToFile(myTransaction);
                BookFile.WriteToFile(myBooks);
            }
            else
            {
                Console.WriteLine("Transaction not found");
            }
        }
        public static void Swap(Transaction[] myTransaction, int x, int y)
        {
            Transaction temp = myTransaction[x];
            myTransaction[x] = myTransaction[y];
            myTransaction[y] = temp;
        }
        public static void PrintTransaction(Transaction[] myTransaction)
        {
            
            for (int i = 0; i < GetCount(); i++)
            {
                Console.WriteLine(myTransaction[i].ToString());
            }

        }
    }
}