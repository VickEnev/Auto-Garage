using AutoGarage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGarage.Controller
{
    public class AutomobileController
    {
        public List<CarViewModel> getCarViewModel()
        {
            return new List<CarViewModel>()
            {
            new CarViewModel() { DRN = "В1234КВ", ModelName="Carisma"},
            new CarViewModel() { DRN = "В1204КВ", ModelName="2"},
            new CarViewModel() { DRN = "В1237КВ", ModelName="Passat"}
            };
        }
    }
}
