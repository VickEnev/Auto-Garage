using AutoGarage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGarage.DataModel.AutomobileDataModels;
using AutoGarage.DataModel.SaveTokens;
using AutoGarage.DataModel.MaintenanceCardDataModel;
using System.Data.Entity.Infrastructure;

namespace AutoGarage.Controller
{
    public class AutomobileController : Controller
    {
        public AutomobileController(Data.AutomobileDbContext context) : base(context) { }
      
        public AutomobileDataModel GetAutomobileDataModel(int Id)
        {
            return context.Automobiles.FirstOrDefault(a => a.Id == Id);
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
                        if (!a.IsDeleted)
                        {
                            CarModelDataModel carModel;
                            if (a.Engine.CarModel == null)
                                carModel = MapIdToClass(a.Engine.CarModelId);
                            else
                                carModel = a.Engine.CarModel;

                            result.Add(new CarViewModel() { DRN = a.DRN, ModelName = carModel.Name, ID = a.Id });
                        }
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
            var mc = new DataModel.MaintenanceCardDataModel.MaintenanceCardDataModel()
            {
                Description = "",
                EmployeeName = "",
                Parts = new List<DataModel.SparePartsDataModels.SparePartsDataModel>(),
                TotalPrice = 0,
                Finished = false
            };


            model.MaintenanceCard = mc;
            model.MaintenanceCardId = mc.Id;

            context.Automobiles.Add(model);
            context.SaveChanges();
        }

        private AutomobileDataModel MakeModelFromToken(AutomobileSaveToken token)
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

            if (!owner.Automobiles.Contains(result))
                owner.Automobiles.Add(result);

            return result;
        }

        public AutomobileDataModel LoadAutomobile(int Id)
        {
            return context.Automobiles.FirstOrDefault(a => a.Id == Id);
        }

        public void UpdateAutomobile(AutomobileSaveToken token, AutomobileDataModel model)
        {
            var updatedModel = MakeModelFromToken(token);
            updatedModel.Id = model.Id;
            var _model = context.Automobiles.FirstOrDefault(a => a.Id == model.Id);
            if (_model != null)
            {
                _model.ChassiNumber = updatedModel.ChassiNumber;
                _model.Color = updatedModel.Color;
                _model.ColorId = updatedModel.ColorId;
                _model.Description = updatedModel.Description;
                _model.DRN = updatedModel.DRN;
                _model.Engine = updatedModel.Engine;
                _model.EngineId = updatedModel.EngineId;
                _model.IsDeleted = updatedModel.IsDeleted;
                _model.Owner = updatedModel.Owner;
                _model.OwnerId = updatedModel.OwnerId;
                _model.Year = updatedModel.Year;
            }
            EditEntity<AutomobileDataModel>(_model);
        }

        public void DeleteAutomobile(int Id)
        {
            var model = context.Automobiles.FirstOrDefault(a => a.Id == Id);
            model.IsDeleted = true;
            EditEntity<AutomobileDataModel>(model);
          
        }


        public ServiceHistoryViewModel GetServiceHistoryViewModel(int id)
        {
            var result = new ServiceHistoryViewModel();
            var auto = context.Automobiles.FirstOrDefault(a => a.Id == id);
            result.DRN = auto.DRN;
            result.Brand = new BrandViewModel()
            {
                Name = auto.Engine.CarModel.CarBrand.Name,
                Id = auto.Engine.CarModel.Id
            };

            result.Model = new CarModelViewModel()
            {
                Name = auto.Engine.CarModel.Name,
                Id = auto.Engine.CarModel.Id
            };

            result.Volume = auto.Engine.Volume;
            result.HP = auto.Engine.Horsepower;

            return result;
        }

        public IList<MaintenanceCardDataModel> GetMaintenanceCardDataModelsByChassisCode(string chassisNumber)
        {
            IList<MaintenanceCardDataModel> result = new List<MaintenanceCardDataModel>();
            foreach(var a in context.Automobiles)
            {
                if(a.ChassiNumber == chassisNumber)
                    result.Add(a.MaintenanceCard);
            }
            return result; 
        }

        public string GetOwnerNameByMaintenanceCardId (int id)
        {
            return context.Automobiles.First(a => a.MaintenanceCardId == id).Owner.Name;     
        }

        public void EditMaintenanceCardModel(int id)
        {

        }


    }
}
