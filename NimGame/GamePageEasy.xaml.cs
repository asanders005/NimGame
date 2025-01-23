using NimGame.GameClasses;
namespace NimGame;

public partial class GamePageEasy : ContentPage
{
	public GamePageEasy()
	{
		InitializeComponent();
   
  }
  public GamePageEasy(Game game)
    {
        InitializeComponent();

        this.game = game;

        var row1col1 = FindByName("row1col1") as Frame;

        var row2col1 = FindByName("row2col1") as Frame;
        var row2col2 = FindByName("row2col2") as Frame;
        var row2col3 = FindByName("row2col3") as Frame;

        var row3col1 = FindByName("row3col1") as Frame;
        var row3col2 = FindByName("row3col2") as Frame;
        var row3col3 = FindByName("row3col3") as Frame;
        var row3col4 = FindByName("row3col4") as Frame;
        var row3col5 = FindByName("row3col5") as Frame;

        rows.Add(new List<Frame> { row1col1 });
        rows.Add(new List<Frame> { row2col1, row2col2, row2col3 });
        rows.Add(new List<Frame> { row3col1, row3col2, row3col3, row3col4, row3col5 });

        player1 = FindByName("Player1Name") as Label;
        player2 = FindByName("Player2Name") as Label;
        currentPlayer = FindByName("CurrentPlayerName") as Label;

        player1.Text = game.Players[0].PlayerName;
        player2.Text = game.Players[1].PlayerName;
        currentPlayer.Text = $"{game.Players[game.CurrentPlayer].PlayerName}'s Turn";

        int[] rowCounts = game.GameBoard.Rows;
        for (int i = 0; i < rowCounts.Length; i++)
        {
            for (int k = rows[i].Count - 1; k >= rowCounts[i]; k--)
            {
                if (rows[i][k].IsVisible) rows[i][k].IsVisible = false;
            }
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
        Game newgame = new Game(GameDifficulty.EASY, player1.Text, player2.Text, game.getIsPvC());

        Application.Current.MainPage = new GamePageEasy(newgame);



    }

    private void ExitGame(object sender, EventArgs e)
    {
        App.Current.Quit();
    }

    private void PassTurn(object sender, EventArgs e)
    {

        if (!game.GameOver)
        {
            game.SwitchPlayer();
            int[] rowCounts = game.GameBoard.Rows;
            for (int i = 0; i < rowCounts.Length; i++)
            {
                for (int k = rows[i].Count - 1; k >= rowCounts[i]; k--)
                {
                    if (rows[i][k].IsVisible) rows[i][k].IsVisible = false;
                }
            }
            if (game.GameOver)
            {
                currentPlayer.Text = $"{game.Winner} Wins!";
            }
            else
            {
                currentPlayer.Text = $"{game.Players[game.CurrentPlayer].PlayerName}'s Turn";
            }
        }
        else
        {
            currentPlayer.Text = $"{game.Winner} Wins!";
        }
    }

    private void Row1(object sender, EventArgs e)
    {
        if (game.UpdateBoard(0))
        {
            for (int i = rows[0].Count - 1; i >= 0; i--)
            {
                if (rows[0][i].IsVisible)
                {
                    rows[0][i].IsVisible = false;
                    break;
                }
            }
        }
    }

    private void Row2(object sender, EventArgs e)
    {
        if (game.UpdateBoard(1))
        {
            for (int i = rows[1].Count - 1; i >= 0; i--)
            {
                if (rows[1][i].IsVisible)
                {
                    rows[1][i].IsVisible = false;
                    break;
                }
            }
        }
    }

    private void Row3(object sender, EventArgs e)
    {
        if (game.UpdateBoard(2))
        {
            for (int i = rows[2].Count - 1; i >= 0; i--)
            {
                if (rows[2][i].IsVisible)
                {
                    rows[2][i].IsVisible = false;
                    break;
                }
            }
        }
    }

    private Game game;
    private Label player1;
    private Label player2;
    private Label currentPlayer;
    private List<List<Frame>> rows = new List<List<Frame>>();
}