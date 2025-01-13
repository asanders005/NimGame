using NimGame.GameClasses;
namespace NimGame;

public partial class GamePage : ContentPage
{
	public GamePage()
	{
        game = new Game(GameDifficulty.MEDIUM, "Hi", isPvC: true);
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
        game = new Game(GameDifficulty.MEDIUM, "HI");
    }

    private void ExitGame(object sender, EventArgs e)
    {
    }

    private void PassTurn(object sender, EventArgs e)
    {
        game.SwitchPlayer();
    }

    private void Row1(object sender, EventArgs e)
    {
        game.UpdateBoard(0);
    }

    private void Row2(object sender, EventArgs e)
    {
        game.UpdateBoard(1);
    }

    private void Row3(object sender, EventArgs e)
    {
        game.UpdateBoard(2);
    }

    private void Row4(object sender, EventArgs e)
    {
        game.UpdateBoard(3);
    }

    private void Row5(object sender, EventArgs e)
    {
        game.UpdateBoard(4);
    }

    private Game game;

}