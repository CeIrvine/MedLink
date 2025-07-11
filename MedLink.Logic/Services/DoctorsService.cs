using MedLink.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MedLink.Logic.Services
{
    public class DoctorsService : BaseService<Doctor>
    {
        public DoctorsService(HttpClient httpClient)
            :base(httpClient, "doctors")
        {              
        }
    }
}
