using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_sparta
{
    public class StatusScene : IScene
    {
        public void Render()
        {
            Console.WriteLine(
                "상태 보기\n" +
                "캐릭터의 정보가 표시됩니다.\n\n"
                );

            if (GameManager.Instance.mainPlayer != null)
                GameManager.Instance.mainPlayer.ShowInfo();

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

            switch (select)
            {
                case 0:
                    // town Scene으로 이동
                    GameManager.Instance.PopScene();
                    break;
                default:
                    GameManager.Instance.PrintError();
                    break;
            }
        }

    }
}
