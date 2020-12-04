using System;
using System.IO;

namespace PA5
{
    class TransactionFile
    {
        public static Transaction[] ReadTransactionFile()
        {
            //reading transaction file
            Transaction[] myTransaction = new Transaction[100];
            if (File.Exists("transactions.txt"))
            {
                StreamReader inFile = new StreamReader("transactions.txt");
                string line = inFile.ReadLine();
                while (line != null)
                {
                    string[] tempArray = line.Split('#');
                    myTransaction[Transaction.GetCount()] = new Transaction(int.Parse(tempArray[0]), tempArray[1], int.Parse(tempArray[2]), tempArray[3], tempArray[4]);
                    Transaction.SetCount(Transaction.GetCount() + 1);
                    line = inFile.ReadLine();
                }

                inFile.Close();
            }

            else
            {
                Console.WriteLine("File not found.");
            }

            return myTransaction;
        }
        public static void WriteToFile(Transaction[] myTransaction)
        {
            //writing to transaction file
            StreamWriter outFile = new StreamWriter("transactions.txt");
            for (int i = 0; i < Transaction.GetCount(); i++)
            {
                outFile.WriteLine(myTransaction[i].ToFile());
            }
            outFile.Close();
        }
    }
}
