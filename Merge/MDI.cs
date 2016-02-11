using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Merge
{
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
            this.FormClosed += OnFormClosed;
        }

        private void MDI_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (CloseCancel() == false)
            {
                e.Cancel = true;
            };
        }

        protected void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        public static bool CloseCancel()
        {
            const string message = "Are you sure to close this program?";
            const string caption = "Close Program";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuImport_Click(object sender, EventArgs e)
        {
            MergeData inpt = new MergeData();
            MDI mdifrm = new MDI();
            inpt.MdiParent = this;

            inpt.Show();



        }

        private void ReportBranches_Click(object sender, EventArgs e)
        {
             ReportBranches inpt = new ReportBranches();
            MDI mdifrm = new MDI();
            inpt.MdiParent = this;

            inpt.Show();

        }

        private void BranchesExpire_Click(object sender, EventArgs e)
        {
            ReportBranchesExpire inpt = new ReportBranchesExpire();
            MDI mdifrm = new MDI();
            inpt.MdiParent = this;

            inpt.Show();


        }

        private void BranchesActive_Click(object sender, EventArgs e)
        {
            BranchActive inpt = new BranchActive();
            MDI mdifrm = new MDI();
            inpt.MdiParent = this;

            inpt.Show();


        }

        private void SummaryByBranchesandInsurer_Click(object sender, EventArgs e)
        {
            SummaryByBranchesInsurer inpt = new SummaryByBranchesInsurer();
            MDI mdifrm = new MDI();
            inpt.MdiParent = this;

            inpt.Show();
        }

        private void SummaryByBranchesOverall_Click(object sender, EventArgs e)
        {
            SummaryByBranchesOverall inpt = new SummaryByBranchesOverall();

            MDI mdifrm = new MDI();
            inpt.MdiParent = this;

            inpt.Show();
        }

        private void SummarybyBranchesOveral_Click(object sender, EventArgs e)
        {
            SummaryByInsurerOverall inpt = new SummaryByInsurerOverall();

            MDI mdifrm = new MDI();
            inpt.MdiParent = this;

            inpt.Show();
        }

        private void ChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword inpt = new ChangePassword();

            MDI mdifrm = new MDI();
            inpt.MdiParent = this;

            inpt.Show();
        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            AddUser inpt = new AddUser();
            MDI mdifrm = new MDI();
            inpt.MdiParent = this;

            inpt.Show();
        }


    }
}
