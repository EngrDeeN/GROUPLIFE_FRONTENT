using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class InstitutionContacts
    {
        public int FSIC_INSTITCONTACT_ID { get; set; }
        public int FSSI_INSTITUTE_ID { get; set; }
        public string FSIC_CONTACT_PERSON { get; set; }
        public string FSIC_CONT_CNIC { get; set; }
        public string FSIC_CONTACT_NO1 { get; set; }
        public string FSIC_CONTACT_NO2 { get; set; }            
        public string FSIC_FAX_NO { get; set; }
        public string FSIC_EMAIL1 { get; set; }
        public string FSIC_EMAIL2 { get; set; }
        public string FSIC_STATUS { get; set; }
        public string FSIC_CONT_DESIGNAT { get; set; }
        public int FSIC_CRUSER { get; set; }
        public DateTime FSIC_CRDATE { get; set; }
    }
}
