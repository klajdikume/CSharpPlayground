using System;

namespace Playground.Interview
{
    
    public abstract class Shape
    {
        private readonly Point _position;
        protected Shape(Point position)
        {
            _position = position;
        }

        public Point Position => _position;

        public abstract double Area();

        public string AsString()
        {
            return $"{GetType().Name}: ({_position.X}, {_position.Y})";
        }
    }

    public class Square : Shape
    {
        private readonly int _width;
        private readonly int _height;

        public Square(Point position, int width, int height) : base(position)
        {
            _width = width;
            _height = height;
        }

        public override double Area()
        {
            return _width * _height;
        }
    }

    public class Circle : Shape
    {
        private readonly int _radius;

        public Circle(Point position, int radius) : base(position)
        {
            _radius = radius;
        }

        public override double Area()
        {
            return _radius * _radius * Math.PI;
        }
    }
}
