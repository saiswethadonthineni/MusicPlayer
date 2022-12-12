using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public class PlaylistSong
    {
        public string playlistName { get; set; }
        public String Name { get; set; }
        public String Path { get; set; }
        public String Image { get; set; }
        public String AlbumName { get; set; }
        public int Duration { get; set; }
    }
}
