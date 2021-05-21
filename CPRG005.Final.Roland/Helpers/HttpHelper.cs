using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using CPRG005.Final.Roland.Models;
using Newtonsoft.Json;

namespace CPRG005.Final.Roland.Helpers
{
    public interface IHttpHelper<T> where T : IEntity
    {
        string BaseUrl { get; set; }
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<string> PostAsync(T entity);
        Task<string> PutAsync(int? id, T entity);
        Task<int> DeleteAsync(int id);

    }

    public class HttpHelper<T> : IHttpHelper<T> where T : Entity
    {
        public string BaseUrl { get; set; }

        public async Task<int> DeleteAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync($"{BaseUrl}/{id}"))
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
                using (var response = await httpClient.GetAsync($"{BaseUrl}"))
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
                using (var response = await httpClient.GetAsync($"{BaseUrl}/{id}"))
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
                using (var response = await httpClient.PostAsync($"{BaseUrl}", byteContent))
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
                using (var response = await httpClient.PostAsync($"{BaseUrl}/{id}", byteContent))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<string>(apiResponse);
                }
            }
        }
    }
}
