namespace Hotel.Items.UserControls
{
    partial class ucItemShortCardWithQuantity
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
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.pbItemImage = new System.Windows.Forms.PictureBox();
            this.numaricQuantity = new Guna.UI2.WinForms.Guna2NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numaricQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 30;
            this.guna2Elipse1.TargetControl = this;
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemPrice.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblItemPrice.Location = new System.Drawing.Point(0, 196);
            this.lblItemPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(256, 30);
            this.lblItemPrice.TabIndex = 165;
            this.lblItemPrice.Text = "Item Price";
            this.lblItemPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblItemName
            // 
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.White;
            this.lblItemName.Location = new System.Drawing.Point(0, 154);
            this.lblItemName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(256, 39);
            this.lblItemName.TabIndex = 164;
            this.lblItemName.Text = "Item Name";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbItemImage
            // 
            this.pbItemImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbItemImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbItemImage.Image = global::Hotel.Properties.Resources.question_mark;
            this.pbItemImage.InitialImage = null;
            this.pbItemImage.Location = new System.Drawing.Point(47, 7);
            this.pbItemImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbItemImage.Name = "pbItemImage";
            this.pbItemImage.Size = new System.Drawing.Size(169, 140);
            this.pbItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbItemImage.TabIndex = 163;
            this.pbItemImage.TabStop = false;
            this.pbItemImage.Click += new System.EventHandler(this.pbItemImage_Click);
            // 
            // numaricQuantity
            // 
            this.numaricQuantity.BackColor = System.Drawing.Color.Transparent;
            this.numaricQuantity.BorderRadius = 15;
            this.numaricQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numaricQuantity.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numaricQuantity.Location = new System.Drawing.Point(10, 231);
            this.numaricQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numaricQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numaricQuantity.Name = "numaricQuantity";
            this.numaricQuantity.Size = new System.Drawing.Size(100, 36);
            this.numaricQuantity.TabIndex = 166;
            this.numaricQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ucItemShortCardWithQuantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.Controls.Add(this.numaricQuantity);
            this.Controls.Add(this.lblItemPrice);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.pbItemImage);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucItemShortCardWithQuantity";
            this.Size = new System.Drawing.Size(256, 274);
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numaricQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label lblItemPrice;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.PictureBox pbItemImage;
        private Guna.UI2.WinForms.Guna2NumericUpDown numaricQuantity;
    }
}
