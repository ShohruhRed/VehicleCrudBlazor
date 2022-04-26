using System.Net.Http.Json;

namespace CrudBlazor.Client.Services.VehicleService
{
    public class VehicleService : IVehicleService
    {
        private readonly HttpClient _http;

        public VehicleService(HttpClient http)
        {
            _http = http;
        }
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public List<VehicleType> VehicleTypes { get; set; } = new List<VehicleType>();

        public Task<Vehicle> GetSingleVehicle(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetVehicles()
        {
            var result = await _http.GetFromJsonAsync<List<Vehicle>>("api/vehicle");
            if (result != null)
                Vehicles = result;
        }

        public async Task GetVehicleTypes()
        {
           
        }
    }
}
