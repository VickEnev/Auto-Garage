using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGarage.DataModel
{
    public class AutomobileModel
    {
        public int Id { get; set; }
        public EngineDataModel Engine { get; set; } // FK - Engine
        public string CoupeNumber { get; set; } // nomer na rama
        public string DRN { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public OwnerDataModel Owner { get; set; }
        public ColorDataModel Color { get; set; }
    }
}
