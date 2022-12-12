using MusicPlayer.Models;
using MusicPlayer.ViewModels;

namespace MusicPlayer;

public partial class PlaylistPage : ContentPage
{
	public PlaylistPage()
	{
		InitializeComponent();
	}
    async void playlistChanged(object sender, EventArgs e)
    {
        Playlist playlist = (Playlist)this.playlistList.SelectedItem;
        GlobalStorage global = GlobalStorage.Instance;
        global.SetPlaylist(playlist);
        await Shell.Current.GoToAsync("PlaylistSongsPage");
    }
    async void playlistCreate(object sender, EventArgs e)
    {
        var val = this.newPlaylistName.Text;
        PlaylistSQL sqlConn = new PlaylistSQL();
        await sqlConn.Init();
        await sqlConn.AddNewPlaylist(new Playlist()
        {
            Name = val
        });
        this.BindingContext = new PlaylistViewModel();
    }
    async void deletePlaylist(object sender, EventArgs e)
    {
        Playlist playlist = (Playlist)this.playlistList.SelectedItem;
        PlaylistSQL sqlConn = new PlaylistSQL();
        await sqlConn.Init();
        await sqlConn.deletePlaylist(playlist);
        this.BindingContext = new PlaylistViewModel();
    }
}