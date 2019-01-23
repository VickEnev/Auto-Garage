using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AutoGarage.DataModel.AutomobileDataModels;
using AutoGarage.Controller;

namespace AutoGarage.Data
{
    /// <summary>
    /// Зарежда таблицата с предварително записане в .txt файл информация
    /// </summary>
    public class DatabaseInfoLoader
    {
        
        private string applicationPath { get; set; }
        private MiscController miscController { get; set; }
       

        public DatabaseInfoLoader(string ApplicationPath, MiscController miscController)
        {
            applicationPath = ApplicationPath;
            this.miscController = miscController;
        }

        /// <summary>
        /// Чете файла с цветове и ги записва в базата данни. След това записва, че е прочел файла в config.file
        /// </summary>
        /// <param name="FileName"></param>
        public void LoadColorsFromFile(string FileName = "")
        {
            if (FileName == "")
            {
                FileName = applicationPath + @"\Car Colors.txt";
            }

            if (File.Exists(applicationPath + @"\config.file") &&
                File.ReadAllLines(applicationPath + @"\config.file")[0] == "colors read")
            {
                return;
            }

           
            var models = new List<ColorDataModel>();

            foreach (var line in File.ReadAllLines(FileName))
            {
                models.Add(new ColorDataModel() { Name = line });
            }

            miscController.WriteColorsDataModelToDatabase(models);

            var obj = File.AppendText(applicationPath + @"\config.file");
            obj.WriteLine("colors read");
            obj.Close();
        }

        /// <summary>
        /// Записва марки и съответсващите им модели в базата данни. Това са 2 отделни файла, които се синхронизират в циклите по-долу и се прочитат.
        /// </summary>
        /// <param name="FileNameBrands"></param>
        /// <param name="FileNameModels"></param>
        public void LoadBrandsAndModels(string FileNameBrands = "", string FileNameModels = "")
        {
            if (FileNameBrands == "")
            {
                FileNameBrands = applicationPath + @"\Car Brands.txt";
            }
            if (FileNameModels == "")
            {
                FileNameModels = applicationPath + @"\Car Models.txt";
            }

            if (!HasConfigForBrandsAndModels())
            {
              
                var brandModels = new List<BrandDataModel>();
                var carModelsModels = new List<CarModelDataModel>();

                string[] brands = File.ReadAllLines(FileNameBrands); 
                string[] models = File.ReadAllLines(FileNameModels); // 51

                int lineN = 0;

                for (int i = 0; i < brands.Length; i++)
                {
                    brandModels.Add(new BrandDataModel() { Name = brands[i] });

                    while (models.Length > lineN && models[lineN] != "---")
                    {
                        carModelsModels.Add(new CarModelDataModel()
                        {
                            Name = models[lineN],
                            CarBrand = brandModels[brandModels.Count - 1],
                            CarBrandId = brandModels[brandModels.Count - 1].Id
                        });
                        lineN++;
                    }
                    lineN++;
                }


                miscController.WriteBrandDataModelToDatabase(brandModels);
                miscController.WriteCarModelsDataModelsToDatabase(carModelsModels);

                var obj = File.AppendText(applicationPath + @"\config.file");
                obj.WriteLine("brands read\nmodels read");
                obj.Close();


            } // end config check if

        }
        /// <summary>
        /// Проверява дали таблицата е конфигуриране - т.е дали са записани цветове, марки и модели.
        /// Ако е така, не позволява да се запишат отново.
        /// </summary>
        /// <returns></returns>
        private bool HasConfigForBrandsAndModels()
        {
            try
            {
                if (File.Exists(applicationPath + @"\config.file") &&
                File.ReadAllLines(applicationPath + @"\config.file")[1] == "brands read")
                {
                    return true;
                }
                if (File.Exists(applicationPath + @"\config.file") &&
                   File.ReadAllLines(applicationPath + @"\config.file")[2] == "models read")
                {
                    return true;
                }
                return false;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }

        }
    }
}
