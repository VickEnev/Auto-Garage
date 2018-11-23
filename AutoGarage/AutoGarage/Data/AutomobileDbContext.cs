using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoGarage.DataModel.AutomobileDataModels;
using AutoGarage.DataModel.SparePartsDataModels;

namespace AutoGarage.Data
{
    /*
      - Car Parts will need to select and Engine or Engines to bind to, 
        when you are adding a part you need to have a dropdown with all available engines in the db and select one from there or 
        if there are no engines that match that part you need to add the engine and then add the part 

      -  

     */
    public class AutomobileDbContext : DbContext
    {
        // Automobile Table
        public DbSet<AutomobileModel> Automobiles { get; set; }
        public DbSet<BrandDataModel> Brands { get; set; }
        public DbSet<CarModelDataModel> Models { get; set; }
        public DbSet<ColorDataModel> Colors { get; set; }
        public DbSet<EngineDataModel> Engines { get; set; }
        public DbSet<OwnerDataModel> Owners { get; set; }

        // Spare Parts Table
        public DbSet<SparePartsDataModel> Spare_Parts { get; set; }

        // Maintenance Cards 



    }
}
