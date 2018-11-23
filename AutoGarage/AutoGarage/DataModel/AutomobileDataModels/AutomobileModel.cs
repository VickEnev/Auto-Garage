using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGarage.DataModel.AutomobileDataModels
{
    public class AutomobileModel
    {
        public int Id { get; set; }

        public EngineDataModel Engine { get; set; } // FK - Engine
        public int EngineId { get; set; }

        public string ChassiNumber { get; set; } // nomer na rama
        public string DRN { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }

        public OwnerDataModel Owner { get; set; }
        public int OwnerId { get; set; }

        public ColorDataModel Color { get; set; }
        public int ColorId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
