using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_sparta
{
    public class StoreScene : IScene
    {
        public void Render()
        {
            Console.WriteLine(
                "상점\n" +
                "필요한 아이템을 얻을 수 있는 상점입니다.\n\n" +
                $"[보유 골드]\n{GameManager.Instance.mainPlayer.Gold} G\n\n" +
                "[아이템 목록]"
                );

            GameManager.Instance.ShowItems();

            Console.WriteLine(
                "\n1. 아이템 구매\n" +
                "2. 아이템 판매\n" +
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
                    GameManager.Instance.PushScene(new StoreBuyScene());
                    break;
                case 2:
                    GameManager.Instance.PushScene(new StoreSellScene());
                    break;
                default:
                    GameManager.Instance.PrintError();
                    break;
            }
        }
    }
}
