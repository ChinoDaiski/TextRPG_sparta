using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_sparta
{
    internal class Inventory
    {
        private List<IEquiptable> items = new List<IEquiptable>();

        public void AddItem(IEquiptable item)
        {
            if (items.Contains(item)) return;
            items.Add(item);
        }

        public void RemoveItem(IEquiptable item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
            }
        }

        public void ShowInfo()
        {
            foreach (IEquiptable item in items)
            {
                item.ShowInfo();
            }
        }
    }
}
