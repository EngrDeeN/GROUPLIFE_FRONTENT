using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class CustomerSociMedProf
    {
        public int FSCU_CUSTOMER_CODE { get; set; }
        public string FSCS_SOCIALMED_TYP { get; set; }
        public string FSCS_SOCIALMED_LINK { get; set; }
        public int FSCS_CRUSER { get; set; }
        public DateTime FSCS_CRDATE { get; set; }
    }
}
