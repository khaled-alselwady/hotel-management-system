namespace Hotel.GuestCompanions
{
    partial class frmAddEditGuestCompanions
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.tcAddEditUser = new Guna.UI2.WinForms.Guna2TabControl();
            this.tpBookingInfo = new System.Windows.Forms.TabPage();
            this.ucReservationsCard1 = new Hotel.Reservations.UserControls.ucReservationsCard();
            this.ucBookingCard1 = new Hotel.Bookings.UserControls.ucBookingCard();
            this.tpGuestInfo = new System.Windows.Forms.TabPage();
            this.ucPersonCard1 = new Hotel.People.UserControls.ucPersonCard();
            this.tpCompanionInfo = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label22 = new System.Windows.Forms.Label();
            this.lblGuestCompanionID = new System.Windows.Forms.Label();
            this.ucPersonCardWithFilter1 = new Hotel.People.UserControls.ucPersonCardWithFilter();
            this.btnClose = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tcAddEditUser.SuspendLayout();
            this.tpBookingInfo.SuspendLayout();
            this.tpGuestInfo.SuspendLayout();
            this.tpCompanionInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 30.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.lblTitle.Location = new System.Drawing.Point(2, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(938, 61);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tcAddEditUser
            // 
            this.tcAddEditUser.Controls.Add(this.tpBookingInfo);
            this.tcAddEditUser.Controls.Add(this.tpGuestInfo);
            this.tcAddEditUser.Controls.Add(this.tpCompanionInfo);
            this.tcAddEditUser.ItemSize = new System.Drawing.Size(180, 40);
            this.tcAddEditUser.Location = new System.Drawing.Point(12, 96);
            this.tcAddEditUser.Name = "tcAddEditUser";
            this.tcAddEditUser.SelectedIndex = 0;
            this.tcAddEditUser.Size = new System.Drawing.Size(909, 574);
            this.tcAddEditUser.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tcAddEditUser.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcAddEditUser.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcAddEditUser.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tcAddEditUser.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcAddEditUser.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tcAddEditUser.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcAddEditUser.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcAddEditUser.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tcAddEditUser.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcAddEditUser.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tcAddEditUser.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.tcAddEditUser.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcAddEditUser.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tcAddEditUser.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tcAddEditUser.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tcAddEditUser.TabIndex = 4;
            this.tcAddEditUser.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcAddEditUser.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tpBookingInfo
            // 
            this.tpBookingInfo.BackColor = System.Drawing.Color.White;
            this.tpBookingInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpBookingInfo.Controls.Add(this.ucReservationsCard1);
            this.tpBookingInfo.Controls.Add(this.ucBookingCard1);
            this.tpBookingInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpBookingInfo.Location = new System.Drawing.Point(4, 44);
            this.tpBookingInfo.Name = "tpBookingInfo";
            this.tpBookingInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpBookingInfo.Size = new System.Drawing.Size(901, 526);
            this.tpBookingInfo.TabIndex = 0;
            this.tpBookingInfo.Text = "Booking Info";
            // 
            // ucReservationsCard1
            // 
            this.ucReservationsCard1.BackColor = System.Drawing.Color.White;
            this.ucReservationsCard1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucReservationsCard1.Location = new System.Drawing.Point(22, 231);
            this.ucReservationsCard1.Name = "ucReservationsCard1";
            this.ucReservationsCard1.Size = new System.Drawing.Size(862, 255);
            this.ucReservationsCard1.TabIndex = 1;
            // 
            // ucBookingCard1
            // 
            this.ucBookingCard1.BackColor = System.Drawing.Color.White;
            this.ucBookingCard1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucBookingCard1.Location = new System.Drawing.Point(22, 21);
            this.ucBookingCard1.Name = "ucBookingCard1";
            this.ucBookingCard1.Size = new System.Drawing.Size(862, 172);
            this.ucBookingCard1.TabIndex = 0;
            // 
            // tpGuestInfo
            // 
            this.tpGuestInfo.BackColor = System.Drawing.Color.White;
            this.tpGuestInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpGuestInfo.Controls.Add(this.ucPersonCard1);
            this.tpGuestInfo.Location = new System.Drawing.Point(4, 44);
            this.tpGuestInfo.Name = "tpGuestInfo";
            this.tpGuestInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpGuestInfo.Size = new System.Drawing.Size(901, 526);
            this.tpGuestInfo.TabIndex = 1;
            this.tpGuestInfo.Text = "Guest Info";
            // 
            // ucPersonCard1
            // 
            this.ucPersonCard1.BackColor = System.Drawing.Color.White;
            this.ucPersonCard1.Location = new System.Drawing.Point(22, 20);
            this.ucPersonCard1.Name = "ucPersonCard1";
            this.ucPersonCard1.Size = new System.Drawing.Size(862, 285);
            this.ucPersonCard1.TabIndex = 0;
            // 
            // tpCompanionInfo
            // 
            this.tpCompanionInfo.BackColor = System.Drawing.Color.White;
            this.tpCompanionInfo.Controls.Add(this.pictureBox1);
            this.tpCompanionInfo.Controls.Add(this.label22);
            this.tpCompanionInfo.Controls.Add(this.lblGuestCompanionID);
            this.tpCompanionInfo.Controls.Add(this.ucPersonCardWithFilter1);
            this.tpCompanionInfo.Location = new System.Drawing.Point(4, 44);
            this.tpCompanionInfo.Name = "tpCompanionInfo";
            this.tpCompanionInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpCompanionInfo.Size = new System.Drawing.Size(901, 526);
            this.tpCompanionInfo.TabIndex = 2;
            this.tpCompanionInfo.Text = "Companion Info";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hotel.Properties.Resources.id;
            this.pictureBox1.Location = new System.Drawing.Point(231, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 171;
            this.pictureBox1.TabStop = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(35, 24);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(195, 25);
            this.label22.TabIndex = 169;
            this.label22.Text = "Guest Companion ID:";
            // 
            // lblGuestCompanionID
            // 
            this.lblGuestCompanionID.AutoSize = true;
            this.lblGuestCompanionID.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestCompanionID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblGuestCompanionID.Location = new System.Drawing.Point(269, 24);
            this.lblGuestCompanionID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGuestCompanionID.Name = "lblGuestCompanionID";
            this.lblGuestCompanionID.Size = new System.Drawing.Size(58, 25);
            this.lblGuestCompanionID.TabIndex = 170;
            this.lblGuestCompanionID.Text = "[????]";
            // 
            // ucPersonCardWithFilter1
            // 
            this.ucPersonCardWithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucPersonCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ucPersonCardWithFilter1.FilterEnabled = true;
            this.ucPersonCardWithFilter1.Location = new System.Drawing.Point(22, 61);
            this.ucPersonCardWithFilter1.Name = "ucPersonCardWithFilter1";
            this.ucPersonCardWithFilter1.ShowAddPersonButton = true;
            this.ucPersonCardWithFilter1.Size = new System.Drawing.Size(870, 428);
            this.ucPersonCardWithFilter1.TabIndex = 0;
            this.ucPersonCardWithFilter1.OnPersonSelected += new System.EventHandler<Hotel.People.UserControls.ucPersonCardWithFilter.PersonSelectedEventArgs>(this.ucPersonCardWithFilter1_OnPersonSelected);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderRadius = 20;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            this.btnClose.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::Hotel.Properties.Resources.close_48;
            this.btnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClose.ImageSize = new System.Drawing.Size(30, 30);
            this.btnClose.Location = new System.Drawing.Point(619, 680);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(155, 45);
            this.btnClose.TabIndex = 201;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BorderRadius = 20;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.Enabled = false;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            this.btnSave.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::Hotel.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSave.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSave.Location = new System.Drawing.Point(785, 680);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnSave.Size = new System.Drawing.Size(155, 45);
            this.btnSave.TabIndex = 200;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAddEditGuestCompanions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(943, 729);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tcAddEditUser);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditGuestCompanions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Guest Companions";
            this.Load += new System.EventHandler(this.frmAddEditGuestCompanions_Load);
            this.tcAddEditUser.ResumeLayout(false);
            this.tpBookingInfo.ResumeLayout(false);
            this.tpGuestInfo.ResumeLayout(false);
            this.tpCompanionInfo.ResumeLayout(false);
            this.tpCompanionInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2TabControl tcAddEditUser;
        private System.Windows.Forms.TabPage tpBookingInfo;
        private System.Windows.Forms.TabPage tpGuestInfo;
        private System.Windows.Forms.TabPage tpCompanionInfo;
        private Reservations.UserControls.ucReservationsCard ucReservationsCard1;
        private Bookings.UserControls.ucBookingCard ucBookingCard1;
        private People.UserControls.ucPersonCard ucPersonCard1;
        private People.UserControls.ucPersonCardWithFilter ucPersonCardWithFilter1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblGuestCompanionID;
        private Guna.UI2.WinForms.Guna2GradientButton btnClose;
        private Guna.UI2.WinForms.Guna2GradientButton btnSave;
    }
}