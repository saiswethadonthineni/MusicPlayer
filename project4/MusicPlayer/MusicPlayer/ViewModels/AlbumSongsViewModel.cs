using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.ViewModels
{

    internal class AlbumSongsViewModel
    {
        public ObservableCollection<Song> AlbumSongs { get; private set; }
        public string Title { get; private set; }

        public AlbumSongsViewModel()
        {
            GlobalStorage global = GlobalStorage.Instance;
            string dir = global.getDirectory();
            Album selectedAlbum = global.getAlbum();
            Title = selectedAlbum.Name;
            var files = Directory.GetFiles(dir + "\\" + selectedAlbum.Name);
            AlbumSongs = new ObservableCollection<Song>();
            for(int i=0;i<files.Length; i++)
            {

                var fileName = files[i].Split("\\").Last();
                if(!fileName.Contains(".jpg"))
                {
                    AlbumSongs.Add(new Song()
                    {
                        AlbumName = selectedAlbum.Name,
                        Image = dir + selectedAlbum.Name + "\\poster.jpg",
                        Name = fileName,
                        Path = dir + selectedAlbum.Name + "\\" + fileName,
                    });
                }
                
            }
        }
    }
}
