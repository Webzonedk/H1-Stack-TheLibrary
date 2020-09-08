using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace TheLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            List<Book> booksBorrowed = new List<Book>();
            Stack<Book> booksToBorrow = new Stack<Book>();
            string titleHeader = "Title:";
            string authorHeader = "Author:";
            string id = "Id:";

            books.Add(new Book("Den hemmelige hemmelighed", "Åberg", "Anton"));
            books.Add(new Book("Den store verden", "Ryge", "Søren"));
            books.Add(new Book("Hvem vil være millionær", "Mogensen", "Søren"));
            books.Add(new Book("Pivedyret", "Jensen", "Marcus"));
            books.Add(new Book("Svenskeren med skovlen", "Hansen", "Svend"));
            books.Add(new Book("Den glade hest", "Jyde", "Oskar"));
            books.Add(new Book("Gyngehøvdingen", "Gynge", "Svend"));
            books.Add(new Book("De vise sten", "Pedersen", "Rasmus"));


            Console.WriteLine(@"  _______  _             _  _  _                              ");
            Console.WriteLine(@" |__   __|| |           | |(_)| |                             ");
            Console.WriteLine(@"    | |   | |__    ___  | | _ | |__   _ __  __ _  _ __  _   _ ");
            Console.WriteLine(@"    | |   | '_ \  / _ \ | || || '_ \ | '__|/ _` || '__|| | | |");
            Console.WriteLine(@"    | |   | | | ||  __/ | || || |_) || |  | (_| || |   | |_| |");
            Console.WriteLine(@"    |_|   |_| |_| \___| |_||_||_.__/ |_|   \__,_||_|    \__, |");
            Console.WriteLine(@"                                                         __/ |");
            Console.WriteLine(@"                                                        |___/ ");
            Thread.Sleep(2000);
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("==================================================================");
            Console.WriteLine("=                        H1 library Menu                         =");
            Console.WriteLine("==================================================================");
            Console.WriteLine();
            Console.WriteLine("1. List books");
            Console.WriteLine("2. To exit");
            Console.WriteLine();
            Console.Write("Enter your choice: \n");
            Console.WriteLine();


            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    bool run = true;
                    while (run)
                    {
                        Console.Clear();
                        Console.WriteLine("==================================================================");
                        Console.WriteLine("=                        Books in stock                          =");
                        Console.WriteLine("==================================================================");
                        Console.WriteLine($"{id,5}  {titleHeader,-50}       {authorHeader}");
                        //if there is content in the list, then it will be listed here
                        if (books.Count >= 1)
                        {
                            for (int i = 0; i < books.Count; i++)
                            {
                                Console.WriteLine($"{i + 1,5}  {books[i].Title,-50}  by:  {books[i].AuthorFirstname} {books[i].Authorlastname}");
                            }
                            Console.WriteLine();

                            //Here the borrowing starts with an error check and followed by a loop to check if the id match a book
                            try
                            {
                                Console.WriteLine($"Chose the books to borrow: 1 - {books.Count} ");
                                uint bookId = UInt32.Parse(Console.ReadLine());
                                for (int j = 0; j < books.Count; j++)
                                {
                                    if (bookId == j + 1)
                                    {
                                        booksToBorrow.Push(books[j]);
                                        books.Remove(books[j]);
                                        Console.Write("{0}", booksToBorrow.Peek().Title + "\t by:\t ");
                                        Console.Write("{0}", booksToBorrow.Peek().AuthorFirstname + " ");
                                        Console.Write("{0}", booksToBorrow.Peek().Authorlastname + " has been added to your basket.");
                                        Console.WriteLine();
                                    }
                                }

                                Console.WriteLine();
                                Console.WriteLine("| Find more books: press 1 | Borrow the books in your Basket: Press 2 | Exit witout borrowing any books: press 3 |");
                                switch (Console.ReadKey(true).KeyChar)
                                {
                                    case '1':
                                        //if 1 is choosen it will return back to the list of books to be able to choose more books
                                        break;
                                    case '2':
                                        //Confirming that the user wants to borrow the books, and fills the books into a list instead of the stack and confirming all the books that the user has choosen.
                                        foreach (Book book in booksToBorrow)
                                        {
                                            booksBorrowed.Add(book);
                                        }
                                        Console.WriteLine("You have now borrowed the following books");
                                        Console.WriteLine($"{id,5}  {titleHeader,-50}       {authorHeader}");
                                        for (int j = 0; j < booksBorrowed.Count; j++)
                                        {
                                            Console.WriteLine($"{j + 1,5}  {books[j].Title,-50}  by:  {books[j].AuthorFirstname} {books[j].Authorlastname}");
                                        }
                                        Console.WriteLine("Press any key to exit:");
                                        run = false;
                                        Console.ReadKey();

                                        break;
                                    case '3':
                                        run = false;
                                        break;
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("You need to pick a number from the list");
                            }
                        }
                        else
                        {
                            //If there is no content in the list, then the user will be prompted and asked if he/she want to borrow the books in the basket.
                            Console.WriteLine("All the books are in your basket. There is nothing more here for you to see.");
                            Console.WriteLine("Press any key to confirm at you want to borrow the books in your basket");
                            Console.ReadKey();
                            foreach (Book book in booksToBorrow)
                            {
                                booksBorrowed.Add(book);
                            }
                            Console.WriteLine("You have now borrowed the following books");
                            Console.WriteLine($"{id,5}  {titleHeader,-50}       {authorHeader}");
                            for (int j = 0; j < booksBorrowed.Count; j++)
                            {
                                Console.WriteLine($"{j + 1,5}  {books[j].Title,-50}  by:  {books[j].AuthorFirstname} {books[j].Authorlastname}");
                            }

                            Console.WriteLine("Press any key to exit:");
                            Console.ReadKey();
                            run = false;
                        }
                    }
                    break;
                case '2':
                    break;
            }
        }
    }
}