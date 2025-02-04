using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_sparta
{
    public class EquipmentScene : IScene
    {
        public void Render()
        {
            Console.WriteLine(
                "인벤토리 - 장착 관리\n" +
                "보유 중인 아이템을 장착할 수 있습니다. \n장착을 원하시는 아이템의 번호를 선택하세요.\n\n" +
                "[아이템 목록]\n"
                );

            GameManager.Instance.mainPlayer.inventory.ShowEquipmentInfo();


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
                if (!GameManager.Instance.mainPlayer.inventory.Equip(select))
                    GameManager.Instance.PrintError();
            }
        }
    }
}
