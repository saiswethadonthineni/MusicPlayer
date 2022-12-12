using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.ViewModels
{
    internal class PlaylistViewModel
    {
        public ObservableCollection<Playlist> Playlists { get; private set; }
        public PlaylistViewModel()
        {
            getData();
            
        }
        async void getData()
        {
            Playlists = new ObservableCollection<Playlist>();
            PlaylistSQL sqlConn = new PlaylistSQL();
            await sqlConn.Init();
            var list = await sqlConn.GetAllPlaylists();
            for(int i = 0; i < list.Count; i++)
            {
                Playlists.Add(list[i]);
            }
        }
    }
}
