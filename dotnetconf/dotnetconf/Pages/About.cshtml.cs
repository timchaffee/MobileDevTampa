using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnetconf.Pages
{
    public class AboutModel : PageModel
    {
        private const int pin = 17;

        //public AboutModel()
        //{
        //    if (!controller.IsPinOpen(pin))
        //        controller.OpenPin(pin, PinMode.Input);
        //}
        //~AboutModel()
        //{
        //    if (controller.IsPinOpen(pin))
        //        controller.ClosePin(pin);
        //}

        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your application description page.";
        }

        public void OnPostToggle()
        {
            GpioController controller = new GpioController();
            if (!controller.IsPinOpen(pin))
            {
                controller.OpenPin(pin, PinMode.Input);
            }

            var mode = controller.GetPinMode(pin);
            if (!PinMode.Input.Equals(mode)) controller.SetPinMode(pin, PinMode.Input);
            var x = controller.Read(pin);
            mode = controller.GetPinMode(pin);
            if (!PinMode.Output.Equals(mode)) controller.SetPinMode(pin, PinMode.Output);
            controller.Write(pin, PinValue.High.Equals(x) ? PinValue.Low : PinValue.High);
        }
    }
}
