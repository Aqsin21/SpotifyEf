using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Spotify
{
    public class AppDbContext :DbContext
    {
        public DbSet<Music>Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-L886DE2;Database=Spotify;Trusted_Connection=True;TrustServerCertificate=true");
        }

    }
}
