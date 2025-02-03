﻿using System;
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

    internal class Player
    {
        private int level;
        private string? name;
        private JOB job;
        private int STR;
        private int DEF;
        private int HP;
        private int Gold;

        Player(string name, JOB job)
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
        }
    }
}
