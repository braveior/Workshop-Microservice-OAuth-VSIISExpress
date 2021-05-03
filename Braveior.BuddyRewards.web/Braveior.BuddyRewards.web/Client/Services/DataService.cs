using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Braveior.BuddyRewards.web.Client.DTO;
using Blazored.LocalStorage;
using System.Net.Http.Json;
using System.Net;

namespace Braveior.BuddyRewards.web.Client.Services
{
    public class DataService : IDataService
    {
        private HttpClient _httpClient { get; }

        private ILocalStorageService _localStorageService { get; }

        private ILoginService _loginService { get; }
        public DataService(HttpClient httpClient, IConfiguration config, ILocalStorageService localStorageService, ILoginService loginService)
        {
            httpClient.BaseAddress = new Uri(config.GetValue<string>("AppSettings:BuddyRewardsBaseAddress"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Blazor Web Assembly");
            _httpClient = httpClient;
            _loginService = loginService;
            _localStorageService = localStorageService;
        }
        /// <summary>
        /// REST API call to search Member data
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<List<MemberDTO>> SearchMembers(string key)
        {
            string authToken = "";
            //Get AccessToken from local storage
            authToken = await _localStorageService.GetItemAsync<string>("accessToken");
            if (authToken == null)
            {
                throw new Exception("Access Token not found");
            }
            //Add AccessToken to the Bearer header
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

            //REST API call for Search
            var response = await _httpClient.GetAsync($"BuddyRewards/searchmember/{key}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<MemberDTO>>();
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
        /// REST API call to get average monthly rating for a member
        /// </summary>
        /// <param name="ratingFor"></param>
        /// <returns></returns>
        public async Task<List<GraphDataDTO>> GetAverageRatings(string ratingFor)
        {
            string authToken = "";
            //Get AccessToken from local storage
            authToken = await _localStorageService.GetItemAsync<string>("accessToken");
            if (authToken == null)
            {
                throw new Exception("Access Token not found");
            }
            //Add AccessToken to the Bearer header
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

            //REST API call to get the average Ratings
            var response = await _httpClient.GetAsync($"BuddyRewards/getaverageRatings/{ratingFor}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<GraphDataDTO>>();
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
        /// REST API call to get member data
        /// </summary>
        /// <param name="tableState"></param>
        /// <returns></returns>
        public async Task<TableDataDTO<MemberDTO>> GetMembers(TableStateDTO tableState)
        {
            string authToken = "";
            //Get AccessToken from local storage
            authToken = await _localStorageService.GetItemAsync<string>("accessToken");
            if (authToken == null)
            {
                throw new Exception("Access Token not found");
            }
            //Add AccessToken to the Bearer header
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);
            
            //REST API call to get the member data
            var response = await _httpClient.PostAsJsonAsync($"BuddyRewards/getmembers", tableState);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TableDataDTO<MemberDTO>>();
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
        /// REST API call to get ratings for a member
        /// </summary>
        /// <param name="tableState"></param>
        /// <returns></returns>
        public async Task<TableDataDTO<RatingDTO>> GetRatings(TableStateDTO tableState)
        {
            string authToken = "";
            //Get AccessToken from local storage
            authToken = await _localStorageService.GetItemAsync<string>("accessToken");
            if (authToken == null)
            {
                throw new Exception("Access Token not found");
            }
            //Add AccessToken to the Bearer header
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);
            
            //REST API call to get the ratings for the member
            var response = await _httpClient.PostAsJsonAsync($"BuddyRewards/getratings", tableState);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TableDataDTO<RatingDTO>>();
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
        /// REST API call to add Rating to a member
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public async Task<bool> SubmitRating(RatingDTO rating)
        {
            string authToken = "";
            //Get AccessToken from local storage
            authToken = await _localStorageService.GetItemAsync<string>("accessToken");
            if (authToken == null)
            {
                throw new Exception("Access Token not found");
            }
            //Add AccessToken to the Bearer header
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);
            
            //REST API call to add the rating for a member
            var response = await _httpClient.PostAsJsonAsync($"BuddyRewards/addrating", rating);
            if (response.IsSuccessStatusCode)
            {
                return true;
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
