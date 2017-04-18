using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace Magellanic.Devices.Gpio
{
    public class Bifröst
    {
        public static void BifröstDiagnostics()
        {
            var osNameAndVersion = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            Console.WriteLine(osNameAndVersion);
            // Linux 4.4.0-1009-raspi2 #10-Ubuntu SMP Tue Apr 19 19:51:04 UTC 2016
            // Microsoft Windows 10.0.15051

            var frameworkDescription = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
            Console.WriteLine(frameworkDescription);
            // .NET Core 4.6.25113.02

            var OSArchitecture = System.Runtime.InteropServices.RuntimeInformation.OSArchitecture;
            Console.WriteLine(OSArchitecture);
            // Arm

            bool isWindows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            Console.WriteLine(isWindows);

            bool isLinux = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            Console.WriteLine(isLinux);

            Console.WriteLine(Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER"));
            // ARM

            Console.WriteLine(Environment.GetEnvironmentVariable("COMPUTERNAME"));
            // MINWINPC

            Console.WriteLine(Environment.GetEnvironmentVariable("USERNAME"));
            // Administrator

            Console.WriteLine(Environment.GetEnvironmentVariable("USER"));
            // root
            Console.WriteLine(Environment.GetEnvironmentVariable("SUDO_USER"));
            // ubuntu
            
            Console.WriteLine(Environment.GetEnvironmentVariable("GPIO_DIR"));

            var isExists = Directory.Exists("/sys/class/gpio");
            Console.WriteLine("/sys/class/gpio = " + isExists);
        }
    }
}
