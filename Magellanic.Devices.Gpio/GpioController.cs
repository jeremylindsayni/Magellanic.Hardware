using System;
using Magellanic.Devices.Gpio.Abstractions;

namespace Magellanic.Devices.Gpio
{
    public class GpioController : IGpioController
    {
        private static string devicePath = "/sys/class/gpio/";

        public static string DevicePath
        {
            get
            {
                return devicePath;
            }
        }

        public static GpioController GetDefault()
        {
            // need to pull the device directory from environment variable

            // need to check that the device path exists

            throw new NotImplementedException();
        }

        public IGpioPin OpenPin(int pinNumber)
        {
            // add a file to the export directory with the name <<pin number>>
            // add folder under device path for "gpio<<pinNumber>>"
            // add two empty files to this folder called "direction" and "value"

            // instantiate the gpiopin object to return with the pin number.

            throw new NotImplementedException();
        }
    }
}
