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
    [Table("surgery", Schema = "dbo")]
    public class Surgery : ITrackable
    {
        [Key]
        [Column("surgery_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        [Column("operation_id")]
        public int OperationId { get; set; }

        [Column("doc_note")]
        public string Note { get; set; }

        [Required]
        [Column("patient_id")]
        public int PatientId { get; set; }

        [Required]
        [Column("doc_id")]
        public int DocId { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Column("last_modified")]
        public DateTime LastModified { get; set; }
    }
}
