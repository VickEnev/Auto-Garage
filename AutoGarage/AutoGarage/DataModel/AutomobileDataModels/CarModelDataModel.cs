using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGarage.DataModel.AutomobileDataModels
{
    public class CarModelDataModel
    {
        int Id { get; set; }
        string Name { get; set; }
        BrandDataModel CarBrand { get; set; }
    }
}
