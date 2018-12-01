using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGarage.DataModel.AutomobileDataModels
{
    public class CarModelDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CarBrandId { get; set; }
        public virtual BrandDataModel  CarBrand { get; set; }
    }
}
