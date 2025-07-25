using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MedLink.Logic.Models;

namespace MedLink.Logic.Services
{
    public class PatientsService : BaseService
    {
        public PatientsService(HttpClient httpClient)
            : base(httpClient, "patients")
        {              
        }
    }
}
