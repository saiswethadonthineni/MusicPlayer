using MusicPlayer.Models;

namespace MusicPlayer;

public partial class LibraryPage : ContentPage
{
	public LibraryPage()
	{
		InitializeComponent();
	}
    async void albumChanged(object sender, SelectionChangedEventArgs e)
    {
        GlobalStorage global = GlobalStorage.Instance;
        global.setAlbum((Album)e.CurrentSelection[0]);
        await Shell.Current.GoToAsync("AlbumSongsPage");
    }
}