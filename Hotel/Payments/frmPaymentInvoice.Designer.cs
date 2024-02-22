namespace Hotel.Payments
{
    partial class frmPaymentInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaymentInvoice));
            this.label22 = new System.Windows.Forms.Label();
            this.lblHotelName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ucPaymentCard1 = new Hotel.Payments.UserControls.ucPaymentCard();
            this.ucInvoiceCard1 = new Hotel.Payments.UserControls.ucInvoiceCard();
            this.btnPrint = new Guna.UI2.WinForms.Guna2GradientButton();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(359, 25);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(106, 21);
            this.label22.TabIndex = 156;
            this.label22.Text = "Hotel Name:";
            // 
            // lblHotelName
            // 
            this.lblHotelName.AutoSize = true;
            this.lblHotelName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHotelName.ForeColor = System.Drawing.Color.Black;
            this.lblHotelName.Location = new System.Drawing.Point(474, 25);
            this.lblHotelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHotelName.Name = "lblHotelName";
            this.lblHotelName.Size = new System.Drawing.Size(50, 21);
            this.lblHotelName.TabIndex = 157;
            this.lblHotelName.Text = "[????]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(359, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 21);
            this.label1.TabIndex = 158;
            this.label1.Text = "Phone:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ForeColor = System.Drawing.Color.Black;
            this.lblPhone.Location = new System.Drawing.Point(474, 62);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(50, 21);
            this.lblPhone.TabIndex = 159;
            this.lblPhone.Text = "[????]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(359, 99);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 21);
            this.label3.TabIndex = 160;
            this.label3.Text = "Email:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.Black;
            this.lblEmail.Location = new System.Drawing.Point(474, 99);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(50, 21);
            this.lblEmail.TabIndex = 161;
            this.lblEmail.Text = "[????]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(359, 136);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 162;
            this.label5.Text = "Address:";
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.Black;
            this.lblAddress.Location = new System.Drawing.Point(474, 136);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(403, 47);
            this.lblAddress.TabIndex = 163;
            this.lblAddress.Text = "[????]";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hotel.Properties.Resources.hotel_login;
            this.pictureBox1.Location = new System.Drawing.Point(76, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(245, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 166;
            this.pictureBox1.TabStop = false;
            // 
            // ucPaymentCard1
            // 
            this.ucPaymentCard1.BackColor = System.Drawing.Color.White;
            this.ucPaymentCard1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucPaymentCard1.Location = new System.Drawing.Point(16, 326);
            this.ucPaymentCard1.Name = "ucPaymentCard1";
            this.ucPaymentCard1.Size = new System.Drawing.Size(862, 255);
            this.ucPaymentCard1.TabIndex = 165;
            // 
            // ucInvoiceCard1
            // 
            this.ucInvoiceCard1.BackColor = System.Drawing.Color.White;
            this.ucInvoiceCard1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucInvoiceCard1.Location = new System.Drawing.Point(16, 193);
            this.ucInvoiceCard1.Name = "ucInvoiceCard1";
            this.ucInvoiceCard1.Size = new System.Drawing.Size(862, 114);
            this.ucInvoiceCard1.TabIndex = 164;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BorderRadius = 20;
            this.btnPrint.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrint.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrint.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrint.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrint.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrint.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            this.btnPrint.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Image = global::Hotel.Properties.Resources.close_48;
            this.btnPrint.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPrint.ImageSize = new System.Drawing.Size(30, 30);
            this.btnPrint.Location = new System.Drawing.Point(669, 654);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnPrint.Size = new System.Drawing.Size(155, 45);
            this.btnPrint.TabIndex = 203;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // frmPaymentInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(890, 725);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ucPaymentCard1);
            this.Controls.Add(this.ucInvoiceCard1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblHotelName);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmPaymentInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Invoice";
            this.Load += new System.EventHandler(this.frmPaymentInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblHotelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAddress;
        private UserControls.ucInvoiceCard ucInvoiceCard1;
        private UserControls.ucPaymentCard ucPaymentCard1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2GradientButton btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}