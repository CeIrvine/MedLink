using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedLink.Logic.Models
{
    [Table("biometrics", Schema = "dbo")]
    public class Biometrics
    {
        [Key]
        [Column("biometrics_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BiometricsId { get; private set; }

        [Required]
        [Column("patient_id")]
        public int PatientId { get; set; }

        [Required]
        [Column("fingerprint_bio")]
        public byte Fingerprint { get; set; }

        [Column("face_bio")]
        public byte FaceId { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("created_at")]
        public DateTime CreatedAt { get; private set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("last_modified")]
        public DateTime LastModified { get; private set; }

        [Required]
        [Column("weight")]
        public int Weight { get; set; }

        [Required]
        [Column("height")]
        public int Height { get; set; }

        [Column("blood_type")]
        public string BloodType { get; set; }
    }
}
