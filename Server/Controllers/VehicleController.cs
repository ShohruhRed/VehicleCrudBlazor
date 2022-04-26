using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        public static List<VehicleType> vehicleTypes = new List<VehicleType>
        {
            new VehicleType{Id = 1, Type = "SPG"},
            new VehicleType{Id = 2, Type = "Heavy tank"}
        };

        public static List<Vehicle> vehicles = new List<Vehicle>
        {
            new Vehicle{
                Id = 1,
                VehicleModel = "T95/FV4201 Chieftain",
                VehicleLevel = "10",
                VehicleCountry = "Great Britain",
                VehicleType = vehicleTypes[0]
            },
            new Vehicle{
                Id = 2,
                VehicleModel = "Type 5 Heavy",
                VehicleLevel = "10",
                VehicleCountry = "Japan",
                VehicleType = vehicleTypes[1]
            },
        };
        
        [HttpGet]
        public async Task<ActionResult<List<Vehicle>>> GetVehicles()
        {
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetSingleVehicle(int id)
        {
            var vehicle = vehicles.FirstOrDefault(h => h.Id == id);
            if(vehicle == null)
            {
                return NotFound("Sorry, no vehicle here. :/");
            }
            return Ok(vehicle);
        }

    }
}
