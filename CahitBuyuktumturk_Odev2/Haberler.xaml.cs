namespace CahitBuyuktumturk_Odev2;

public partial class Haberler : ContentPage
{
	public Haberler()
		
	{
		InitializeComponent();

		Kategorilistesi.ItemsSource = new List<Categoriler>()
			{
			  new Categoriler() { Baslik = "Gündem" },
			new Categoriler() { Baslik = "Spor" ,   },
			new Categoriler() { Baslik = "Kültür-Sanat" },

			new Categoriler() { Baslik = "Teknoloji" },
			new Categoriler() { Baslik = "Ekonomi" }
			};
		kaynak = new Kaynak();
		AkýsDetay.ItemsSource = new List<Categoriler>() { new Categoriler() { Baslik="Guncel", Baglanti="https://www.trthaber.com/guncel_articles.rss"} };



	}
	Kaynak kaynak;
	static DetayHaber haberdetayý;
	private async void TepeMenu(object sender, SelectionChangedEventArgs e)
	{
		Categoriler kategori= (Categoriler)e.CurrentSelection;
		if (kategori.Baslik == "Spor") 
		{
			AkýsDetay.ItemsSource = new List<Haber>();
			new Haber() { link= kaynak.Enclosure.link , title=kaynak.Item.title };
		}
		if (kategori.Baslik == "Guncel") 
		{
			AkýsDetay.ItemsSource = new List<Haber>();
			new Haber() { title="Spor", link = "\"https://www.trthaber.com/guncel_articles.rss" };

		}
		

	}
	private void AltMenu(object sender, SelectionChangedEventArgs e)
	{
		
	}

	public static async Task<string> GetirHaber(Categoriler ctg)
	{
		try
		{
			HttpClient client = new HttpClient();
			string url = $"https://api.rss2json.com/v1/api.json?rss_url={ctg.Baglanti}";
			using HttpResponseMessage response = await client.GetAsync(url);
			response.EnsureSuccessStatusCode();
			string jsondata = await response.Content.ReadAsStringAsync();
			return jsondata;
		}
		catch
		{
			return null;

		}
	}
	private  async void Detay(object sender, EventArgs e) 
	{

		await Navigation.PushModalAsync(new DetayHaber());
	}







}



	

	public class Enclosure
{
	public string link { get; set; }
	public string type { get; set; }
}

public class Feed
{
	public string url { get; set; }
	public string title { get; set; }
	public string link { get; set; }
	public string author { get; set; }
	public string description { get; set; }
	public string image { get; set; }
}

public class Item
{
	public string title { get; set; }
	public string pubDate { get; set; }
	public string link { get; set; }
	public string guid { get; set; }
	public string author { get; set; }
	public string thumbnail { get; set; }
	public string description { get; set; }
	public string content { get; set; }
	public Enclosure enclosure { get; set; }
	public List<object> categories { get; set; }
}

public class Root
{
	public string status { get; set; }
	public Feed feed { get; set; }
	public List<Item> items { get; set; }
}


public class Haber
{
	public string title { get; set; }
	public string pubDate { get; set; }
	public string author { get; set; }
	public string link { get; set; }
	public string image { get; set; }
}
public class Categoriler
{
	public string Baslik { get; set; }
	public string Baglanti { get; set; }
	public static List<Categoriler> kategoriler = new List<Categoriler>()
		{
			new Categoriler() { Baslik = "Gündem", Baglanti = "https://www.trthaber.com/guncel_articles.rss" },
			new Categoriler() { Baslik = "Spor", Baglanti = "https://www.trthaber.com/spor_articles.rss" },
			new Categoriler() { Baslik = "Kültür-Sanat", Baglanti = "https://www.trthaber.com/kultur_sanat_articles.rss" },
			new Categoriler() { Baslik = "Teknoloji", Baglanti = "https://www.trthaber.com/bilim_teknoloji_articles.rss" },
			new Categoriler() { Baslik = "Ekonomi", Baglanti = "https://www.trthaber.com/ekonomi_articles.rss" }
		};
}
public class Kaynak
{
	public Item Item { get; set; }
	public Enclosure Enclosure { get; set; }
	public Feed Feed { get; set; }



}


