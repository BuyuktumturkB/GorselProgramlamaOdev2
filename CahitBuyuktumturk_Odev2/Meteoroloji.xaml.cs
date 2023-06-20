using System.Collections.ObjectModel;
using System.Text.Json;

namespace CahitBuyuktumturk_Odev2;

public partial class Meteoroloji : ContentPage
{
	public Meteoroloji()
	{
		InitializeComponent();
		if (File.Exists(dosyaismi)) 
		{
		 string data=File.ReadAllText(dosyaismi);
		}
		Grad.ItemsSource = Sehirler;
	}
	static string dosyaismi = Path.Combine(FileSystem.Current.AppDataDirectory, "hdata.json");
	static ObservableCollection<SehirHavaDurumu> Sehirler = new ObservableCollection<SehirHavaDurumu>();
	
	private async void SehirEkle(Object sender, EventArgs e) 
	{
		string vilayet = await DisplayPromptAsync("�ehir:", "�ehir ismi", "OK", "Cancel");
		vilayet = vilayet.ToUpper(System.Globalization.CultureInfo.CurrentCulture);
		vilayet = vilayet.Replace('�', 'C');
		vilayet = vilayet.Replace('�', 'G');
		vilayet = vilayet.Replace('�', 'I');
		vilayet = vilayet.Replace('�', 'O');
		vilayet = vilayet.Replace('�', 'U');
		vilayet = vilayet.Replace('�', 'S');

		Sehirler.Add(new SehirHavaDurumu() { Name = vilayet });
		string data=JsonSerializer.Serialize(Sehirler);
		File.WriteAllText(dosyaismi,data);

	}

	private  async void Sil(Object sender, EventArgs e)
	{
		var kald�r = sender as ImageButton;
		if (kald�r != null)
		{
			var temizle = Sehirler.First(o => o.Name == kald�r.CommandParameter.ToString());


			Sehirler.Remove(temizle);


		}

	}

	
}
public class SehirHavaDurumu
{
	public string Name { get; set; }
	public string Source => $"https://www.mgm.gov.tr/sunum/tahmin-klasik-5070.aspx?m={Name}&basla=1&bitir=5&rC=111&rZ=fff";
}

