using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGarage.DataModel.AutomobileDataModels;

namespace AutoGarage.DataModel.MaintenanceCardDataModel
{
    public class MaintenanceCardDataModel
    {
        public MaintenanceCardDataModel()
        {
            Parts = new List<SparePartsDataModels.SparePartsDataModel>();
        }

        public int Id { get; set; }
        public DateTime DateOfArrival { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public int AutomobileId { get; set; }
        public virtual AutomobileModel Automobile { get; set; }
        public string Description { get; set; }
        public string EmployeeName { get; set; }
        public virtual List<SparePartsDataModels.SparePartsDataModel> Parts { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsDeleted { get; set; }
    }
}
