using MedLink.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MedLink.Logic.Services
{
    public class IllnessesService : BaseService<Illness>
    {
        private readonly HttpClient _httpClient;

        public IllnessesService(HttpClient httpClient)
            : base(httpClient, "illnesses")
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Illness>>(json);
            }
            return new List<Illness>();
        }

        public async Task<Illness> GetIllnessByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"illnesses/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Illness>(json);
            }
            return null;
        }

        public async Task<bool> AddIllnessAsync(Illness illness)
        {
            var json = JsonSerializer.Serialize(illness);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("illnesses", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateIllnessAsync(Illness illness)
        {
            var json = JsonSerializer.Serialize(illness);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"illnesses/{illness.Id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteIllnessAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"illnesses/{id}");
            return response.IsSuccessStatusCode;
        }
    }

}
