using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetTrainer.Models.DataTransferObjs
{
    public class DiseaseCaseDto
    {
        public DiseaseCaseDto()
        {
            DiseaseCaseTabs = new List<DiseaseCaseTabDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }

        public virtual IList<DiseaseCaseTabDto> DiseaseCaseTabs { get; set; }
    }
}

