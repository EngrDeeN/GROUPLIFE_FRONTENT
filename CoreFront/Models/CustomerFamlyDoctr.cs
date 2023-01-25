using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class CustomerFamlyDoctr
    {
        public int FSCU_CUSTOMER_CODE { get; set; }
        public string FSFD_DOCTOR_NAME { get; set; }
        public string FSFD_DOCTOR_TYPE { get; set; }
        public int FSFD_SERIAL_NO { get; set; }
        public string FSFD_HOSPCLINC_NAME { get; set; }
        public string FSFD_HOSPCLINC_ADDRESS { get; set; }
        public int FSSC_COUNTRY_ID { get; set; }
        public int FSSP_PROVINCE_ID { get; set; }
        public int FSCT_CITY_ID { get; set; }
        public string FSFD_STATUS { get; set; }
        public string FSFD_DOCTR_CONTNO { get; set; }
        public int FSFD_CRUSER { get; set; }
        public DateTime FSFD_CRDATE { get; set; }
    }
}
