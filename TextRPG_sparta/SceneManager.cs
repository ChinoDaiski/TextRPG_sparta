using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_sparta
{
    internal class SceneManager
    {
        private static readonly SceneManager instance = new SceneManager();
        private SceneManager() { }
        public static SceneManager Instance { get { return instance; } }

        private Stack<IScene> scenes = new Stack<IScene>();
        
        public void PushScene(IScene scene) // 씬 추가
        {
            scenes.Push(scene);
        }
        public void PopScene()  // 마지막 씬 제거
        {
            if (scenes.Count > 0)
                scenes.Pop();
        }
        public void ClearScene()    // 모든 씬 제거
        {
            scenes.Clear();
        }

        public void ReplaceScene(IScene scene)
        {
            PopScene();
            PushScene(scene);
        }

        public void Progress()
        {
            while (scenes.Count > 0)
            {
                scenes.Peek().Render();
                scenes.Peek().Update();
            }
        }
    }
}
