using System;

namespace library_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book();
            book1.SetAuthor("J.K. Rowling");
            book1.SetTitle("Harry Potter and the Philosopher's Stone");


            Console.WriteLine(book1.GetBookInfo());

            Picturebook book2 = new Picturebook();
            book2.SetAuthor("Dr. Seuss");
            book2.SetTitle("The Cat in the Hat");
            book2.SetIllustrator("Dr. Seuss");

            Console.WriteLine(book2.GetPictureBookInfo());
        }
    }
}