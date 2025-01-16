using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace coding
{
    internal class Inventory<T>
    {
        private readonly Dictionary<T, int> inventory = new Dictionary<T, int>();

        public int GetQuantity(T item)
        {
            bool value = inventory.TryGetValue(item, out int quantity);
            return quantity;
        }

        public void Add(T item)
        {
            int count = inventory.GetValueOrDefault(item);
            inventory.Add(item, count + 1);
        }

        public void Deduct(T item)
        {
            if (HasItem(item))
            {
                int count = inventory.GetValueOrDefault(item);
                inventory.Add(item, count - 1);
            }
        }

        public bool HasItem(T item)
        {
            return GetQuantity(item) > 0;
        }

        public void Clear()
        {
            inventory.Clear();
        }

        public void Add(T item, int quantity)
        {
            inventory.Add(item, quantity);
        }
    }
}
