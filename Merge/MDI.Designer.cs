using System.Windows.Forms;
namespace Merge
{
    partial class MDI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                Application.Exit();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuMain = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.Report = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportBranches = new System.Windows.Forms.ToolStripMenuItem();
            this.BranchesExpire = new System.Windows.Forms.ToolStripMenuItem();
            this.BranchesActive = new System.Windows.Forms.ToolStripMenuItem();
            this.SummaryByBranchesandInsurer = new System.Windows.Forms.ToolStripMenuItem();
            this.SummaryByBranchesOverall = new System.Windows.Forms.ToolStripMenuItem();
            this.SummarybyBranchesOveral = new System.Windows.Forms.ToolStripMenuItem();
            this.DebitNoteSummary = new System.Windows.Forms.ToolStripMenuItem();
            this.UserMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.AddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuMain
            // 
            this.MenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.Report,
            this.UserMenu});
            this.MenuMain.Location = new System.Drawing.Point(0, 0);
            this.MenuMain.Name = "MenuMain";
            this.MenuMain.Size = new System.Drawing.Size(507, 24);
            this.MenuMain.TabIndex = 1;
            // 
            // File
            // 
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImport,
            this.mnuExit});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(37, 20);
            this.File.Text = "File";
            // 
            // mnuImport
            // 
            this.mnuImport.Name = "mnuImport";
            this.mnuImport.Size = new System.Drawing.Size(197, 22);
            this.mnuImport.Text = "Import and Merge Data";
            this.mnuImport.Click += new System.EventHandler(this.mnuImport_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(197, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // Report
            // 
            this.Report.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReportBranches,
            this.BranchesExpire,
            this.BranchesActive,
            this.SummaryByBranchesandInsurer,
            this.SummaryByBranchesOverall,
            this.SummarybyBranchesOveral,
            this.DebitNoteSummary});
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(54, 20);
            this.Report.Text = "Report";
            // 
            // ReportBranches
            // 
            this.ReportBranches.Name = "ReportBranches";
            this.ReportBranches.Size = new System.Drawing.Size(254, 22);
            this.ReportBranches.Text = "Report Branches";
            this.ReportBranches.Click += new System.EventHandler(this.ReportBranches_Click);
            // 
            // BranchesExpire
            // 
            this.BranchesExpire.Name = "BranchesExpire";
            this.BranchesExpire.Size = new System.Drawing.Size(254, 22);
            this.BranchesExpire.Text = "Report Branches Expire";
            this.BranchesExpire.Click += new System.EventHandler(this.BranchesExpire_Click);
            // 
            // BranchesActive
            // 
            this.BranchesActive.Name = "BranchesActive";
            this.BranchesActive.Size = new System.Drawing.Size(254, 22);
            this.BranchesActive.Text = "Branches Active";
            this.BranchesActive.Click += new System.EventHandler(this.BranchesActive_Click);
            // 
            // SummaryByBranchesandInsurer
            // 
            this.SummaryByBranchesandInsurer.Name = "SummaryByBranchesandInsurer";
            this.SummaryByBranchesandInsurer.Size = new System.Drawing.Size(254, 22);
            this.SummaryByBranchesandInsurer.Text = "Summary By Branches and Insurer";
            this.SummaryByBranchesandInsurer.Click += new System.EventHandler(this.SummaryByBranchesandInsurer_Click);
            // 
            // SummaryByBranchesOverall
            // 
            this.SummaryByBranchesOverall.Name = "SummaryByBranchesOverall";
            this.SummaryByBranchesOverall.Size = new System.Drawing.Size(254, 22);
            this.SummaryByBranchesOverall.Text = "Summary By Branches Overall";
            this.SummaryByBranchesOverall.Click += new System.EventHandler(this.SummaryByBranchesOverall_Click);
            // 
            // SummarybyBranchesOveral
            // 
            this.SummarybyBranchesOveral.Name = "SummarybyBranchesOveral";
            this.SummarybyBranchesOveral.Size = new System.Drawing.Size(254, 22);
            this.SummarybyBranchesOveral.Text = "Summary By Insurer Overall";
            this.SummarybyBranchesOveral.Click += new System.EventHandler(this.SummarybyBranchesOveral_Click);
            // 
            // DebitNoteSummary
            // 
            this.DebitNoteSummary.Name = "DebitNoteSummary";
            this.DebitNoteSummary.Size = new System.Drawing.Size(254, 22);
            this.DebitNoteSummary.Text = "Debit Note Summary";
            // 
            // UserMenu
            // 
            this.UserMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangePassword,
            this.AddUser});
            this.UserMenu.Name = "UserMenu";
            this.UserMenu.Size = new System.Drawing.Size(42, 20);
            this.UserMenu.Text = "User";
            // 
            // ChangePassword
            // 
            this.ChangePassword.Name = "ChangePassword";
            this.ChangePassword.Size = new System.Drawing.Size(168, 22);
            this.ChangePassword.Text = "Change Password";
            this.ChangePassword.Click += new System.EventHandler(this.ChangePassword_Click);
            // 
            // AddUser
            // 
            this.AddUser.Name = "AddUser";
            this.AddUser.Size = new System.Drawing.Size(168, 22);
            this.AddUser.Text = "Add User";
            this.AddUser.Click += new System.EventHandler(this.AddUser_Click);
            // 
            // MDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 262);
            this.Controls.Add(this.MenuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuMain;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DMMS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDI_Load);
            this.MenuMain.ResumeLayout(false);
            this.MenuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuMain;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.ToolStripMenuItem mnuImport;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private ToolStripMenuItem Report;
        private ToolStripMenuItem ReportBranches;
        private ToolStripMenuItem BranchesExpire;
        private ToolStripMenuItem BranchesActive;
        private ToolStripMenuItem SummaryByBranchesandInsurer;
        private ToolStripMenuItem SummaryByBranchesOverall;
        private ToolStripMenuItem SummarybyBranchesOveral;
        private ToolStripMenuItem DebitNoteSummary;
        private ToolStripMenuItem UserMenu;
        private ToolStripMenuItem ChangePassword;
        private ToolStripMenuItem AddUser;
    }
}