using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGarage.Controller;

namespace AutoGarage.Data
{
    public class Dependancies
    {
        private AutomobileDbContext DatabaseContext { get; set; }
        public MiscController MiscController { get; private set; }
        public AutomobileController AutomobileController { get; private set; }

        public Dependancies()
        {
            DatabaseContext = new AutomobileDbContext();
            MiscController = new MiscController(DatabaseContext);
            AutomobileController = new AutomobileController(DatabaseContext);
        }


    }
}