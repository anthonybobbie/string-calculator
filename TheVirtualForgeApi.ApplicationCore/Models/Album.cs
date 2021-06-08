using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVirtualForgeApi.ApplicationCore.Models
{
    public class Album
    {
        public int Id { get; set; }
       [Required(ErrorMessage ="Album title required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "ArtistName title required")]
        public string ArtistName { get; set; }
        
        [Required(ErrorMessage = "AlbumTypeID title required")]
        public int AlbumTypeID { get; set; }
        [Required(ErrorMessage = "Stock title required")]
        public int Stock { get; set; }
    }
}
