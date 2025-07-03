using MedLink.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedLink.Logic.Models
{
    [Table("insurance", Schema = "dbo")]
    public class Insurance : ITrackable
    {
        [Key]
        [Column("insurance_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("patient_id")]
        [MaxLength(10)]
        public int PatientId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("insurance_num")]
        public string InsuranceNum { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Column("last_modified")]
        public DateTime LastModified { get; set; }
    }
}
