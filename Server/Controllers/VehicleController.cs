using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly DataContext _context;

        public VehicleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Vehicle>>> GetVehicles()
        {
            var vehicles = await _context.Vehicles.Include(v => v.VehicleType).ToListAsync();
            return Ok(vehicles);
        }

        [HttpGet("vehicletypes")]
        public async Task<ActionResult<List<VehicleType>>> GetVehicleTypes()
        {
            var vehicleTypes = await _context.VehicleTypes.ToListAsync();
            return Ok(vehicleTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetSingleVehicle(int id)
        {
            var vehicle = await _context.Vehicles
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(v => v.Id == id);
            if(vehicle == null)
            {
                return NotFound("Sorry, no vehicle here. :/");
            }
            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<ActionResult<List<Vehicle>>> CreateVehicle(Vehicle vehicle)
        {
            vehicle.VehicleType = null;
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
         
            return Ok(await GetDbVehicles());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Vehicle>>> UpdateVehicle(Vehicle vehicle, int id)
        {
            var dbVehicle = await _context.Vehicles
                 .Include(v => v.VehicleType)
                 .FirstOrDefaultAsync(v => v.Id == id);
            if (dbVehicle == null)
                return NotFound("Sorry, but no vehicle for you. :/");

            dbVehicle.VehicleModel = vehicle.VehicleModel;
            dbVehicle.VehicleLevel = vehicle.VehicleLevel;
            dbVehicle.VehicleCountry = vehicle.VehicleCountry;
            dbVehicle.VehicleTypeId = vehicle.VehicleTypeId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbVehicles());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Vehicle>>> DeleteVehicle(int id)
        {
            var dbVehicle = await _context.Vehicles
                 .Include(v => v.VehicleType)
                 .FirstOrDefaultAsync(v => v.Id == id);
            if (dbVehicle == null)
                return NotFound("Sorry, but no vehicle for you. :/");

            _context.Vehicles.Remove(dbVehicle);
            await _context.SaveChangesAsync();

            return Ok(await GetDbVehicles());
        }

        private async Task<List<Vehicle>> GetDbVehicles()
        {
            return await _context.Vehicles.Include(v => v.VehicleType).ToListAsync();
        }

    }
}
