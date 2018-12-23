using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGarage.DataModel.SaveTokens
{
    public class AutomobileSaveToken
    {
        public string DRN { get; set; }
        public int EngineID { get; set; }
        public int Year { get; set; }
        public string ChassiNumber { get; set; }
        public int ColorId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerTelephoneNumber { get; set; }
        public string Description { get; set; }
    }
}
