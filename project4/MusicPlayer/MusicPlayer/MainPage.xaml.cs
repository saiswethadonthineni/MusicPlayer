
using MusicPlayer.Models;

namespace MusicPlayer;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
    async void albumChanged(object sender, SelectionChangedEventArgs e)
    {
        GlobalStorage global = GlobalStorage.Instance;
        global.setAlbum((Album)e.CurrentSelection[0]);
        await Shell.Current.GoToAsync("AlbumSongsPage");
    }
    async void playlistChanged(object sender, SelectionChangedEventArgs e)
    {
        GlobalStorage global = GlobalStorage.Instance;
        global.SetPlaylist((Playlist)e.CurrentSelection[0]);
        await Shell.Current.GoToAsync("PlaylistSongsPage");
    }
    async void showAllAlbums(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//LibraryPage");
    }
    async void showAllPlaylists(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//PlaylistPage");
    }
}

