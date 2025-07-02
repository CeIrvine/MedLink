using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedLink.Logic.Models
{
    [Table("doctor", Schema = "dbo")]
    public class Doctor
    {
        [Key]
        [Column("doc_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("last_name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("role")]
        public string Role { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("created_at")]
        public DateTime CreatedAt { get; private set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("last_modified")]
        public DateTime LastModified { get; private set; }
    }
}
