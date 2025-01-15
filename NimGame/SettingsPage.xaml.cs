
using System.Security.Cryptography.X509Certificates;

namespace NimGame;

public partial class SettingsPage : ContentPage
{
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
                button.BackgroundColor = Colors.Green;
            }
            else
            {
                button.BackgroundColor = Colors.Black;
            }
        }
    }

    private void GamePage(object sender, EventArgs e)
    {
        if (Application.Current != null)
        {
            Application.Current.MainPage = new GamePage();
        }
    }
    
    private void PlayerVersusPlayer(object sender, EventArgs e)
    {
    }
    private void PlayerVersusAI(object sender, EventArgs e)
    {
    }
    private void Easy(object sender, EventArgs e)
    {
    }
    private void Medium(object sender, EventArgs e)
    {
    }
    private void Hard(object sender, EventArgs e)
    {
    }
}