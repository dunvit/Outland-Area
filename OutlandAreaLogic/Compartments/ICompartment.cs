using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlandAreaLogic.Compartments
{
    public interface ICompartment
    {
        string Name { get; set; }

        void Activate();
    }
}
