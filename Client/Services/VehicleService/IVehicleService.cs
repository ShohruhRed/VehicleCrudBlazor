namespace CrudBlazor.Client.Services.VehicleService
{
    public interface IVehicleService
    { 
        List<Vehicle> Vehicles { get; set; }
        List<VehicleType> VehicleTypes { get; set; }
        Task GetVehicleTypes();
        Task GetVehicles();
        Task<Vehicle> GetSingleVehicle(int id);
        Task CreateVehicle(Vehicle vehicle);
        Task UpdateVehicle(Vehicle vehicle);
        Task DeleteVehicle(int id);

    }
}
