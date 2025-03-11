using Microsoft.EntityFrameworkCore;
using System.Transactions;
using System.Xml.Linq;

namespace Spotify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Action>
            {
                {"Addartist", AddArtist },
                {"AddMusic", Add},
                {"CreateAlbum",CreateAlbum },
                {"ShowMusic",ShowMusic },
                {"ShowArtist",ShowArtists },
                {"ShowAlbums", ShowAlbums },
                {"RemoveMusic",RemoveMusic },
                {"RemoveAlbum",RemoveAlbum},
                {"RemoveArtist",RemoveArtist }


            
            };


            while (true)
            {
                string command = Console.ReadLine();

                if (dict.TryGetValue(command, out Action action))
                    action.Invoke();
                else
                    Console.WriteLine("Command not correct");
            }
        }

        // Add Methods
        static void AddArtist()
        {
            var DbContext = new AppDbContext();
            Console.WriteLine("Enter Artist Name ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter artist description");
            string description = Console.ReadLine();

            var artist = new Artist()
            { Name=name,
              Description=description
            };

            DbContext.Add(artist);
            DbContext.SaveChanges();
            
            

        }

        static void Add() 
        {
            var DbContext = new AppDbContext();
            Console.Write("Enter Music Name");
            var name = Console.ReadLine();
            Console.Write("Enter Total Seconds: ");
            double totalSeconds;

            while (!double.TryParse(Console.ReadLine(), out totalSeconds))
            {
                Console.Write("Invalid input. Please enter a number for Total Seconds: ");
            }

            Console.Write("Enter Artist Id: ");
            int artistId;
            while (!int.TryParse(Console.ReadLine(), out artistId))
            {
                Console.Write("Invalid input. Please enter a valid Artist Id: ");
            }
            Console.Write("Enter Album Id (optional, press Enter to skip): ");
            string albumInput = Console.ReadLine();
            int? albumId = null;
            if (int.TryParse(albumInput, out int parsedAlbumId))
            {
                albumId = parsedAlbumId;
            }

            var music = new Music()
            {
                Name=name ,
                TotalSecond=totalSeconds,
                ArtistId=artistId,
                AlbumId=albumId
            };

            DbContext.Add(music);
            DbContext.SaveChanges();



           

            
        }


        static void CreateAlbum()
        {
            var DbContext = new AppDbContext();
            Console.Write("Enter the Album Name");
            var name = Console.ReadLine();

            Console.Write("Enter the music count");
            int countMusic;
            while (!int.TryParse(Console.ReadLine(), out countMusic))
            {
                Console.Write("Invalid input. Please enter a number: ");
            }

            Console.Write("Enter the Artist Id");
            int artistId;
            while (!int.TryParse(Console.ReadLine(), out artistId))
            {
                Console.Write("Invalid input. Please enter a valid Artist Id: ");
            }

            var artist =DbContext.Artists.Find(artistId);
            if (artist == null)
            {
                Console.WriteLine("Artist not found.");
                return;
            }



            var album = new Album()
            {
                Name = name,
                CountMusic = countMusic,
                ArtistId = artistId
            };

            DbContext.Add(album);
            DbContext.SaveChanges();
        }

        // Show  methods 

        static void ShowMusic()
        {
            var dbContext = new AppDbContext();

            var musics = dbContext.Musics
                .Include(m => m.Artist)
                .Include(m => m.Album)
                .ToList();

            if (!musics.Any())
            {
                Console.WriteLine("No musics found.");
                return;
            }

            foreach (var music in musics)
            {
         
                Console.WriteLine($"Id: {music.Id}");
                Console.WriteLine($"Name: {music.Name}");
                Console.WriteLine($"Total Seconds: {music.TotalSecond}");
                Console.WriteLine($"Artist: {music.Artist?.Name ?? "Unknown"}");
                Console.WriteLine($"Album: {music.Album?.Name ?? "No Album"}");
               
            }


        }

        static void ShowArtists()
        {
            var dbContext = new AppDbContext();

            var artists = dbContext.Artists
               
                .ToList();

            if (!artists.Any())
            {
                Console.WriteLine("No artists found.");
                return;
            }

            foreach (var artist in artists)
            {

                Console.WriteLine($"Id: {artist.Id}");
                Console.WriteLine($"Name: {artist.Name}");
                Console.WriteLine($"Description:{artist.Description}");




            }
        }


        static void ShowAlbums()
        {
            var dbContext = new AppDbContext();
            var albums = dbContext.Albums
                .Include(m => m.Artist)
                .ToList();

            if (!albums.Any())
            {
                Console.WriteLine("No albums found.");
                return;
            }
            foreach (var album in albums)
            {
                Console.WriteLine($"Album Id:{album.Id}");
                Console.WriteLine($"Name:{album.Name}" );
                Console.WriteLine($"Artist:{album.Artist}");

            }

        }

        // Remove Methods 
         static void RemoveMusic()
        {
            var dbContext = new AppDbContext();
            Console.Write("Enter the Music ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var music = dbContext.Musics.Find(id);

            if (music == null)
            {
                Console.WriteLine("Music not found.");
                return;
            }

            dbContext.Musics.Remove(music);
            dbContext.SaveChanges();

            Console.WriteLine("Music  has been deleted.");

        }

        static void RemoveAlbum()
        {
            var dbContext = new AppDbContext();
            Console.Write("Enter the Album Id to delete");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }
            var album = dbContext.Albums.Find(id);

            if(album == null)
            {
                Console.WriteLine("Album not find");
            }

            dbContext.Albums.Remove(album);
            dbContext.SaveChanges() ;
            Console.WriteLine("Album has been deleted");

        }


        static void RemoveArtist()
        {
            var dbContext = new AppDbContext();
            Console.WriteLine("Enter the Artist Id to the delete");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id");
                return;
            }
            var artist= dbContext.Artists.Find(id);
            if (artist==null)
            {
                Console.WriteLine("Artist Not found ");

            }

            dbContext.Artists.Remove(artist);
            dbContext.SaveChanges () ;
            Console.WriteLine("Artist has been deleted");
        }


        // Update Methods 

        static void UpdateMusic()
        {
            var dbContext = new AppDbContext();
        }
    }
}
