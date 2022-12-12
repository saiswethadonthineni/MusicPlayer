using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public class Song
    {
        public Song(string album, string path, string filename)
        {
            this.Name = filename;
            this.AlbumName = album;
            this.Path = path;
        }
        public Song()
        {

        }
        public String Name { get; set; }
        public String Path { get; set; }
        public String Image { get; set; }
        public String AlbumName { get; set; }
        public int Duration { get; set; }
    }
}
