using System;
using System.IO;

namespace PA5
{
    class BookFile
    {
        public static Book[] ReadBookFile()
        {
            //reading book file
            Book[] myBooks = new Book[100];
            if (File.Exists("books.txt"))
            {
                StreamReader inFile = new StreamReader("books.txt");
                string line = inFile.ReadLine();
                while (line != null)
                {
                    string[] tempArray = line.Split('#');
                    myBooks[Book.GetCount()] = new Book(int.Parse(tempArray[0]), tempArray[1], tempArray[2], tempArray[3], int.Parse(tempArray[4]), bool.Parse(tempArray[5]));

                    Book.SetCount(Book.GetCount() + 1);
                    line = inFile.ReadLine();
                }

                inFile.Close();
            }
        
            else
            {
                Console.WriteLine("File not found.");
            }

            return myBooks;
        }
        public static void WriteToFile(Book[]myBooks)
        {
            //writing to movie file
            StreamWriter outFile = new StreamWriter("books.txt");
            for (int i = 0; i < Book.GetCount(); i++)
            {
                outFile.WriteLine(myBooks[i].ToFile());
            }
            outFile.Close();
        }
       

    }
}