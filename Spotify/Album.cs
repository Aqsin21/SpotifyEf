using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountMusic { get; set; }


        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public List<Music> Musics { get; set; }



    }
}
