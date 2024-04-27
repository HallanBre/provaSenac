using Dominio.Entidades;
using Integracao;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace prova;

public partial class CotacaoPage : ContentPage
{
	private string _shareSymbol;
	private readonly BaseClient _client = new BaseClient();
	public CotacaoPage(String shareSymbol)
	{
		InitializeComponent();
		_shareSymbol = shareSymbol;
		Mostra(_shareSymbol);
	}

	private async Task Mostra(String shareSymbol)
	{
		HttpResponseMessage respostaApi = await _client.GetShare(shareSymbol);
		string conteudo = await respostaApi.Content.ReadAsStringAsync();
		Acao acao = JsonConvert.DeserializeObject<Acao>(conteudo);

        Long.Text = $"{acao.LongName}";
        Name.Text = $"{acao.ShortName}";
        Price.Text = $"{acao.RegularMarketPrice}";
        Change.Text = $"{acao.RegularMarketChange}";
		ChangePercent.Text = $" {acao.RegularMarketChangePercent}%";
		DayHigh.Text = $"{acao.RegularMarketDayHigh}";
		DayLow.Text = $"{acao.RegularMarketDayLow}";

    }
}