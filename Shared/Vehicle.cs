using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBlazor.Shared
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string VehicleModel { get; set; } = string.Empty;
        public string VehicleLevel { get; set; } = string.Empty;
        public string VehicleCountry { get; set; }
        public VehicleType? VehicleType { get; set; }
        public int VehicleTypeId { get; set; }




    }
}
