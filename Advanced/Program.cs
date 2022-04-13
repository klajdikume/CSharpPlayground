using Advanced.Delegates;
using Advanced.Generics;
using System;
using System.Collections.Generic;

namespace Advanced
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var book = new Book { Isbn = "1234" };

            //var numbers = new List();
            //numbers.Add(10);

            //var books = new BookList();
            //books.Add(book);

            //var numbers = new GenericList<int>();
            //numbers.Add(10);

            //var books = new GenericList<Book>();
            //books.Add(new Book());

            //var dictionary = new GenericDictionary<string, Book>();
            //dictionary.Add("1234", new Book());

            var number = new Generics.Nullable<int>(6);
            Console.WriteLine(number.HasValue);
            Console.WriteLine(number.GetVAlueOrDefault());

            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();
            PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;

            processor.Process("photo.jpg", filterHandler);

        }

        static void RemoveRedEyeFilter(Photo photo)
        {

        }
    }
}
