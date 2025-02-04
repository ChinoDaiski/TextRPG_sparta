using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_sparta
{
    internal class Inventory
    {
        private List<Item> items = new List<Item>();
        public List<Item> Items
        {
            get { return items; }
        }

        public void AddItem(Item item)
        {
            if (items.Contains(item)) return;
            items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
            }
        }

        public bool Equip(int index)
        {
            if (0 < index && index <= items.Count)
            {
                items[index - 1].Equip();
                return true;
            }

            return false;
        }

        public void GetTotalEquippedStats(out int HP, out int STR, out int DEF)
        {
            HP = 0;
            STR = 0; 
            DEF = 0;

            foreach (Item item in items)
            {
                if(item.Equipment)
                {
                    HP += item.HP;
                    STR += item.STR;
                    DEF += item.DEF;
                }
            }
        }


        public void ShowInfo()
        {
            foreach (Item item in items)
            {
                if (item.Equipment)
                {
                    Console.WriteLine($"[E]" + item.GetInfo());
                }
                else
                {
                    Console.WriteLine(item.GetInfo());
                }
            }
        }
        public void ShowEquipmentInfo()
        {
            int index = 1;
            foreach (Item item in items)
            {
                if(item.Equipment)
                {
                    Console.WriteLine($"-{index} [E] " + item.GetInfo());
                }
                else
                {
                    Console.WriteLine($"-{index} " + item.GetInfo());
                }

                ++index;
            }
        }
    }
}
