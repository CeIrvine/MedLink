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
    public class PatientsService : BaseService<Patient>
    {
        private readonly HttpClient _httpClient;

        public PatientsService(HttpClient httpClient)
            : base(httpClient, "patients")
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Patient>>(json);
            }
            return new List<Patient>();
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"patients/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Patient>(json);
            }

            return null;
        }

        public async Task<bool> AddPatientAsync(Patient patient)
        {
            var json = JsonSerializer.Serialize(patient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("patients", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdatePatientAsync(Patient patient)
        {
            var json = JsonSerializer.Serialize(patient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"patients/{patient.Id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePatientAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"patients/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
