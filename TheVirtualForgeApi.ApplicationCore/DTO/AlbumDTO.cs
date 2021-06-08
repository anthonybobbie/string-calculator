using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVirtualForgeApi.ApplicationCore.DTO
{
   public class AlbumDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ArtistName { get; set; }
        public string AlbumType { get; set; }
        public int Stock { get; set; }
    }
}
