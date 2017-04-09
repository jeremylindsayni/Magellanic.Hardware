using Magellanic.Devices.Gpio;
using Magellanic.Devices.Gpio.Core;
using System;

namespace GpioSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentNullException("You must specify a logic level for Pin 26");
            }
            else
            {
                if (args[0] != "1" && args[0] != "0")
                {
                    throw new ArgumentOutOfRangeException("Unknown logic level");
                }
            }
            
            int value = Convert.ToInt16(args[0]);
            
            // create gpio controller
            var controller = GpioController.Instance;

            // open pin
            var pin = controller.OpenPin(26);

            // set direction
            pin.SetDriveMode(GpioPinDriveMode.Output);

            // set value
            if (value == 1)
            {
                pin.Write(GpioPinValue.High);
            }
            else
            {
                pin.Write(GpioPinValue.Low);
            }
        }
    }
}