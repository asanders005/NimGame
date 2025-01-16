namespace NimGame;

public partial class GamePage : ContentPage
{
	public GamePage()
	{
		InitializeComponent();
	}
    public GamePage(Game game)
    {
        InitializeComponent();

        this.game = game;

        var player1Label = FindByName("Player1Name") as Label;
        if (player1Label != null)
        {
            player1Label.Text = this.game.GetPlayerName(0);
        }

        var player2Label = FindByName("Player2Name") as Label;
        if (player2Label != null)
        {
            player2Label.Text = this.game.GetPlayerName(1);
        }

        var currentPlayerLabel = FindByName("CurrentPlayerName") as Label;
        if (currentPlayerLabel != null)
        {
            currentPlayerLabel.Text = this.game.GetCurrentPlayerName() + "'s Turn";
        }
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
<<<<<<< Updated upstream
=======
        this.game = new Game(GameDifficulty.MEDIUM, "HI");
>>>>>>> Stashed changes
    }

    private void ExitGame(object sender, EventArgs e)
    {
        App.Current.Quit();
    }

    private void PassTurn(object sender, EventArgs e)
<<<<<<< Updated upstream
    { 
=======
    {
        this.game.SwitchPlayer();

        var currentPlayerLabel = FindByName("CurrentPlayerName") as Label;
        if (currentPlayerLabel != null)
        {
            currentPlayerLabel.Text = this.game.GetCurrentPlayerName() + "'s Turn";
        }
>>>>>>> Stashed changes
    }

    private void Row1(object sender, EventArgs e)
    {
<<<<<<< Updated upstream
=======
        this.game.UpdateBoard(0);
>>>>>>> Stashed changes
    }

    private void Row2(object sender, EventArgs e)
    {
<<<<<<< Updated upstream
=======
        this.game.UpdateBoard(1);
>>>>>>> Stashed changes
    }

    private void Row3(object sender, EventArgs e)
    {
<<<<<<< Updated upstream
=======
        this.game.UpdateBoard(2);
>>>>>>> Stashed changes
    }

    private void Row4(object sender, EventArgs e)
    {
<<<<<<< Updated upstream
=======
        this.game.UpdateBoard(3);
>>>>>>> Stashed changes
    }

    private void Row5(object sender, EventArgs e)
    {
<<<<<<< Updated upstream
=======
        this.game.UpdateBoard(4);
>>>>>>> Stashed changes
    }

}