namespace NimGame;

public partial class GamePage : ContentPage
{
	public GamePage()
	{
		InitializeComponent();
	}

    private void HowToPlay(object sender, EventArgs e)
    {
        if (Application.Current != null)
        {
            Application.Current.MainPage = new HowToPlay();
        }
    }
    private void TitlePage(object sender, EventArgs e)
    {
        if (Application.Current != null)
        {
            Application.Current.MainPage = new MainPage();
        }
    }
    private void NewGame(object sender, EventArgs e)
    {
    }

    private void ExitGame(object sender, EventArgs e)
    {
    }

    private void PassTurn(object sender, EventArgs e)
    { 
    }

    private void Row1(object sender, EventArgs e)
    {
    }

    private void Row2(object sender, EventArgs e)
    {
    }

    private void Row3(object sender, EventArgs e)
    {
    }

    private void Row4(object sender, EventArgs e)
    {
    }

    private void Row5(object sender, EventArgs e)
    {
    }

}