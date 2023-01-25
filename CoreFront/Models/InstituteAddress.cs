using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class InstituteAddress
    {
        public int FSIA_INSTITADDRESS_ID { get; set; }
        public int FSSI_INSTITUTE_ID { get; set; }
        public string FSIA_ADDRESS_TYPE { get; set; }
        public int FSSC_COUNTRY_ID { get; set; }
        public int FSSP_PROVINCE_ID { get; set; }
        public int FSCT_CITY_ID { get; set; }
        public int FSPS_POSTAL_ID { get; set; }
        public string FSIA_ADDRESS1 { get; set; }
        public string FSIA_ADDRESS2 { get; set; }
        public string FSIA_ADDRESS3 { get; set; }
        public string FSIA_ADDR_ISCORSP { get; set; }
        public string FSIA_STATUS { get; set; }
        public int FSIA_CRUSER { get; set; }
        public DateTime FSIA_CRDATE { get; set; }
    }
}
