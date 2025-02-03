namespace TextRPG_sparta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SceneManager.Instance.PushScene(new TownScene());
            SceneManager.Instance.Progress();
        }
    }
}
