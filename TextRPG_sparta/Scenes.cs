using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_sparta
{
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
                Console.WriteLine("잘못된 입력입니다");
                Console.ReadKey();
            }

            switch (select)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }

            Console.Clear();
        }

    }

}