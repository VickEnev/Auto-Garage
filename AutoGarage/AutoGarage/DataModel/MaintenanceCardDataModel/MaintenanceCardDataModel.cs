using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGarage.DataModel.AutomobileDataModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoGarage.DataModel.MaintenanceCardDataModel
{
    public class MaintenanceCardDataModel
    {
        public MaintenanceCardDataModel()
        {
            this.Parts = new HashSet<SparePartsDataModels.SparePartsDataModel>();
            DateOfArrival = DateTime.Now;
            DateOfDeparture = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateOfArrival { get; set; }

        public DateTime DateOfDeparture { get; set; }
       
        public string Description { get; set; }
        public string EmployeeName { get; set; }
        public virtual ICollection<SparePartsDataModels.SparePartsDataModel> Parts { get; set; }
        public decimal TotalPrice { get; set; }

        public bool Finished { get; set; }

    }
}
