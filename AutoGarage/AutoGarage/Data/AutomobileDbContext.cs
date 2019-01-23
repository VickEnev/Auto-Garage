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
        
        /// <summary>
        /// Таблицата за автомобили
        /// </summary>
        public DbSet<AutomobileDataModel> Automobiles { get; set; }

        /// <summary>
        /// Таблицата за марки
        /// </summary>
        public DbSet<BrandDataModel> Brands { get; set; }

        /// <summary>
        /// Таблицата за модел на автомобили
        /// </summary>
        public DbSet<CarModelDataModel> Models { get; set; }

        /// <summary>
        /// Таблицата за цветове
        /// </summary>
        public DbSet<ColorDataModel> Colors { get; set; }

        /// <summary>
        /// Таблицата за двигатели
        /// </summary>
        public DbSet<EngineDataModel> Engines { get; set; }
        
        /// <summary>
        /// Таблицата за собственици
        /// </summary>
        public DbSet<OwnerDataModel> Owners { get; set; }

       /// <summary>
       /// Таблицата за резервни части
       /// </summary>
        public DbSet<SparePartsDataModel> Spare_Parts { get; set; }

       /// <summary>
       /// Таблицата за ремонтни карти
       /// </summary>
        public DbSet<MaintenanceCardDataModel> Maintenances { get; set; }

        /// <summary>
        /// Излишна таблица
        /// </summary>
        public DbSet<CardsParts> CardsParts { get; set; }

        /// <summary>
        /// Тука се случва цялото преобразувание на кода в таблица. Тук също задаваме и името на таблицата.
        /// </summary>
        public AutomobileDbContext() : base("name=GarageDatabase") { }


    }
}
