using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Artist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public ICollection<Album> Albums { get; set; }
        public ICollection<Music> Musics { get; set; }
    }
}
