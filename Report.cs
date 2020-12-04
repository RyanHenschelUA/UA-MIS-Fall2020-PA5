using System;

namespace PA5
{
    class Report
    {
        public static void RentedByEmail(Book[] myBooks, Transaction[] myTransaction)
        {
            //showing movies currently rented
            Console.WriteLine("Enter the email used to rent the books:");
            string email = Console.ReadLine();
            int count = 0;
            for(int i = 0; i < Book.GetCount(); i++)
            {
                for (int j = 0; j < Transaction.GetCount(); j++)
                {
                    if (myTransaction[j].GetEmail() == email && myBooks[i].GetInStock() == false && myBooks[i].GetIsbn()==myTransaction[j].GetIsbn()&&myTransaction[j].GetReturnDate()=="N/A")
                    {
                        Console.WriteLine(myBooks[i].GetIsbn()+" "+myBooks[i].GetTitle());
                        count++;
                    }
                }
                
              
            }
            if(count == 0)
            {
                Console.WriteLine("No rentals found");
            }

        }
    }
}