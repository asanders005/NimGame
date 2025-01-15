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
            bool confirmExit = Application.Current.MainPage.DisplayAlert(
       "Exit Game",
       "Are you sure you want to exit?",
       "Yes",
       "No").Result;

            if (confirmExit)
            {
#if ANDROID
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
#elif IOS
        UIKit.UIApplication.SharedApplication.PerformSelector(
            new ObjCRuntime.Selector("terminateWithSuccess"), null, 0f);
#else
        Application.Current.Quit();
#endif
            }
        }
    }
}