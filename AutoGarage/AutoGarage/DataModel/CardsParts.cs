using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoGarage.DataModel
{
    public class CardsParts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int MaintenanceCardId { get; set; }
        public MaintenanceCardDataModel.MaintenanceCardDataModel MaintenanceCard { get; set; }
        public int SparePartId { get; set; }
        public SparePartsDataModels.SparePartsDataModel SparePart { get; set; }

    }
}
