using System;
using System.Collections.Generic;

namespace OO_AssociationInClasses
{
    // Code reuse
    // Polymorphic behaviour
    
    public class PresentationObject
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public void Copy()
        {
            Console.WriteLine("Object copied to clipboard");
        }
        public void Duplicate()
        {
            Console.WriteLine("Object was duplicated");
        }
    }

    // Composition
    public class Logger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class DbMigrator
    {
        private readonly Logger logger;

        public DbMigrator(Logger logger)
        {
            this.logger = logger;
        }

        public void Migrate()
        {
            this.logger.Log("We are migrating abc...");
        }
    }

    public class Installer
    {
        private readonly Logger logger;

        public Installer(Logger logger)
        {
            this.logger = logger;
        }

        public void Install()
        {
            this.logger.Log("We are Installing the app...");
        }
    }

    public class Text : PresentationObject
    {
        public int FontSize { get; set; }
        public string FontName { get; set; }

        public void AddHyperLink(string url)
        {
            Console.WriteLine("We added a link to" + url);
        }
    }

    public class Customer
    {
        public int Id { get; set; }

        public void Promote()
        {
            var rating = CalculateRating(true);
            if (rating == 0)
                Console.WriteLine("Promoted Level 1");
            else
                Console.WriteLine("Promoted to Level 2");
        }
        public int CalculateRating(bool excludeOrders)
        {
            return 0;
        }
    }

    public class GoldCustomer : Customer
    {
        public void OfferVouchar()
        {
            var rating = this.CalculateRating(true);

        }
    }

    public class Vehicle
    {
        private readonly string _registrationNumber;
        public Vehicle()
        {
            Console.WriteLine("Vehicle is being initialized {0}", _registrationNumber);
        }

        public Vehicle(string registrationNumber)
        {
            _registrationNumber = registrationNumber;
        }
    }

    public class Car : Vehicle
    {
        public Car(string registrationNumber)
            : base(registrationNumber)
        {
            Console.WriteLine("Vehicle is being initialized, {0}", registrationNumber);
        }
    }

    public class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public void Draw()
        {
            
        }
    }

    public class TextShape : Shape
    {
        public int FontSize { get; set; }
        public int FontName { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var text = new Text();
            text.Width = 100;
            text.Copy();

            var dbMigrator = new DbMigrator(new Logger());

            var logger = new Logger();
            var installer = new Installer(logger);

            dbMigrator.Migrate();

            installer.Install();

            // inheritence or compozition

            var car = new Car("XYZ0123");

            // Upcasting
            TextShape textShape = new TextShape();
            Shape shape = new Shape();

            textShape.Width = 200;
            shape.Width = 100;

            Console.WriteLine(textShape.Width);

            Shape shape1 = new TextShape();
            TextShape textShape1 = (TextShape)shape1;

            //


        }
    }
}
