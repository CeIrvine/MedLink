using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedLink.Logic.Models
{
    [Table("operation", Schema = "dbo")]
    public class Operation
    {
        [Key]
        [Column("operation_id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("operation_name")]
        public string OperationName { get; set; }

        [Column("doc_note")]
        public string DocNote { get; set; }

        [Required]
        [Column("doc_id")]
        public int DocId { get; set; }

        [Required]
        [Column("patient_id")]
        public int PatientId { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Column("last_modified")]
        public DateTime LastModified { get; set; }
    }
}
