using System;
using System.Collections.Generic;
using System.Text;

namespace EngineCore.Session
{
    public class OuterSpace
    {
        public event Action<int> OnEndTurn;

        public void Refresh(GameSession gameSession, System.Drawing.PointF coordinates)
        {
            throw new NotImplementedException();
        }
    }
}
