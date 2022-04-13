using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.Generics
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }

    public class Nullable<T> where T : struct
    {
        private object _value;
        public Nullable(T value)
        {
            _value = value;
        }

        public bool HasValue
        {
            get { return _value != null; }
        }

        public T GetVAlueOrDefault()
        {
            if (HasValue)
                return (T) _value;

            return default(T);
        }
    }

    public class DiscountCalculator<TProduct>
        where TProduct : Product
    {
        public float CalculateDiscount(TProduct product)
        {
            return product.Price;
        }
    }
}
