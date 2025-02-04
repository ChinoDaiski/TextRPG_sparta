using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_sparta
{
    enum Difficulty
    {
        Easy = 0,
        Medium,
        Hard,
        END
    }

    internal class GameManager
    {
        private static readonly GameManager instance = new GameManager();
        private GameManager() { }
        public static GameManager Instance { get { return instance; } }

        // 씬 매니저 초기화
        private SceneManager sceneManager = new SceneManager();
        private Shop shop = new Shop();
        public Shop mainShop { get { return shop; } }


        public Player mainPlayer;

        // 던전 난이도 설정
        public Dictionary<Difficulty, (int enemyStrength, int reward)> dungeonData = new()
        {
            { Difficulty.Easy, (10, 500)},
            { Difficulty.Medium, (30, 1500)},
            { Difficulty.Hard, (50, 3000)}
        };

        //========================================================================
        // 게임 매니저 전용
        //========================================================================
        public void Run()
        {
            while (true)
            {
                sceneManager.Progress();
            }
        }




        //========================================================================
        // shop 관련
        //========================================================================
        public void AddItem(Item item)
        {
            shop.AddItem(item);
        }
        public void ShowItems()
        {
            shop.ShowItems();
        }
        public void ShowItemsBuying()
        {
            shop.ShowItemsBuying();
        }
        public bool BuyItem(int index)
        {
            return shop.BuyItem(ref mainPlayer, index);
        }
        public bool SellItem(int index)
        {
            return shop.SellItem(ref mainPlayer, index);
        }

        //========================================================================
        // 씬 매니저 관련
        //========================================================================
        public void PushScene(IScene scene)
        {
            sceneManager.PushScene(scene);
        }
        public void PopScene()
        {
            sceneManager.PopScene();
        }


        //========================================================================
        // 에러 메시지 관련
        //========================================================================

        public void PrintError()
        {
            Console.WriteLine("잘못된 입력입니다");
            Console.ReadKey();
        }
    }
}