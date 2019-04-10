using System;
using System.Device.Gpio;
using System.Diagnostics;
using System.Threading;

namespace BlinkGPIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
#if DEBUG
            Console.WriteLine("Waiting for debugger to attach");
            while (!Debugger.IsAttached)
            {
                Thread.Sleep(100);
            }
            Console.WriteLine("Debugger attached");
#endif
            int pin = 17;
            GpioController controller = new GpioController();
            controller.OpenPin(pin, PinMode.Output);

            int lightTimeInMilliseconds = 1000;
            int dimTimeInMilliseconds = 200;

            while (true)
            {
                Console.WriteLine($"Light for {lightTimeInMilliseconds}ms");
                controller.Write(pin, PinValue.High);
                Thread.Sleep(lightTimeInMilliseconds);
                Console.WriteLine($"Dim for {dimTimeInMilliseconds}ms");
                controller.Write(pin, PinValue.Low);
                Thread.Sleep(dimTimeInMilliseconds);
            }
        }
    }
}
