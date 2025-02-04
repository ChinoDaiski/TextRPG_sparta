using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_sparta
{
    public class StoreBuyScene : IScene
    {
        public void Render()
        {
            Console.WriteLine(
                      "상점\n" +
                      "구매할 아이템의 번호를 입력해주세요.\n\n" +
                      $"[보유 골드]\n{GameManager.Instance.mainPlayer.Gold} G\n\n" +
                      "[아이템 목록]"
                      );

            GameManager.Instance.ShowItemsBuying();

            Console.WriteLine(
                "\n0. 나가기\n\n" +
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

            if (select == 0)
            {
                // town Scene으로 이동
                GameManager.Instance.PopScene();
            }
            else
            {
                if (!GameManager.Instance.BuyItem(select))
                    GameManager.Instance.PrintError();
            }
        }
    }
}
