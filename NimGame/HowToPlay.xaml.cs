namespace NimGame;

public partial class HowToPlay : ContentPage
{
	public HowToPlay()
	{
		InitializeComponent();
	}
    private void TitlePage(object sender, EventArgs e)
    {
        if (Application.Current != null)
        {
            Application.Current.MainPage = new MainPage();
        }
    }
}