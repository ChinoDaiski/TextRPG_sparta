using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_sparta
{
    public class DungeonClearScene : IScene
    {
        Difficulty diff { get; set; }
        int enemySTR { get; set; }
        int reward { get; set; }

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
                GameManager.Instance.PrintError();
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
                    GameManager.Instance.PrintError();
                    break;
            }
        }
    }
}
