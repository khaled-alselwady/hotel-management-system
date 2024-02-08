namespace Hotel.Reservations
{
    partial class frmListReservations
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbReservationStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReservationList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cmsEditProfile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowReservationDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.EditReservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteReservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.ConfirmReservationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CancelReservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.CheckInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddGuestCompanionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewReservation = new Guna.UI2.WinForms.Guna2Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservationList)).BeginInit();
            this.cmsEditProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.AutoRoundedCorners = true;
            this.txtSearch.BorderColor = System.Drawing.Color.Gray;
            this.txtSearch.BorderRadius = 17;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.txtSearch.Location = new System.Drawing.Point(336, 211);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(273, 36);
            this.txtSearch.TabIndex = 192;
            this.txtSearch.Visible = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // cbFilter
            // 
            this.cbFilter.BackColor = System.Drawing.Color.Transparent;
            this.cbFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbFilter.BorderRadius = 17;
            this.cbFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbFilter.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbFilter.ForeColor = System.Drawing.Color.Black;
            this.cbFilter.ItemHeight = 30;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "Reservation ID",
            "Reserved By",
            "Room Number",
            "Status"});
            this.cbFilter.Location = new System.Drawing.Point(95, 211);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(218, 36);
            this.cbFilter.StartIndex = 0;
            this.cbFilter.TabIndex = 195;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // cbReservationStatus
            // 
            this.cbReservationStatus.BackColor = System.Drawing.Color.Transparent;
            this.cbReservationStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbReservationStatus.BorderRadius = 17;
            this.cbReservationStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbReservationStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReservationStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbReservationStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbReservationStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbReservationStatus.ForeColor = System.Drawing.Color.Black;
            this.cbReservationStatus.ItemHeight = 30;
            this.cbReservationStatus.Items.AddRange(new object[] {
            "All",
            "Pending",
            "Confirmed",
            "Canceled",
            "Invalid"});
            this.cbReservationStatus.Location = new System.Drawing.Point(336, 211);
            this.cbReservationStatus.Name = "cbReservationStatus";
            this.cbReservationStatus.Size = new System.Drawing.Size(151, 36);
            this.cbReservationStatus.StartIndex = 0;
            this.cbReservationStatus.TabIndex = 193;
            this.cbReservationStatus.Visible = false;
            this.cbReservationStatus.SelectedIndexChanged += new System.EventHandler(this.cbReservationStatus_SelectedIndexChanged);
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(115, 727);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(27, 20);
            this.lblNumberOfRecords.TabIndex = 189;
            this.lblNumberOfRecords.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 727);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 188;
            this.label2.Text = "# Records:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 187;
            this.label1.Text = "Filter By:";
            // 
            // dgvReservationList
            // 
            this.dgvReservationList.AllowUserToAddRows = false;
            this.dgvReservationList.AllowUserToDeleteRows = false;
            this.dgvReservationList.AllowUserToOrderColumns = true;
            this.dgvReservationList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReservationList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReservationList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvReservationList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReservationList.ColumnHeadersHeight = 35;
            this.dgvReservationList.ContextMenuStrip = this.cmsEditProfile;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(133)))), ((int)(((byte)(147)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReservationList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReservationList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvReservationList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.dgvReservationList.Location = new System.Drawing.Point(13, 254);
            this.dgvReservationList.Name = "dgvReservationList";
            this.dgvReservationList.ReadOnly = true;
            this.dgvReservationList.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReservationList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReservationList.RowTemplate.Height = 33;
            this.dgvReservationList.ShowCellToolTips = false;
            this.dgvReservationList.Size = new System.Drawing.Size(1318, 469);
            this.dgvReservationList.TabIndex = 199;
            this.dgvReservationList.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.WetAsphalt;
            this.dgvReservationList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.dgvReservationList.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReservationList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvReservationList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvReservationList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvReservationList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvReservationList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.dgvReservationList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.dgvReservationList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvReservationList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReservationList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReservationList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReservationList.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvReservationList.ThemeStyle.ReadOnly = true;
            this.dgvReservationList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dgvReservationList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReservationList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReservationList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvReservationList.ThemeStyle.RowsStyle.Height = 33;
            this.dgvReservationList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(133)))), ((int)(((byte)(147)))));
            this.dgvReservationList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvReservationList.DoubleClick += new System.EventHandler(this.dgvGuestsList_DoubleClick);
            // 
            // cmsEditProfile
            // 
            this.cmsEditProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmsEditProfile.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsEditProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowReservationDetailsToolStripMenuItem1,
            this.toolStripSeparator6,
            this.EditReservationToolStripMenuItem,
            this.DeleteReservationToolStripMenuItem,
            this.toolStripSeparator7,
            this.ConfirmReservationToolStripMenuItem1,
            this.CancelReservationToolStripMenuItem,
            this.toolStripSeparator8,
            this.CheckInToolStripMenuItem,
            this.AddGuestCompanionToolStripMenuItem});
            this.cmsEditProfile.Name = "contextMenuStrip1";
            this.cmsEditProfile.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsEditProfile.Size = new System.Drawing.Size(273, 288);
            this.cmsEditProfile.Opening += new System.ComponentModel.CancelEventHandler(this.cmsEditProfile_Opening);
            // 
            // ShowReservationDetailsToolStripMenuItem1
            // 
            this.ShowReservationDetailsToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.ShowReservationDetailsToolStripMenuItem1.Image = global::Hotel.Properties.Resources.show_reservation_32;
            this.ShowReservationDetailsToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowReservationDetailsToolStripMenuItem1.Name = "ShowReservationDetailsToolStripMenuItem1";
            this.ShowReservationDetailsToolStripMenuItem1.Size = new System.Drawing.Size(272, 38);
            this.ShowReservationDetailsToolStripMenuItem1.Text = "Show Reservation Details";
            this.ShowReservationDetailsToolStripMenuItem1.Click += new System.EventHandler(this.ShowReservationDetailsToolStripMenuItem1_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(269, 6);
            // 
            // EditReservationToolStripMenuItem
            // 
            this.EditReservationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.EditReservationToolStripMenuItem.Image = global::Hotel.Properties.Resources.edit_reservation32;
            this.EditReservationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditReservationToolStripMenuItem.Name = "EditReservationToolStripMenuItem";
            this.EditReservationToolStripMenuItem.Size = new System.Drawing.Size(272, 38);
            this.EditReservationToolStripMenuItem.Text = "Edit Reservation";
            this.EditReservationToolStripMenuItem.Click += new System.EventHandler(this.EditReservationToolStripMenuItem_Click);
            // 
            // DeleteReservationToolStripMenuItem
            // 
            this.DeleteReservationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.DeleteReservationToolStripMenuItem.Image = global::Hotel.Properties.Resources.delete_reservation_40;
            this.DeleteReservationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DeleteReservationToolStripMenuItem.Name = "DeleteReservationToolStripMenuItem";
            this.DeleteReservationToolStripMenuItem.Size = new System.Drawing.Size(272, 38);
            this.DeleteReservationToolStripMenuItem.Text = "Delete Reservation";
            this.DeleteReservationToolStripMenuItem.Click += new System.EventHandler(this.DeleteReservationToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(269, 6);
            // 
            // ConfirmReservationToolStripMenuItem1
            // 
            this.ConfirmReservationToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.ConfirmReservationToolStripMenuItem1.Image = global::Hotel.Properties.Resources.confirm_32;
            this.ConfirmReservationToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ConfirmReservationToolStripMenuItem1.Name = "ConfirmReservationToolStripMenuItem1";
            this.ConfirmReservationToolStripMenuItem1.Size = new System.Drawing.Size(272, 38);
            this.ConfirmReservationToolStripMenuItem1.Text = "Confirm Reservation";
            this.ConfirmReservationToolStripMenuItem1.Click += new System.EventHandler(this.ConfirmReservationToolStripMenuItem1_Click);
            // 
            // CancelReservationToolStripMenuItem
            // 
            this.CancelReservationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.CancelReservationToolStripMenuItem.Image = global::Hotel.Properties.Resources.cancel_32;
            this.CancelReservationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CancelReservationToolStripMenuItem.Name = "CancelReservationToolStripMenuItem";
            this.CancelReservationToolStripMenuItem.Size = new System.Drawing.Size(272, 38);
            this.CancelReservationToolStripMenuItem.Text = "Cancel Reservation";
            this.CancelReservationToolStripMenuItem.Click += new System.EventHandler(this.CancelReservationToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(269, 6);
            // 
            // CheckInToolStripMenuItem
            // 
            this.CheckInToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.CheckInToolStripMenuItem.Image = global::Hotel.Properties.Resources.check_in_32;
            this.CheckInToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CheckInToolStripMenuItem.Name = "CheckInToolStripMenuItem";
            this.CheckInToolStripMenuItem.Size = new System.Drawing.Size(272, 38);
            this.CheckInToolStripMenuItem.Text = "Check-In";
            this.CheckInToolStripMenuItem.Click += new System.EventHandler(this.CheckInToolStripMenuItem_Click);
            // 
            // AddGuestCompanionToolStripMenuItem
            // 
            this.AddGuestCompanionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.AddGuestCompanionToolStripMenuItem.Image = global::Hotel.Properties.Resources.add__guest_companion_32;
            this.AddGuestCompanionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddGuestCompanionToolStripMenuItem.Name = "AddGuestCompanionToolStripMenuItem";
            this.AddGuestCompanionToolStripMenuItem.Size = new System.Drawing.Size(272, 38);
            this.AddGuestCompanionToolStripMenuItem.Text = "Add Guest Companion";
            this.AddGuestCompanionToolStripMenuItem.Click += new System.EventHandler(this.AddGuestCompanionToolStripMenuItem_Click);
            // 
            // btnAddNewReservation
            // 
            this.btnAddNewReservation.Checked = true;
            this.btnAddNewReservation.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.btnAddNewReservation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewReservation.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewReservation.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewReservation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewReservation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewReservation.FillColor = System.Drawing.Color.White;
            this.btnAddNewReservation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddNewReservation.ForeColor = System.Drawing.Color.White;
            this.btnAddNewReservation.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnAddNewReservation.Image = global::Hotel.Properties.Resources.add_reservation_50;
            this.btnAddNewReservation.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnAddNewReservation.ImageSize = new System.Drawing.Size(55, 55);
            this.btnAddNewReservation.Location = new System.Drawing.Point(1264, 192);
            this.btnAddNewReservation.Name = "btnAddNewReservation";
            this.btnAddNewReservation.Size = new System.Drawing.Size(78, 57);
            this.btnAddNewReservation.TabIndex = 198;
            this.btnAddNewReservation.Click += new System.EventHandler(this.btnAddNewReservation_Click);
            // 
            // pbImage
            // 
            this.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbImage.Image = global::Hotel.Properties.Resources.reservations_dashboard;
            this.pbImage.InitialImage = null;
            this.pbImage.Location = new System.Drawing.Point(493, 12);
            this.pbImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(325, 169);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 190;
            this.pbImage.TabStop = false;
            // 
            // frmListReservations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1344, 759);
            this.Controls.Add(this.dgvReservationList);
            this.Controls.Add(this.btnAddNewReservation);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.cbReservationStatus);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListReservations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Manage Reservations";
            this.Text = "frmListReservations";
            this.Load += new System.EventHandler(this.frmListReservations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservationList)).EndInit();
            this.cmsEditProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cbReservationStatus;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnAddNewReservation;
        private Guna.UI2.WinForms.Guna2DataGridView dgvReservationList;
        private System.Windows.Forms.ContextMenuStrip cmsEditProfile;
        private System.Windows.Forms.ToolStripMenuItem ShowReservationDetailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem EditReservationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteReservationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem ConfirmReservationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CancelReservationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CheckInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddGuestCompanionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    }
}