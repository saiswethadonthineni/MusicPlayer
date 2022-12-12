
namespace MusicPlayer;

public partial class App : Application
{
    GlobalStorage global;
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
        global = GlobalStorage.Instance;
        
    }
}
