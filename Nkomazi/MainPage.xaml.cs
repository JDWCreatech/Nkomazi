using Nkomazi.Models;
using Nkomazi.Pages;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nkomazi
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            if (Models.Globals.IsAuthenticated)
            {
                lblUsername.Text = $"Welcome {Models.Globals.UserName}";
            }
        }
        private async void btnDipReading_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DipReading());
        }
        private async void btnOrders_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Orders());
        }
        private async void btnPOD_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new POD());
        }
        private async void btnLogout_Click(object sender, EventArgs e)
        {
            Models.Globals.UserName = string.Empty;
            Models.Globals.IsAuthenticated = false;

            if (!Models.Globals.IsAuthenticated)
            {
                //await Navigation.PushAsync(new LoginPage()); // This doesn't clear the navigation stack so the user can still go back to the previous Page. 
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}
