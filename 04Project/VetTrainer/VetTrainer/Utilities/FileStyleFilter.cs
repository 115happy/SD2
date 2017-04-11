using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetTrainer.Utilities
{
    public static class FileStyleFilter
    {
        public static int FileStyle(string contentType)
        {
            int result = 0;
            if(contentType== "image/png"||contentType=="image/gif"||contentType=="image/bmp"||contentType=="image/jpeg")
            {
                result = 1;
            }
            else if (contentType == "video/avi" || contentType == "video/rmvb" || contentType == "video/mp4" || contentType == "image/jpeg")
            {
                result = 2;
            }
            return result;
        }
    }
}