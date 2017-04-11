using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace VetTrainer.Controllers.Apis
{
    public class PictureUploadController : ApiController
    {
        public HttpResponseMessage Post()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            var tm = httpRequest.Form["clinicId"];
            if (httpRequest.Files.Count > 0)
            {
                for (int i = 0; i < httpRequest.Files.Count; i++)
                {
                    var postedFile = httpRequest.Files[i];
                    var x = postedFile.ContentType;
                    //Image image = Bitmap.FromFile(postedFile.);
                    var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                    //postedFile.SaveAs(filePath);
                }
                var str = "{ \"Message\" : \"" + "123" + "\" , \"" + "Data\" : \"" + "null" + "\" }";
                result = Request.CreateResponse(HttpStatusCode.Created, str);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return result;
        }
    }
}
