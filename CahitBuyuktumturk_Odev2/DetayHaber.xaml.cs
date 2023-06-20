namespace CahitBuyuktumturk_Odev2;

public partial class DetayHaber : ContentPage
{
	public DetayHaber()
	{
		InitializeComponent();
	}

	private async  void Paylas(object sender, EventArgs e) 
	{
			
	}
	private async void Geri(object sender, EventArgs e) 
	{ 
	 await Navigation.PopModalAsync();
	}
}