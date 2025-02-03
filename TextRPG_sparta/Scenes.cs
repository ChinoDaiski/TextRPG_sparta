﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_sparta
{
    static class HandleError
    {
        public static void PrintError()
        {
            Console.WriteLine("잘못된 입력입니다");
            Console.ReadKey();
        }
    }

    public class TownScene : IScene
    {
        public void Render()
        {
            Console.WriteLine(
                "스파르타 마을에 오신 여러분 환영합니다.\n" +
                "이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n\n" +
                "1. 상태 보기\n" +
                "2. 인벤토리\n" +
                "3. 상점\n\n" +
                "원하시는 행동을 입력해주세요.");
        }

        public void Update()
        {
            int select;
            if (!int.TryParse(Console.ReadLine(), out select))
            {
                HandleError.PrintError();
                return;
            }

            switch (select)
            {
                case 1:
                    SceneManager.Instance.PushScene(new StatusScene());
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    HandleError.PrintError();
                    break;
            }
        }

    }
    public class StatusScene : IScene
    {
        public void Render()
        {
            Console.WriteLine(
                "상태 보기\n" +
                "캐릭터의 정보가 표시됩니다.\n\n" +
                "Lv. 01      \n" +
                "Chad ( 전사 )\n" +
                "공격력 : 10\n" +
                "방어력 : 5\n" +
                "체 력 : 100\n" +
                "Gold : 1500 G\n\n" +
                "0. 나가기\n\n" +
                "원하시는 행동을 입력해주세요."
                );
        }

        public void Update()
        {
            int select;
            if (!int.TryParse(Console.ReadLine(), out select))
            {
                HandleError.PrintError();
                return;
            }

            switch (select)
            {
                case 0:
                    // town Scene으로 이동
                    SceneManager.Instance.PopScene();
                    break;
                default:
                    HandleError.PrintError();
                    break;
            }
        }

    }
}