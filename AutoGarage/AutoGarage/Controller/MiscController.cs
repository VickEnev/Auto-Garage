using AutoGarage.Data;
using AutoGarage.DataModel.AutomobileDataModels;
using AutoGarage.DataModel.SparePartsDataModels;
using AutoGarage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
namespace AutoGarage.Controller
{
    /// <summary>
    /// Управлява по-малките операции с по-проста логика
    /// </summary>
    public class MiscController : Controller
    {


        public MiscController(AutomobileDbContext context) : base(context)
        {
            this.context = context;
        }

        // read methods 

        /// <summary>
        /// Връща всички марки
        /// </summary>
        /// <returns></returns>
        public List<object> GetAllBrands()
        {
            try
            {
                if (context.Brands != null)
                {
                    var result = new List<object>();
                    foreach (var b in context.Brands)
                    {
                        result.Add(new BrandViewModel() { Id = b.Id, Name = b.Name });
                    }
                    return result;
                }
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }


            return null;
        }
        /// <summary>
        /// Връща всички модели на автомобили в базата данни
        /// </summary>
        /// <returns></returns>
        public List<CarModelViewModel> GetAllModels()
        {
            try
            {
                if (context.Models != null)
                {
                    var result = new List<CarModelViewModel>();
                    foreach (var b in context.Models)
                    {
                        result.Add(new CarModelViewModel() { Id = b.Id, Name = b.Name });
                    }
                    return result;
                }

            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }


            return null;
        }
        /// <summary>
        /// Връща всички модели за специфична марка
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public List<CarModelViewModel> GetAllModels(string brandName)
        {
            try
            {
                if (context.Models != null)
                {
                    var result = new List<CarModelViewModel>();
                    foreach (var b in context.Models)
                    {
                        if (b.CarBrand.Name == brandName)
                            result.Add(new CarModelViewModel() { Id = b.Id, Name = b.Name });
                    }
                    return result;
                }

            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }


            return null;
        }

        /// <summary>
        /// Връща всички цветове
        /// </summary>
        /// <returns></returns>
        public List<ColorViewModel> GetAllColors()
        {
            try
            {
                if (context.Colors != null)
                {
                    var result = new List<ColorViewModel>();
                    foreach (var b in context.Colors)
                    {
                        result.Add(new ColorViewModel() { Id = b.Id, Name = b.Name });
                    }
                    return result;
                }
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }



            return null;
        }

        /// <summary>
        /// Връща всички двигатели по име на модел
        /// </summary>
        /// <param name="ModelName"></param>
        /// <returns></returns>
        public List<EngineViewModel> GetAllEnginesByModel(string ModelName)
        {
            try
            {
                if (context.Engines != null)
                {
                    var result = new List<EngineViewModel>();
                    foreach (var b in context.Engines.Where(e => e.CarModel.Name == ModelName))
                    {
                        result.Add(new EngineViewModel() { Id = b.Id, EngineNumber = b.EngineNumber, Volume = b.Volume });
                    }
                    return result;
                }
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }



            return null;
        }
        /// <summary>
        /// Връща модел по име на модел и име на марка
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="brandName"></param>
        /// <returns></returns>
        public CarModelDataModel GetModelByName(string modelName, string brandName)
        {
            try
            {
                CarModelDataModel result = new CarModelDataModel();
                result = context.Models.FirstOrDefault(m => m.Name == modelName && m.CarBrand.Name == brandName);
                return result;
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }
            return null;
        }

        /// <summary>
        /// Връща View модел на всички части в базата данни
        /// </summary>
        /// <returns></returns>
        public IList<PartsViewModel> GetSparePartsViewModels()
        {
            var result = new List<PartsViewModel>();
            var parts = context.Spare_Parts.ToList();
            foreach (var p in parts)
            {
                result.Add(new PartsViewModel() { Id = p.Id, Name = p.Name, Price = p.Price });
            }
            return result;
        }

        /// <summary>
        /// Връща част по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SparePartsDataModel GetPartsById(int id)
        {
            return context.Spare_Parts.FirstOrDefault(p => p.Id == id);
        }


        // Методи за записване на даннови модели в базата
        

        public void WriteBrandDataModelToDatabase(BrandDataModel model)
        {
            context.Brands.Add(model);
            context.SaveChanges();
        }

        public void WriteColorsDataModelToDatabase(List<ColorDataModel> models)
        {
            context.Colors.AddRange(models);
            context.SaveChanges();
        }

        public void WriteBrandDataModelToDatabase(List<BrandDataModel> models)
        {
            context.Brands.AddRange(models);
            context.SaveChanges();
        }

        public void WriteCarModelsDataModelsToDatabase(List<CarModelDataModel> models)
        {
            context.Models.AddRange(models);
            context.SaveChanges();
        }

        public void WriteEngineDataModelToDatabase(EngineDataModel model)
        {
            context.Engines.Add(model);
            context.SaveChanges();
        }

        /// <summary>
        /// Създава или подновява част в базата. Ако частта вече е в базата я подновява, а ако я няма я създава.
        /// </summary>
        /// <param name="model"></param>
        public void AddOrUpdateParts(SparePartsDataModel model)
        {
            var part = context.Spare_Parts.FirstOrDefault(s => s.Id == model.Id);
            if (part != null)
            {
                part.Name = model.Name;
                part.Price = model.Price;


                this.EditEntity<SparePartsDataModel>(part);
            }
            else
            {
                context.Spare_Parts.Add(model);
                context.SaveChanges();
            }

        }

        /// <summary>
        /// Изтрива част по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeletePartById(int id)
        {
            var part = context.Spare_Parts.FirstOrDefault(p => p.Id == id);
            if (context.Maintenances.FirstOrDefault(m => m.Parts.FirstOrDefault(p=>p.Id == id) != null) != null)
            {
                return false;
            }

            context.Spare_Parts.Remove(part);
            context.SaveChanges();

            return true;
        }
        /// <summary>
        /// Създава връзката Много към Много в базата данни
        /// </summary>
        /// <param name="idPart"></param>
        /// <param name="idCard"></param>
        public void LinkPartsToMaintenanceCards(int idPart, int idCard)
        {
            var part = context.Spare_Parts.First(p => p.Id == idPart);
            var mc = context.Maintenances.First(m => m.Id == idCard);
            part.MaintenanceCards.Add(mc);
            mc.Parts.Add(part);

            context.SaveChanges();
        }

        /// <summary>
        /// Прекратява връзката Много към Много в базата данни
        /// </summary>
        /// <param name="idPart"></param>
        /// <param name="idCard"></param>
        public void UnlinkPartsAndMaintenanceCards(int idPart, int idCard)
        {
            var part = context.Spare_Parts.First(p => p.Id == idPart);
            var mc = context.Maintenances.First(m => m.Id == idCard);

            part.MaintenanceCards.Remove(mc);
            mc.Parts.Remove(part);

            context.SaveChanges();
        }
    }
}
