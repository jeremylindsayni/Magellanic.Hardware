using Magellanic.Devices.Gpio.Core;
using Magellanic.Devices.Gpio.Abstractions;
using System;

namespace Magellanic.Devices.Gpio
{
    public class GpioPin : IGpioPin, IDisposable
    {
        public int PinNumber { get; private set; }

        public GpioPin(int pinNumber)
        {
            this.PinNumber = pinNumber;
        }

        public void Dispose()
        {
            // equivalent to unexport
            // write a file with the pin name to the unexport folder
            // delete files and folders from the device path
            throw new NotImplementedException();
        }

        public void SetDriveMode(GpioPinDriveMode driveMode)
        {
            //var path = GpioController.DevicePath;
            // write in or out to the "direction" file for this pin.
            throw new NotImplementedException();
        }

        public void Write(GpioPinValue pinValue)
        {
            //var path = GpioController.DevicePath;
            // write a 1 or a 0 to the "value" file for this pin
            throw new NotImplementedException();
        }
    }
}
