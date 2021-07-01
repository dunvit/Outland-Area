using System;
using System.Collections.Generic;
using System.Text;

namespace EngineCore.Session
{
    interface IStatus
    {
        bool IsPause { get; }

        void Resume();

        void Pause();
    }
}
