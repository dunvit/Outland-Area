using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlandArea.BL.Equipment
{
    public interface IModule
    {
        long Id { get; set; }
        string Name { get; set; }
        Category Category { get; set; }

        double ActivationCost { get; set; }
    }
}
