using Playground.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Playground
{

    public class Customer
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public List<Order> Orders = new List<Order>();

        public Customer(int id)
        {
            this.Id = id;
        }
        public Customer(int id, string name) : this (id)
        {
            this.Name = name;
        }

        public void Promote()
        {

            // ...
        }

    }
   
    public class Order
    {
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Signature of Methods
            // Method Overloading
            // Params modifier
            // Ref modifier
            // Out modifier

            var customer = new Customer(1);
            customer.Orders.Add(new Order());
            customer.Orders.Add(new Order());

            var point = new Point(10, 20);
            point.Move(new Point(40, 60));
            Console.WriteLine("Points is at ({0},{1})", point.X, point.Y);

            var person = new Person(new DateTime(1992, 1, 1));

            var cookie = new HttpCookie();
            cookie["name"] = "Mosh";
            Console.WriteLine(cookie["name"]);
        }
    }

    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Move(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Move(Point newLocation)
        {
            this.X = newLocation.X;
            this.Y = newLocation.Y;
        }
    }

    public class Calculator
    {
        public int Add(params int[] numbers) {
            return 1;
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public DateTime Birthdate { get; private set; }

        public Person(DateTime birthdate)
        {
            this.Birthdate = birthdate;
        }
        
        public int Age
        {
            // based on birthdate
            get
            {
                var timespan = DateTime.Now - Birthdate;
                var years = timespan.Days / 365;

                return years;
            }
        }

        //public DateTime Birthdate
        //{
        //    get { return _birthdate; }
        //    set { _birthdate = value; }
        //}
    }

    public class HttpCookie
    {
        public readonly Dictionary<string, string> _dictionary;

        public HttpCookie()
        {
            _dictionary = new Dictionary<string, string>();
        }

        public string this[string key]
        {
            get 
            {
                return _dictionary[key];
            }
            set 
            {
                _dictionary[key] = value;
            }
        }
    }
}
