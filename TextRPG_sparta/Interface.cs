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
}
