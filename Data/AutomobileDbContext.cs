using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoGarage.DataModel.AutomobileDataModels;
using AutoGarage.DataModel.SparePartsDataModels;
using AutoGarage.DataModel.MaintenanceCardDataModel;



namespace AutoGarage.Data
{

    /* - Car Parts will need to select and Engine or Engines to bind to, 
       when you are adding a part you need to have a dropdown with all available engines in the db and select one from there or 
       if there are no engines that match that part you need to add the engine and then add the part 

     -  */


    public class AutomobileDbContext : DbContext
    {
        // Automobile Table
        /// <summary>
        /// Main Automobile Table
        /// </summary>
        public DbSet<AutomobileDataModel> Automobiles { get; set; }

        public DbSet<BrandDataModel> Brands { get; set; }

        /// <summary>
        /// Car Models
        /// </summary>
        public DbSet<CarModelDataModel> Models { get; set; }

        public DbSet<ColorDataModel> Colors { get; set; }

        public DbSet<EngineDataModel> Engines { get; set; }

        public DbSet<OwnerDataModel> Owners { get; set; }

        // Spare Parts Table
        public DbSet<SparePartsDataModel> Spare_Parts { get; set; }

        // Maintenance Cards 
        public DbSet<MaintenanceCardDataModel> Maintenances { get; set; }


        public AutomobileDbContext() : base("name=GarageDatabase")
        {

        }

        
    }
}
