
using Plugin.Maui.Audio;
using MusicPlayer.Models;
using System.Collections.ObjectModel;

namespace MusicPlayer.ViewModels;

internal class PlayerViewModel
{
    public string SongImage { get; set; }
    public ObservableCollection<string> Playlists { get; private set; }
    public PlayerViewModel()
    {
        getPlaylists();
        SongImage = "";
        GlobalStorage global = GlobalStorage.Instance;
        Song selectedSong = global.getSong();
        if (selectedSong.Name != "")
        {
            IAudioManager audioManager = new Plugin.Maui.Audio.AudioManager();
            if(global.getSong().Path != null && global.getSong().Path != "")
            {
                if(global.audioPlayer != null)
                {
                    try
                    {
                        if (global.audioPlayer.IsPlaying)
                        {
                            global.audioPlayer.Dispose();
                        }
                    }
                    catch (Exception E) { }
                    
                }
                
                var bytes = File.ReadAllBytes(global.getSong().Path);
                this.SongImage = global.getSong().Image;
                global.audioPlayer = audioManager.CreatePlayer(new MemoryStream(bytes));
            }
            
        }
        async void getPlaylists() {
            Playlists = new ObservableCollection<string>();
            PlaylistSQL sqlConn = new PlaylistSQL();
            await sqlConn.Init();
            var list = await sqlConn.GetAllPlaylists();
            for (int i = 0; i < list.Count; i++)
            {
                Playlists.Add(list[i].Name);
            }
        }
    }
}
