using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGarage.Data
{
    /// <summary>
    /// DDL controller, controls database functions.
    /// </summary>
    public class DatabaseController
    {
        public bool CreateIfNotExists(out Exception ex)
        {
            try
            {
                Task<bool> t = Task<bool>.Factory.StartNew(() =>
                {
                    using (var db = new Data.AutomobileDbContext())
                    {
                        db.Database.CreateIfNotExists();
                    }
                    return true;
                });
                ex = null;
                return t.Result;
            }
            catch(Exception e)
            {
                ex = e;
                return false;
            }
        }
    }
}
