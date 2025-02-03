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
