using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.ViewModels
{
    
    internal class HomeViewModel
    {
        public ObservableCollection<Playlist> Playlists { get; private set; }
        public ObservableCollection<Album> Albums { get; private set; }

        public HomeViewModel()
        {
            GlobalStorage global = GlobalStorage.Instance;
            string dir = global.getDirectory();
            var directories = Directory.GetDirectories(dir);
            Albums = new ObservableCollection<Album>();
            for (int i = 0; i < directories.Length; i++)
            {
                var album = new Album();
                album.Name = directories[i].Split("\\").Last();
                album.Image = dir + "\\" + directories[i].Split("\\").Last() + "\\poster.jpg";
                Albums.Add(album);
            }
            Playlists = new ObservableCollection<Playlist>();
            setPlaylists();
        }
        async void setPlaylists()
        {
            PlaylistSQL sqlConn = new PlaylistSQL();
            await sqlConn.Init();
            var list = await sqlConn.GetAllPlaylists();
            for (int i = 0; i < list.Count; i++)
            {
                Playlists.Add(list[i]);
            }

        }
    }
}
