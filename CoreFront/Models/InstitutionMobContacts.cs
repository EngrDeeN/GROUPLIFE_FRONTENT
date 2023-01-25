using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class InstitutionMobContacts
    {
        public int FSIM_INSTITMOBILE_ID { get; set; }
        public int FSSI_INSTITUTE_ID { get; set; }
        public string FSIM_MOBILE_NO1 { get; set; }
        public string FSIM_MOBILE_NO2 { get; set; }
        public string FSIM_STATUS { get; set; }
        public int FSIM_CRUSER { get; set; }
        public DateTime FSIM_CRDATE { get; set; }
    }
}
