namespace TextRPG_sparta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //==============================================================================================================================
            // 게임 관련 초기화 작업
            //==============================================================================================================================
            GameManager.Instance.PushScene(new TownScene());    // 마을 생성
            GameManager.Instance.mainPlayer = new Player("성욱", JOB.WARRIOR);    // 플레이어 초기화

            // 상점에 아이템 추가
            GameManager.Instance.AddItem(new Item("수련자 갑옷     ", 1000, "수련에 도움을 주는 갑옷입니다.", 0, 0, 5));
            GameManager.Instance.AddItem(new Item("무쇠갑옷        ", 2000, "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 0, 9));
            GameManager.Instance.AddItem(new Item("스파르타의 갑옷 ", 3500, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 0, 0, 15));
            GameManager.Instance.AddItem(new Item("낡은 검         ", 600, "쉽게 볼 수 있는 낡은 검입니다.", 0, 2, 0));
            GameManager.Instance.AddItem(new Item("청동 도끼       ", 1500, "어디선가 사용됐던 거 같은 도끼입니다.", 0, 5, 0));
            GameManager.Instance.AddItem(new Item("스파르타의 창   ", 3000, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 0, 7, 0));


            // 게임 시작
            GameManager.Instance.Run();
        }
    }
}
