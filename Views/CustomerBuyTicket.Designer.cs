namespace StadiumMS.Views
{
    partial class CustomerBuyTicket
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
            this.panelCard = new System.Windows.Forms.Panel();
            this.lblEvent = new System.Windows.Forms.Label();
            this.txtEvent = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.lblSeat = new System.Windows.Forms.Label();
            this.cmbSeat = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPayment = new System.Windows.Forms.Label();
            this.cmbPayment = new System.Windows.Forms.ComboBox();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelCard.SuspendLayout();
            this.SuspendLayout();
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.panelHeader.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(520, 70);
            this.panelHeader.TabIndex = 0;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.lblTitle.Location = new System.Drawing.Point(24, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Buy Ticket";
            this.panelCard.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.panelCard.Location = new System.Drawing.Point(24, 92);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(472, 396);
            this.panelCard.TabIndex = 1;
            this.lblEvent.AutoSize = true;
            this.lblEvent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEvent.ForeColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.lblEvent.Location = new System.Drawing.Point(24, 18);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(120, 19);
            this.lblEvent.TabIndex = 0;
            this.lblEvent.Text = "Event";
            this.txtEvent.BackColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.txtEvent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEvent.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEvent.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.txtEvent.ReadOnly = true;
            this.txtEvent.Location = new System.Drawing.Point(24, 42);
            this.txtEvent.Name = "txtEvent";
            this.txtEvent.Size = new System.Drawing.Size(424, 27);
            this.txtEvent.TabIndex = 1;
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.lblDate.Location = new System.Drawing.Point(24, 88);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(120, 19);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date";
            this.txtDate.BackColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDate.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.txtDate.ReadOnly = true;
            this.txtDate.Location = new System.Drawing.Point(24, 112);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(424, 27);
            this.txtDate.TabIndex = 3;
            this.lblSeat.AutoSize = true;
            this.lblSeat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSeat.ForeColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.lblSeat.Location = new System.Drawing.Point(24, 158);
            this.lblSeat.Name = "lblSeat";
            this.lblSeat.Size = new System.Drawing.Size(120, 19);
            this.lblSeat.TabIndex = 4;
            this.lblSeat.Text = "Seat";
            this.cmbSeat.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.cmbSeat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSeat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSeat.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.cmbSeat.FormattingEnabled = true;
            this.cmbSeat.Items.AddRange(new object[] {
            "-- Select Seat --"});
            this.cmbSeat.Location = new System.Drawing.Point(24, 182);
            this.cmbSeat.Name = "cmbSeat";
            this.cmbSeat.Size = new System.Drawing.Size(424, 27);
            this.cmbSeat.TabIndex = 5;
            this.cmbSeat.SelectedIndex = 0;
            this.cmbSeat.SelectedIndexChanged += new System.EventHandler(this.cmbSeat_SelectedIndexChanged);
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.lblPrice.Location = new System.Drawing.Point(24, 228);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(120, 19);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Price (RWF)";
            this.txtPrice.BackColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPrice.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Location = new System.Drawing.Point(24, 252);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(424, 27);
            this.txtPrice.TabIndex = 7;
            this.lblPayment.AutoSize = true;
            this.lblPayment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPayment.ForeColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.lblPayment.Location = new System.Drawing.Point(24, 298);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(160, 19);
            this.lblPayment.TabIndex = 8;
            this.lblPayment.Text = "Payment Method";
            this.cmbPayment.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.cmbPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPayment.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbPayment.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.cmbPayment.FormattingEnabled = true;
            this.cmbPayment.Items.AddRange(new object[] {
            "-- Select Payment Method --", "Cash", "Mobile Money", "Credit Card"});
            this.cmbPayment.Location = new System.Drawing.Point(24, 322);
            this.cmbPayment.Name = "cmbPayment";
            this.cmbPayment.Size = new System.Drawing.Size(424, 27);
            this.cmbPayment.TabIndex = 9;
            this.cmbPayment.SelectedIndex = 0;
            this.btnPurchase.BackColor = System.Drawing.Color.FromArgb(20, 184, 166);
            this.btnPurchase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPurchase.FlatAppearance.BorderSize = 0;
            this.btnPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchase.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPurchase.ForeColor = System.Drawing.Color.FromArgb(6, 43, 40);
            this.btnPurchase.Location = new System.Drawing.Point(24, 506);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(230, 46);
            this.btnPurchase.TabIndex = 2;
            this.btnPurchase.Text = "Purchase";
            this.btnPurchase.UseVisualStyleBackColor = false;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.btnBack.Location = new System.Drawing.Point(266, 506);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(230, 46);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.ClientSize = new System.Drawing.Size(520, 580);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelCard);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CustomerBuyTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stadium Management - Buy Ticket";
            this.Load += new System.EventHandler(this.CustomerBuyTicket_Load);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelCard.Controls.Add(this.lblEvent);
            this.panelCard.Controls.Add(this.txtEvent);
            this.panelCard.Controls.Add(this.lblDate);
            this.panelCard.Controls.Add(this.txtDate);
            this.panelCard.Controls.Add(this.lblSeat);
            this.panelCard.Controls.Add(this.cmbSeat);
            this.panelCard.Controls.Add(this.lblPrice);
            this.panelCard.Controls.Add(this.txtPrice);
            this.panelCard.Controls.Add(this.lblPayment);
            this.panelCard.Controls.Add(this.cmbPayment);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.TextBox txtEvent;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label lblSeat;
        private System.Windows.Forms.ComboBox cmbSeat;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.ComboBox cmbPayment;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button btnBack;
    }
}
