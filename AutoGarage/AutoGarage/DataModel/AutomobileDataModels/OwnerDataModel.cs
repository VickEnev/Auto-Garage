using System.Collections.Generic;

namespace AutoGarage.DataModel.AutomobileDataModels
{
    public class OwnerDataModel
    {
        public OwnerDataModel()
        {
            Automobiles = new List<AutomobileModel>();
        }

        public int Id { get; set; }
        public string TelephoneNumber { get; set; }
        public string Name { get; set; }

        public virtual List<AutomobileModel> Automobiles { get; set; } 
    }
}