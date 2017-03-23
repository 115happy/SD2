using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetTrainer.Models.DataTransferObjs
{
    public class DiseaseCaseTabDto
    {
        public DiseaseCaseTabDto()
        {
            Analyses = new List<AnalysisDto>();
            Drugs = new List<DrugDto>();
            Texts = new List<TextDto>();
            Pictures = new List<PictureDto>();
            Videos = new List<VideoDto>();
        }

        public int Id { get; set; }
        public string Index { get; set; }
        public virtual IList<AnalysisDto> Analyses { get; set; }
        public virtual IList<DrugDto> Drugs { get; set; }
        public virtual IList<TextDto> Texts { get; set; }
        public virtual IList<PictureDto> Pictures { get; set; }
        public virtual IList<VideoDto> Videos { get; set; }

        //*********************************************************************

        public int DiseaseCaseId { get; set; }
    }
}