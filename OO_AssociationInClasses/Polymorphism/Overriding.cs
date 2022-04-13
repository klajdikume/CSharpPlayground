using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_AssociationInClasses.Polymorphism
{
    public class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Position { get; set; }

        public virtual void Draw()
        {

        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw a circle");
        }
    }
    public class Retangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw a rectangle");
        }
    }

    public class Canvas
    {
        public void DrawShapes(List<Shape> shapes)
        {
            foreach(var shape in shapes)
            {
                shape.Draw();
            }
        }
    }

    public class Overriding
    {

    }
}
