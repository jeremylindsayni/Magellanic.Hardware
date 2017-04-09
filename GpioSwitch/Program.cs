using Magellanic.Devices.Gpio;
using Magellanic.Devices.Gpio.Core;
using System;

namespace GpioSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Starting...");
            
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

            Console.WriteLine("Hoping to switch light to status = " + args[0]);

            // create gpio controller
            Console.WriteLine("About to instantiate the switch controller");
            var controller = GpioController.Instance;

            // open pin
            Console.WriteLine("Opening pin 26");
            var pin = controller.OpenPin(26);

            // set direction
            Console.WriteLine("Setting the direction to out");
            pin.SetDriveMode(GpioPinDriveMode.Output);

            // set value
            if (value == 1)
            {
                Console.WriteLine("Setting the value to high");
                pin.Write(GpioPinValue.High);
            }
            else
            {
                Console.WriteLine("Setting the value to low");
                pin.Write(GpioPinValue.Low);
            }
        }
    }
}