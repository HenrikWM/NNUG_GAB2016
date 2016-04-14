using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GAB.Http.ApiClients
{
    public abstract class BaseApiClient<TEntity, TGReturnEntity> 
        where TEntity : class
        where TGReturnEntity : class
    {
        private readonly string _baseUrl;

        protected BaseApiClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        protected async Task<IEnumerable<TGReturnEntity>> Get(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<TGReturnEntity>>();
                }
            }
            return new List<TGReturnEntity>();
        }

        protected async Task<TGReturnEntity> GetById(string url, string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<TGReturnEntity>();
                }
            }
            return null;
        }

        protected async Task<TGReturnEntity> Create(string url, TEntity entity)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string serializedEntity = JsonConvert.SerializeObject(entity);
                HttpContent content = new StringContent(serializedEntity, Encoding.UTF8, "application/json");
                
                HttpResponseMessage response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<TGReturnEntity>();
                }
            }
            return null;
        }

        protected async Task<bool> Delete(string url, string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, url);

                HttpResponseMessage response = await client.SendAsync(httpRequestMessage);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

        protected async Task<bool> Update(string url, TEntity entity)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string serializedEntity = JsonConvert.SerializeObject(entity);
                HttpContent content = new StringContent(serializedEntity, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}