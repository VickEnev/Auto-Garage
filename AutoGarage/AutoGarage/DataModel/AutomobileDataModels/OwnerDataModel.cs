using System.Collections.Generic;

namespace AutoGarage.DataModel.AutomobileDataModels
{
    public class OwnerDataModel
    {
        int Id { get; set; }
        string TelephoneNumber { get; set; }
        string Name { get; set; }
        public List<AutomobileModel> Automobiles { get; set; } 
    }
}