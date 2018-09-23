using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public int AvailableUnits { get; set; }

        //FK MovieGenre
        [Required]
        public byte MovieGenreId { get; set; }
        public MovieGenre MovieGenre { get; set; }
    }
}