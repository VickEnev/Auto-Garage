using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGarage.DataModel.AutomobileDataModels;

namespace AutoGarage.DataModel.SparePartsDataModels
{
    public class SparePartsDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }      
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
    }
}
