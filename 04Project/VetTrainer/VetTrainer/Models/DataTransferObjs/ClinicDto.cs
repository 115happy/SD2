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
            Instruments = new List<Instrument>();
            Texts = new List<Text>();
            Pictures = new List<Picture>();
            Videos = new List<Video>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? PositionX { get; set; }
        public decimal? PositionY { get; set; }
        public virtual IList<Text> Texts { get; set; }
        public virtual IList<Picture> Pictures { get; set; }
        public virtual IList<Video> Videos { get; set; }
        public virtual IList<Instrument> Instruments { get; set; }
    }
}