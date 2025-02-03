namespace TextRPG_sparta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SceneManager sceneManager = new SceneManager();
            sceneManager.PushScene(new TownScene());
            sceneManager.Progress();
        }
    }
}
