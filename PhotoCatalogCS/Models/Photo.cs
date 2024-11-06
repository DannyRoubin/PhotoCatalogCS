using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoCatalogCS.Models
{
    public class Photo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhotoId { get; set; }

        [Required]
        [Column(TypeName = "uniqueidentifier")]
        public Guid PhotoGUID { get; set; }

        [Required]
        [MaxLength(256)]
        public string FileName { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }
    }
}

