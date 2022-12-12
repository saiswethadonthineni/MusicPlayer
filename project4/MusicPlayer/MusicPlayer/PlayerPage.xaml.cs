using MusicPlayer.ViewModels;

namespace MusicPlayer;

public partial class PlayerPage : ContentPage
{
	public PlayerPage()
	{
		InitializeComponent();
        this.BindingContext = new PlayerViewModel();
    }
    void play(object sender, EventArgs e)
    {
        var global = GlobalStorage.Instance;
        global.audioPlayer.Play();

    }
    void pause(object sender, EventArgs e)
    {
        var global = GlobalStorage.Instance;
        if (global.audioPlayer.IsPlaying)
        {
            global.audioPlayer.Pause();
        } else
        {
            global.audioPlayer.Play();
        }

    }
    void stop(object sender, EventArgs e)
    {
        var global = GlobalStorage.Instance;
        global.audioPlayer.Stop();

    }
    async void addToPlaylist(object sender, EventArgs e)
    {
        GlobalStorage global = GlobalStorage.Instance;
        var playlistName = (string)this.playlistPicker.SelectedItem;
        PlaylistSQL conn = new PlaylistSQL();
        await conn.Init();
        await conn.AddNewPlaylistSong(new Models.Playlist()
        {
            Name = playlistName
        }, global.getSong());
    }
}