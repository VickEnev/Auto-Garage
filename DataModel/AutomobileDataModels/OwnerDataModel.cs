using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoGarage.DataModel.AutomobileDataModels
{
    public class OwnerDataModel
    {
        public OwnerDataModel()
        {
            Automobiles = new List<AutomobileDataModel>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TelephoneNumber { get; set; }
        public string Name { get; set; }

        public virtual List<AutomobileDataModel> Automobiles { get; set; } 
    }
}