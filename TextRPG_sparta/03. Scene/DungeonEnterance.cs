using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_sparta
{
    public class DungeonEnteranceScene : IScene
    {
        public void Render()
        {
            Console.WriteLine(
                "던전입장\n" +
                "이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n\n" +
                "1. 쉬운 던전     | 방어력 5 이상 권장\n" +
                "2. 일반 던전     | 방어력 11 이상 권장\n" +
                "3. 어려운 던전    | 방어력 17 이상 권장\n" +
                "0. 나가기\n\n" +
                "원하시는 행동을 입력해주세요.\n"
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
                case 2:
                case 3:
                    GameManager.Instance.PushScene(new DungeonClearScene(select));
                    break;
                default:
                    GameManager.Instance.PrintError();
                    break;
            }
        }
    }
}
