using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetTrainer.Models.DataTransferObjs
{
    public class ClinicDto
    {
        public ClinicDto()
        {
            Instruments = new List<InstrumentDto>();
            Texts = new List<TextDto>();
            Pictures = new List<PictureDto>();
            Videos = new List<VideoDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? PositionX { get; set; }
        public decimal? PositionY { get; set; }
        public virtual IList<TextDto> Texts { get; set; }
        public virtual IList<PictureDto> Pictures { get; set; }
        public virtual IList<VideoDto> Videos { get; set; }
        public virtual IList<InstrumentDto> Instruments { get; set; }
    }
}