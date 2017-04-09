using System;
using Magellanic.Devices.Gpio.Abstractions;
using Magellanic.Devices.Gpio.Core;
using System.Runtime.InteropServices;
using System.IO;

namespace Magellanic.Devices.Gpio
{
    public class GpioController : IGpioController
    {
        private static GpioController instance = new GpioController();

        public static IGpioController Instance
        {
            get
            {
                // need to pull the device directory from environment variable
                DevicePath = Environment.GetEnvironmentVariable("GPIO_DIR");

                // need to check that the device path exists
                if (string.IsNullOrEmpty(DevicePath))
                {
                    throw new NullReferenceException("There is no value for GPIO_DIR");
                }

                return instance;
            }
        }

        public static string DevicePath { get; private set; }

        public IGpioPin OpenPin(int pinNumber)
        {
            if (pinNumber < 1 || pinNumber > 26)
            {
                throw new ArgumentOutOfRangeException("Valie pins are between 1 and 26.");
            }
            // add a file to the export directory with the name <<pin number>>
            // add folder under device path for "gpio<<pinNumber>>"
            // add two empty files to this folder called "direction" and "value"

            // instantiate the gpiopin object to return with the pin number.
            var gpioDirectoryPath = Path.Combine(DevicePath, "gpio", pinNumber.ToString());

            var gpioExportPath = Path.Combine(DevicePath, "export");

            var osNameAndVersion = RuntimeInformation.OSDescription;

            if (!Directory.Exists(gpioDirectoryPath))
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    // create the directory, and files
                    Directory.CreateDirectory(gpioDirectoryPath);
                    File.Create(Path.Combine(gpioDirectoryPath, "direction"));
                    File.Create(Path.Combine(gpioDirectoryPath, "value"));
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                    && osNameAndVersion.Contains("Ubuntu")
                    && osNameAndVersion.Contains("16.04"))
                {
                    File.WriteAllText(gpioExportPath, pinNumber.ToString());
                }
                else
                {
                    throw new NotSupportedException("This is an unsupported OS");
                }
            }

            return new GpioPin(pinNumber, gpioDirectoryPath);
        }
    }
}
