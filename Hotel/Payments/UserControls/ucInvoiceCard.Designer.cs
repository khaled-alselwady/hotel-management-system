namespace Hotel.Payments.UserControls
{
    partial class ucInvoiceCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblInvoiceID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Controls.Add(this.lblInvoiceDate);
            this.guna2GroupBox1.Controls.Add(this.label22);
            this.guna2GroupBox1.Controls.Add(this.lblInvoiceID);
            this.guna2GroupBox1.Controls.Add(this.label12);
            this.guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(862, 114);
            this.guna2GroupBox1.TabIndex = 3;
            this.guna2GroupBox1.Text = "Invoice Details";
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.AutoSize = true;
            this.lblInvoiceDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceDate.Location = new System.Drawing.Point(636, 67);
            this.lblInvoiceDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(50, 21);
            this.lblInvoiceDate.TabIndex = 162;
            this.lblInvoiceDate.Text = "[????]";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(13, 67);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(91, 21);
            this.label22.TabIndex = 141;
            this.label22.Text = "Invoice ID:";
            // 
            // lblInvoiceID
            // 
            this.lblInvoiceID.AutoSize = true;
            this.lblInvoiceID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceID.ForeColor = System.Drawing.Color.Black;
            this.lblInvoiceID.Location = new System.Drawing.Point(127, 67);
            this.lblInvoiceID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInvoiceID.Name = "lblInvoiceID";
            this.lblInvoiceID.Size = new System.Drawing.Size(50, 21);
            this.lblInvoiceID.TabIndex = 155;
            this.lblInvoiceID.Text = "[????]";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(525, 67);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 21);
            this.label12.TabIndex = 147;
            this.label12.Text = "Invoice Date:";
            // 
            // ucInvoiceCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2GroupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucInvoiceCard";
            this.Size = new System.Drawing.Size(862, 114);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Label lblInvoiceDate;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblInvoiceID;
        private System.Windows.Forms.Label label12;
    }
}
