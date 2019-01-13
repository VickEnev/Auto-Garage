using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutoGarage.DataModel.AutomobileDataModels
{
    public class AutomobileDataModel
    {

        public AutomobileDataModel()
        {
            MaintenanceCards = new HashSet<MaintenanceCardDataModel.MaintenanceCardDataModel>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int EngineId { get; set; }
        public virtual EngineDataModel Engine { get; set; } // FK - Engine
        

        public string ChassiNumber { get; set; } // nomer na rama
        public string DRN { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }

        public virtual OwnerDataModel Owner { get; set; }
        public int OwnerId { get; set; }

        public virtual ColorDataModel Color { get; set; }
        public int ColorId { get; set; }

        
        public virtual ICollection<MaintenanceCardDataModel.MaintenanceCardDataModel> MaintenanceCards { get; set; }

        
    }
}
