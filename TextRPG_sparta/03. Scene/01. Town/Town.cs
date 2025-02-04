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
                "3. 상점\n" +
                "4. 휴식\n" +
                "5. 던전입장\n\n" +
                "원하시는 행동을 입력해주세요.");
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
                case 1:
                    GameManager.Instance.PushScene(new StatusScene());
                    break;
                case 2:
                    GameManager.Instance.PushScene(new InventroyScene());
                    break;
                case 3:
                    GameManager.Instance.PushScene(new StoreScene());
                    break;
                case 4:
                    GameManager.Instance.PushScene(new RestAreaScene());
                    break;
                case 5:
                    GameManager.Instance.PushScene(new DungeonEnteranceScene());
                    break;
                default:
                    GameManager.Instance.PrintError();
                    break;
            }
        }

    }
}
