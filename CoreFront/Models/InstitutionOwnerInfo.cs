using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class InstitutionOwnerInfo
    {
        public int FSIO_OWNER_ID { get; set; }
        public int FSSI_INSTITUTE_ID { get; set; }
        public string FSIO_OWNER_NAME { get; set; }
        public string FSIO_OWNER_DESIGN { get; set; }
        public string FSIO_OWNER_TELNO { get; set; }
        public string FSIO_OWNER_MOBNO { get; set; }
        public string FSIO_OWNER_EMAIL { get; set; }
        public string FSIO_OWNER_CNIC { get; set; }
        public int FSIO_SHARE_PERCENT { get; set; }
        public string FSIO_STATUS { get; set; }
        public DateTime FSIO_OCNIC_EXPRDATE { get; set; }
        public DateTime FSIO_OCNIC_ISSUDATE { get; set; }
        public int FSIO_CRUSER { get; set; }
        public DateTime FSIO_CRDATE { get; set; }
    }
}
