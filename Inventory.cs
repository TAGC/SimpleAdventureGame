using System.Collections.Generic;
using System.Linq;

namespace experiment
{
    public class Inventory
    {
        private readonly ISet<string> _items;

        public Inventory()
        {
            _items = new HashSet<string>();
        }

        public IEnumerable<string> Items => _items.ToList();

        public void StoreItem(string item) => _items.Add(item);

        public void RemoveItem(string item) => _items.Remove(item);
    }
}