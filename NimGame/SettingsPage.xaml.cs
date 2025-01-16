using NimGame.GameClasses;
using System.Security.Cryptography.X509Certificates;

namespace NimGame;

public partial class SettingsPage : ContentPage
{
    public static bool isPvP = false;
    public static bool isPvC = false;
    public static bool isEasy = false;
    public static bool isMedium = false;
    public static bool isHard = false;
    public SettingsPage()
	{
		InitializeComponent();
	}

    private void ToggleButtonClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button != null)
        {
            // Toggle the button's state
            if (button.BackgroundColor == Colors.Black)
            {
                button.BackgroundColor = Colors.DarkGray;
            }
            else
            {
                button.BackgroundColor = Colors.Black;
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

    private void GamePage(object sender, EventArgs e)
    {
        if (Application.Current != null)
        {
            // Get selected difficulty
            GameDifficulty selectedDifficulty = GameDifficulty.MEDIUM; // Default value
            var easyButton = FindByName("EasyButton") as Button;
            var normalButton = FindByName("NormalButton") as Button;
            var hardButton = FindByName("HardButton") as Button;

            if (easyButton != null && easyButton.BackgroundColor == Colors.Green)
            {
                selectedDifficulty = GameDifficulty.EASY;
            }
            else if (normalButton != null && normalButton.BackgroundColor == Colors.Green)
            {
                selectedDifficulty = GameDifficulty.MEDIUM;
            }
            else if (hardButton != null && hardButton.BackgroundColor == Colors.Green)
            {
                selectedDifficulty = GameDifficulty.HARD;
            }

            // Get player names
            var player1Entry = FindByName("Player1Entry") as Entry;
            var player2Entry = FindByName("Player2Entry") as Entry;

            var player1Name = player1Entry?.Text ?? "Player 1";
            var player2Name = player2Entry?.Text ?? "Player 2";

            if(player1Name == "" || player1Name == null)
            {
                player1Name = "Bob the Pirate";
            }

            if (player2Name == "" || player2Name == null)
            {
                player2Name = "Joe the Buccaneer";
            }

            // Determine if it's Player vs. AI or Player vs. Player
            bool isPvC = (FindByName("PvAIButton") as Button)?.BackgroundColor == Colors.Green;

            // Create the Game instance
            Game game = new Game(selectedDifficulty, player1Name, player2Name, isPvC);

            switch (selectedDifficulty)
            {
                case GameDifficulty.EASY:
                    Application.Current.MainPage = new GamePageEasy(game);
                    break;
                case GameDifficulty.MEDIUM:
                    Application.Current.MainPage = new GamePageMedium(game);
                    break;
                case GameDifficulty.HARD:
                    Application.Current.MainPage = new GamePageHard(game);
                    break;
            }
        }
    }
    
    private void PlayerVersusPlayer(object sender, EventArgs e)
    {
        isPvP = !isPvP;

        var playerVersusPlayerButton = base.FindByName("PvPButton") as Button;
        if (playerVersusPlayerButton != null)
        {
            playerVersusPlayerButton.BackgroundColor = isPvP ? Colors.Green : Colors.Black;
            playerVersusPlayerButton.IsEnabled = true;
        }

        // Update the Player vs. AI button
        var playerVersusAIButton = base.FindByName("PvAIButton") as Button;
        if (playerVersusAIButton != null)
        {
           
            playerVersusAIButton.BackgroundColor = isPvP ? Colors.DarkRed : Colors.Black;
            playerVersusAIButton.IsEnabled = !isPvP; // Disable the other button
        }

        var player2Entry = FindByName("Player2Entry") as Entry;
        var player1Entry = FindByName("Player1Entry") as Entry;
        if (player1Entry != null && player2Entry != null)
        {
            player1Entry.IsEnabled = true;
            player1Entry.Text = "";
            player1Entry.Placeholder = "Bob the Pirate";
            player1Entry.BackgroundColor = Colors.Black;
        }
        if (player2Entry != null)
        {
            player2Entry.IsEnabled = true;
            player2Entry.Text = "";
            player2Entry.Placeholder = "Joe the Buccaneer";
            player2Entry.BackgroundColor = Colors.Black;
        }
    }
    private void PlayerVersusAI(object sender, EventArgs e)
    {
        isPvC = !isPvC;
        var playerVersusAIButton = base.FindByName("PvAIButton") as Button;
        if (playerVersusAIButton != null)
        {
            playerVersusAIButton.BackgroundColor = isPvC ? Colors.Green : Colors.Black;
            playerVersusAIButton.IsEnabled = true;
        }

        // Update the Player vs. Player button
        var playerVersusPlayerButton = base.FindByName("PvPButton") as Button;
        if (playerVersusPlayerButton != null)
        {
            playerVersusPlayerButton.BackgroundColor = isPvC ? Colors.DarkRed : Colors.Black;
            playerVersusPlayerButton.IsEnabled = !isPvC; // Disable the other button
        }

        // Disable the first name entry (prompt for player name)
        var player2Entry = FindByName("Player2Entry") as Entry;
        if (player2Entry != null)
        {
            player2Entry.IsEnabled = false; // Disable input
            player2Entry.Text = "Player 2 (CPU)";
            player2Entry.BackgroundColor = Colors.LightGray; // Grey out visually
        }
    }
    private void Easy(object sender, EventArgs e)
    {
        isEasy = true;
        isMedium = false;
        isHard = false;
        UpdateDifficultyButtons("EasyButton");

    }
    private void Medium(object sender, EventArgs e)
    {
        isMedium = true;
        isEasy = false;
        isHard = false;
        UpdateDifficultyButtons("NormalButton");
    }
    private void Hard(object sender, EventArgs e)
    {
        isHard = true;
        isEasy = false;
        isMedium = false;
        UpdateDifficultyButtons("HardButton");
    }

    private void UpdateDifficultyButtons(string clickedButtonName)
    {
        var buttons = new List<Button>
    {
        FindByName("EasyButton") as Button,
        FindByName("NormalButton") as Button,
        FindByName("HardButton") as Button
    };

        foreach (var button in buttons)
        {
            if (button != null)
            {
                button.BackgroundColor = button.StyleId == clickedButtonName ? Colors.Green : Colors.DarkGray;
                
            }
        }
    }
}
