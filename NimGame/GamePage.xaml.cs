using NimGame.GameClasses;
namespace NimGame;

public partial class GamePage : ContentPage
{
	public GamePage()
	{
		InitializeComponent();

        rows.Add(new List<Frame> { this.row1col1 });
        rows.Add(new List<Frame> { this.row2col1, this.row2col2, this.row2col3 });
        rows.Add(new List<Frame> { this.row3col1, this.row3col2, this.row3col3, this.row3col4, this.row3col5 });
        rows.Add(new List<Frame> { this.row4col1, this.row4col2, this.row4col3, this.row4col4, this.row4col5, this.row4col6, this.row4col7 });

        player1 = this.Player1;
        player2 = this.Player2;
        currentPlayer = this.CurrentPlayer;

        game = new Game(GameDifficulty.MEDIUM, "Hi", isPvC: true);

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
        game = new Game(GameDifficulty.MEDIUM, "HI");
    }

    private void ExitGame(object sender, EventArgs e)
    {
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

    private void Row4(object sender, EventArgs e)
    {
        if (game.UpdateBoard(3))
        {
            for (int i = rows[3].Count - 1; i >= 0; i--)
            {
                if (rows[3][i].IsVisible)
                {
                    rows[3][i].IsVisible = false;
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