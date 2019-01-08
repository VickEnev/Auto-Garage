using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGarage.ViewModels
{
    public class EngineViewModel
    {
        public int Id { get; set; }
        public string Volume { get; set; }
        public string EngineNumber { get; set; }

        public override string ToString()
        {
            return $"{EngineNumber} | {Volume}";
        }
    }
}
