using MusicPlayer.Models;
using MusicPlayer.ViewModels;

namespace MusicPlayer;

public partial class PlaylistSongsPage : ContentPage
{
	public PlaylistSongsPage()
	{
		InitializeComponent();
		this.BindingContext = new PlaylistSongsViewModel();
	}
    async void songClicked(object sender, SelectionChangedEventArgs e)
    {
        GlobalStorage global = GlobalStorage.Instance;
        global.SetSong((Song)e.CurrentSelection[0]);
        await Shell.Current.GoToAsync("//PlayerPage");
    }
}