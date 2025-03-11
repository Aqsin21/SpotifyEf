using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Music
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double TotalSecond { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public int? AlbumId { get; set; }  
        public Album? Album { get; set; }
    }
}
