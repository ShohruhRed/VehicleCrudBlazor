using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace CrudBlazor.Client.Services.VehicleService
{
    public class VehicleService : IVehicleService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public VehicleService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public List<VehicleType> VehicleTypes { get; set; } = new List<VehicleType>();

        public async Task CreateVehicle(Vehicle vehicle)
        {
            var result = await _http.PostAsJsonAsync("api/vehicle", vehicle);
            await SetVehicles(result);
        }

        private async Task SetVehicles(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Vehicle>>();
            Vehicles = response;
            _navigationManager.NavigateTo("vehicles");
        }

        public async Task DeleteVehicle(int id)
        {
            var result = await _http.DeleteAsync($"api/vehicle/{id}");            
            await SetVehicles(result);
        }

        public async Task<Vehicle> GetSingleVehicle(int id)
        {
            var result = await _http.GetFromJsonAsync<Vehicle>($"api/vehicle/{id}");
            if (result != null)
                return  result;
            throw new Exception("Vehicle not found!");
        }

        public async Task GetVehicles()
        {
            var result = await _http.GetFromJsonAsync<List<Vehicle>>("api/vehicle");
            if (result != null)
                Vehicles = result;
            
        }

        public async Task GetVehicleTypes()
        {
            var result = await _http.GetFromJsonAsync<List<VehicleType>>("api/vehicle/vehicletypes");
            if (result != null)
                VehicleTypes = result;
        }

        public async Task UpdateVehicle(Vehicle vehicle)
        {
            var result = await _http.PutAsJsonAsync($"api/vehicle/{vehicle.Id}", vehicle);            
            await SetVehicles(result);
        }
    }
}
