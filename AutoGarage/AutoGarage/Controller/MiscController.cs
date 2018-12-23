using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGarage.ViewModels;
using AutoGarage.Data;
using AutoGarage.DataModel.AutomobileDataModels;


namespace AutoGarage.Controller
{
    public class MiscController
    {
        private AutomobileDbContext Context { get; set; }

        public MiscController(AutomobileDbContext context)
        {
            this.Context = context;
        }

        // read methods 
        public List<object> GetAllBrands()
        {
            try
            {
                if (Context.Brands != null)
                {
                    var result = new List<object>();
                    foreach (var b in Context.Brands)
                    {
                        result.Add(new BrandViewModel() { Id = b.Id, Name = b.Name });
                    }
                    return result;
                }
            }
            catch(Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }


            return null;
        }
        /// <summary>
        /// Gets all car models in the database.
        /// </summary>
        /// <returns></returns>
        public List<CarModelViewModel> GetAllModels()
        {
            try
            {
                if (Context.Models != null)
                {
                    var result = new List<CarModelViewModel>();
                    foreach (var b in Context.Models)
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
        /// Gets all car models for a specific brand.
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public List<CarModelViewModel> GetAllModels(string brandName)
        {
            try
            {
                if (Context.Models != null)
                {
                    var result = new List<CarModelViewModel>();
                    foreach (var b in Context.Models)
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

        public List<ColorViewModel> GetAllColors()
        {
            try
            {
                if (Context.Colors != null)
                {
                    var result = new List<ColorViewModel>();
                    foreach (var b in Context.Colors)
                    {
                        result.Add(new ColorViewModel() { Id = b.Id, Name = b.Name });
                    }
                    return result;
                }
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }
          


            return null;
        }


        public List<EngineViewModel> GetAllEnginesByModel(string ModelName)
        {
            try
            {
                if (Context.Engines != null)
                {
                    var result = new List<EngineViewModel>();
                    foreach (var b in Context.Engines.Where(e => e.CarModel.Name == ModelName))
                    {
                        result.Add(new EngineViewModel() { Id = b.Id, EngineNumber = b.EngineNumber, Volume = b.Volume });
                    }
                    return result;
                }
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }
           


            return null;
        }

        public CarModelDataModel GetModelByName(string modelName, string brandName)
        {
            try
            {
                CarModelDataModel result = new CarModelDataModel();
                result = Context.Models.FirstOrDefault(m => m.Name == modelName && m.CarBrand.Name == brandName);
                return result;
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }
            return null;
        }

        // write methods

        public void WriteBrandDataModelToDatabase(BrandDataModel model)
        {

            Context.Brands.Add(model);
            Context.SaveChanges();

        }

        public void WriteColorsDataModelToDatabase(List<ColorDataModel> models)
        {

            Context.Colors.AddRange(models);
            Context.SaveChanges();

        }

        public void WriteBrandDataModelToDatabase(List<BrandDataModel> models)
        {

            Context.Brands.AddRange(models);
            Context.SaveChanges();

        }

        public void WriteCarModelsDataModelsToDatabase(List<CarModelDataModel> models)
        {

            Context.Models.AddRange(models);
            Context.SaveChanges();

        }

        public void WriteEngineDataModelToDatabase(EngineDataModel model)
        {

            Context.Engines.Add(model);
            Context.SaveChanges();

        }



    }
}
