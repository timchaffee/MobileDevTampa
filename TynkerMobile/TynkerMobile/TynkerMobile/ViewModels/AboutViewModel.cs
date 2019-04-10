using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace TynkerMobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private static bool on = false;
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
            ToggleCommand = new Command(async () =>
            {
                on = !on;
                await tynkerAPI.ToggleAsync(on);
            });
        }

        public ICommand OpenWebCommand { get; }
        public ICommand ToggleCommand { get; }
    }
}