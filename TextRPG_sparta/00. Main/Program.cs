namespace TextRPG_sparta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //==============================================================================================================================
            // 게임 관련 초기화 작업
            //==============================================================================================================================
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            GameManager.Instance.PushScene(new TownScene());    // 마을 생성


            // SaveData 파일이 존재한다면, 이전에 했던 데이터가 남아 있다는 의미
            if (SaveLoadManager.FileExists($"SaveData"))
            {
                // 1. 플레이어 스탯 정보 불러오기
                var loadedPlayer = SaveLoadManager.Load<Player>("Player");
                if (loadedPlayer != null)
                {
                    GameManager.Instance.mainPlayer = loadedPlayer;
                    Console.WriteLine("플레이어 정보 불러오기 완료!");
                }
                else
                {
                    Console.WriteLine("저장된 플레이어 데이터가 없습니다.");
                }

                // 2. 플레이어 인벤토리 불러오기
                var loadedInventory = SaveLoadManager.Load<List<Item>>("Inventory");
                if (loadedInventory != null)
                {
                    GameManager.Instance.mainPlayer.inventory.Items = loadedInventory;
                    Console.WriteLine("플레이어 인벤토리 불러오기 완료!");
                }
                else
                {
                    Console.WriteLine("저장된 인벤토리가 없습니다.");
                }

                // 3. 상점 아이템 불러오기
                var loadedShopItems = SaveLoadManager.Load<List<Item>>("Shop");
                if (loadedShopItems != null)
                {
                    GameManager.Instance.mainShop.ItemsForSale = loadedShopItems;
                    Console.WriteLine("상점 아이템 불러오기 완료!");
                }
                else
                {
                    Console.WriteLine("저장된 상점 아이템이 없습니다.");
                }
            }
            else
            {
                GameManager.Instance.mainPlayer = new Player("성욱", JOB.WARRIOR);    // 플레이어 초기화
                GameManager.Instance.mainPlayer.Gold += 100000;

                // 상점에 아이템 추가
                GameManager.Instance.AddItem(new Item("수련자 갑옷     ", 1000, "수련에 도움을 주는 갑옷입니다.", 0, 0, 5));
                GameManager.Instance.AddItem(new Item("무쇠갑옷        ", 2000, "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 0, 9));
                GameManager.Instance.AddItem(new Item("스파르타의 갑옷 ", 3500, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 0, 0, 15));
                GameManager.Instance.AddItem(new Item("낡은 검         ", 600, "쉽게 볼 수 있는 낡은 검입니다.", 0, 2, 0));
                GameManager.Instance.AddItem(new Item("청동 도끼       ", 1500, "어디선가 사용됐던 거 같은 도끼입니다.", 0, 5, 0));
                GameManager.Instance.AddItem(new Item("스파르타의 창   ", 3000, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 0, 7, 0));

                // 던전 난이도 추가 -> 현재 이 부분은 게임 매니저에서 관리 중 
            }

            // 게임 시작
            GameManager.Instance.Run();
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            try
            {
                Console.Clear();

                // 데이터를 저장하는 로직
                Console.WriteLine("프로세스 종료 전에 데이터 저장...\n");



                // 플레이어 인벤토리
                SaveLoadManager.Save(GameManager.Instance.mainPlayer.inventory.Items, "Inventory");

                // 상점 아이템
                SaveLoadManager.Save(GameManager.Instance.mainShop.ItemsForSale, "Shop");

                // 플레이어 스탯 정보
                SaveLoadManager.Save(GameManager.Instance.mainPlayer, "Player");

                // 플레이어 스탯 정보
                bool bSave = true;
                SaveLoadManager.Save(bSave, "SaveData");



                Console.WriteLine("\n프로세스 종료 전에 데이터 완료!");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("데이터 저장 중 예외 발생: " + ex.Message);
                Console.ReadKey();
            }
        }
    }
}
