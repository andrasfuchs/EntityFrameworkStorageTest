using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StorageTest.DataModel
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(500)]
        public string Text { get; set; }

        [Required]
        [InverseProperty("Notes")]
        public Film Film { get; set; }
    }
}
