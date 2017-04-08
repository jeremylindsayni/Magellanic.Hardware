using Magellanic.Devices.Gpio.Core;
using System;

namespace Magellanic.Devices.Gpio.Abstractions
{
    public interface IGpioPin : IDisposable
    {
        void Write(GpioPinValue pinValue);

        void SetDriveMode(GpioPinDriveMode driveMode);
    }
}
