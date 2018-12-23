using AutoGarage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGarage.DataModel.AutomobileDataModels;
using AutoGarage.DataModel.SaveTokens;

namespace AutoGarage.Controller
{
    public class AutomobileController
    {

        private Data.AutomobileDbContext context { get; set; }

        public AutomobileController(Data.AutomobileDbContext context)
        {
            this.context = context;
        }

        public List<CarViewModel> getCarViewModel()
        {
            var result = new List<CarViewModel>();
            try
            {

                foreach (var a in context.Automobiles)
                {
                    try
                    {
                        CarModelDataModel carModel;
                        if (a.Engine.CarModel == null)
                            carModel = MapIdToClass(a.Engine.CarModelId);
                        else
                            carModel = a.Engine.CarModel;

                        result.Add(new CarViewModel() { DRN = a.DRN, ModelName = carModel.Name });
                     
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.ToString());
                    }

                }


            }
            catch (NullReferenceException n)
            {
                System.Diagnostics.Debug.WriteLine(n.ToString());
            }
            return result;
        }

        private CarModelDataModel MapIdToClass(int id)
        {
            try
            {
                var result = context.Models.First(i => i.Id == id);
                return result;
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }

            return null;
        }

        public void SaveAutomobile(AutomobileSaveToken token)
        {
            var model = MakeModelFromToken(token);
            context.Automobiles.Add(model);
            context.SaveChanges();

        }

        public AutomobileDataModel MakeModelFromToken(AutomobileSaveToken token)
        {
            OwnerDataModel owner = null;
            AutomobileDataModel result = new AutomobileDataModel();
            ColorDataModel color = null;
            EngineDataModel engine = null;


            owner = context.Owners.FirstOrDefault(o => o.TelephoneNumber == token.OwnerTelephoneNumber);
            color = context.Colors.FirstOrDefault(c => c.Id == token.ColorId);
            engine = context.Engines.FirstOrDefault(e => e.Id == token.EngineID);


            if (owner == null)
            {
                owner = new OwnerDataModel()
                {
                    Name = token.OwnerName,
                    TelephoneNumber = token.OwnerTelephoneNumber,
                };
            }

            result.DRN = token.DRN;
            result.ChassiNumber = token.ChassiNumber;
            result.Color = color;
            result.ColorId = color.Id;
            result.Description = token.Description;
            result.Engine = engine;
            result.EngineId = engine.Id;
            result.IsDeleted = false;
            result.Owner = owner;
            result.OwnerId = owner.Id;
            result.Year = token.Year;
            owner.Automobiles.Add(result);

            return result;
        }



    }
}
