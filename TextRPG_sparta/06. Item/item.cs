using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_sparta
{
    internal class Item : IEquiptable, IStat
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Info { get; set; }

        private bool bEquipment = false;


        public int HP { get; set; }
        public int STR { get; set; }
        public int DEF { get; set; }


        public Item(string name, int price, string info, int HP, int STR, int DEF)
        {
            Name = name;
            Price = price;
            Info = info;

            this.HP = HP;
            this.STR = STR;
            this.DEF = DEF;
        }

        public void Equip()
        {
            bEquipment = !bEquipment;
        }

        public string ShowInfo()
        {
            string info = $"{Name} |\t";

            if (HP != 0)
            {
                info += $"체력 +{HP} |\t";
            }
            if (STR != 0)
            {
                info += $"공격력 +{STR} |\t";
            }
            if (DEF != 0)
            {
                info += $"방어력 +{DEF} |\t";
            }

            info += Info;

            return info;
        }
    }
}
