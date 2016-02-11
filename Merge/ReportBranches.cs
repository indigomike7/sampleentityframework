using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace Merge
{
    public partial class ReportBranches : Form
    {
        List<t_dmms_master> selectBranch = new List<t_dmms_master>();
        HSSFWorkbook hssfworkbook;
        public ReportBranches()
        {
            InitializeComponent();
        }

        private void ReportBranches_Load(object sender, EventArgs e)
        {
            Entities1 mdl = new Entities1();
            mdl.Connection.Open();
            List<t_dmms_master> selectBranch = new List<t_dmms_master>();
            selectBranch = (from c in mdl.t_dmms_master
                            orderby c.BRANCH_CODE
                            select c).ToList();

            /*IF NOT EXIST, DO INSERT*/
            if (selectBranch != null)
            {
                dataGridView1.DataSource = selectBranch;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                string name = saveFileDialog1.FileName;
                //InitializeWorkbook(name);
                //FileStream file = new FileStream(name, FileMode.Create);
                hssfworkbook = new HSSFWorkbook();


                ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");

                /*CREATE TITLE*/

                IRow row = sheet1.CreateRow(0);
                row.CreateCell(0).SetCellValue("Bank Ref Number");
                row.CreateCell(1).SetCellValue("New NRIC");
                row.CreateCell(2).SetCellValue("Old NRIC");
                row.CreateCell(3).SetCellValue("Customer Name");
                row.CreateCell(4).SetCellValue("Customer Address 1");
                row.CreateCell(5).SetCellValue("Customer Address 2");
                row.CreateCell(6).SetCellValue("Customer Address 3");
                row.CreateCell(7).SetCellValue("Customer Address 4");
                row.CreateCell(8).SetCellValue("Customer Address 5");
                row.CreateCell(9).SetCellValue("Customer City");
                row.CreateCell(10).SetCellValue("Customer Post Code");
                row.CreateCell(11).SetCellValue("Property Type");
                row.CreateCell(12).SetCellValue("Property Address 1");
                row.CreateCell(13).SetCellValue("Property Address 2");
                row.CreateCell(14).SetCellValue("Property Address 3");
                row.CreateCell(15).SetCellValue("Property Address 4");
                row.CreateCell(16).SetCellValue("Property City");
                row.CreateCell(17).SetCellValue("Property Post Code");
                row.CreateCell(18).SetCellValue("Insurance Type");
                row.CreateCell(19).SetCellValue("Cert Start Date");
                row.CreateCell(20).SetCellValue("Cert End Date");
                row.CreateCell(21).SetCellValue("Sum Insured Amount");
                row.CreateCell(22).SetCellValue("Cert Number");
                row.CreateCell(23).SetCellValue("Bank Staff");
                row.CreateCell(24).SetCellValue("Account Number");
                row.CreateCell(25).SetCellValue("Triton Account Number");
                row.CreateCell(26).SetCellValue("Branch Code");
                row.CreateCell(27).SetCellValue("Facility Type");
                row.CreateCell(28).SetCellValue("Approved Limit");
                row.CreateCell(29).SetCellValue("Approved Date");
                row.CreateCell(30).SetCellValue("Bal Outstanding");
                row.CreateCell(31).SetCellValue("Cost Outstanding");
                row.CreateCell(32).SetCellValue("Principal Outstanding");
                row.CreateCell(33).SetCellValue("UEI Outstanding");
                row.CreateCell(34).SetCellValue("Month Arears");
                row.CreateCell(35).SetCellValue("Credit Status");
                row.CreateCell(36).SetCellValue("Credit Stat Chg Date");
                row.CreateCell(37).SetCellValue("NPF Status");
                row.CreateCell(38).SetCellValue("Reporting Balance");
                row.CreateCell(39).SetCellValue("Income Arears");
                row.CreateCell(40).SetCellValue("Current Balance Outstanding");
                row.CreateCell(41).SetCellValue("Collateral Ref Number");
                row.CreateCell(42).SetCellValue("Claim Type");
                row.CreateCell(43).SetCellValue("Title Number");
                row.CreateCell(44).SetCellValue("Land Office");
                row.CreateCell(45).SetCellValue("Lot Number");
                row.CreateCell(46).SetCellValue("Property District");
                row.CreateCell(47).SetCellValue("Mukim");
                row.CreateCell(48).SetCellValue("Security Value");
                row.CreateCell(49).SetCellValue("Property Desc");
                row.CreateCell(50).SetCellValue("Property Owner 1");
                row.CreateCell(51).SetCellValue("Property Owner 2");
                row.CreateCell(52).SetCellValue("Insurance Company");
                row.CreateCell(53).SetCellValue("Policy Number");
                row.CreateCell(54).SetCellValue("Coverage Type");
                row.CreateCell(55).SetCellValue("Participant Name");
                row.CreateCell(56).SetCellValue("Risk Address 1");
                row.CreateCell(57).SetCellValue("Risk Address 2");
                row.CreateCell(58).SetCellValue("Risk Address 3");
                row.CreateCell(59).SetCellValue("Risk Address 4");
                row.CreateCell(60).SetCellValue("Risk Address 5");
                row.CreateCell(61).SetCellValue("Risk Post Code");
                row.CreateCell(62).SetCellValue("Risk State Code");
                row.CreateCell(63).SetCellValue("Premium Amount");
                row.CreateCell(64).SetCellValue("Insurance Last Modified Date");
                row.CreateCell(65).SetCellValue("Status");
                row.CreateCell(66).SetCellValue("Time Stamp2");
                row.CreateCell(67).SetCellValue("Contribution To Be Paid By Customer");
                row.CreateCell(68).SetCellValue("Contribution To Be Paid By Broker");
                row.CreateCell(69).SetCellValue("Insurance Last Modified Date");
                row.CreateCell(70).SetCellValue("Contribution");
                row.CreateCell(71).SetCellValue("Comission");
                row.CreateCell(72).SetCellValue("Stamp Duty");
                row.CreateCell(73).SetCellValue("Police or Army No");
                row.CreateCell(74).SetCellValue("Passport Number");
                row.CreateCell(75).SetCellValue("Branches");
                row.CreateCell(76).SetCellValue("FileName");
                row.CreateCell(77).SetCellValue("Username");
                row.CreateCell(78).SetCellValue("Settlement Date");
                row.CreateCell(79).SetCellValue("Remarks");
                row.CreateCell(80).SetCellValue("Add New Customer Date");
                /*LOOP THROUGH DATA AND CREATE TO SHEET*/
                Entities1 mdl = new Entities1();
                mdl.Connection.Open();
                List<t_dmms_master> selectBranch = new List<t_dmms_master>();
                selectBranch = (from c in mdl.t_dmms_master
                                orderby c.BRANCH_CODE
                                select c).ToList();


                int i = 1;
                foreach (t_dmms_master dmms in selectBranch)
                {
                    //DateTime settlementdate =DateTime.Parse("01/01/1970");
                    //DateTime addnewcustomerdate = DateTime.Parse("01/01/1970");
                    //if (dmms.SETTLEMENT_DATE == null) { settlementdate = DateTime.Parse("01/01/1970"); } else { settlementdate = dmms.SETTLEMENT_DATE   }
                    //if (dmms.ADD_NEW_CUSTOMER_DATE == null) { addnewcustomerdate = DateTime.Parse("01/01/1970"); }
                    row = sheet1.CreateRow(i);
                    row.CreateCell(0).SetCellValue(dmms.BANK_REF_NO);
                    row.CreateCell(1).SetCellValue(dmms.NEW_NRIC);
                    row.CreateCell(2).SetCellValue(dmms.OLD_NRIC);
                    row.CreateCell(3).SetCellValue(dmms.CUSTOMER_NAME);
                    row.CreateCell(4).SetCellValue(dmms.CUSTOMER_ADD2);
                    row.CreateCell(5).SetCellValue(dmms.CUSTOMER_ADD2);
                    row.CreateCell(6).SetCellValue(dmms.CUSTOMER_ADD3);
                    row.CreateCell(7).SetCellValue(dmms.CUSTOMER_ADD4);
                    row.CreateCell(8).SetCellValue(dmms.CUSTOMER_ADD5);
                    row.CreateCell(9).SetCellValue(dmms.CUSTOMER_CITY);
                    row.CreateCell(10).SetCellValue(dmms.CUSTOMER_POSTCODE);
                    row.CreateCell(11).SetCellValue(dmms.PROPERTY_TYPE);
                    row.CreateCell(12).SetCellValue(dmms.PROPERTY_ADD1);
                    row.CreateCell(13).SetCellValue(dmms.PROPERTY_ADD2);
                    row.CreateCell(14).SetCellValue(dmms.PROPERTY_ADD3);
                    row.CreateCell(15).SetCellValue(dmms.PROPERTY_ADD4);
                    row.CreateCell(16).SetCellValue(dmms.PROPERTY_CITY);
                    row.CreateCell(17).SetCellValue(dmms.PROPERTY_POSCODE);
                    row.CreateCell(18).SetCellValue(dmms.INSURANCE_TYPE);
                    row.CreateCell(19).SetCellValue(dmms.CERT_START_DATE);
                    row.CreateCell(20).SetCellValue(dmms.CERT_END_DATE);
                    row.CreateCell(21).SetCellValue(dmms.SUM_INSURED_AMOUNT);
                    row.CreateCell(22).SetCellValue(dmms.CERTIFICATE_NO);
                    row.CreateCell(23).SetCellValue(dmms.BANK_STAFF);
                    row.CreateCell(24).SetCellValue(dmms.ACC_NO);
                    row.CreateCell(25).SetCellValue(dmms.TRITON_ACC_NO);
                    row.CreateCell(26).SetCellValue(dmms.BRANCH_CODE);
                    row.CreateCell(27).SetCellValue(dmms.FACILTY_TYPE);
                    row.CreateCell(28).SetCellValue(dmms.APPROVED_LIMIT);
                    row.CreateCell(29).SetCellValue(dmms.APPROVED_DATE);
                    row.CreateCell(30).SetCellValue(dmms.BAL_OUTSTANDING);
                    row.CreateCell(31).SetCellValue(dmms.COST_OUTSTANDING);
                    row.CreateCell(32).SetCellValue(dmms.PRINCIPAL_OUTSTANDING);
                    row.CreateCell(33).SetCellValue(dmms.UEI_OUTSTANDING);
                    row.CreateCell(34).SetCellValue(dmms.MONTH_ARREARS);
                    row.CreateCell(35).SetCellValue(dmms.CREDIT_STATUS);
                    row.CreateCell(36).SetCellValue(dmms.CREDIT_STAT_CHG_DATE);
                    row.CreateCell(37).SetCellValue(dmms.NPF_STATUS);
                    row.CreateCell(38).SetCellValue(dmms.REPORTING_BALANCE);
                    row.CreateCell(39).SetCellValue(dmms.INCOME_ARREARS);
                    row.CreateCell(40).SetCellValue(dmms.CURR_BAL_OUTSTANDING);
                    row.CreateCell(41).SetCellValue(dmms.COLLATERAL_REFNO);
                    row.CreateCell(42).SetCellValue(dmms.CLAIM_TYPE);
                    row.CreateCell(43).SetCellValue(dmms.TITLE_NO);
                    row.CreateCell(44).SetCellValue(dmms.LAND_OFFICE);
                    row.CreateCell(45).SetCellValue(dmms.LOT_NO);
                    row.CreateCell(46).SetCellValue(dmms.PROPERTY_DISTRICT);
                    row.CreateCell(47).SetCellValue(dmms.MUKIM);
                    row.CreateCell(48).SetCellValue(dmms.SECURITY_VALUE);
                    row.CreateCell(49).SetCellValue(dmms.PROPERTY_DESC);
                    row.CreateCell(50).SetCellValue(dmms.PROPERTY_OWNER1);
                    row.CreateCell(51).SetCellValue(dmms.PROPERTY_OWNER1);
                    row.CreateCell(52).SetCellValue(dmms.INSURANCE_COMPANY);
                    row.CreateCell(53).SetCellValue(dmms.POLICY_NO);
                    row.CreateCell(54).SetCellValue(dmms.COVERAGE_TYPE);
                    row.CreateCell(55).SetCellValue(dmms.PARTICIPANT_NAME);
                    row.CreateCell(56).SetCellValue(dmms.RISK_ADD1);
                    row.CreateCell(57).SetCellValue(dmms.RISK_ADD2);
                    row.CreateCell(58).SetCellValue(dmms.RISK_ADD3);
                    row.CreateCell(59).SetCellValue(dmms.RISK_ADD4);
                    row.CreateCell(60).SetCellValue(dmms.RISK_ADD5);
                    row.CreateCell(61).SetCellValue(dmms.RISK_POSTCODE);
                    row.CreateCell(62).SetCellValue(dmms.RISK_STATE_CODE);
                    row.CreateCell(63).SetCellValue(dmms.PREMIUM_AMOUNT);
                    row.CreateCell(64).SetCellValue(dmms.INSURANCE_LAST_MOD_DATE);
                    row.CreateCell(65).SetCellValue(dmms.STATUS);
                    row.CreateCell(66).SetCellValue(dmms.TIMESTAMP2);
                    row.CreateCell(67).SetCellValue(dmms.CONTRIBUTION_TO_BE_PAID_BY_CUST);
                    row.CreateCell(68).SetCellValue(dmms.CONTRIBUTION_TO_BE_PAID_BY_BROKER);
                    row.CreateCell(69).SetCellValue(dmms.INSURANCE_LAST_MODIFIED_DATE);
                    row.CreateCell(70).SetCellValue(dmms.CONTRIBUTION);
                    row.CreateCell(71).SetCellValue(dmms.COMISSION);
                    row.CreateCell(72).SetCellValue(dmms.STAMP_DUTY);
                    row.CreateCell(73).SetCellValue(dmms.POLICE_OR_ARMY_NO);
                    row.CreateCell(74).SetCellValue(dmms.PASSPORT_NO);
                    row.CreateCell(75).SetCellValue(dmms.BRANCHES);
                    row.CreateCell(76).SetCellValue(dmms.FileName);
                    row.CreateCell(77).SetCellValue(dmms.UserName);
                    row.CreateCell(78).SetCellValue(dmms.SETTLEMENT_DATE ?? DateTime.Parse("01/01/1970"));
                    row.CreateCell(79).SetCellValue(dmms.REMARKS);
                    row.CreateCell(80).SetCellValue(dmms.ADD_NEW_CUSTOMER_DATE ?? DateTime.Parse("01/01/1970"));
                    i++;
                }

                mdl.Connection.Close();
                //Write the stream data of workbook to the root directory
                FileStream file = new FileStream(name, FileMode.Create);
                hssfworkbook.Write(file);
                file.Close();

                MessageBox.Show("Sukses Export Data, Tersimpan di " + name, "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //                MessageBox.Show("Excel file created , you can find the file :" + name + "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }


        }
    }
}
