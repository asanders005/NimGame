namespace NimGame
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void SettingPage(object sender, EventArgs e)
        {
            if (Application.Current != null)
            {
                Application.Current.MainPage = new SettingsPage();
            }


        }
        private void HowToPlay(object sender, EventArgs e)
        {
            if (Application.Current != null)
            {
                Application.Current.MainPage = new HowToPlay();
            }


        }
        private void ExitGame(object sender, EventArgs e)
        {
            App.Current.Quit();
        }
    }
}