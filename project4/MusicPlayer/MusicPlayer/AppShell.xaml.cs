using MusicPlayer;
using MusicPlayer.ViewModels;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MusicPlayer;

public partial class AppShell : Shell
{
    public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();
    public ICommand HelpCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

    public AppShell()
    {
        InitializeComponent();
        RegisterRoutes();
        BindingContext = this;
    }
    void test(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new MainPage());

    }
    async void gotoHome(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");

    }
    async void gotoLibrary(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//LibraryPage");

    }
    async void gotoPlaylist(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//PlaylistPage");

    }
    void RegisterRoutes()
    {
        Routes.Add(nameof(MainPage), typeof(MainPage));
        Routes.Add(nameof(LibraryPage), typeof(LibraryPage));
        Routes.Add(nameof(PlaylistPage), typeof(PlaylistPage));
        Routes.Add(nameof(PlayerPage), typeof(PlayerPage));
        Routes.Add(nameof(AlbumSongsPage), typeof(AlbumSongsPage));
        Routes.Add(nameof(PlaylistSongsPage), typeof(PlaylistSongsPage));

        foreach (var item in Routes)
        {
            Routing.RegisterRoute(item.Key, item.Value);
        }
    }
    protected override void OnNavigated(ShellNavigatedEventArgs args)
    {
        string location = args.Current?.Location?.ToString();
        GlobalStorage global = GlobalStorage.Instance;
        if(global.audioPlayer != null)
        {
            try
            {
                if (global.audioPlayer.IsPlaying)
                {
                    global.audioPlayer.Dispose();
                }
            } catch(Exception e)
            {

            }
        }
        

        if (location is $"//{nameof(MainPage)}")
        {
            ((MainPage)Shell.Current.CurrentPage).BindingContext = new HomeViewModel();
        }
        else if (location is $"//{nameof(LibraryPage)}")
        {
            ((LibraryPage)Shell.Current.CurrentPage).BindingContext = new LibraryViewModel();
        }
        else if (location is $"//{nameof(PlayerPage)}")
        {
            ((PlayerPage)Shell.Current.CurrentPage).BindingContext = new PlayerViewModel();
        }
        else if (location is $"//{nameof(AlbumSongsPage)}")
        {
            ((AlbumSongsPage)Shell.Current.CurrentPage).BindingContext = new AlbumSongsViewModel();
        }
        else if (location is $"//{nameof(PlaylistPage)}")
        {
            ((PlaylistPage)Shell.Current.CurrentPage).BindingContext = new PlaylistViewModel();
        }

        base.OnNavigated(args);
    }
}