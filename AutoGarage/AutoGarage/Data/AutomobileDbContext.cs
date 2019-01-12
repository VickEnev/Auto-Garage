using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;
using AutoGarage.DataModel.AutomobileDataModels;
using AutoGarage.DataModel.SparePartsDataModels;
using AutoGarage.DataModel.MaintenanceCardDataModel;
using AutoGarage.DataModel;



namespace AutoGarage.Data
{



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

        public DbSet<CardsParts> CardsParts { get; set; }

        public AutomobileDbContext() : base("name=GarageDatabase") { }


    }
}
