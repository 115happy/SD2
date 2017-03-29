using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetTrainer.Models.DataTransferObjs
{
    public class DiseaseTypeDto
    {
        public DiseaseTypeDto()
        {
            Diseases = new List<DiseaseDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<DiseaseDto> Diseases { get; set; }
    }
}