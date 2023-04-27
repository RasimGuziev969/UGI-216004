using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    public interface IButttonManagedDevice
    {
        bool IsActive { get; }
        void TurnOn();
        void TurnOff();
    }
}
