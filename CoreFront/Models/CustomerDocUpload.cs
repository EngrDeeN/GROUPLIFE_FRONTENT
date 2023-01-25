using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFront.Models
{
    public class CustomerDocUpload
    {
        public int FSCU_CUSTOMER_CODE { get; set; }
        public int FSDU_DOCUMENT_ID { get; set; }
        public string FSDU_DOCUMENT_NAME { get; set; }
        public string FSDU_DOC_ACTUAL_PATH { get; set; }
        public string FSDU_STATUS { get; set; }
        public int FSDU_CRUSER { get; set; }
        public DateTime FSDU_CRDATE { get; set; }
    }
}
