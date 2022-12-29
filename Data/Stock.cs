using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeService.Data
{
    public class Stock
    {
        private List<StockItem> _items;

        public Stock()
        {
            _items = new List<StockItem>();
        }

        public void AddItem(StockItem item)
        {
            _items.Add(item);
        }

        public void RemoveItem(StockItem item)
        {
            _items.Remove(item);
        }

        public List<StockItem> GetItems()
        {
            return _items;
        }

    }
}
