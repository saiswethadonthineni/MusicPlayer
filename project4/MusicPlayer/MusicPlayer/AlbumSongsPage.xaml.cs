using MusicPlayer.Models;
using MusicPlayer.ViewModels;

namespace MusicPlayer;

public partial class AlbumSongsPage : ContentPage
{
	public AlbumSongsPage()
	{
		InitializeComponent();
        this.BindingContext = new AlbumSongsViewModel();
    }
    async void songClicked(object sender, SelectionChangedEventArgs e)
    {
        GlobalStorage global = GlobalStorage.Instance;
        global.SetSong((Song)e.CurrentSelection[0]);
        await Shell.Current.GoToAsync("//PlayerPage");
    }
}