using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.ViewModels
{
    internal class PlaylistSongsViewModel
    {
        public ObservableCollection<Song> playlistSongs { get; private set; }
        public string Title { get; private set; }
        public PlaylistSongsViewModel()
        {
            getPlaylists();

        }
        async void getPlaylists()
        {
            GlobalStorage global = GlobalStorage.Instance;
            var playlist = global.getPlaylist();
            playlistSongs = new ObservableCollection<Song>();
            PlaylistSQL conn = new PlaylistSQL();
            await conn.Init();
            var songs = await conn.GetSongsByPlaylist(playlist);
            Title = playlist.Name;
            for (int i = 0; i < songs.Count; i++)
            {
                playlistSongs.Add(new Song() {
                    AlbumName = songs[i].AlbumName,
                    Duration = songs[i].Duration,
                    Image = songs[i].Image,
                    Name = songs[i].Name,
                    Path = songs[i].Path
                });
            }
        }
    }
}
