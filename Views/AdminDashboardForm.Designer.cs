namespace StadiumMS.Views
{
    partial class AdminDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.panelEvents = new System.Windows.Forms.Panel();
            this.lblEventsValue = new System.Windows.Forms.Label();
            this.lblEventsCaption = new System.Windows.Forms.Label();
            this.panelTickets = new System.Windows.Forms.Panel();
            this.lblTicketsValue = new System.Windows.Forms.Label();
            this.lblTicketsCaption = new System.Windows.Forms.Label();
            this.panelRevenue = new System.Windows.Forms.Panel();
            this.lblRevenueValue = new System.Windows.Forms.Label();
            this.lblRevenueCaption = new System.Windows.Forms.Label();
            this.btnManageEvents = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelEvents.SuspendLayout();
            this.panelTickets.SuspendLayout();
            this.panelRevenue.SuspendLayout();
            this.SuspendLayout();
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(720, 90);
            this.panelHeader.TabIndex = 0;
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.lblTitle.Location = new System.Drawing.Point(28, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(640, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Admin Dashboard";
            this.lblSubtitle.AutoSize = false;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            this.lblSubtitle.Location = new System.Drawing.Point(28, 52);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(640, 22);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Overview of events and ticket sales";
            this.panelEvents.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.panelEvents.Location = new System.Drawing.Point(28, 120);
            this.panelEvents.Name = "panelEvents";
            this.panelEvents.Size = new System.Drawing.Size(200, 110);
            this.panelEvents.TabIndex = 1;
            this.lblEventsValue.AutoSize = false;
            this.lblEventsValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEventsValue.ForeColor = System.Drawing.Color.FromArgb(20, 184, 166);
            this.lblEventsValue.Location = new System.Drawing.Point(16, 18);
            this.lblEventsValue.Name = "lblEventsValue";
            this.lblEventsValue.Size = new System.Drawing.Size(168, 40);
            this.lblEventsValue.TabIndex = 0;
            this.lblEventsValue.Text = "0";
            this.lblEventsCaption.AutoSize = false;
            this.lblEventsCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEventsCaption.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            this.lblEventsCaption.Location = new System.Drawing.Point(16, 66);
            this.lblEventsCaption.Name = "lblEventsCaption";
            this.lblEventsCaption.Size = new System.Drawing.Size(168, 22);
            this.lblEventsCaption.TabIndex = 1;
            this.lblEventsCaption.Text = "Total Events";
            this.panelTickets.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.panelTickets.Location = new System.Drawing.Point(260, 120);
            this.panelTickets.Name = "panelTickets";
            this.panelTickets.Size = new System.Drawing.Size(200, 110);
            this.panelTickets.TabIndex = 2;
            this.lblTicketsValue.AutoSize = false;
            this.lblTicketsValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTicketsValue.ForeColor = System.Drawing.Color.FromArgb(20, 184, 166);
            this.lblTicketsValue.Location = new System.Drawing.Point(16, 18);
            this.lblTicketsValue.Name = "lblTicketsValue";
            this.lblTicketsValue.Size = new System.Drawing.Size(168, 40);
            this.lblTicketsValue.TabIndex = 0;
            this.lblTicketsValue.Text = "0";
            this.lblTicketsCaption.AutoSize = false;
            this.lblTicketsCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTicketsCaption.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            this.lblTicketsCaption.Location = new System.Drawing.Point(16, 66);
            this.lblTicketsCaption.Name = "lblTicketsCaption";
            this.lblTicketsCaption.Size = new System.Drawing.Size(168, 22);
            this.lblTicketsCaption.TabIndex = 1;
            this.lblTicketsCaption.Text = "Tickets Sold";
            this.panelRevenue.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.panelRevenue.Location = new System.Drawing.Point(492, 120);
            this.panelRevenue.Name = "panelRevenue";
            this.panelRevenue.Size = new System.Drawing.Size(200, 110);
            this.panelRevenue.TabIndex = 3;
            this.lblRevenueValue.AutoSize = false;
            this.lblRevenueValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRevenueValue.ForeColor = System.Drawing.Color.FromArgb(20, 184, 166);
            this.lblRevenueValue.Location = new System.Drawing.Point(16, 18);
            this.lblRevenueValue.Name = "lblRevenueValue";
            this.lblRevenueValue.Size = new System.Drawing.Size(168, 40);
            this.lblRevenueValue.TabIndex = 0;
            this.lblRevenueValue.Text = "0";
            this.lblRevenueCaption.AutoSize = false;
            this.lblRevenueCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRevenueCaption.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            this.lblRevenueCaption.Location = new System.Drawing.Point(16, 66);
            this.lblRevenueCaption.Name = "lblRevenueCaption";
            this.lblRevenueCaption.Size = new System.Drawing.Size(168, 22);
            this.lblRevenueCaption.TabIndex = 1;
            this.lblRevenueCaption.Text = "Revenue (RWF)";
            this.btnManageEvents.BackColor = System.Drawing.Color.FromArgb(20, 184, 166);
            this.btnManageEvents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageEvents.FlatAppearance.BorderSize = 0;
            this.btnManageEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageEvents.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnManageEvents.ForeColor = System.Drawing.Color.FromArgb(6, 43, 40);
            this.btnManageEvents.Location = new System.Drawing.Point(28, 260);
            this.btnManageEvents.Name = "btnManageEvents";
            this.btnManageEvents.Size = new System.Drawing.Size(328, 52);
            this.btnManageEvents.TabIndex = 4;
            this.btnManageEvents.Text = "Manage Events";
            this.btnManageEvents.UseVisualStyleBackColor = false;
            this.btnManageEvents.Click += new System.EventHandler(this.btnManageEvents_Click);
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.btnLogout.Location = new System.Drawing.Point(364, 260);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(328, 52);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.ClientSize = new System.Drawing.Size(720, 360);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelEvents);
            this.Controls.Add(this.panelTickets);
            this.Controls.Add(this.panelRevenue);
            this.Controls.Add(this.btnManageEvents);
            this.Controls.Add(this.btnLogout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdminDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stadium Management - Admin";
            this.Load += new System.EventHandler(this.AdminDashboardForm_Load);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblSubtitle);
            this.panelEvents.Controls.Add(this.lblEventsValue);
            this.panelEvents.Controls.Add(this.lblEventsCaption);
            this.panelTickets.Controls.Add(this.lblTicketsValue);
            this.panelTickets.Controls.Add(this.lblTicketsCaption);
            this.panelRevenue.Controls.Add(this.lblRevenueValue);
            this.panelRevenue.Controls.Add(this.lblRevenueCaption);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelEvents.ResumeLayout(false);
            this.panelEvents.PerformLayout();
            this.panelTickets.ResumeLayout(false);
            this.panelTickets.PerformLayout();
            this.panelRevenue.ResumeLayout(false);
            this.panelRevenue.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel panelEvents;
        private System.Windows.Forms.Label lblEventsValue;
        private System.Windows.Forms.Label lblEventsCaption;
        private System.Windows.Forms.Panel panelTickets;
        private System.Windows.Forms.Label lblTicketsValue;
        private System.Windows.Forms.Label lblTicketsCaption;
        private System.Windows.Forms.Panel panelRevenue;
        private System.Windows.Forms.Label lblRevenueValue;
        private System.Windows.Forms.Label lblRevenueCaption;
        private System.Windows.Forms.Button btnManageEvents;
        private System.Windows.Forms.Button btnLogout;
    }
}
