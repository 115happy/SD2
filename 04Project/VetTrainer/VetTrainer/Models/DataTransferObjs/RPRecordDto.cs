using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetTrainer.Models.DataTransferObjs
{
    public class RPRecordDto
    {
        public RPRecordDto()
        {
            Pictures = new List<PictureDto>();
            Videos = new List<VideoDto>();
        }
        public int RoleId { get; set; }
        public int ClinicId { get; set; }
        public RoleDto Role { get; set; }
        public ClinicDto Clinic { get; set; }
        public string Description { get; set; }
        public IList<PictureDto> Pictures { get; set; }
        public IList<VideoDto> Videos { get; set; }
    }
}