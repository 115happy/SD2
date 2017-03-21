using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetTrainer.Models.DataTransferObjs
{
    public class DiseaseDto
    {
        public DiseaseDto()
        {
            DiseaseCases = new List<DiseaseCaseDto>();

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<DiseaseCaseDto> DiseaseCases { get; set; }
    }
}