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
		string vilayet = await DisplayPromptAsync("Þehir:", "Þehir ismi", "OK", "Cancel");
		vilayet = vilayet.ToUpper(System.Globalization.CultureInfo.CurrentCulture);
		vilayet = vilayet.Replace('Ç', 'C');
		vilayet = vilayet.Replace('Ð', 'G');
		vilayet = vilayet.Replace('Ý', 'I');
		vilayet = vilayet.Replace('Ö', 'O');
		vilayet = vilayet.Replace('Ü', 'U');
		vilayet = vilayet.Replace('Þ', 'S');

		Sehirler.Add(new SehirHavaDurumu() { Name = vilayet });
		string data=JsonSerializer.Serialize(Sehirler);
		File.WriteAllText(dosyaismi,data);

	}

	private  async void Sil(Object sender, EventArgs e)
	{
		var kaldýr = sender as ImageButton;
		if (kaldýr != null)
		{
			var temizle = Sehirler.First(o => o.Name == kaldýr.CommandParameter.ToString());


			Sehirler.Remove(temizle);


		}

	}

	
}
public class SehirHavaDurumu
{
	public string Name { get; set; }
	public string Source => $"https://www.mgm.gov.tr/sunum/tahmin-klasik-5070.aspx?m={Name}&basla=1&bitir=5&rC=111&rZ=fff";
}

