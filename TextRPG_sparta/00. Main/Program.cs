namespace TextRPG_sparta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 게임 관련 초기화 작업
            GameManager.Instance.PushScene(new TownScene());
            GameManager.Instance.mainPlayer = new Player("성욱", JOB.WARRIOR);

            // 게임 시작
            GameManager.Instance.Run();
        }
    }
}
