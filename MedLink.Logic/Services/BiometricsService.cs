using MedLink.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MedLink.Logic.Services
{
    public class BiometricsService : BaseService<Biometric>
    {
        private readonly HttpClient _httpClient;

        public BiometricsService(HttpClient httpClient)
            :base(httpClient, "biometrics")
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Biometric>>(json);
            }
            return new List<Biometric>();
        }

        public async Task<Biometric> GetBiometricByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"biometrics/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Biometric>(json);
            }
            return null;
        }

        public async Task<bool> AddBiometricAsync(Biometric biometric)
        {
            var json = JsonSerializer.Serialize(biometric);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("biometrics", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateBiometricAsync(Biometric biometric)
        {
            var json = JsonSerializer.Serialize(biometric);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"biometrics/{biometric.Id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteBiometricAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"biometrics/{id}");
            return response.IsSuccessStatusCode;
        }
    }

}
