using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StorageTest.DataModel
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        
        [Required]
        [StringLength(50)]        
        public string Email { get; set; }
        
        [StringLength(200)]
        public string Note { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}
