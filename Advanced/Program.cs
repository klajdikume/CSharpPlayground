using Advanced.Delegates;
using Advanced.EventDelegate;
using Advanced.Generics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advanced
{
    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book(){Name = "ABC", Price = 2},
                new Book(){Name = "ABC", Price = 2},
                new Book(){Name = "ABC", Price = 2},
                new Book(){Name = "ABC", Price = 2},
            };
        }
    }

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

            //var number = new Generics.Nullable<int>(6);
            //Console.WriteLine(number.HasValue);
            //Console.WriteLine(number.GetVAlueOrDefault());

            //var processor = new PhotoProcessor();
            //var filters = new PhotoFilters();
            //PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            //filterHandler += filters.ApplyContrast;
            //filterHandler += RemoveRedEyeFilter;

            //processor.Process("photo.jpg", filterHandler);


            Func<int, int> square = number => number * number;

            var video = new Video() { Name = "Video1" };
            var videoEncoder = new VideoEncoder(); // publisher
            var mailSErvice = new MailService(); // subscriber
            var messageService = new MessageService(); // subscriber

            videoEncoder.VideoEncoded += mailSErvice.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;


            videoEncoder.Encode(video);

            string post = "A long textg";
            var shortenedPost = post.Shorten(5);


            var books = new BookRepository().GetBooks();

            var cheaperBooks =
                from b in books
                where b.Price < 10
                orderby b.Name
                select b.Name;

            var cheaperBooks1 = books.Where(b => b.Price < 10).OrderBy(b => b.Name).Select(b => b.Name);

            int i = 5;
            dynamic d = i;
            string l = d;
            
            //object obj = "Mosh";

            //var methodInfo = obj.GetType().GetMethod("GetHashCode");
            //methodInfo.Invoke(null, null);

            //dynamic excelObject = "mosh";
            //excelObject.Optimize();
        }

        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Apply RemoveRedEye");
        }
        
    }

   

    public static class StringExtensions
    {
        public static string Shorten(this String str, int numberOfWords)
        {
            if (numberOfWords < 0)
                throw new ArgumentOutOfRangeException("numberOfWords should be greater than zero");

            if (numberOfWords == 0)
                return "";

            var words = str.Split(' ');

            if (words.Length <= numberOfWords)
                return str;

            return string.Join("", words.Take(numberOfWords));
        }
    }
    public class MessageService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("MessageService: Sending a text message..." + e.Video.Name);
        }
    }

    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("MailService: Sending an email..." + e.Video.Name);
        }
    }

}
