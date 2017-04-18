using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using VetTrainer.Views;

namespace VetTrainer.Utilities
{
    public static class FileUtil
    {
        private static int FileStyle(string contentType)
        {
            int result = 0;
            if(contentType== "image/png"||contentType=="image/gif"||contentType=="image/bmp"||contentType=="image/jpeg"|| contentType == "image/jpg")
            {
                result = 1;
            }
            else if (contentType == "video/avi" || contentType == "video/rmvb" || contentType == "video/mp4" || contentType == "image/jpeg")
            {
                result = 2;
            }
            return result;
        }

        public static string SaveFile(HttpPostedFile postedFile,string filePath,string fileName)
        {
            string contentType = postedFile.ContentType;
            int fileStyle = FileStyle(contentType);
            string[] tmp = contentType.Split('/');
            string fileSuffix = tmp.Last();
            fileName += "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string fileLastPath = "";
            if (fileStyle == 1)
            {
                fileName += ".jpeg";
                Image image = Bitmap.FromStream(postedFile.InputStream);
                fileLastPath = Strings.Path.RootPath() + "Pictures" + filePath;
                if (!Directory.Exists(fileLastPath))
                {
                    Directory.CreateDirectory(fileLastPath);
                }
                fileLastPath += fileName;
                image.Save(fileLastPath, ImageFormat.Jpeg);
            }else if(FileStyle(postedFile.ContentType) == 1)
            {
                fileName += "." + fileSuffix;
                fileLastPath = Strings.Path.RootPath() + "Videos" + filePath;
                if (Directory.Exists(fileLastPath))
                {
                    Directory.CreateDirectory(fileLastPath);
                }
                fileLastPath += fileName;
                postedFile.SaveAs(fileLastPath);
            }
            if (fileLastPath == "" || !File.Exists(fileLastPath))
            {
                fileName = "";
            }
            return fileName;
        }
    }
}