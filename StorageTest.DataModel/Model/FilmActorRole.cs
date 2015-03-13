using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StorageTest.DataModel
{
    public class FilmActorRole
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FilmTitleId { get; set; }

        [ForeignKey("FilmTitleId")]
        public Film FilmTitle { get; set; }

        [Required]
        public int ActorId { get; set; }
        [ForeignKey("ActorId")]
        public Actor Actor { get; set; }

        [Required]
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [Required]
        [StringLength(100)]
        public string Character { get; set; }
        
        [StringLength(500)]
        public string Description { get; set; }

    }
}
