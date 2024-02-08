namespace Hotel.Items.UserControls
{
    partial class ucItemShortCard
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
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.cmsEditProfile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowItemDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.EditItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbItemImage = new System.Windows.Forms.PictureBox();
            this.cmsEditProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 30;
            this.guna2Elipse1.TargetControl = this;
            // 
            // lblItemName
            // 
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.White;
            this.lblItemName.Location = new System.Drawing.Point(0, 166);
            this.lblItemName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(256, 39);
            this.lblItemName.TabIndex = 161;
            this.lblItemName.Text = "Item Name";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblItemName.DoubleClick += new System.EventHandler(this.lblItemName_DoubleClick);
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemPrice.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblItemPrice.Location = new System.Drawing.Point(0, 216);
            this.lblItemPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(256, 30);
            this.lblItemPrice.TabIndex = 162;
            this.lblItemPrice.Text = "Item Price";
            this.lblItemPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblItemPrice.Click += new System.EventHandler(this.lblItemPrice_Click);
            // 
            // cmsEditProfile
            // 
            this.cmsEditProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmsEditProfile.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsEditProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowItemDetailsToolStripMenuItem1,
            this.toolStripSeparator6,
            this.EditItemToolStripMenuItem});
            this.cmsEditProfile.Name = "contextMenuStrip1";
            this.cmsEditProfile.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsEditProfile.Size = new System.Drawing.Size(222, 86);
            // 
            // ShowItemDetailsToolStripMenuItem1
            // 
            this.ShowItemDetailsToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.ShowItemDetailsToolStripMenuItem1.Image = global::Hotel.Properties.Resources.show_reservation_32;
            this.ShowItemDetailsToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowItemDetailsToolStripMenuItem1.Name = "ShowItemDetailsToolStripMenuItem1";
            this.ShowItemDetailsToolStripMenuItem1.Size = new System.Drawing.Size(221, 38);
            this.ShowItemDetailsToolStripMenuItem1.Text = "Show Item Details";
            this.ShowItemDetailsToolStripMenuItem1.Click += new System.EventHandler(this.ShowItemDetailsToolStripMenuItem1_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(218, 6);
            // 
            // EditItemToolStripMenuItem
            // 
            this.EditItemToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.EditItemToolStripMenuItem.Image = global::Hotel.Properties.Resources.edit_reservation32;
            this.EditItemToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditItemToolStripMenuItem.Name = "EditItemToolStripMenuItem";
            this.EditItemToolStripMenuItem.Size = new System.Drawing.Size(221, 38);
            this.EditItemToolStripMenuItem.Text = "Edit Item";
            this.EditItemToolStripMenuItem.Click += new System.EventHandler(this.EditItemToolStripMenuItem_Click);
            // 
            // pbItemImage
            // 
            this.pbItemImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbItemImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbItemImage.Image = global::Hotel.Properties.Resources.question_mark;
            this.pbItemImage.InitialImage = null;
            this.pbItemImage.Location = new System.Drawing.Point(47, 6);
            this.pbItemImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbItemImage.Name = "pbItemImage";
            this.pbItemImage.Size = new System.Drawing.Size(169, 140);
            this.pbItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbItemImage.TabIndex = 141;
            this.pbItemImage.TabStop = false;
            this.pbItemImage.Click += new System.EventHandler(this.pbItemImage_Click);
            // 
            // ucItemShortCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.ContextMenuStrip = this.cmsEditProfile;
            this.Controls.Add(this.lblItemPrice);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.pbItemImage);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucItemShortCard";
            this.Size = new System.Drawing.Size(256, 255);
            this.DoubleClick += new System.EventHandler(this.ucItemShortCard_DoubleClick);
            this.cmsEditProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.PictureBox pbItemImage;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemPrice;
        private System.Windows.Forms.ContextMenuStrip cmsEditProfile;
        private System.Windows.Forms.ToolStripMenuItem ShowItemDetailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem EditItemToolStripMenuItem;
    }
}
