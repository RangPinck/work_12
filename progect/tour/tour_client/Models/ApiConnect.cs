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

        public async Task<string> GetTours()
        {
            HttpResponseMessage response = await HttpClient.GetAsync("v1/Tour/get_tours");
            if (response.StatusCode > (HttpStatusCode)399)
            {
                return string.Empty;
            }
            string responceBody = await response.Content.ReadAsStringAsync();
            return responceBody;
        }

        public async Task<string> GetToursTypes()
        {
            HttpResponseMessage response = await HttpClient.GetAsync("v1/TourTypes/get_tours_types");
            if (response.StatusCode > (HttpStatusCode)399)
            {
                return string.Empty;
            }
            string responceBody = await response.Content.ReadAsStringAsync();
            return responceBody;
        }

        public async Task<string> GetHotels()
        {
            HttpResponseMessage response = await HttpClient.GetAsync("v1/Hotel/get_hotels");
            if (response.StatusCode > (HttpStatusCode)399)
            {
                return string.Empty;
            }
            string responceBody = await response.Content.ReadAsStringAsync();
            return responceBody;
        }

        public async Task DeleteHotel(int hotelId)
        {
            HttpResponseMessage response = await HttpClient.DeleteAsync($"v1/Hotel/delete_hotel?hotelId={hotelId}");
        }
    }
}
