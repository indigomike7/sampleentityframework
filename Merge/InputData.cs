using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Merge.APP_CODE;
namespace Merge
{
    public partial class MergeData : Form
    {
        HSSFWorkbook hssfworkbook;
        XSSFWorkbook xssfworkbook;
        List<t_Insurance_data> insList = new List<t_Insurance_data>();
        List<t_Bank_data> bankList = new List<t_Bank_data>();
        List<t_dmms_master> mrgList = new List<t_dmms_master>();
        public MergeData()
        {
            InitializeComponent();
//            tabControl1.
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
/*            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage1"])//your specific tabname
            {
                // your stuff
                start();
            }
 * */
        }
        private void MergeData_Load(object sender, EventArgs e)
        {
            start();
        }
        private void start()
        {
            btnFinish.Enabled = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            tabControl1.SelectTab(0);
            tabPage2.Enabled = false;
            tabPage3.Enabled = false;
            tabPage4.Enabled = false;

        }

        private void input_next()
        {
            btnFinish.Enabled = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = true;
        }

        private void page2()
        {
            btnFinish_2.Enabled = false;
            btnPrevious_2.Enabled = true;
            btnNext_2.Enabled = true;
            txtBank_2.Text = txtBank.Text;
            txtInsurance_2.Text = txtInsurance.Text;
            txtBank_3.Text = txtBank.Text;
            txtInsurance_3.Text = txtInsurance.Text;
            verify_xls();
        }
        private void InitializeWorkbook(string path)
        {
            //read the template via FileStream, it is suggested to use FileAccess.Read to prevent file lock.
            //book1.xls is an Excel-2007-generated file, so some new unknown BIFF records are added. 
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
        }
        private void InitializeWorkbook2(string path)
        {
            //read the template via FileStream, it is suggested to use FileAccess.Read to prevent file lock.
            //book1.xls is an Excel-2007-generated file, so some new unknown BIFF records are added. 
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                xssfworkbook = new XSSFWorkbook(file);
            }
        }

