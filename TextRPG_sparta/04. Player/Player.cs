using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_sparta
{
    enum JOB
    {
        WARRIOR = 0,
        WIZARD,
        ARCHER,
        END
    }

    internal class Player : IStat
    {
        private int level;
        private string? name;
        private JOB job;
        private int STR;
        private int DEF;
        private int HP;
        
        int IStat.HP { get => HP; set => HP = value; }
        int IStat.STR { get => STR; set => STR = value; }
        int IStat.DEF { get => DEF; set => DEF = value; }

        public int Gold { get; set; }

        public Inventory inventory { get; set; }

        public Player(string name, JOB job)
        {
            this.name = name;
            this.job = job;
            level = 1;
            Gold = 0;

            switch (job)
            {
                case JOB.WARRIOR:
                    STR = 10;
                    DEF = 10;
                    HP = 10;
                    break;
                case JOB.WIZARD:
                    STR = 10;
                    DEF = 10;
                    HP = 10;
                    break;
                case JOB.ARCHER:
                    STR = 10;
                    DEF = 10;
                    HP = 10;
                    break;
                case JOB.END:
                    break;
                default:
                    break;
            }

            inventory = new Inventory();
        }

        public void ShowInfo()
        {
            int itemHP = 0;
            int itemSTR = 0;
            int itemDEF = 0;

            inventory.GetTotalEquippedStats(out itemHP, out itemSTR, out itemDEF);

            Console.WriteLine(
                $"Lv. {level}      \n" +
                $"{name} ( {job} )\n" +
                $"공격력 : {STR} (+{itemSTR})\n" +
                $"방어력 : {DEF} (+{itemDEF})\n" +
                $"체 력 : {HP} (+{itemHP})\n" +
                $"Gold : {Gold} G\n"
                );
        }
    }
}
