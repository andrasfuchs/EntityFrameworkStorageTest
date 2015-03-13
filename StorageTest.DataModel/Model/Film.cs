using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StorageTest.DataModel
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        
        [Required]
        [StringLength(1000)]
        public string Story { get; set; }
        
        [Required]
        public int ReleaseYear { get; set; }
        
        [Required]
        public int Duration { get; set; }

        [InverseProperty("Film")]
        public virtual ICollection<Note> Notes { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public virtual ICollection<Producer> Producers { get; set; }

        public virtual ICollection<FilmActorRole> FilmActorRoles { get; set; }
    }
}
