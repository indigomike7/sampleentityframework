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
    public partial class SummaryByBranchesOverall : Form
    {
        List<t_dmms_master> selectBranch = new List<t_dmms_master>();
        HSSFWorkbook hssfworkbook;
        public SummaryByBranchesOverall()
        {
            InitializeComponent();
        }

        private void SummaryByBranchesOverall_Load(object sender, EventArgs e)
        {
            Entities1 mdl = new Entities1();
            mdl.Connection.Open();
            //            List<t_dmms_master> selectBranch = new List<t_dmms_master>();
            DateTime now = DateTime.Now;
            string nowstr = now.ToLongDateString();
            var selectBranch1 = (from c in mdl.t_dmms_master
                                 where (c.CERT_END_DATE.CompareTo(nowstr) >= 0)
                                 group c by new { c.BRANCH_CODE, c.BRANCHES } into g
                                 select new { g.Key.BRANCH_CODE, g.Key.BRANCHES, NumberofAccountActive = g.Count(), Total = g.Count() });
            var selectBranch2 = (from c in mdl.t_dmms_master
                                 where (c.CERT_END_DATE.CompareTo(nowstr) < 0)
                                 group c by new { c.BRANCH_CODE, c.BRANCHES } into g
                                 select new { g.Key.BRANCH_CODE, g.Key.BRANCHES, NumberofAccountExpire = g.Count(), Total = g.Count() });
            var unions = from post in selectBranch2
                         join meta in selectBranch1 on new { post.BRANCH_CODE } equals new { meta.BRANCH_CODE } into gj
                         from a in gj.DefaultIfEmpty()
                         select new { post.BRANCH_CODE, post.BRANCHES, post.NumberofAccountExpire, NumbersofAccountActive = (a.NumberofAccountActive == null) ? 0 : a.NumberofAccountActive };
            //            var data = selectBranch.ToList();

            /*           selectBranch = mdl.t_dmms_master.Where(x => x.CERT_END_DATE.OfType<DateTime>() < now).ToList();
             * */
            /*IF NOT EXIST, DO INSERT*/
            if (unions != null)
            {
                dataGridView1.DataSource = unions;
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
                row.CreateCell(0).SetCellValue("Branch Code");
                row.CreateCell(1).SetCellValue("NumberofAccountExpire");
                row.CreateCell(2).SetCellValue("NumbersofAccountActive");
                /*LOOP THROUGH DATA AND CREATE TO SHEET*/
                Entities1 mdl = new Entities1();
                mdl.Connection.Open();
                //            List<t_dmms_master> selectBranch = new List<t_dmms_master>();
                DateTime now = DateTime.Now;
                string nowstr = now.ToLongDateString();
                var selectBranch1 = (from c in mdl.t_dmms_master
                                     where (c.CERT_END_DATE.CompareTo(nowstr) >= 0)
                                     group c by new { c.BRANCH_CODE, c.BRANCHES } into g
                                     select new { g.Key.BRANCH_CODE,g.Key.BRANCHES, NumberofAccountActive = g.Count(), Total = g.Count() });
                var selectBranch2 = (from c in mdl.t_dmms_master
                                     where (c.CERT_END_DATE.CompareTo(nowstr) < 0)
                                     group c by new { c.BRANCH_CODE,c.BRANCHES } into g
                                     select new { g.Key.BRANCH_CODE, g.Key.BRANCHES, NumberofAccountExpire = g.Count(), Total = g.Count() });
                var unions = from post in selectBranch2
                             join meta in selectBranch1 on new { post.BRANCH_CODE } equals new { meta.BRANCH_CODE } into gj
                             from a in gj.DefaultIfEmpty()
                             select new { post.BRANCH_CODE, post.BRANCHES, post.NumberofAccountExpire, NumbersofAccountActive = (a.NumberofAccountActive == null) ? 0 : a.NumberofAccountActive };

                int i = 1;
                foreach (var dmms in unions)
                {
                    //DateTime settlementdate =DateTime.Parse("01/01/1970");
                    //DateTime addnewcustomerdate = DateTime.Parse("01/01/1970");
                    //if (dmms.SETTLEMENT_DATE == null) { settlementdate = DateTime.Parse("01/01/1970"); } else { settlementdate = dmms.SETTLEMENT_DATE   }
                    //if (dmms.ADD_NEW_CUSTOMER_DATE == null) { addnewcustomerdate = DateTime.Parse("01/01/1970"); }
                    row = sheet1.CreateRow(i);
                    row.CreateCell(0).SetCellValue(dmms.BRANCHES);
                    row.CreateCell(1).SetCellValue(dmms.BRANCH_CODE);
                    row.CreateCell(2).SetCellValue(dmms.NumberofAccountExpire);
                    row.CreateCell(3).SetCellValue(dmms.NumbersofAccountActive);
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
