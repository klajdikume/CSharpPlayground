using Playground.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Playground
{
    public delegate string WriteLogDelegate(string logMessage);
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class TypeTests 
    {
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;

            log += ReturnMessage;

            var result = log("Hello");
            Assert.Equal("Hello", result);
        }

        string ReturnMessage(string message)
        {
            return message;
        }
    }

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

    public class Snake
    {
        private int width, height;
        private Queue<(int, int)> food;
        private LinkedList<(int, int)> snake;
        private HashSet<(int, int)> snakeSet;
        private Dictionary<string, (int, int)> directions;
        private int score;

        public Snake(int width, int height, int[][] food)
        {
            this.width = width;
            this.height = height;
            this.food = new Queue<(int, int)>();
            foreach (var f in food)
            {
                this.food.Enqueue((f[0], f[1]));
            }

            this.snake = new LinkedList<(int, int)>();
            this.snake.AddFirst((0, 0));
            this.snakeSet = new HashSet<(int, int)>() { (0,0) };

            this.directions = new Dictionary<string, (int, int)>
            {
                { "U", (-1, 0) },
                { "D", (1, 0) },
                { "L", (0, -1) },
                { "R", (0, 1) },
            };

            this.score = 0;
        }

        public int Move(string direction)
        {
            if (!directions.ContainsKey(direction))
            {
                throw new ArgumentException($"Invalid direction: {direction}");
            }

            var (dx, dy) = directions[direction];
            var (headX, headY) = snake.First.Value;
            var newHead = (headX + dx, headY + dy);

            if (IsOutOfBounds(newHead))
            {
                return -1;
            }

            if(snakeSet.Contains(newHead) && !newHead.Equals(snake.Last.Value))
            {
                return -1;
            }

            snake.AddFirst(newHead);
            snakeSet.Add(newHead);

            if (food.Count > 0 && newHead.Equals(food.Peek()))
            {
                food.Dequeue();
                score++;
            }
            else
            {
                var tail = snake.Last.Value;
                snake.RemoveLast();
                snakeSet.Remove(tail);
            }

            return score;
        }
        private bool IsOutOfBounds((int x, int y) position)
        {
            return position.x < 0 || position.x >= height || position.y < 0 || position.y >= width;
        }
    }


    // input s = "abcabcbb"

    

    class Program
    {
        private static int LengthOfTheLongestSubstring(string line)
        {
            int l = 0;
            int maxLength = 0;

            HashSet<int> substringChars = new HashSet<int>();

            for(int r = 0; r < line.Length; r++)
            {
                while (substringChars.Contains(line[r]))
                {
                    line.Remove(line[l]);
                    l += 1;
                }
                maxLength = Math.Max(maxLength, (r - l) + 1);
                substringChars.Add(line[r]);
            }

            return maxLength;
        }

        static void Main(string[] args)
        {
            // Signature of Methods
            // Method Overloading
            // Params modifier
            // Ref modifier
            // Out modifier

            //
         
            Console.WriteLine(LengthOfTheLongestSubstring("abcabcbb"));

            /*
            int[][] food = new int[][]
            {
                new int[] { 1, 2},
                new int[] { 0, 1},
            };

            var game = new Snake(3, 3, food);

            Console.WriteLine(game.Move("R")); // 0
            Console.WriteLine(game.Move("D")); // 0
            Console.WriteLine(game.Move("R")); // 1 (Food eaten)
            Console.WriteLine(game.Move("U")); // 1
            Console.WriteLine(game.Move("L")); // 2 (Food eaten)
            Console.WriteLine(game.Move("U")); // -1 (Game over: collision)

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

            */

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
