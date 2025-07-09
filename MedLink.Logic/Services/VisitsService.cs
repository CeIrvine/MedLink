using MedLink.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MedLink.Logic.Services
{
    public class VisitsService
    {
        private readonly HttpClient _httpClient;

        public VisitsService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<Visit>> GetVisitsAsync()
        {
            var response = await _httpClient.GetAsync("visits");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Visit>>(json);
            }
            return new List<Visit>();
        }

        public async Task<Visit> GetVisitByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"visits/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Visit>(json);
            }
            return null;
        }

        public async Task<bool> AddVisitAsync(Visit visit)
        {
            var json = JsonSerializer.Serialize(visit);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("visits", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateVisitAsync(Visit visit)
        {
            var json = JsonSerializer.Serialize(visit);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"visits/{visit.Id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteVisitAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"visits/{id}");
            return response.IsSuccessStatusCode;
        }
    }

}
