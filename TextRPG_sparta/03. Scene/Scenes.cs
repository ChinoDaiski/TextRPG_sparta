using System;
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
                HandleError.PrintError();
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
                HandleError.PrintError();
                return;
            }

            switch (select)
            {
                case 0:
                    // town Scene으로 이동
                    GameManager.Instance.PopScene();
                    break;
                default:
                    HandleError.PrintError();
                    break;
            }
        }

    }

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
                HandleError.PrintError();
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
                    HandleError.PrintError();
                    break;
            }
        }
    }

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
                HandleError.PrintError();
                return;
            }

            if(select == 0)
            {
                // town Scene으로 이동
                GameManager.Instance.PopScene();
            }
            else
            {
                if (!GameManager.Instance.mainPlayer.inventory.Equip(select))
                    HandleError.PrintError();
            }
        }
    }

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
                    GameManager.Instance.PopScene();
                    break;
                case 1:
                    // town Scene으로 이동
                    GameManager.Instance.PushScene(new StoreBuyScene());
                    break;
                default:
                    HandleError.PrintError();
                    break;
            }
        }
    }

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
                HandleError.PrintError();
                return;
            }

            if(select == 0)
            {
                // town Scene으로 이동
                GameManager.Instance.PopScene();
            }
            else
            {
                if (!GameManager.Instance.BuyItem(select))
                    HandleError.PrintError();
            }
        }
    }

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
                HandleError.PrintError();
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
                    HandleError.PrintError();
                    break;
            }
        }
    }

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
                HandleError.PrintError();
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
                    HandleError.PrintError();
                    break;
            }
        }
    }

    public class DungeonClearScene : IScene
    {
        Difficulty diff {  get; set; }
        int enemySTR {  get; set; }
        int reward {  get; set; }

        public DungeonClearScene(int difficulty)
        {
            diff = (Difficulty)(difficulty - 1);
            enemySTR = GameManager.Instance.dungeonData[diff].enemyStrength;
            reward = GameManager.Instance.dungeonData[diff].reward;
        }

        public void Render()
        {
            int hpBefore, hpAfter;
            GameManager.Instance.mainPlayer.GetDamaged(enemySTR, out hpBefore, out hpAfter);

            string Difficulty = "";
            switch (diff)
            {
                case TextRPG_sparta.Difficulty.Easy:
                    Difficulty = "쉬움";
                    break;
                case TextRPG_sparta.Difficulty.Medium:
                    Difficulty = "보통";
                    break;
                case TextRPG_sparta.Difficulty.Hard:
                    Difficulty = "어려움";
                    break;
                default:
                    break;
            }



            if (GameManager.Instance.mainPlayer.Dead)
            {
                int gold = GameManager.Instance.mainPlayer.Gold;
                GameManager.Instance.mainPlayer.Gold = GameManager.Instance.mainPlayer.Gold / 5 * 4;

                Console.WriteLine(
                    "던전 클리어 실패\n" +
                    Difficulty + "던전을 클리어하지 못했습니다.\n\n" +
                    "[탐험 결과]\n" +
                    $"체력 {hpBefore} -> {hpAfter}\n" +
                    $"Gold {gold} G -> {GameManager.Instance.mainPlayer.Gold} G \n\n" +
                    "0. 나가기\n\n" +
                    "원하시는 행동을 입력해주세요."
                    );
            }

            else
            {
                int gold = GameManager.Instance.mainPlayer.Gold;
                GameManager.Instance.mainPlayer.Gold += reward;
                Console.WriteLine(
                    "던전 클리어\n" +
                    "축하합니다!!\n" +
                    Difficulty + "던전을 클리어 하였습니다.\n\n" +
                    "[탐험 결과]\n" +
                    $"체력 {hpBefore} -> {hpAfter}\n" +
                    $"Gold {gold} G -> {GameManager.Instance.mainPlayer.Gold} G \n\n" +
                    "0. 나가기\n\n" +
                    "원하시는 행동을 입력해주세요."
                    );
            }
            
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
                    if (GameManager.Instance.mainPlayer.Dead)
                        GameManager.Instance.mainPlayer.Revive();

                    // 던전 입장 씬으로 돌아가기
                    GameManager.Instance.PopScene();
                    break;
                default:
                    HandleError.PrintError();
                    break;
            }
        }
    }
}