using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedLink.Logic.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }    
        public DateTime createdAt { get; set; }
        public DateTime lastModified {  get; set; }
        public string patientNote { get; set; }
    }
}
