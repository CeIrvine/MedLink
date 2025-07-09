using MedLink.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MedLink.Logic.Services
{
    public class DoctorsService
    {
        private readonly HttpClient _httpClient;

        public DoctorsService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<Doctor>> GetDoctorsAsync()
        {
            var response = await _httpClient.GetAsync("doctors");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Doctor>>(json);
            }
            return new List<Doctor>();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"doctors/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Doctor>(json);
            }
            return null;
        }

        public async Task<bool> AddDoctorAsync(Doctor doctor)
        {
            var json = JsonSerializer.Serialize(doctor);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("doctors", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateDoctorAsync(Doctor doctor)
        {
            var json = JsonSerializer.Serialize(doctor);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"doctors/{doctor.Id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"doctors/{id}");
            return response.IsSuccessStatusCode;
        }
    }

}
