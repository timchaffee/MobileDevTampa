using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Device.Gpio;

namespace dotnetconf.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlinkController : ControllerBase
    {
        private const int pin = 17;

        [HttpPost]
        public ActionResult<string> Post([FromBody] string toggle)
        {
            try
            {

            GpioController controller = new GpioController();
            if (!controller.IsPinOpen(pin))
            {
                controller.OpenPin(pin, PinMode.Output);
            }

            if ("on".Equals(toggle))
            {
                controller.Write(pin, PinValue.High);
                return Ok("Toggled on");
            }
            else
            {
                controller.Write(pin, PinValue.Low);
                return Ok("Toggled off");
            }
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }
    }
}
