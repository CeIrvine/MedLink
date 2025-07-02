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
        public int Id { get; private set; }

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
        [MaxLength(10)]
        [Column("weight")]
        public int Weight { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("height")]
        public int Height { get; set; }

        [MaxLength(10)]
        [Column("blood_type")]
        public string BloodType { get; set; }

        [MaxLength(10)]
        [Column("gender")]
        public string Gender { get; set; }
    }
}
