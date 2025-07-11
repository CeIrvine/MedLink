using MedLink.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MedLink.Logic.Services
{
    public class InsurancesService : BaseService<Insurance>
    {
        private readonly HttpClient _httpClient;

        public InsurancesService(HttpClient httpClient)
            : base(httpClient, "insurances")
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Insurance>>(json);
            }
            return new List<Insurance>();
        }

        public async Task<Insurance> GetInsuranceByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"insurances/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Insurance>(json);
            }
            return null;
        }

        public async Task<bool> AddInsuranceAsync(Insurance insurance)
        {
            var json = JsonSerializer.Serialize(insurance);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("insurances", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateInsuranceAsync(Insurance insurance)
        {
            var json = JsonSerializer.Serialize(insurance);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"insurances/{insurance.Id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteInsuranceAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"insurances/{id}");
            return response.IsSuccessStatusCode;
        }
    }

}
