
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace CahitBuyuktumturk_Odev2;

public partial class Borsa : ContentPage
{
	public Borsa()
	{
		InitializeComponent();
	}
	private static Borsa kopya;
	public static Borsa Page 
	{
		get
		{
			if(kopya== null)
				kopya = new Borsa();
			return kopya;

			
		}
	}
	BorsaDurum borsa;
	protected async override void OnAppearing()
	{
		base.OnAppearing();
		await Load();
	}

	async Task Load()
	{
		var jsondata = await GetGuncel();

		borsa = JsonSerializer.Deserialize<BorsaDurum>(jsondata);
		Sepet.ItemsSource = new List<Doviz>()
		{
			 new Doviz()
		 { Dovizismi = "------", DovizAlis = "Merkezi ", DovizSatis ="Paralar " ,
			 Fark="---- ", Durum="Birimleri ",},
		 new Doviz()
		 { Dovizismi="ABD Dolarý ", DovizAlis=borsa.USD.alis, DovizSatis=borsa.USD.satis,
			 Fark=borsa.USD.degisim, Durum=Statement(borsa.USD.d_yon),},
		 new Doviz()
		 { Dovizismi="Euro-Avro ", DovizAlis=borsa.EUR.alis, DovizSatis=borsa.EUR.satis,
			 Fark=borsa.EUR.degisim, Durum=Statement(borsa.EUR.d_yon),},
		  new Doviz()
		 { Dovizismi = "Sterlin-Pound ", DovizAlis = borsa.GBP.alis, DovizSatis = borsa.GBP.satis,
			 Fark=borsa.GBP.degisim, Durum=Statement(borsa.GBP.d_yon),},
		  new Doviz()
		 { Dovizismi = "------ ", DovizAlis = "Deðerli", DovizSatis ="Metaller " ,
			 Fark="---- ", Durum="---- ",},
		  new Doviz()
		 { Dovizismi = "Gram Altýn ", DovizAlis = borsa.GA.alis, DovizSatis = borsa.GA.satis,
			 Fark=borsa.GA.degisim, Durum=Statement(borsa.GA.d_yon),},
		  new Doviz()
		 { Dovizismi = "Çeyrek ", DovizAlis = borsa.C.alis, DovizSatis = borsa.C.satis,
			 Fark=borsa.C.degisim, Durum=Statement(borsa.C.d_yon),},
		   new Doviz()
		 { Dovizismi = "Gümüþ ", DovizAlis = borsa.GAG.alis, DovizSatis = borsa.GAG.satis,
			 Fark=borsa.GAG.degisim, Durum=Statement(borsa.GAG.d_yon),},

			new Doviz()
		 { Dovizismi = "-----", DovizAlis = "Kripto", DovizSatis = "Paralar", Fark="-------"},
			 new Doviz()
		 { Dovizismi = "Bitcoin ", DovizAlis = borsa.BTC.alis, DovizSatis = borsa.BTC.satis,
			 Fark=borsa.BTC.degisim, Durum=Statement(borsa.BTC.d_yon),},
			 new Doviz(){Dovizismi="Ether",DovizAlis=borsa.ETH.alis,DovizSatis=borsa.ETH.satis, Fark=borsa.ETH.degisim,Durum=Statement(borsa.ETH.d_yon)},
			 

		};
	}

	private string Statement(string str)
	{
		if (str.Contains("up"))
			return "redarrow.png";
		if (str.Contains("down"))
			return "greenarrow.png";
		if (str.Contains("minus"))
			return "stable.png";
		return "";
		
	}

	async Task<string> GetGuncel()
	{
		HttpClient client = new HttpClient();
		string url = "https://api.genelpara.com/embed/altin.json";
		
		using HttpResponseMessage response = await client.GetAsync(url);
		response.EnsureSuccessStatusCode();

		string jsondata=await response.Content.ReadAsStringAsync();
		return jsondata;
	}
	private async void Yenile(object sender, EventArgs e) 
	{
		await Load();
	}
}
public class Doviz
{
	public string Dovizismi { get; set; }
	public string DovizAlis { get; set; }
	public string DovizSatis { get; set; }
	public string Fark { get;set; }
	public string Durum { get; set; }

}
public class BorsaDurum
{
	public USD USD { get; set; }
	public EUR EUR { get; set; }
	public GBP GBP { get; set; }
	public GA GA { get; set; }
	public C C { get; set; }
	public GAG GAG { get; set; }
	public BTC BTC { get; set; }
	public ETH ETH { get; set; }
	public XU100 BXU100 { get; set; }
}
public class BTC
{
	public string satis { get; set; }
	public string alis { get; set; }
	public string degisim { get; set; }
	public string d_oran { get; set; }
	public string d_yon { get; set; }
}

public class C
{
	public string satis { get; set; }
	public string alis { get; set; }
	public string degisim { get; set; }
	public string d_oran { get; set; }
	public string d_yon { get; set; }
}

public class ETH
{
	public string satis { get; set; }
	public string alis { get; set; }
	public string degisim { get; set; }
	public string d_oran { get; set; }
	public string d_yon { get; set; }
}

public class EUR
{
	public string satis { get; set; }
	public string alis { get; set; }
	public string degisim { get; set; }
	public string d_oran { get; set; }
	public string d_yon { get; set; }
}

public class GA
{
	public string satis { get; set; }
	public string alis { get; set; }
	public string degisim { get; set; }
	public string d_oran { get; set; }
	public string d_yon { get; set; }
}

public class GAG
{
	public string satis { get; set; }
	public string alis { get; set; }
	public string degisim { get; set; }
	public string d_oran { get; set; }
	public string d_yon { get; set; }
}

public class GBP
{
	public string satis { get; set; }
	public string alis { get; set; }
	public string degisim { get; set; }
	public string d_oran { get; set; }
	public string d_yon { get; set; }
}



public class USD
{
	public string satis { get; set; }
	public string alis { get; set; }
	public string degisim { get; set; }
	public string d_oran { get; set; }
	public string d_yon { get; set; }
}

public class XU100
{
	public string satis { get; set; }
	public string alis { get; set; }
	public string degisim { get; set; }
}

