using Nkomazi.Models;
using System.Data;

namespace Nkomazi.Pages;

public partial class DipReading : ContentPage
{
	DBEngine Execute = new DBEngine();
	public DipReading()
	{
		InitializeComponent();

		DataTable dt = Execute.Qry($"SELECT * FROM tLocations");

		lueLocation.ItemsSource = dt.DefaultView; 
    }
}