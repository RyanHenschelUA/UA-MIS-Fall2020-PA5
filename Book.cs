using System;

namespace PA5
{
    class Book
    {
        int isbn;
        string title;
        string genre;
        string author; 
        int time;
        bool inStock;
        static private int count;
        //declaring variables
        public Book()
        {

        }
        public Book(int isbn, string title, string genre, string author, int time, bool inStock)
        {
            this.isbn = isbn;
            this.title = title;
            this.genre = genre;
            this.author = author;
            this.time = time;
            this.inStock = inStock;
            
          
        }
        //calling all getters and setters
        public int GetIsbn()
        {
            return isbn;
        }
        public void SetIsbn(int isbn)
        {
            this.isbn = isbn;
        }
        public string GetTitle()
        {
            return title;
        }
        public void SetTitle(string title)
        {
            this.title = title;
        }
        public string GetGenre()
        {
            return genre;
        }
        public void SetGenre(string genre)
        {
            this.genre = genre;
        }
        public string GetAuthor()
        {
            return author;
        }
        public void SetAuthor(string author)
        {
            this.author = author;
        }
        public int GetTime()
        {
            return time;
        }
        public void SetTime(int time)
        {
            this.time = time;
        }
        public static int GetCount()
        {
            return count;
        }
        public static void SetCount(int count)
        {
            Book.count = count;
        }
        public bool GetInStock()
        {
            return inStock;
        }
       public void SetInStock(bool inStock)
        {
            this.inStock = inStock;
        }
        public void InStock()
        {
            inStock = !inStock;
        }
        public override string ToString()
        {
            return isbn + "\t" + title + "\t" + genre + "\t" + author + "\t" + time;
        }
        public string ToFile()
        {
            return isbn + "#" + title + "#" + genre + "#" + author + "#" + time + "#" + inStock;
        }
        public static void PrintBooks(Book[] myBooks)
        {
            Console.WriteLine("\nIsbn\tTitle\t\tGenre\tAuthor\tTime\tIn Stock Indicator");
            for (int i = 0; i < GetCount(); i++)
            {
                Console.WriteLine(myBooks[i].ToString());
            }
            //printing all books
        }
        public static void SortByIsbn(Book[] myBooks)
        {
            //sortign books by id
            int minIndex;
            for(int i=0; i < Book.GetCount() - 1; i++)
            {
                minIndex = i;
                for(int j= i + 1; j < GetCount(); j++)
                {
                    if (myBooks[j].GetIsbn() < myBooks[minIndex].GetIsbn())
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Swap(myBooks, i, minIndex);
                }
            }
        }
        
        public static void Swap(Book[] myBooks, int x, int y)
        {
            
            Book temp = myBooks[x];
            myBooks[x] = myBooks[y];
            myBooks[y] = temp;
        }
        public static void AddBook(Book[] myBooks)
        {
            Console.WriteLine("What is the ISBN of the new book?: ");
            int isbn = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the title of the book you would like to add?");
            string title = Console.ReadLine();

            Console.WriteLine("What is the genre of the book?: ");
            string genre = Console.ReadLine();

            Console.WriteLine("Who is the author of the book?: ");
            string author = Console.ReadLine();

            Console.WriteLine("How long is the recording (in minutes)?: ");
            int time = int.Parse(Console.ReadLine());
            bool inStock = true;

            myBooks[Book.GetCount()] = new Book(isbn, title, genre, author, time, inStock);
            Book.SetCount(Book.GetCount() + 1);

            BookFile.WriteToFile(myBooks);

        }
        public static int EditBook(Book[] myBooks)
        {
            Console.WriteLine("What is the ISBN of the book you will be editing?:");
            int editIsbn = int.Parse(Console.ReadLine());
            bool found = false;
            int index=0;
            for (int i = 0; i < Book.GetCount() && found == false; i++)
            {
                if (myBooks[i].GetIsbn() == editIsbn)
                {
                    found = true;
                    index = i;
                    
                }
            }
           if (found != true)
           {
             Console.WriteLine("Book ISBN " + editIsbn + " not found");
           }
           else
           {
                Console.WriteLine(myBooks[index].ToString());
                EditMenu(index,myBooks);
           }
            
            BookFile.WriteToFile(myBooks);
            return myBooks[index].GetIsbn();
        }
        public static int GetEditMenuChoice()
        {
            int choice;
            bool notValid = true;
            Console.WriteLine("1) Title");
            Console.WriteLine("2) Genre");
            Console.WriteLine("3) Author");
            Console.WriteLine("4) Time");
            Console.WriteLine("5) In-Stock");
            Console.WriteLine("6) Exit");
            string inputChoice = Console.ReadLine();
            if (int.TryParse(inputChoice, out choice))
            {
                if (choice >= 1 && choice <= 6)
                {
                    notValid = false;

                }
            }
            while (notValid)
            {
                Console.WriteLine("Please enter a valid menu choice: ");
                inputChoice = Console.ReadLine();
                if (int.TryParse(inputChoice, out choice))
                {
                    if (choice >= 1 && choice <= 6)
                    {
                        notValid = false;

                    }
                }
            }
            return choice;
        }
        public static void EditMenu(int index,Book[] myBooks)
        {
            int menuChoice = GetEditMenuChoice();


            while (menuChoice != 6)
            {
                if (menuChoice == 1)
                {
                   
                    Console.WriteLine("What would you like the title to be: ");
                    string title = Console.ReadLine();

                    myBooks[index].SetTitle(title);

                }
                else if (menuChoice == 2)
                {
                    Console.WriteLine("What would you like the genre to be: ");
                    string genre = Console.ReadLine();
                    myBooks[index].SetGenre(genre);
                }
                else if (menuChoice == 3)
                {
                    Console.WriteLine("What would you like to change the author to:");
                    string author = Console.ReadLine();
                    myBooks[index].SetAuthor(author);

                }
                else if (menuChoice == 4)
                {
                    Console.WriteLine("What would you like to change the length of time to: ");
                    int time = int.Parse(Console.ReadLine());
                }
                else if (menuChoice == 5)
                {
                    myBooks[index].InStock();
                }
                menuChoice = GetEditMenuChoice();
            }
                
            
        }



    }
}