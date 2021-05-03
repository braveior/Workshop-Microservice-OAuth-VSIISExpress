using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Braveior.BuddyRewards.web.Client.DTO;
using System.Net.Http.Json;
using System.Net;
using Microsoft.AspNetCore.DataProtection;

namespace Braveior.BuddyRewards.web.Client.Services
{
    public class LoginService : ILoginService
    {
        private HttpClient _httpClient { get; }

        public LoginService(HttpClient httpClient, IConfiguration config)
        {
            httpClient.BaseAddress = new Uri(config.GetValue<string>("AppSettings:BuddyRewardsBaseAddress"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Blazor Web Assembly");
            _httpClient = httpClient;
        }
        /// <summary>
        /// REST API call to authenticate a User by Email and Password
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public async Task<MemberDTO> LoginAsync(LoginDTO userDTO)
        {
           var response = await _httpClient.PostAsJsonAsync($"Login/Login", userDTO);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<MemberDTO>();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new Exception("Invalid Access Token");
            }
            else
            {
                throw new Exception("Internal Server Error");
            }
        }
        /// <summary>
        /// REST API call to validate an accesstoken to authenticate a user
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<MemberDTO> GetUserByAccessTokenAsync(string accessToken)
        {
            var response = await _httpClient.PostAsJsonAsync($"Login/GetUserByAccessToken", accessToken);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<MemberDTO>();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new Exception("Invalid Access Token");
            }
            else
            {
                throw new Exception("Internal Server Error");
            }

        }

      
    }
}
