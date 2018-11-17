using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGarage.DataModel
{
    public class EngineDataModel
    {
        public int Id { get; set; }
        public string Volume { get; set; }
        public string EngineNumber { get; set; }
        public CarModelDataModel CarModel { get; set; }
    }
}
