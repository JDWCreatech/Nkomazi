using Nkomazi.Models;

namespace Nkomazi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            Page startPage = Globals.IsAuthenticated
                ? new MainPage()
                : new Pages.LoginPage();

            return new Window(new NavigationPage(startPage));
        }
    }
}
