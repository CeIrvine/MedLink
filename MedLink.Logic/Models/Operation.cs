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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("operation_name")]
        public string Name { get; set; }

        [Column("doc_note")]
        public string DocNote { get; set; }

        [Required]
        [Column("doc_id")]
        public int DocId { get; set; }

        [Required]
        [Column("patient_id")]
        public int PatientId { get; set; }

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
