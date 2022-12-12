using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.Models;
using SQLite;

namespace MusicPlayer
{
    class TableNames
    {
        string? name { get; set; }
    }
    internal class PlaylistSQL
    {
        private SQLiteAsyncConnection conn;
        private string directoryPath = "C:\\Users\\donth\\OneDrive\\Desktop\\final crossmobile\\MusicPlayer\\MusicPlayer\\Resources\\Database\\";
        private string dbFileName = "playlist.db3";

        public async Task Init()
        {
            conn = new SQLiteAsyncConnection(Path.Combine(directoryPath, dbFileName));
            await CreatePlaylistTable();

        }
        private async Task CreatePlaylistTable()
        {
            try
            {
                List<TableNames> result = await conn.QueryAsync<TableNames>("SELECT name FROM sqlite_master WHERE type='table' AND name='Playlist';");
                if (result.Count == 0)
                {
                    await conn.CreateTableAsync<Playlist>();
                    
                }
                List<TableNames> res = await conn.QueryAsync<TableNames>("SELECT name FROM sqlite_master WHERE type='table' AND name='PlaylistSong';");
                if (res.Count == 0)
                {
                    await conn.CreateTableAsync<PlaylistSong>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public async Task<List<Playlist>> GetAllPlaylists()
        {
            try
            {
                return await conn.Table<Playlist>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Failed to retrieve data. {0}", ex.Message));
            }

            return new List<Playlist>();
        }
        public async Task<List<PlaylistSong>> GetSongsByPlaylist(Playlist playlist)
        {
            try
            {
                return await conn.Table<PlaylistSong>().Where(v=> v.playlistName.Equals(playlist.Name)).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Failed to retrieve data. {0}", ex.Message));
            }

            return new List<PlaylistSong>();
        }
        public async Task AddNewPlaylist(Playlist op)
        {
            int result = 0;
            try
            {
                result = await conn.InsertAsync(new Playlist
                {
                    Name=op.Name
                });
                Console.WriteLine(string.Format("{0} record(s) added", result));
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Failed to add {0}.", ex.Message));
            }
        }
        public async Task AddNewPlaylistSong(Playlist op,Song song)
        {
            int result = 0;
            try
            {
                result = await conn.InsertAsync(new PlaylistSong
                {
                    playlistName = op.Name,
                    Name = song.Name,
                    AlbumName = song.AlbumName,
                    Duration = song.Duration,
                    Image = song.Image,
                    Path = song.Path
                });
                Console.WriteLine(string.Format("{0} record(s) added", result));
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Failed to add {0}.", ex.Message));
            }
        }
        public async Task<int> RemoveAll()
        {
            try
            {
                return await conn.ExecuteAsync("DELETE FROM Playlist;");
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        public async Task<int> deletePlaylist(Playlist p)
        {
            try
            {
                var res = await conn.ExecuteAsync("DELETE FROM Playlist WHERE Name = ?;",p.Name);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
