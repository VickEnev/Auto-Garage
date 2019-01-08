using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGarage.DataModel.AutomobileDataModels
{
    public class CarModelDataModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }


        public int CarBrandId { get; set; }

        public virtual BrandDataModel CarBrand { get; set; }
    }
}
