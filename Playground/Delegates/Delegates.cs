using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Delegates
{
    public class Delegates
    {
        static void WorkPerformed1(int hours)
        {
            Console.WriteLine($"Work performed is { hours } Hours in method WorkPerformed 1");
        }

        static void WorkPerformed2(int hours)
        {
            Console.WriteLine($"Work performed is {hours} Hours in method WorkPerformed 2");
        }

        static void WorkPerformed3(int hours)
        {
            Console.WriteLine($"Work performed is {hours} Hours in method WorkPerformed 3");
        }

        WorkPerformedHandler handler = WorkPerformed1;

        // handler += WorkPerformed2;
    }
    
    // delegate is pipeline between the event and the event handlers

    public delegate void WorkPerformedHandler(int hours);

}
