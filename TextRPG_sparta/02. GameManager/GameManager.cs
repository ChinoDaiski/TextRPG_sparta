using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_sparta
{
    internal class GameManager
    {
        private static readonly GameManager instance = new GameManager();
        private GameManager() { }
        public static GameManager Instance { get { return instance; } }

        // 씬 매니저 초기화
        private SceneManager sceneManager = new SceneManager();
        private Shop shop = new Shop();


        public Player? mainPlayer { get; set; }

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
    }
}
