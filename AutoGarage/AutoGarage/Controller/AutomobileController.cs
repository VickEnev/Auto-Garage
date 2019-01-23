using AutoGarage.DataModel.AutomobileDataModels;
using AutoGarage.DataModel.MaintenanceCardDataModel;
using AutoGarage.DataModel.SaveTokens;
using AutoGarage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoGarage.Controller
{
    /// <summary>
    /// Този клас управлява таблиците - Automobiles, Owners, MaintenanceCards
    /// </summary>
    public class AutomobileController : Controller
    {
        /// <summary>
        /// Експлицитен конструктор приемащ context-та на базата данни.
        /// </summary>
        /// <param name="context">Контекста на базата - базата данни</param>
        public AutomobileController(Data.AutomobileDbContext context) : base(context) { }

        /// <summary>
        /// Връща автомобил по Id, ако съществува
        /// </summary>
        /// <param name="Id">Id-то на автомобила който искаме да вземем</param>
        /// <returns>Обект от тип AutomobileDataModel</returns>
        public AutomobileDataModel GetAutomobileDataModel(int Id)
        {
            return context.Automobiles.FirstOrDefault(a => a.Id == Id);
        }

        /// <summary>
        /// Взема всички автомобили от таблицата и ги връща като View модели
        /// </summary>
        /// <returns>Лист от View модели на автомобилите</returns>
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

                        result.Add(new CarViewModel() { DRN = a.DRN, ModelName = carModel.Name, ID = a.Id });

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
        /// <summary>
        /// Този метод се използва за да направи връзката между двигател и модел на автомобил. 
        /// </summary>
        /// <param name="id">Id-то на модела на автомобила</param>
        /// <returns></returns>
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
        /// <summary>
        /// Запазва автомобила в базата данни
        /// </summary>
        /// <param name="token">Това е обект съдържащ пълната информация за автомобила</param>
        public void SaveAutomobile(AutomobileSaveToken token)
        {
            var model = MakeModelFromToken(token);
            var mc = new MaintenanceCardDataModel();

            model.MaintenanceCards.Add(mc);
            mc.Automobile = model;
            mc.AutomobileId = model.Id;

            context.Automobiles.Add(model);
            context.Maintenances.Add(mc);
            context.SaveChanges();
        }

        /// <summary>
        /// Създава дата модел от пълната информация
        /// </summary>
        /// <param name="token">Пълната информация за автомобила взета от View-то -> AutomobileDataInput </param>
        /// <returns></returns>
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

            result.Owner = owner;
            result.OwnerId = owner.Id;
            result.Year = token.Year;

           

            if (!owner.Automobiles.Contains(result))
                owner.Automobiles.Add(result);

            return result;
        }
       
        /// <summary>
        /// Edit-ва вече съществуващ автомобил, логиката е сходна с тази на добавянето на автомобили
        /// </summary>
        /// <param name="token">Пълната информация за автомобила</param>
        /// <param name="model">Записа от таблицата, който edit-ваме</param>
        public void UpdateAutomobile(AutomobileSaveToken token, AutomobileDataModel model)
        {
            var updatedModel = MakeModelFromToken(token);
            updatedModel.Id = model.Id;
            var _model = context.Automobiles.FirstOrDefault(a => a.Id == model.Id);
            if (_model != null)
            {
                _model.ChassiNumber = updatedModel.ChassiNumber;
                _model.ColorId = updatedModel.ColorId;
                _model.Color = updatedModel.Color;               
                _model.Description = updatedModel.Description;
                _model.DRN = updatedModel.DRN;
                _model.Engine = updatedModel.Engine;
                _model.EngineId = updatedModel.EngineId;

                _model.Owner = updatedModel.Owner;
                _model.OwnerId = updatedModel.OwnerId;
                _model.Year = updatedModel.Year;
            }
            EditEntity<AutomobileDataModel>(_model);
        }
        /// <summary>
        /// Изтриване на автомобил по Id
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteAutomobile(int Id)
        {
            var model = context.Automobiles.FirstOrDefault(a => a.Id == Id);
            context.Automobiles.Remove(model);
            foreach (var m in model.MaintenanceCards)
            {
                context.Maintenances.Remove(m);
            }

            context.SaveChanges();
        }
        /// <summary>
        /// Връща името на собственика на автомобила
        /// </summary>
        /// <param name="automobileId"></param>
        /// <returns></returns>
        public string GetOwnerName(int automobileId)
        {
            return context.Automobiles.First(a => a.Id == automobileId).Owner.Name;
        }

        private CarViewModel ConvertDataModel_To_ViewModel(AutomobileDataModel model)
        {
            return new CarViewModel() { ID = model.Id, DRN = model.DRN, ModelName = model.Engine.CarModel.Name };
        }

        // queries 
        /// <summary>
        /// Заявка номер 1
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public CarViewModel[] GetAutomobilesAfterDate(DateTime date)
        {
            List<AutomobileDataModel> result = new List<AutomobileDataModel>();
            foreach (var auto in context.Automobiles)
            {
                foreach (var card in auto.MaintenanceCards)
                {
                    if (card.DateOfArrival.Date > date.Date)
                        if (!result.Contains(auto))
                            result.Add(auto);
                }
            }

            return Array.ConvertAll(result.ToArray(), ConvertDataModel_To_ViewModel);
        }

        /// <summary>
        /// Заявка номер 2
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public CarViewModel[] GetAutomobilesBeforeDate(DateTime date)
        {
            List<AutomobileDataModel> result = new List<AutomobileDataModel>();
            foreach (var auto in context.Automobiles)
            {
                foreach (var card in auto.MaintenanceCards)
                {
                    if (card.DateOfArrival.Date < date.Date)
                        if (!result.Contains(auto))
                            result.Add(auto);
                }
            }
            return Array.ConvertAll(result.ToArray(), ConvertDataModel_To_ViewModel);
        }
        /// <summary>
        /// Заявка номер 4
        /// </summary>
        /// <returns></returns>
        public CarViewModel[] GetAllAutomobilesWithUnfinishedRepairs()
        {
            List<AutomobileDataModel> result = new List<AutomobileDataModel>();
            foreach (var auto in context.Automobiles)
            {
                foreach (var card in auto.MaintenanceCards)
                {
                    if (!card.Finished)
                        if (!result.Contains(auto))
                            result.Add(auto);
                }
            }
            return Array.ConvertAll(result.ToArray(), ConvertDataModel_To_ViewModel);
        }

        // end queries

        // Maintenance card control
        /// <summary>
        /// Връща View модел, който съдържа информацията която ще се покаже в View-то ServiceHistory.
        /// </summary>
        /// <param name="id">Id-то на автомобила за който искаме да изкараме сервизна история</param>
        /// <returns></returns>
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
        /// <summary>
        /// Връща всички ремонтни карти за 1 автомобил
        /// </summary>
        /// <param name="chassisNumber">Номер на шасито, то е уникално за всеки един автомобил</param>
        /// <returns></returns>
        public IList<MaintenanceCardDataModel> GetMaintenanceCardDataModelsByChassisCode(string chassisNumber)
        {
            IList<MaintenanceCardDataModel> result = new List<MaintenanceCardDataModel>();
            foreach (var a in context.Automobiles)
            {
                if (a.ChassiNumber == chassisNumber)
                {
                    foreach (var card in a.MaintenanceCards)
                    {
                        result.Add(card);
                    }
                }
            }
            return result;
        }

      /// <summary>
      /// Записва ремонтнатат карта. Използва се за edit-ване на записа в базата данни
      /// </summary>
      /// <param name="Model"></param>
        public void SaveMaintenanceCard(MaintenanceCardDataModel Model)
        {
            EditEntity<MaintenanceCardDataModel>(Model);
            EditEntity<AutomobileDataModel>(context.Automobiles.First(a => a.Id == Model.AutomobileId));
        }

       
        /// <summary>
        /// Добавя празна ремонтна карта в базата данни
        /// </summary>
        /// <param name="automobileId"></param>
        public void AddMaintenanceCard(int automobileId)
        {
            var auto = context.Automobiles.FirstOrDefault(a => a.Id == automobileId);
            if (auto != null)
            {
                var mc = new MaintenanceCardDataModel();

                auto.MaintenanceCards.Add(mc);
                mc.Automobile = auto;
                mc.AutomobileId = auto.Id;


                context.Maintenances.Add(mc);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Изтрива ремонтна карта.
        /// </summary>
        /// <param name="automobileId">id-то на автомобила, на който принадлежи ремонтната карта</param>
        /// <param name="cardId">id-to на р. карта, която искаме да изтрием</param>
        public void DeleteMaintenanceCard(int automobileId, int cardId)
        {
            var auto = context.Automobiles.FirstOrDefault(a => a.Id == automobileId);
            var mc = context.Maintenances.FirstOrDefault(m => m.Id == cardId);

            auto.MaintenanceCards.Remove(mc);
            mc.Automobile = null;
            mc.AutomobileId = -1;

            context.Maintenances.Remove(mc);

            context.SaveChanges();
        }

        // end maintenance card control
    }
}
