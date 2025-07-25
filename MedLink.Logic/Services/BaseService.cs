using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MedLink.Logic.Services
{
    public class BaseService
    {
        protected readonly HttpClient _httpClient;
        private readonly string _endpoint;
        private static readonly JsonSerializerOptions _jsonOptions = new ()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        public BaseService(HttpClient httpClient, string endpoint)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
        }

        public async Task<List<T>> GetAllAsync<T>()
        {
            var response = await _httpClient.GetAsync(_endpoint);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<T>>(_jsonOptions);
            }
            return new List<T>();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
            }
            return default;
        }

        public async Task<bool> AddAsync<T>(T item)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_endpoint, content);           
            return response.IsSuccessStatusCode;
        }

        public async Task<TResponse?> PostAndReceiveAsync<TRequest, TResponse>(TRequest item)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_endpoint, content);

            if (!response.IsSuccessStatusCode)
                return default;
            
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(responseContent, _jsonOptions);
        }

        public async Task<bool> UpdateAsync<T>(int id, T item)
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
