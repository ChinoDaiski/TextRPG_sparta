using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_sparta
{
    public interface IScene
    {
        void Render();  // 씬의 내용을 그리는 역할
        void Update();  // 게임 로직 관련

    }

    public interface IEquiptable
    {
        void Equip();
        string ShowInfo(); // 무기 정보 출력
    }
    public interface IStat
    {
        int HP { get; set; }      // 체력
        int STR { get; set; }    // 공격력
        int DEF { get; set; }     // 방어력
    }
}