        private void verify_xls()
        {

            Boolean error = false;
            Boolean emptyfound = false;
            /* EMPTY THE LIST */          
            insList = new List<t_Insurance_data>();
            bankList = new List<t_Bank_data>();
            int rowEmptyBank=-1;
            int colEmptyBank=-1;

            int rowEmptyInsurance = -1;
            int colEmptyInsurance = -1;

            /* BANK DATA */
            string x="";
            try
            {

                InitializeWorkbook(txtBank.Text);

                ISheet sheet = hssfworkbook.GetSheetAt(0);
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                rows.MoveNext();
                while (rows.MoveNext())
                {
                    t_Bank_data objBank = new t_Bank_data();
                    IRow row = (HSSFRow)rows.Current;

                    for (int i = 0; i < row.LastCellNum; i++)
                    {
                        ICell cell = row.GetCell(i);
                        if (cell == null && rowEmptyInsurance == -1 && (i != 2 && i != 5 && i != 6 && i != 7 && i != 8 && i != 12 && i != 13 && i != 14 && i != 15))
                        {
                            emptyfound = true;
                            rowEmptyBank = row.RowNum + 1;
                            colEmptyBank = i + 1;
                            return;
                        }
                        else
                        {
                            if (Convert.ToString(cell) == "" && rowEmptyBank == -1 && (i != 2 && i != 5 && i != 6 && i != 7 && i != 8 && i != 12 && i != 13 && i != 14 && i != 15))
                            {
                                emptyfound = true;
                                rowEmptyBank = row.RowNum + 1;
                                colEmptyBank = i + 1;
                            }
                            else
                            {
                                if (i == 0)
                                {
                                    objBank.bank_ref_number = Convert.ToString(cell);
                                }
                                if (i == 1)
                                {
                                    objBank.nric = Convert.ToString(cell);
                                }
                                if (i == 2)
                                {
                                    objBank.old_ic = Convert.ToString(cell);
                                }
                                if (i == 3)
                                {
                                    objBank.participant_name = Convert.ToString(cell);
                                }
                                if (i == 4)
                                {
                                    objBank.customer_address_1 = Convert.ToString(cell);
                                }
                                if (i == 5)
                                {
                                    objBank.customer_address_2 = Convert.ToString(cell);
                                }
                                if (i == 6)
                                {
                                    objBank.customer_address_3 = Convert.ToString(cell);
                                }
                                if (i == 7)
                                {
                                    objBank.customer_address_4 = Convert.ToString(cell);
                                }
                                if (i == 8)
                                {
                                    objBank.customer_address_5 = Convert.ToString(cell);
                                }
                                if (i == 9)
                                {
                                    objBank.customer_post_code = Convert.ToString(cell);
                                }
                                if (i == 10)
                                {
                                    objBank.property_type = Convert.ToString(cell);
                                }
                                if (i == 11)
                                {
                                    objBank.property_address = Convert.ToString(cell);
                                }
                                if (i == 12)
                                {
                                    objBank.property_address_1 = Convert.ToString(cell);
                                }
                                if (i == 13)
                                {
                                    objBank.property_address_2 = Convert.ToString(cell);
                                }
                                if (i == 14)
                                {
                                    objBank.property_address_3 = Convert.ToString(cell);
                                }
                                if (i == 15)
                                {
                                    objBank.property_address_4 = Convert.ToString(cell);
                                }
                                if (i == 16)
                                {
                                    objBank.property_post_code = Convert.ToString(cell);
                                }
                                if (i == 17)
                                {
                                    objBank.risk_type = Convert.ToString(cell);
                                }
                                if (i == 18)
                                {
                                    objBank.policy_effective_date = (Convert.ToString(cell) == "") ? Convert.ToDateTime("01/01/1970") : Convert.ToDateTime(Convert.ToString(cell));
                                }
                                if (i == 19)
                                {
                                    objBank.policy_expired_date = (Convert.ToString(cell) == "") ? Convert.ToDateTime("01/01/1970") : Convert.ToDateTime(Convert.ToString(cell));
                                }
                                if (i == 20)
                                {
                                    objBank.sum_covered = (Convert.ToString(cell) == "") ? Convert.ToDecimal("0") : Convert.ToDecimal(Convert.ToString(cell));
                                }
                                if (i == 21)
                                {
                                    objBank.policy_no = Convert.ToString(cell);
                                }
                            }
                        }

                    }
                    bankList.Add(objBank);
                }

                /*EOF BANK DATA*/



            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("2007") > 0)
                {
                    try
                    {
                        InitializeWorkbook2(txtBank.Text);

                        ISheet sheet = xssfworkbook.GetSheetAt(0);
                        System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                        rows.MoveNext();
                        while (rows.MoveNext())
                        {
                            t_Bank_data objBank = new t_Bank_data();
                            IRow row = (XSSFRow)rows.Current;

                            for (int i = 0; i < row.LastCellNum; i++)
                            {
                                ICell cell = row.GetCell(i);
                                if (cell == null && rowEmptyInsurance == -1 && (i != 2 && i != 5 && i != 6 && i != 7 && i != 8 && i != 12 && i != 13 && i != 14 && i != 15))
                                {
                                    emptyfound = true;
                                    rowEmptyBank = row.RowNum + 1;
                                    colEmptyBank = i + 1;
                                    return;
                                }
                                else
                                {
                                    if (Convert.ToString(cell) == "" && rowEmptyBank == -1 && (i != 2 && i != 5 && i != 6 && i != 7 && i != 8 && i != 12 && i != 13 && i != 14 && i != 15))
                                    {
                                        emptyfound = true;
                                        rowEmptyBank = row.RowNum + 1;
                                        colEmptyBank = i + 1;
                                    }
                                    else
                                    {
                                        if (i == 0)
                                        {
                                            objBank.bank_ref_number = Convert.ToString(cell);
                                        }
                                        if (i == 1)
                                        {
                                            objBank.nric = Convert.ToString(cell);
                                        }
                                        if (i == 2)
                                        {
                                            objBank.old_ic = Convert.ToString(cell);
                                        }
                                        if (i == 3)
                                        {
                                            objBank.participant_name = Convert.ToString(cell);
                                        }
                                        if (i == 4)
                                        {
                                            objBank.customer_address_1 = Convert.ToString(cell);
                                        }
                                        if (i == 5)
                                        {
                                            objBank.customer_address_2 = Convert.ToString(cell);
                                        }
                                        if (i == 6)
                                        {
                                            objBank.customer_address_3 = Convert.ToString(cell);
                                        }
                                        if (i == 7)
                                        {
                                            objBank.customer_address_4 = Convert.ToString(cell);
                                        }
                                        if (i == 8)
                                        {
                                            objBank.customer_address_5 = Convert.ToString(cell);
                                        }
                                        if (i == 9)
                                        {
                                            objBank.customer_post_code = Convert.ToString(cell);
                                        }
                                        if (i == 10)
                                        {
                                            objBank.property_type = Convert.ToString(cell);
                                        }
                                        if (i == 11)
                                        {
                                            objBank.property_address = Convert.ToString(cell);
                                        }
                                        if (i == 12)
                                        {
                                            objBank.property_address_1 = Convert.ToString(cell);
                                        }
                                        if (i == 13)
                                        {
                                            objBank.property_address_2 = Convert.ToString(cell);
                                        }
                                        if (i == 14)
                                        {
                                            objBank.property_address_3 = Convert.ToString(cell);
                                        }
                                        if (i == 15)
                                        {
                                            objBank.property_address_4 = Convert.ToString(cell);
                                        }
                                        if (i == 16)
                                        {
                                            objBank.property_post_code = Convert.ToString(cell);
                                        }
                                        if (i == 17)
                                        {
                                            objBank.risk_type = Convert.ToString(cell);
                                        }
                                        if (i == 18)
                                        {
                                            objBank.policy_effective_date = (Convert.ToString(cell) == "") ? Convert.ToDateTime("01/01/1970") : Convert.ToDateTime(Convert.ToString(cell));
                                        }
                                        if (i == 19)
                                        {
                                            objBank.policy_expired_date = (Convert.ToString(cell) == "") ? Convert.ToDateTime("01/01/1970") : Convert.ToDateTime(Convert.ToString(cell));
                                        }
                                        if (i == 20)
                                        {
                                            objBank.sum_covered = (Convert.ToString(cell) == "") ? Convert.ToDecimal("0") : Convert.ToDecimal(Convert.ToString(cell));
                                        }
                                        if (i == 21)
                                        {
                                            objBank.policy_no = Convert.ToString(cell);
                                        }
                                    }
                                }

                            }
                            bankList.Add(objBank);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        error = true;
                    }
                }
                else
                {
                    MessageBox.Show(ex.Message);
                    error = true;
                }
            }

            /* INSURANCE DATA */

            try
            {

                InitializeWorkbook(txtInsurance.Text);

                ISheet sheet = hssfworkbook.GetSheetAt(0);
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

                /*GO TO ROW 3*/
//                rows.MoveNext();
//                rows.MoveNext();
                rows.MoveNext();

                while (rows.MoveNext())
                {
                    t_Insurance_data objIns = new t_Insurance_data();
                    IRow row = (HSSFRow)rows.Current;

                    for (int i = 0; i < row.LastCellNum; i++)
                    {
                        ICell cell = row.GetCell(i);
                        if (cell == null && rowEmptyInsurance == -1 && (i != 2 && i != 9 && i != 10 && i != 11 && i != 12 && i != 13 && i != 14 && i != 15 && i != 16 && i != 17 && i != 18 && i != 19 && i != 20 && i != 21 && i != 22 && i != 23 && i != 24 && i != 25 && i != 26 && i != 28 && i != 29 && i != 30 && i != 34 && i != 35 && i != 38 && i != 39 && i != 40 && i != 41 && i != 26 && i != 47 && i != 48 && i != 51 && i != 53 && i != 58))
                        {

                            emptyfound = true;
                            rowEmptyInsurance = row.RowNum + 1;
                            colEmptyInsurance = i + 1;
                            return;
                        }
                        else
                        {
                            if (Convert.ToString(cell) == "" && rowEmptyInsurance == -1 && (i != 2 && i != 9 && i != 10 && i != 11 && i != 12 && i != 13 && i != 14 && i != 15 && i != 16 && i != 17 && i != 18 && i != 19 && i != 20 && i != 21 && i != 22 && i != 23 && i != 24 && i != 25 && i != 26 && i != 28 && i != 29 && i != 30 && i != 34 && i != 35 && i != 38 && i != 39 && i != 40 && i != 41 && i != 26 && i != 47 && i != 48 && i != 51 && i != 53 && i != 58))
                            {
                                emptyfound = true;
                                rowEmptyInsurance = row.RowNum + 1;
                                colEmptyInsurance = i + 1;
                            }
                            else
                            {
                                if (i == 0)
                                {
                                    objIns.ic_breg_no = Convert.ToString(cell);
                                }
                                if (i == 1)
                                {
                                    objIns.customer_name = Convert.ToString(cell);
                                }
                                if (i == 2)
                                {
                                    objIns.bank_staff = Convert.ToString(cell);
                                }
                                if (i == 3)
                                {
                                    objIns.address_1 = Convert.ToString(cell);
                                }
                                if (i == 4)
                                {
                                    objIns.address_2 = Convert.ToString(cell);
                                }
                                if (i == 5)
                                {
                                    objIns.address_3 = Convert.ToString(cell);
                                }
                                if (i == 6)
                                {
                                    objIns.post_code = Convert.ToString(cell);
                                }
                                if (i == 7)
                                {
                                    objIns.city = Convert.ToString(cell);
                                }
                                if (i == 8)
                                {
                                    objIns.account_no = Convert.ToString(cell);
                                }
                                if (i == 9)
                                {
                                    objIns.triton_account_no = Convert.ToString(cell);
                                }
                                if (i == 10)
                                {
                                    objIns.branch_code = Convert.ToString(cell);
                                }
                                if (i == 11)
                                {
                                    objIns.facility_type = Convert.ToString(cell);
                                }
                                if (i == 12)
                                {
                                    objIns.approved_limit = Convert.ToString(cell);
                                }
                                if (i == 13)
                                {
                                    objIns.approved_date = (Convert.ToString(cell) == "") ? Convert.ToDateTime("01/01/1970") : Convert.ToDateTime(Convert.ToString(cell));
                                }
                                if (i == 14)
                                {
                                    objIns.balance_outstanding = Convert.ToString(cell);
                                }
                                if (i == 15)
                                {
                                    objIns.cost_outstanding = Convert.ToString(cell);
                                }
                                if (i == 16)
                                {
                                    objIns.principal_outstanding = Convert.ToString(cell);
                                }
                                if (i == 17)
                                {
                                    objIns.uei_outstanding = Convert.ToString(cell);
                                }
                                if (i == 18)
                                {
                                    objIns.month_arrears = Convert.ToString(cell);
                                }
                                if (i == 19)
                                {
                                    objIns.credit_status = Convert.ToString(cell);
                                }
                                if (i == 20)
                                {
                                    objIns.credit_stat_change_date = (Convert.ToString(cell) == "") ? Convert.ToDateTime("01/01/1970") : Convert.ToDateTime(Convert.ToString(cell));
                                }
                                if (i == 21)
                                {
                                    objIns.npf_status = Convert.ToString(cell);
                                }
                                if (i == 22)
                                {
                                    objIns.income_arrears = Convert.ToString(cell);
                                }
                                if (i == 23)
                                {
                                    objIns.curr_balance_outstanding = Convert.ToString(cell);
                                }
                                if (i == 24)
                                {
                                    objIns.collateral_ref_number = Convert.ToString(cell);
                                }
                                if (i == 25)
                                {
                                    objIns.claim_type = Convert.ToString(cell);
                                }
                                if (i == 26)
                                {
                                    objIns.property_type = Convert.ToString(cell);
                                }
                                if (i == 27)
                                {
                                    objIns.credit_status = Convert.ToString(cell);
                                }
                                if (i == 28)
                                {
                                    objIns.title_no = Convert.ToString(cell);
                                }
                                if (i == 29)
                                {
                                    objIns.land_office = Convert.ToString(cell);
                                }
                                if (i == 30)
                                {
                                    objIns.lot_number = Convert.ToString(cell);
                                }
                                if (i == 31)
                                {
                                    objIns.property_address_1= Convert.ToString(cell);
                                }
                                if (i == 32)
                                {
                                    objIns.property_address_2 = Convert.ToString(cell);
                                }
                                if (i == 33)
                                {
                                    objIns.property_address_3 = Convert.ToString(cell);
                                }
                                if (i == 34)
                                {
                                    objIns.property_district = Convert.ToString(cell);
                                }
                                if (i == 35)
                                {
                                    objIns.mukim = Convert.ToString(cell);
                                }
                                if (i == 36)
                                {
                                    objIns.property_city = Convert.ToString(cell);
                                }
                                if (i == 37)
                                {
                                    objIns.property_post_code = Convert.ToString(cell);
                                }
                                if (i == 38)
                                {
                                    objIns.security_value = Convert.ToString(cell);
                                }
                                if (i == 39)
                                {
                                    objIns.property_desc= Convert.ToString(cell);
                                }
                                if (i == 40)
                                {
                                    objIns.property_owner_1 = Convert.ToString(cell);
                                }
                                if (i == 41)
                                {
                                    objIns.property_owner_2 = Convert.ToString(cell);
                                }
                                if (i == 42)
                                {
                                    objIns.insurance_company = Convert.ToString(cell);
                                }
                                if (i == 43)
                                {
                                    objIns.policy_no = Convert.ToString(cell);
                                }
                                if (i == 44)
                                {
                                    objIns.insurance_type = Convert.ToString(cell);
                                }
                                if (i == 45)
                                {
                                    objIns.coverage_type = Convert.ToString(cell);
                                }
                                if (i == 46)
                                {
                                    objIns.participant_name = Convert.ToString(cell);
                                }
                                if (i == 47)
                                {
                                    objIns.risk_address_1 = Convert.ToString(cell);
                                }
                                if (i == 48)
                                {
                                    objIns.risk_address_2 = Convert.ToString(cell);
                                }
                                if (i == 49)
                                {
                                    objIns.risk_address_3 = Convert.ToString(cell);
                                }
                                if (i == 50)
                                {
                                    objIns.risk_post_code = Convert.ToString(cell);
                                }
                                if (i == 51)
                                {
                                    objIns.risk_city = Convert.ToString(cell);
                                }
                                if (i == 52)
                                {
                                    objIns.risk_state_code = Convert.ToString(cell);
                                }
                                if (i == 53)
                                {
                                    objIns.risk_country_code = Convert.ToString(cell);
                                }
                                if (i == 54)
                                {
                                    objIns.start_date = (Convert.ToString(cell) == "") ? Convert.ToDateTime("01/01/1970") : Convert.ToDateTime(Convert.ToString(cell));
                                }
                                if (i == 55)
                                {
                                    objIns.end_date = (Convert.ToString(cell) == "") ? Convert.ToDateTime("01/01/1970") : Convert.ToDateTime(Convert.ToString(cell));
                                }
                                if (i == 56)
                                {
                                    objIns.premium_amt = Convert.ToString(cell);
                                }
                                if (i == 57)
                                {
                                    objIns.sum_insured_amt = Convert.ToString(cell);
                                }
                                if (i == 58)
                                {
                                    objIns.insurance_last_modified_date = (Convert.ToString(cell) == "") ? Convert.ToDateTime("01/01/1970") : Convert.ToDateTime(Convert.ToString(cell));
                                }

                            }
                        }

                    }
                    insList.Add(objIns);
                }

            }
            catch (Exception e)
            {
                if (e.Message.IndexOf("2007") > 0)
                {
                    try
                    {
                        InitializeWorkbook2(txtInsurance.Text);

                        ISheet sheet = xssfworkbook.GetSheetAt(0);
                        System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

                        int rowcount = sheet.LastRowNum;
                        /*GO TO ROW 2*/
                        //rows.MoveNext();
                        //rows.MoveNext();
                        rows.MoveNext();
//                        MessageBox.Show(rowcount.ToString());
                        while (rows.MoveNext())
                        {
                            t_Insurance_data objIns = new t_Insurance_data();
                            IRow row = (XSSFRow)rows.Current;

                            for (int i = 0; i < row.LastCellNum; i++)
                            {
                                ICell cell = row.GetCell(i);
                                if (cell == null && rowEmptyInsurance == -1 && i != 2 && i != 9 && i != 10 && i != 11 && i != 12 && i != 13 && i != 14 && i != 15 && i != 16 && i != 17 && i != 18 && i != 19 && i != 20 && i != 21 && i != 22 && i != 23 && i != 24 && i != 25 && i != 26 && i != 28 && i != 29 && i != 30 && i != 34 && i != 35 && i != 38 && i != 39 && i != 40 && i != 41 && i != 26 && i != 47 && i != 48 && i != 51 && i != 53 && i != 58)
                                {

                                    emptyfound = true;
                                    rowEmptyInsurance = row.RowNum + 1;
                                    colEmptyInsurance = i + 1;
                                    return;
                                }
                                else
                                {
                                    if (Convert.ToString(cell) == "" && rowEmptyInsurance == -1 && (i != 2 && i != 9 && i != 10 && i != 11 && i != 12 && i != 13 && i != 14 && i != 15 && i != 16 && i != 17 && i != 18 && i != 19 && i != 20 && i != 21 && i != 22 && i != 23 && i != 24 && i != 25 && i != 26 && i != 28 && i != 29 && i != 30 && i != 34 && i != 35 && i != 38 && i != 39 && i != 40 && i != 41 && i != 26 && i != 47 && i != 48 && i != 51 && i != 53 && i != 58))
                                    {
                                        emptyfound = true;
                                        rowEmptyInsurance = row.RowNum + 1;
                                        colEmptyInsurance = i + 1;
                                    }
                                    else
                                    {
                                        if (i == 0)
                                        {
                                            objIns.ic_breg_no = Convert.ToString(cell);
                                        }
                                        if (i == 1)
                                        {
                                            objIns.customer_name = Convert.ToString(cell);
                                        }
                                        if (i == 2)
                                        {
                                            objIns.bank_staff = Convert.ToString(cell);
                                        }
                                        if (i == 3)
                                        {
                                            objIns.address_1 = Convert.ToString(cell);
                                        }
                                        if (i == 4)
                                        {
                                            objIns.address_2 = Convert.ToString(cell);
                                        }
                                        if (i == 5)
                                        {
                                            objIns.address_3 = Convert.ToString(cell);
                                        }
                                        if (i == 6)
                                        {
                                            objIns.post_code = Convert.ToString(cell);
                                        }
                                        if (i == 7)
                                        {
                                            objIns.city = Convert.ToString(cell);
                                        }
                                        if (i == 8)
                                        {
                                            objIns.account_no = Convert.ToString(cell);
                                        }
                                        if (i == 9)
                                        {
                                            objIns.triton_account_no = Convert.ToString(cell);
                                        }
                                        if (i == 10)
                                        {
                                            objIns.branch_code = Convert.ToString(cell);
                                        }
                                        if (i == 11)
                                        {
                                            objIns.facility_type = Convert.ToString(cell);
                                        }
                                        if (i == 12)
                                        {
                                            objIns.approved_limit = Convert.ToString(cell);
                                        }
                                        if (i == 13)
                                        {
                                            objIns.approved_date = (Convert.ToString(cell) == "") ? Convert.ToDateTime("01/01/1970") : Convert.ToDateTime(Convert.ToString(cell));
                                        }
                                        if (i == 14)
                                        {
                                            objIns.balance_outstanding = Convert.ToString(cell);
                                        }
                                        if (i == 15)
                                        {
                                            objIns.cost_outstanding = Convert.ToString(cell);
                                        }
                                        if (i == 16)
                                        {
                                            objIns.principal_outstanding = Convert.ToString(cell);
                                        }
                                        if (i == 17)
                                        {
                                            objIns.uei_outstanding = Convert.ToString(cell);
                                        }
                                        if (i == 18)
                                        {
                                            objIns.month_arrears = Convert.ToString(cell);
                                        }
                                        if (i == 19)
                                        {
                                            objIns.credit_status = Convert.ToString(cell);
                                        }
                                        if (i == 20)
                                        {
                                            objIns.credit_stat_change_date = (Convert.ToString(cell) == "") ? Convert.ToDateTime("01/01/1970") : Convert.ToDateTime(Convert.ToString(cell));
                                        }
                                        if (i == 21)
                                        {
                                            objIns.npf_status = Convert.ToString(cell);
                                        }
                                        if (i == 22)
                                        {
                                            objIns.income_arrears = Convert.ToString(cell);
                                        }
                                        if (i == 23)
                                        {
                                            objIns.curr_balance_outstanding = Convert.ToString(cell);
                                        }
                                        if (i == 24)
                                        {
                                            objIns.collateral_ref_number = Convert.ToString(cell);
                                        }
                                        if (i == 25)
                                        {
                                            objIns.claim_type = Convert.ToString(cell);
                                        }
                                        if (i == 26)
                                        {
                                            objIns.property_type = Convert.ToString(cell);
                                        }
                                        if (i == 27)
                                        {
                                            objIns.credit_status = Convert.ToString(cell);
                                        }
                                        if (i == 28)
                                        {
                                            objIns.title_no = Convert.ToString(cell);
                                        }
                                        if (i == 29)
                                        {
                                            objIns.land_office = Convert.ToString(cell);
                                        }
                                        if (i == 30)
                                        {
                                            objIns.lot_number = Convert.ToString(cell);
                                        }
                                        if (i == 31)
                                        {
                                            objIns.property_address_1 = Convert.ToString(cell);
                                        }
                                        if (i == 32)
                                        {
                                            objIns.property_address_2 = Convert.ToString(cell);
                                        }
                                        if (i == 33)
                                        {
                                            objIns.property_address_3 = Convert.ToString(cell);
                                        }
                                        if (i == 34)
                                        {
                                            objIns.property_district = Convert.ToString(cell);
                                        }
                                        if (i == 35)
                                        {
                                            objIns.mukim = Convert.ToString(cell);
                                        }
                                        if (i == 36)
                                        {
                                            objIns.property_city = Convert.ToString(cell);
                                        }
                                        if (i == 37)
                                        {
                                            objIns.property_post_code = Convert.ToString(cell);
                                        }
                                        if (i == 38)
                                        {
                                            objIns.security_value = Convert.ToString(cell);
                                        }
                                        if (i == 39)
                                        {
                                            objIns.property_desc = Convert.ToString(cell);
                                        }
                                        if (i == 40)
                                        {
                                            objIns.property_owner_1 = Convert.ToString(cell);
                                        }
                                        if (i == 41)
                                        {
                                            objIns.property_owner_2 = Convert.ToString(cell);
                                        }
                                        if (i == 42)
                                        {
                                            objIns.insurance_company = Convert.ToString(cell);
                                        }
                                        if (i == 43)
                                        {
                                            objIns.policy_no = Convert.ToString(cell);
                                        }
                                        if (i == 44)
                                        {
                                            objIns.insurance_type = Convert.ToString(cell);
                                        }
                                        if (i == 45)
                                        {
                                            objIns.coverage_type = Convert.ToString(cell);
                                        }
                                        if (i == 46)
                                        {
                                            objIns.participant_name = Convert.ToString(cell);
                                        }
                                        if (i == 47)
                                        {
                                            objIns.risk_address_1 = Convert.ToString(cell);
                                        }
                                        if (i == 48)
                                        {
                                            objIns.risk_address_2 = Convert.ToString(cell);
                                        }
                                        if (i == 49)
                                        {
                                            objIns.risk_address_3 = Convert.ToString(cell);
                                        }
                                        if (i == 50)
                                        {
                                            objIns.risk_post_code = Convert.ToString(cell);
                                        }
                                        if (i == 51)
                                        {
                                            objIns.risk_city = Convert.ToString(cell);
                                        }
                                        if (i == 52)
                                        {
                                            objIns.risk_state_code = Convert.ToString(cell);
                                        }
                                        if (i == 53)
                                        {
                                            objIns.risk_country_code = Convert.ToString(cell);
                                        }
                                        if (i == 54)
                                        {
                                            objIns.start_date = (Convert.ToString(cell) == "") ? Convert.ToDateTime("01/01/1970") : Convert.ToDateTime(Convert.ToString(cell));
                                        }
                                        if (i == 55)
                                        {
                                            objIns.end_date = (Convert.ToString(cell) == "") ? Convert.ToDateTime("01/01/1970") : Convert.ToDateTime(Convert.ToString(cell));
                                        }
                                        if (i == 56)
                                        {
                                            objIns.premium_amt = Convert.ToString(cell);
                                        }
                                        if (i == 57)
                                        {
                                            objIns.sum_insured_amt = Convert.ToString(cell);
                                        }
                                        if (i == 58)
                                        {
                                            objIns.insurance_last_modified_date = (Convert.ToString(cell) == "") ? Convert.ToDateTime("01/01/1970") : Convert.ToDateTime(Convert.ToString(cell));
                                        }

                                    }
                                }

                            }
                            insList.Add(objIns);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        error = true;
                    }

                }
                else
                {
                    MessageBox.Show(e.Message);
                    error = true;
                }
            }
            dataGridView1.DataSource = bankList;
            dataGridView2.DataSource = insList;

            foreach (DataGridViewRow rw in this.dataGridView1.Rows)
            {
              for (int i = 0; i < rw.Cells.Count; i++)
              {
                if (rw.Cells[i].Value == null && rw.Cells[i].Value == DBNull.Value && rw.Cells[i].Value.ToString() == "")
                {
                  rw.Cells[i].ErrorText = "Empty";
                }
              } 
            }
            foreach (DataGridViewRow rw in this.dataGridView2.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null && rw.Cells[i].Value == DBNull.Value && rw.Cells[i].Value.ToString() == "")
                    {
                        rw.Cells[i].ErrorText = "Empty";
                    }
                }
            }
            if (error == false)
            {
//                MessageBox.Show("Import Sukses", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
/*                var hashset = new HashSet<Bank>();
                foreach (Bank name in bankList)
                {
                    if (!hashset.Add(name))
                    {
                        MessageBox.Show("Found Duplicate data in Bank File", "Found Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error = true;
                    }
                }
                var hashset2 = new HashSet<Insurance>();
                foreach (Insurance name in insList)
                {
                    if (!hashset2.Add(name))
                    {
                        MessageBox.Show("Found Duplicate data in Bank File", "Found Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error = true;
                    }
                }
*/
                if (insList.Count != insList.Select(c => new { c.policy_no }).Distinct().Count())
                {
                    MessageBox.Show("Found Duplicate Lines of data in Insurance File", "Found Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                }
                if (bankList.Count != bankList.Select(c => new { c.policy_no }).Distinct().Count())
                {
                    MessageBox.Show("Found Duplicate Lines of data in Bank File", "Found Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                }
                //if (bankList.Count != bankList.Select(c => new { c }).Distinct().Count())
                //{
                //    MessageBox.Show("Found Duplicate IC Number in Bank File", "Found Duplicate IC Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    error = true;
                //}
                if (emptyfound == true)
                {
                    MessageBox.Show("Found Empty Column, System can't merge it!", "Found Empty Column", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                }
                if (rowEmptyBank != -1)
                {
                    lblErrorBank.Text += "Empty value in Bank Data, row " + rowEmptyBank.ToString() + ", column " + colEmptyBank.ToString() + "";
                    error = true;
                }
                if (rowEmptyInsurance != -1)
                {
                    lblErrorInsurance.Text += "Empty value in Insurance Data, row " + rowEmptyInsurance.ToString() + ", column " + colEmptyInsurance.ToString() + "";
                    error = true;
                }
            }

            if (error == true)
            {
                btnNext_2.Enabled = false;
                btnFinish_2.Enabled = false;
            }
            else
            {
                btnNext_2.Enabled = true;
                btnFinish_2.Enabled = false;
            }
        
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
            start();
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txtBank.Text = fdlg.FileName;
                if (txtInsurance.Text.Trim() != "" && txtBank.Text != txtInsurance.Text)
                {
                    input_next();
                }
                if (txtBank.Text == txtInsurance.Text)
                {
                    MessageBox.Show("Bank File is the same file with Insurance File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtBank.Text = "";
                }
            }


        }

        private void btnFinish_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            tabPage2.Enabled = true;
            page2();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txtInsurance.Text = fdlg.FileName;
                if (txtBank.Text.Trim() != "" && txtBank.Text != txtInsurance.Text)
                {
                    input_next();
                }
                if (txtBank.Text == txtInsurance.Text)
                {
                    MessageBox.Show("Bank File is the same file with Insurance File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtInsurance.Text = "";
                }
            }


        }

        private void btnNext_2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            tabPage3.Enabled = true;
            merge_cond();
            merging();
        }
        private List<t_Insurance_data> getInsurance(string polis_no)
        {
            List<t_Insurance_data> insList2 = new List<t_Insurance_data>();
            foreach (t_Insurance_data insObj2 in insList)
            {
                if (insObj2.policy_no == polis_no)
                {
                    insList2.Add(insObj2);
                }
            }
            return insList2;
        }
        private Boolean foundDuplicateBank()
        {
            Boolean found = false;
/*            int sum = 0;
            List<Bank> tempBank = new List<Bank>();
            tempBank = bankList;
            foreach(Bank tmpBank in tempBank)
            {
                if()
            }
 * */
            return found;       
        }
        private void merging()
        {
            foreach (t_Bank_data bank in bankList)
            {
                List<t_Insurance_data> tempInsList =  new List<t_Insurance_data>();
                tempInsList = getInsurance(bank.policy_no);
                if(tempInsList.Count > 0)
                {
                    foreach(t_Insurance_data tempIns in tempInsList)
                    {
                        t_dmms_master mrgObj = new t_dmms_master();
                        mrgObj.BANK_REF_NO = bank.bank_ref_number;
                        mrgObj.NEW_NRIC = bank.nric;
                        mrgObj.POLICY_NO = bank.policy_no;
                        mrgObj.CUSTOMER_NAME = bank.participant_name;
                        //mrgObj.CUSTOMER_ADD2 = bank.customer_address_1;
                        mrgObj.CUSTOMER_ADD2 = bank.customer_address_2;
                        mrgObj.CUSTOMER_ADD3 = bank.customer_address_3;
                        mrgObj.CUSTOMER_ADD4 = bank.customer_address_4;
                        mrgObj.CUSTOMER_ADD5 = bank.customer_address_5;
                        mrgObj.CUSTOMER_CITY = tempIns.city;
                        mrgObj.CUSTOMER_POSTCODE = tempIns.post_code;
                        mrgObj.PROPERTY_TYPE = bank.property_type;
                        mrgObj.PROPERTY_ADD1 = bank.property_address_1;
                        mrgObj.PROPERTY_ADD2 = bank.property_address_2;
                        mrgObj.PROPERTY_ADD3 = bank.property_address_3;
                        mrgObj.PROPERTY_ADD4 = bank.property_address_4;
                        mrgObj.PROPERTY_CITY = tempIns.property_city;
                        mrgObj.PROPERTY_POSCODE = tempIns.property_post_code;
                        mrgObj.INSURANCE_TYPE = tempIns.insurance_type;
                        mrgObj.CERT_START_DATE = Convert.ToString(bank.policy_effective_date);
                        mrgObj.CERT_END_DATE = Convert.ToString(bank.policy_expired_date);
                        mrgObj.SUM_INSURED_AMOUNT = tempIns.sum_insured_amt;
                        mrgObj.BANK_STAFF = tempIns.bank_staff;
                        mrgObj.ACC_NO = tempIns.account_no;
                        mrgObj.TRITON_ACC_NO = tempIns.triton_account_no;
                        mrgObj.BRANCH_CODE = tempIns.branch_code;
                        mrgObj.FACILTY_TYPE = tempIns.facility_type;
                        mrgObj.APPROVED_LIMIT = tempIns.approved_limit;
                        mrgObj.APPROVED_DATE = Convert.ToString(tempIns.approved_date);
                        mrgObj.BAL_OUTSTANDING = tempIns.balance_outstanding;
                        mrgObj.COST_OUTSTANDING = tempIns.cost_outstanding;
                        mrgObj.PRINCIPAL_OUTSTANDING = tempIns.principal_outstanding;
                        mrgObj.UEI_OUTSTANDING = tempIns.uei_outstanding;
                        mrgObj.MONTH_ARREARS = tempIns.month_arrears;
                        mrgObj.CREDIT_STATUS = tempIns.credit_status;
                        mrgObj.CREDIT_STAT_CHG_DATE = Convert.ToString(tempIns.credit_stat_change_date);
                        mrgObj.NPF_STATUS = tempIns.npf_status;
                        mrgObj.REPORTING_BALANCE = tempIns.reporting_balance;
                        mrgObj.INCOME_ARREARS = tempIns.income_arrears;
                        mrgObj.CURR_BAL_OUTSTANDING = tempIns.curr_balance_outstanding;
                        mrgObj.COLLATERAL_REFNO = tempIns.collateral_ref_number;
                        mrgObj.CLAIM_TYPE = tempIns.claim_type;
                        mrgObj.TITLE_NO = tempIns.title_no;
                        mrgObj.LAND_OFFICE = tempIns.land_office;
                        mrgObj.LOT_NO = tempIns.lot_number;
                        mrgObj.PROPERTY_DISTRICT = tempIns.property_district;
                        mrgObj.MUKIM = tempIns.mukim;
                        mrgObj.SECURITY_VALUE = tempIns.security_value;
                        mrgObj.PROPERTY_DESC = tempIns.property_desc;
                        mrgObj.PROPERTY_OWNER1 = tempIns.property_owner_1;
                        mrgObj.PROPERTY_OWNER2 = tempIns.property_owner_2;
                        mrgObj.INSURANCE_COMPANY = tempIns.insurance_company;
                        mrgObj.COVERAGE_TYPE = tempIns.coverage_type;
                        mrgObj.PARTICIPANT_NAME = tempIns.participant_name;
                        mrgObj.RISK_ADD1 = tempIns.risk_address_1;
                        mrgObj.RISK_ADD2 = tempIns.risk_address_2;
                        mrgObj.RISK_ADD3 = tempIns.risk_address_3;
                        mrgObj.RISK_POSTCODE = tempIns.risk_post_code;
                        mrgObj.RISK_STATE_CODE = tempIns.risk_state_code;
                        mrgObj.PREMIUM_AMOUNT = tempIns.premium_amt;
                        mrgObj.INSURANCE_LAST_MODIFIED_DATE = Convert.ToString(tempIns.insurance_last_modified_date);
                        



                        mrgList.Add(mrgObj);
                    }
                }
                else
                {
                    t_dmms_master mrgObj = new t_dmms_master();
                    mrgObj.BANK_REF_NO = bank.bank_ref_number;
                    mrgObj.NEW_NRIC = bank.nric;
                    mrgObj.POLICY_NO = bank.policy_no;
                    mrgObj.CUSTOMER_NAME = bank.participant_name;
//                    mrgObj.CUSTOMER_ADD2 = bank.customer_address_1;
                    mrgObj.CUSTOMER_ADD2 = bank.customer_address_2;
                    mrgObj.CUSTOMER_ADD3 = bank.customer_address_3;
                    mrgObj.CUSTOMER_ADD4 = bank.customer_address_4;
                    mrgObj.CUSTOMER_ADD5 = bank.customer_address_5;
                    mrgObj.CUSTOMER_POSTCODE = bank.customer_post_code;
                    mrgObj.PROPERTY_TYPE = bank.property_type;
                    mrgObj.PROPERTY_ADD1 = bank.property_address_1;
                    mrgObj.PROPERTY_ADD2 = bank.property_address_2;
                    mrgObj.PROPERTY_ADD3 = bank.property_address_3;
                    mrgObj.PROPERTY_ADD4 = bank.property_address_4;
                    mrgObj.PROPERTY_POSCODE = bank.property_post_code;
                    mrgObj.CERT_START_DATE = Convert.ToString(bank.policy_effective_date);
                    mrgObj.CERT_END_DATE = Convert.ToString(bank.policy_expired_date);
                    mrgObj.SUM_INSURED_AMOUNT = Convert.ToString(bank.sum_covered);



                    mrgList.Add(mrgObj);
                }
            }
            dataGridView3.DataSource = mrgList;
        }
        private void merge_cond()
        {
            btnPrevious_3.Enabled = true;
            btnNext_3.Enabled = true;
            btnFinish_3.Enabled = false;
            txtBank_3.Text = txtBank.Text;
            txtInsurance_3.Text = txtInsurance.Text;
        }
        private void btnFinish_4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrevious_2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void btnPrevious_3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void btnPrevious_4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }

        private void btnNext_3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
            tabPage4.Enabled = true;
            save_cond();
        }
        private void save_cond()
        {
            btnFinish_4.Enabled = true;
            btnPrevious_4.Enabled = true;
            btnSaveData.Enabled = true;
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            Boolean error = false;
            try
            {
                /* SAVE BANK DATA */
                foreach (t_Bank_data bankObj in bankList)
                {

                    Entities1 mdl = new Entities1();
                    mdl.Connection.Open();
                    t_Bank_data selectBank = new t_Bank_data();
                    selectBank = (from c in mdl.t_Bank_data
                                  where (c.policy_no == bankObj.policy_no)
                                  select c).FirstOrDefault();

                    /*IF NOT EXIST, DO INSERT*/
                    if (selectBank == null)
                    {

                        mdl.AddTot_Bank_data(bankObj);
                        mdl.SaveChanges();
                        mdl.Connection.Close();
                    }
                }


                t_Insurance_data temp = new t_Insurance_data();
                /* SAVE INSURANCE DATA */
                foreach (t_Insurance_data insObj in insList)
                {

                    Entities1 mdl = new Entities1();
                    mdl.Connection.Open();
                    t_Insurance_data selectIns = new t_Insurance_data();
                    selectIns = (from c in mdl.t_Insurance_data
                                 where (c.policy_no == insObj.policy_no)&& (c.ic_breg_no == insObj.ic_breg_no)
                                 select c).FirstOrDefault();

                    /*IF NOT EXIST, DO INSERT*/
                    if (selectIns == null)
                    {
                        temp=insObj;
                        mdl.AddTot_Insurance_data(temp);
                        mdl.SaveChanges();
                        mdl.Connection.Close();
                    }
                }

                /*SAVE DMMS*/
                foreach(t_dmms_master mergeObj in mrgList)
                {
                    Entities1 mdl = new Entities1();
                    mdl.Connection.Open();
//                    mergeObj.SETTLEMENT_DATE = Convert.ToDateTime("01/01/1970");
//                    mergeObj.ADD_NEW_CUSTOMER_DATE = Convert.ToDateTime("01/01/1970");
                    mdl.AddTot_dmms_master(mergeObj);
                    mdl.SaveChanges();
                    mdl.Connection.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Inner Exception : " + ex.InnerException + " " + ex.Source + ex.StackTrace);
                error = true;
                btnFinish_4.Enabled = false;
                btnSaveData.Enabled = true;
            }
            if (error == false)
            {
                MessageBox.Show("Save Success");
                btnFinish_4.Enabled = true;
                btnSaveData.Enabled = false;
            }
        }

    }
}
