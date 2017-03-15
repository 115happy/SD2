using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetTrainer.Models
{
    public class RPRecord
    {
        public RPRecord()
        {
            Pictures = new List<Picture>();
            Videos = new List<Video>();
        }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public string Description { get; set; }
        public IList<Picture> Pictures { get; set; }
        public IList<Video> Videos { get; set; }
    }
}