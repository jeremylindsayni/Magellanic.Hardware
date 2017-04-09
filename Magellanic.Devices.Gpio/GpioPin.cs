using Magellanic.Devices.Gpio.Core;
using Magellanic.Devices.Gpio.Abstractions;
using System;
using System.IO;

namespace Magellanic.Devices.Gpio
{
    public class GpioPin : IGpioPin, IDisposable
    {
        public int PinNumber { get; private set; }

        public string GpioPath { get; private set; }

        public GpioPin(int pinNumber, string gpioPath)
        {
            this.PinNumber = pinNumber;
            this.GpioPath = gpioPath;
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
            if (File.Exists(Path.Combine(this.GpioPath, "direction")))
            {
                File.WriteAllText(Path.Combine(this.GpioPath, "direction"), "out");
            }
            else
            {
                throw new FileNotFoundException("No direction file found");
            }
        }

        public void Write(GpioPinValue pinValue)
        {
            //var path = GpioController.DevicePath;
            // write a 1 or a 0 to the "value" file for this pin
            if (File.Exists(Path.Combine(this.GpioPath, "value")))
            {
                File.WriteAllText(Path.Combine(this.GpioPath, "value"), ((int)pinValue).ToString());
            }
            else
            {
                throw new FileNotFoundException("No value file found");
            }
        }
    }
}
