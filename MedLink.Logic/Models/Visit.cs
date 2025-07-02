using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MedLink.Logic.Models
{
    [Table("visit", Schema = "dbo")]
    public class Visit
    {
        [Key]
        [Column("visit_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("patient_id")]
        public int PatientId { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("operation_id")]
        public int OperationId { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("doc_id")]
        public int DocId { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("illness_id")]
        public int IllnessId { get; set; }

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

        [Column("conclusion")]
        public string Conclusion { get; set; }
    }
}
