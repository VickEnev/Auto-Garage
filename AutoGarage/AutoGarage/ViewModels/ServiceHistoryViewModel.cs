using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGarage.ViewModels
{
    public class ServiceHistoryViewModel
    {
       
        public string DRN { get; set; }

        public BrandViewModel Brand { get; set; }

        public CarModelViewModel Model { get; set; }

        public string Volume { get; set; }

        public int HP { get; set; }


    }
}
