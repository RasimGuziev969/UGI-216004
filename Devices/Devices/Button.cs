using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    public class Button
    {
        IButttonManagedDevice device;

        public Button(IButttonManagedDevice device)
        {
            this.device = device;
        }

        public void Press() 
        { 
            if(device.IsActive)
                device.TurnOff();
            else
                device.TurnOn();
        }
    }
}
