using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Models
{
    public class BusRoute
    {
        public int Number { get; set; }
        public string Origin { get; set; }
        public string Destination { get; }
        public BusRoute(int number, string origin, string destination)
        {
            this.Number = number;
            this.Origin = origin;
            this.Destination = destination;
        }
        public override string ToString() => $"{Number}: {Origin} -> {Destination}";
        
    }
}
