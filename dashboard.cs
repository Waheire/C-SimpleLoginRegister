
using login_Registration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login_Registration
{
    public class Dashboard
    {
        public List<Book> Books = new List<Book>();
        private string _filePath;

        //add a book
        public void addBook() 
        {
            Console.WriteLine("===== Add Book =====");
            Console.Write("Enter Book Title: ");
            string bookTitle = Console.ReadLine();
            Console.Write("Enter Book Description: ");
            string bookDescription = Console.ReadLine();
            Console.Write("Enter Book Author: ");
            string BookAuthor = Console.ReadLine();


            Book newBook = new Book(bookTitle, bookDescription, BookAuthor);

            //check if file exists 
            if (File.Exists(_filePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(_filePath);

                    foreach (var line in lines)
                    {
                        string[] parts = line.Split(':');
                        if (parts.Length == 4)
                        {
                            string storedId = parts[0].Trim();
                            string storedTitle = parts[1].Trim();
                            string storedDescription = parts[2].Trim();
                            string storedAuthor = parts[3].Trim();
                            Books.Add(new Book(
                                storedTitle,
                                storedDescription,
                                storedAuthor
                                ));
                            //check if book exists
                            if (Books.FirstOrDefault().bookId == storedId) { 

                            }
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error reading from file: {ex.Message}");
                }
            }

            //save book information 
            Books.Add(newBook);
            saveBook();

            Console.WriteLine("Book Registered successfully!");
        }

        private void saveBook()
        {
            try
            {
                List<string> userLines = new List<string>();

                foreach (var book in Books)
                {
                    userLines.Add($"{book.bookId}:{book.Title}:{book.Description}:{book.Author}");
                }
                File.WriteAllLines(_filePath, userLines);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

        //show books




    }
}
