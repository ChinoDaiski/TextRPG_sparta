using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_sparta
{
    public class InventroyScene : IScene
    {
        public void Render()
        {
            Console.WriteLine(
                "인벤토리\n" +
                "보유 중인 아이템을 관리할 수 있습니다.\n\n" +
                "[아이템 목록]\n"
                );

            GameManager.Instance.mainPlayer.inventory.ShowInfo();

            Console.WriteLine(
                "\n1. 장착 관리\n" +
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
                    // Equipment Scene으로 이동
                    GameManager.Instance.PushScene(new EquipmentScene());
                    break;
                default:
                    GameManager.Instance.PrintError();
                    break;
            }
        }
    }
}
