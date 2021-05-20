using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using CPRG005.Final.Roland.Models;
using Newtonsoft.Json;

namespace CPRG005.Final.Roland.Helpers
{
    public interface IHttpHelper<T> where T : IEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<string> PostAsync(T entity);
        Task<string> PutAsync(int? id, T entity);
        Task<int> DeleteAsync(int id);

    }

    public class HttpHelper<T> : IHttpHelper<T> where T : Entity
    {
        private string baseUrl;
        public HttpHelper(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync($"{baseUrl}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<int>(apiResponse);
                } 
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{baseUrl}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<T>>(apiResponse);
                }
            }
        }

        public async Task<T> GetAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{baseUrl}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(apiResponse);
                }
            }
        }

        public async Task<string> PostAsync(T entity)
        {
            var content = JsonConvert.SerializeObject(entity);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync($"{baseUrl}", byteContent))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<string>(apiResponse);
                }
            }
        }

        public async Task<string> PutAsync(int? id, T entity)
        {
            var content = JsonConvert.SerializeObject(entity);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync($"{baseUrl}/{id}", byteContent))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<string>(apiResponse);
                }
            }
        }
    }
}
