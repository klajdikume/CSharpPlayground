using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding
{
    public interface IVendingMachine
    {
        public long selectItemAndGetPrice(Item item);
        public void insertCoin(Coin coin);
        public List<Coin> refund();
        public Bucket<Item, List<Coin>> collectItemAndChange();
        public void reset();
    }
}
