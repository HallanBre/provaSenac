namespace prova
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void handleButton(object sender, EventArgs e)
        {
           string simboloAcao = campoSimbolo.Text;
           CotacaoPage shareDetail = new CotacaoPage(simboloAcao);
           CotacaoPage telaCot = new CotacaoPage(simboloAcao);
           await Navigation.PushAsync(shareDetail);
           SemanticScreenReader.Announce(simboloAcao);

        }
    }

}
