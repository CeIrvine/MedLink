using MedLink.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MedLink.Logic.Services
{
    public class SurgeriesService
    {
        private readonly HttpClient _httpClient;

        public SurgeriesService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<Surgery>> GetSurgeriesAsync()
        {
            var response = await _httpClient.GetAsync("surgeries");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Surgery>>(json);
            }
            return new List<Surgery>();
        }

        public async Task<Surgery> GetSurgeryByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"surgeries/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Surgery>(json);
            }
            return null;
        }

        public async Task<bool> AddSurgeryAsync(Surgery surgery)
        {
            var json = JsonSerializer.Serialize(surgery);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("surgeries", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateSurgeryAsync(Surgery surgery)
        {
            var json = JsonSerializer.Serialize(surgery);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"surgeries/{surgery.Id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteSurgeryAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"surgeries/{id}");
            return response.IsSuccessStatusCode;
        }
    }

}
