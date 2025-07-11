using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedLink.Logic.Services
{
    public class BaseService<T>
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public BaseService(HttpClient httpClient, string endpoint)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
        }

        public async Task<List<T>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(_endpoint);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<List<T>>(json);
            }
            return new List<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<T>(json);
            }
            return default;
        }

        public async Task<bool> AddAsync(T item)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_endpoint, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, T item)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_endpoint}/{id}", content);
            return response.IsSuccessStatusCode;
        }   

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
