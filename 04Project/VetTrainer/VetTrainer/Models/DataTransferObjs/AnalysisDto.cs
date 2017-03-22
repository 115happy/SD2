using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetTrainer.Models.DataTransferObjs
{
    public class AnalysisDto
    {
        public AnalysisDto()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}