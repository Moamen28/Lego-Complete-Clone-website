using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roposityres.Helper
{
    public static class UploadHelper
    {

        public static List<string> SaveFile(List<IFormFile> FileUrl, string FolderPath)
        {
            List<string> FileNameList = new List<string>();
            foreach (var Url in FileUrl)
            {
                // Get Directory
                string FilePath = Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderPath;

                // Get File Name
                string FileName = Guid.NewGuid() + Path.GetFileName(Url.FileName);
                FileNameList.Add(FileName);

                // Merge The Directory With File Name
                string FinalPath = Path.Combine(FilePath, FileName);

                // Save Your File As Stream "Data Overtime"
                using (var Stream = new FileStream(FinalPath, FileMode.Create))
                {
                    Url.CopyTo(Stream);
                }

            }
            return FileNameList;

        }
        #region Return One FileName
        public static string SaveOneFile(IFormFile FileUrl, string FolderPath)
        {

            // Get Directory
            string FilePath = Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderPath;

            // Get File Name
            string FileName = Guid.NewGuid() + Path.GetFileName(FileUrl.FileName);

            // Merge The Directory With File Name
            string FinalPath = Path.Combine(FilePath, FileName);

            // Save Your File As Stream "Data Overtime"
            using (var Stream = new FileStream(FinalPath, FileMode.Create))
            {
                FileUrl.CopyTo(Stream);
            }

            return FileName;
        }
        #endregion
        public static void RemoveFile(string FolderName, string RemovedFileName)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName + RemovedFileName))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName + RemovedFileName);
            }

        }

        public static void RemoveListOfFile(string FolderName, List<string> RemovedFileName)
        {
            foreach(var item in RemovedFileName)
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName + item))
                {
                    File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName + item);
                }
            }

        }
        public static List<ProductImage> GetAllByPath(string FolderName, List<ProductImage> ImgDB)
        {
            var direction = Directory.GetCurrentDirectory();
            direction = direction.Replace("API_User","Admin_MVC");
            foreach (var item in ImgDB)
            {
                if (File.Exists(direction + "/wwwroot/Files/" + FolderName + item.ProdImage))
                {
                    //item.ProdImage = direction + "/wwwroot/Files/" + FolderName + item.ProdImage;
                    item.ProdImage = "https://localhost:44351/Files/" + FolderName + item.ProdImage;
                }
            }
            return ImgDB;
        }
        public static Product GetOneByPath(string FolderName, Product ImgDB)
        {
            var direction = Directory.GetCurrentDirectory();
            direction = direction.Replace("API_User", "Admin_MVC");
                if (File.Exists(direction + "/wwwroot/Files/" + FolderName + ImgDB.MainImg))
                {
                    ImgDB.MainImg = "https://localhost:44351/Files/" + FolderName + ImgDB.MainImg;
                }
            return ImgDB;
        }


        public static List<Product> GetAllByPathForProduct(string FolderName, List<Product> ImgDB)
        {
            var direction = Directory.GetCurrentDirectory();
            direction = direction.Replace("API_User", "Admin_MVC");
            foreach (var item in ImgDB)
            {
                if (File.Exists(direction + "/wwwroot/Files/" + FolderName + item.MainImg))
                {
                    //item.ProdImage = direction + "/wwwroot/Files/" + FolderName + item.ProdImage;
                    item.MainImg = "https://localhost:44351/Files/" + FolderName + item.MainImg;
                }
            }
            return ImgDB;
        }

    }
}
