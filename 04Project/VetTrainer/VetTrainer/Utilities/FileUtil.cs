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
            if (FileStyle(postedFile.ContentType) == 1)
            {
                fileName += "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpeg";
                Image image = Bitmap.FromStream(postedFile.InputStream);
                image.Save(Strings.Global.ServerDataLocation + "Pictures" + filePath + fileName, ImageFormat.Jpeg);
            }
            return fileName;
        }
    }
}