using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGarage.DataModel.AutomobileDataModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoGarage.DataModel.SparePartsDataModels
{
    public class SparePartsDataModel
    {
        public SparePartsDataModel()
        {
          this.MaintenanceCards = new HashSet<MaintenanceCardDataModel.MaintenanceCardDataModel>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }      
        public decimal Price { get; set; }
        

        public virtual ICollection<MaintenanceCardDataModel.MaintenanceCardDataModel> MaintenanceCards { get; set; }
    }
}
