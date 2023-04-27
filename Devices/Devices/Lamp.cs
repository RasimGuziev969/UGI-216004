using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    public class Lamp : IButttonManagedDevice
    {
        public bool IsActive { get; private set; }

        public void TurnOn()
        {
            if(!IsActive)
                IsActive = true;
        }

        public void TurnOff() 
        {
            if(IsActive)
                IsActive = false;
        }
    }
}
