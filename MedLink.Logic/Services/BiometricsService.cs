using MedLink.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MedLink.Logic.DTOs.Post;

namespace MedLink.Logic.Services
{
    public class BiometricsService : BaseService
    {
        public BiometricsService(HttpClient httpClient)
            :base(httpClient, "biometrics")
        {
        }       
    }
}
