
using MusicPlayer.Models;
using Plugin.Maui.Audio;
using System.Diagnostics;

namespace MusicPlayer
{
    public sealed class GlobalStorage
    {
        private Song SelectedSong = new Song();
        private Album selectedAlbum = new Album();
        private Playlist SelectedPlaylist = new Playlist();
        private string DirectoryPath = "C:\\Users\\donth\\OneDrive\\Desktop\\final crossmobile\\MusicPlayer\\MusicPlayer\\Resources\\Data\\";
        public IAudioPlayer audioPlayer;
        private static GlobalStorage instance = null;
        private static readonly object padlock = new object();

        private GlobalStorage() { }
        public static GlobalStorage Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new GlobalStorage();
                    }
                    return instance;
                }
            }
        }
        public void SetSong(Song song)
        {
            this.SelectedSong = song;
        }
        public void setAlbum(Album album)
        {
            this.selectedAlbum = album;
        }
        public void SetPlaylist(Playlist playlist)
        {
            this.SelectedPlaylist = playlist;
        }
        public Playlist getPlaylist()
        {
            return this.SelectedPlaylist;
        }
        public Song getSong()
        {
            return this.SelectedSong;
        }
        public Album getAlbum()
        {
            return this.selectedAlbum;
        }
        public string getDirectory()
        {
            return this.DirectoryPath;
        }

    }
}