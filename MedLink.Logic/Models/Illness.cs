using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedLink.Logic.Models
{
    [Table("illness", Schema = "dbo")]
    public class Illness
    {
        [Key]
        [Column("illness_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("created_at")]
        public DateTime CreatedAt { get; private set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("last_modified")]
        public DateTime LastModified { get; private set; }

        [Column("note")]
        public string Note { get; set; }
    }
}
