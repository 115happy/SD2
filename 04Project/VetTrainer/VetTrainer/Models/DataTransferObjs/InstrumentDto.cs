using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetTrainer.Models.DataTransferObjs
{
    public class InstrumentDto
    {
        public InstrumentDto()
        {
            Texts = new List<Text>();
            Pictures = new List<Picture>();
            Videos = new List<Video>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ModelUrl { get; set; }
        public virtual IList<Text> Texts { get; set; }
        public virtual IList<Picture> Pictures { get; set; }
        public virtual IList<Video> Videos { get; set; }

    }
}