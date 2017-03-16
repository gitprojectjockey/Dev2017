using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using OnlineShoppingStore.Domain.Abstract;
using System.Collections.Generic;

namespace OnlineShoppingStore.Domain.Concrete
{
    public class UserRepository : Abstract.IUserRepository
    {
        private static HttpClient _httpClient;
        private Uri _uri;
        public UserRepository(HttpClient httpClient, Uri uri)
        {
            _httpClient = httpClient;
            _uri = uri;
        }

        public bool IsValid(string userEmail, string password)
        {
            Uri uri = new Uri(string.Format("{0}{1}", _uri.AbsoluteUri, "/IsClientKeyValid"));

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{userEmail}:{password}")));

            var response = _httpClient.GetAsync(uri).Result;
            var isValid = response.Content.ReadAsAsync<bool>().Result;
            return isValid;
        }

        List<Entities.UserRole> IUserRepository.UserRoles(string userEmail, string password)
        {
            Uri uri = new Uri(string.Format("{0}{1}", _uri.AbsoluteUri, "/GetUserRoles"));

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{userEmail}:{password}")));

            var response = _httpClient.GetAsync(uri).Result;
            var roles = response.Content.ReadAsAsync<List<Entities.UserRole>>().Result;
            return roles;
        }
    }
}
