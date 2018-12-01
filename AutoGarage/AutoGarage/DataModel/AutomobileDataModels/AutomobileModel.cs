using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGarage.DataModel.MaintenanceCardDataModel;

namespace AutoGarage.DataModel.AutomobileDataModels
{
    public class AutomobileModel
    {

        public AutomobileModel()
        {
            maintenanceCards = new List<MaintenanceCardDataModel.MaintenanceCardDataModel>();
        }

        public int Id { get; set; }

        public virtual EngineDataModel Engine { get; set; } // FK - Engine
        public int EngineId { get; set; }

        public string ChassiNumber { get; set; } // nomer na rama
        public string DRN { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }

        public virtual OwnerDataModel Owner { get; set; }
        public int OwnerId { get; set; }

        public virtual ColorDataModel Color { get; set; }
        public int ColorId { get; set; }


        public virtual List<MaintenanceCardDataModel.MaintenanceCardDataModel> maintenanceCards { get; set; }

        public bool IsDeleted { get; set; }
    }
}
