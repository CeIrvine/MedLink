using MedLink.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MedLink.Logic.Services
{
    public class OperationsService : BaseService<Operation>
    {
        private readonly HttpClient _httpClient;

        public OperationsService(HttpClient httpClient)
            : base(httpClient, "operations")
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Operation>>(json);
            }
            return new List<Operation>();
        }

        public async Task<Operation> GetOperationByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"operations/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Operation>(json);
            }
            return null;
        }

        public async Task<bool> AddOperationAsync(Operation operation)
        {
            var json = JsonSerializer.Serialize(operation);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("operations", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateOperationAsync(Operation operation)
        {
            var json = JsonSerializer.Serialize(operation);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"operations/{operation.Id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteOperationAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"operations/{id}");
            return response.IsSuccessStatusCode;
        }
    }

}
