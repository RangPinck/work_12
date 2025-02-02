using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace tour_client.Models
{
    public class ApiConnect
    {
        private HttpClient _httpClient;

        public HttpClient HttpClient{
            get => _httpClient;
        }

        public enum ConnectionState
        {
            Connected,
            DisconnectedInternet,
            DisconnectedDataBase
        }

        public ApiConnect(string baseUrl)
        {
            _httpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<ConnectionState> CheckConnection()
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync("v1/Connection/check_connection");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return ConnectionState.Connected;
                }

                return ConnectionState.DisconnectedDataBase;
            }
            catch (Exception)
            {
                return ConnectionState.DisconnectedInternet;
            }
            
        }
    }
}
