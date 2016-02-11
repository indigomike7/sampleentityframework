using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Merge.APP_CODE
{
    class merged
    {
        public string agent_code { get; set; }
        public string agent_name { get; set; }
        public string class_code { get; set; }
        public string prc_sc_code { get; set; }
        public string policy_no { get; set; }
        public string risk_class { get; set; }
        public string risk_desc { get; set; }
        public string prop_address_1 { get; set; }
        public string prop_address_2 { get; set; }
        public string prop_address_3 { get; set; }
        public string prop_address_4 { get; set; }
        public string endorsement_number { get; set; }
        public string assured_code { get; set; }
        public string assured_name { get; set; }
        public string assured_name_additional { get; set; }
        public string ic { get; set; }
        public DateTime from_date { get; set; }
        public DateTime to_date { get; set; }
        public DateTime approved_date { get; set; }
        public decimal sum_covered { get; set; }
        public decimal gross_premium { get; set; }

        public Int32 no { get; set; }
        public string account_number { get; set; }
        public string nric { get; set; }
        public string name { get; set; }
        public decimal limit { get; set; }
        public string property_address { get; set; }
        public string property_type { get; set; }
        public decimal value { get; set; }
//        public string policy_number { get; set; }
        public string insurance_co { get; set; }
        public string insurance_type { get; set; }
        public DateTime start_date { get; set; }
        public DateTime expired_date { get; set; }
        public decimal premium { set; get; }
        public decimal sum_insurance { set; get; }
    
    }
}
