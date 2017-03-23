using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetTrainer.Models.DataTransferObjs
{
    public class TextDto
    {
        public TextDto()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        //*********************************************************************

        public int? RelatedClinicId { get; set; }
    }
}