using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding
{
    public class VendingMachine : IVendingMachine
    {
        private Inventory<Coin> cashInventory = new Inventory<Coin>();
        private Inventory<Item> itemInventory = new Inventory<Item>();
        private long totalSales;
        private Item currentItem;
        private long currentBalance;

        public VendingMachine()
        {
            initialize();
        }

        private void initialize()
        {
            //initialize machine with 5 coins of each denomination
            //and 5 cans of each Item       
            //for (Coin c : Coin.values())
            //{
            //    cashInventory.put(c, 5);
            //}

            //for (Item i : Item.values())
            //{
            //    itemInventory.put(i, 5);
            //}

        }

        public Bucket<Item, List<Coin>> collectItemAndChange()
        {
            throw new NotImplementedException();
        }

        public void insertCoin(Coin coin)
        {
            throw new NotImplementedException();
        }

        public List<Coin> refund()
        {
            throw new NotImplementedException();
        }

        public void reset()
        {
            throw new NotImplementedException();
        }

        public long selectItemAndGetPrice(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
