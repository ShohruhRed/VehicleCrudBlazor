namespace CrudBlazor.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleType>().HasData(
                 new VehicleType { Id = 1, Type = "SPG" },
                 new VehicleType { Id = 2, Type = "Heavy tank" }
                );

            modelBuilder.Entity<Vehicle>().HasData(
                 new Vehicle
                 {
                     Id = 1,
                     VehicleModel = "T95/FV4201 Chieftain",
                     VehicleLevel = "10",
                     VehicleCountry = "Great Britain",                     
                     VehicleTypeId = 1,

                 },
                 new Vehicle
                 {
                    Id = 2,
                    VehicleModel = "Type 5 Heavy",
                    VehicleLevel = "10",
                    VehicleCountry = "Japan",                
                    VehicleTypeId = 2,
                 }
                 
             );

        }
        
    }
}
