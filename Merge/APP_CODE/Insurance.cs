using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Merge.APP_CODE
{
    class Insurance
    {
        public Int32 no { get; set; }
        public string account_number { get; set; }
        public string nric { get; set; }
        public string name { get; set; }
        public decimal limit { get; set; }
        public string property_address { get; set; }
        public string property_type { get; set; }
        public decimal value { get; set; }
        public string policy_number { get; set; }
        public string insurance_co { get; set; }
        public string insurance_type { get; set; }
        public DateTime start_date { get; set; }
        public DateTime expired_date { get; set; }
        public decimal premium { set; get; }
        public decimal sum_insurance { set; get; }
    }
}
