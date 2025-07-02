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
    public class Insurance
    {
        [Key]
        [Column("insurance_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InsuranceId { get; set; }

        [Required]
        [Column("patient_id")]
        public int PatientId { get; set; }

        [Required]
        [Column("insurance_num")]
        public string InsuranceNum { get; set; }

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
