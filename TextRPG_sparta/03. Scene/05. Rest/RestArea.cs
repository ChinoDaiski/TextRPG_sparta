using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_sparta
{
    public class RestAreaScene : IScene
    {
        public void Render()
        {
            Console.WriteLine(
                "휴식하기\n" +
                $"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {GameManager.Instance.mainPlayer.Gold} G)\n\n" +
                "1. 휴식하기\n" +
                "0. 나가기\n\n" +
                "원하시는 행동을 입력해주세요."
                );
        }
        public void Update()
        {
            int select;
            if (!int.TryParse(Console.ReadLine(), out select))
            {
                GameManager.Instance.PrintError();
                return;
            }

            switch (select)
            {
                case 0:
                    // town Scene으로 이동
                    GameManager.Instance.PopScene();
                    break;
                case 1:
                    if (GameManager.Instance.mainPlayer.Gold >= 500)
                    {
                        // 500 골드 감소
                        GameManager.Instance.mainPlayer.Gold -= 500;

                        // hp 100으로 변경
                        GameManager.Instance.mainPlayer.Rest();
                        Console.WriteLine("휴식을 완료했습니다.");
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다.");
                    }

                    Console.ReadKey();
                    break;
                default:
                    GameManager.Instance.PrintError();
                    break;
            }
        }
    }
}
