namespace Hotel.Rooms
{
    partial class frmListRooms
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
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsEditProfile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowRoomDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.EditRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PutUnderMaintenanceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ReleaseFromMaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvRoomList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbRoomStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRoomTypes = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnAddNewRoom = new Guna.UI2.WinForms.Guna2Button();
            this.cmsEditProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(279, 6);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(279, 6);
            // 
            // cmsEditProfile
            // 
            this.cmsEditProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmsEditProfile.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsEditProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowRoomDetailsToolStripMenuItem1,
            this.toolStripSeparator6,
            this.EditRoomToolStripMenuItem,
            this.DeleteRoomToolStripMenuItem,
            this.toolStripSeparator7,
            this.PutUnderMaintenanceToolStripMenuItem1,
            this.ReleaseFromMaintenanceToolStripMenuItem});
            this.cmsEditProfile.Name = "contextMenuStrip1";
            this.cmsEditProfile.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsEditProfile.Size = new System.Drawing.Size(283, 206);
            this.cmsEditProfile.Opening += new System.ComponentModel.CancelEventHandler(this.cmsEditProfile_Opening);
            // 
            // ShowRoomDetailsToolStripMenuItem1
            // 
            this.ShowRoomDetailsToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.ShowRoomDetailsToolStripMenuItem1.Image = global::Hotel.Properties.Resources.show_reservation_32;
            this.ShowRoomDetailsToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowRoomDetailsToolStripMenuItem1.Name = "ShowRoomDetailsToolStripMenuItem1";
            this.ShowRoomDetailsToolStripMenuItem1.Size = new System.Drawing.Size(282, 38);
            this.ShowRoomDetailsToolStripMenuItem1.Text = "Show Room Details";
            this.ShowRoomDetailsToolStripMenuItem1.Click += new System.EventHandler(this.ShowRoomDetailsToolStripMenuItem1_Click);
            // 
            // EditRoomToolStripMenuItem
            // 
            this.EditRoomToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.EditRoomToolStripMenuItem.Image = global::Hotel.Properties.Resources.edit_reservation32;
            this.EditRoomToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditRoomToolStripMenuItem.Name = "EditRoomToolStripMenuItem";
            this.EditRoomToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.EditRoomToolStripMenuItem.Text = "Edit Room";
            this.EditRoomToolStripMenuItem.Click += new System.EventHandler(this.EditRoomToolStripMenuItem_Click);
            // 
            // DeleteRoomToolStripMenuItem
            // 
            this.DeleteRoomToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.DeleteRoomToolStripMenuItem.Image = global::Hotel.Properties.Resources.delete_reservation_40;
            this.DeleteRoomToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DeleteRoomToolStripMenuItem.Name = "DeleteRoomToolStripMenuItem";
            this.DeleteRoomToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.DeleteRoomToolStripMenuItem.Text = "Delete Room";
            this.DeleteRoomToolStripMenuItem.Click += new System.EventHandler(this.DeleteRoomToolStripMenuItem_Click);
            // 
            // PutUnderMaintenanceToolStripMenuItem1
            // 
            this.PutUnderMaintenanceToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.PutUnderMaintenanceToolStripMenuItem1.Image = global::Hotel.Properties.Resources.maintenance_32;
            this.PutUnderMaintenanceToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PutUnderMaintenanceToolStripMenuItem1.Name = "PutUnderMaintenanceToolStripMenuItem1";
            this.PutUnderMaintenanceToolStripMenuItem1.Size = new System.Drawing.Size(282, 38);
            this.PutUnderMaintenanceToolStripMenuItem1.Text = "Put Under Maintenance";
            this.PutUnderMaintenanceToolStripMenuItem1.Click += new System.EventHandler(this.PutUnderMaintenanceToolStripMenuItem1_Click);
            // 
            // ReleaseFromMaintenanceToolStripMenuItem
            // 
            this.ReleaseFromMaintenanceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ReleaseFromMaintenanceToolStripMenuItem.Image = global::Hotel.Properties.Resources.confirm_32;
            this.ReleaseFromMaintenanceToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ReleaseFromMaintenanceToolStripMenuItem.Name = "ReleaseFromMaintenanceToolStripMenuItem";
            this.ReleaseFromMaintenanceToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.ReleaseFromMaintenanceToolStripMenuItem.Text = "Release From Maintenance";
            this.ReleaseFromMaintenanceToolStripMenuItem.Click += new System.EventHandler(this.ReleaseFromMaintenanceToolStripMenuItem_Click);
            // 
            // dgvRoomList
            // 
            this.dgvRoomList.AllowUserToAddRows = false;
            this.dgvRoomList.AllowUserToDeleteRows = false;
            this.dgvRoomList.AllowUserToOrderColumns = true;
            this.dgvRoomList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRoomList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRoomList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvRoomList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRoomList.ColumnHeadersHeight = 35;
            this.dgvRoomList.ContextMenuStrip = this.cmsEditProfile;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(133)))), ((int)(((byte)(147)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoomList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRoomList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRoomList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.dgvRoomList.Location = new System.Drawing.Point(9, 254);
            this.dgvRoomList.Name = "dgvRoomList";
            this.dgvRoomList.ReadOnly = true;
            this.dgvRoomList.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRoomList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRoomList.RowTemplate.Height = 33;
            this.dgvRoomList.ShowCellToolTips = false;
            this.dgvRoomList.Size = new System.Drawing.Size(1318, 469);
            this.dgvRoomList.TabIndex = 208;
            this.dgvRoomList.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.WetAsphalt;
            this.dgvRoomList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.dgvRoomList.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRoomList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvRoomList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvRoomList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvRoomList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvRoomList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.dgvRoomList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.dgvRoomList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRoomList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRoomList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRoomList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRoomList.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvRoomList.ThemeStyle.ReadOnly = true;
            this.dgvRoomList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dgvRoomList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRoomList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRoomList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvRoomList.ThemeStyle.RowsStyle.Height = 33;
            this.dgvRoomList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(133)))), ((int)(((byte)(147)))));
            this.dgvRoomList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvRoomList.DoubleClick += new System.EventHandler(this.dgvRoomList_DoubleClick);
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
            this.txtSearch.Location = new System.Drawing.Point(332, 211);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(273, 36);
            this.txtSearch.TabIndex = 204;
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
            "Room ID",
            "Room Type",
            "Room Number",
            "Floor Number",
            "Status"});
            this.cbFilter.Location = new System.Drawing.Point(91, 211);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(218, 36);
            this.cbFilter.StartIndex = 0;
            this.cbFilter.TabIndex = 206;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // cbRoomStatus
            // 
            this.cbRoomStatus.BackColor = System.Drawing.Color.Transparent;
            this.cbRoomStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbRoomStatus.BorderRadius = 17;
            this.cbRoomStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbRoomStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoomStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbRoomStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbRoomStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbRoomStatus.ForeColor = System.Drawing.Color.Black;
            this.cbRoomStatus.ItemHeight = 30;
            this.cbRoomStatus.Items.AddRange(new object[] {
            "All",
            "Available",
            "Booked",
            "Under Maintenance"});
            this.cbRoomStatus.Location = new System.Drawing.Point(332, 211);
            this.cbRoomStatus.Name = "cbRoomStatus";
            this.cbRoomStatus.Size = new System.Drawing.Size(253, 36);
            this.cbRoomStatus.StartIndex = 0;
            this.cbRoomStatus.TabIndex = 205;
            this.cbRoomStatus.Visible = false;
            this.cbRoomStatus.SelectedIndexChanged += new System.EventHandler(this.cbRoomStatus_SelectedIndexChanged);
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(111, 727);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(27, 20);
            this.lblNumberOfRecords.TabIndex = 202;
            this.lblNumberOfRecords.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 727);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 201;
            this.label2.Text = "# Records:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 200;
            this.label1.Text = "Filter By:";
            // 
            // cbRoomTypes
            // 
            this.cbRoomTypes.BackColor = System.Drawing.Color.Transparent;
            this.cbRoomTypes.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbRoomTypes.BorderRadius = 17;
            this.cbRoomTypes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbRoomTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoomTypes.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbRoomTypes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbRoomTypes.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbRoomTypes.ForeColor = System.Drawing.Color.Black;
            this.cbRoomTypes.ItemHeight = 30;
            this.cbRoomTypes.Location = new System.Drawing.Point(332, 211);
            this.cbRoomTypes.Name = "cbRoomTypes";
            this.cbRoomTypes.Size = new System.Drawing.Size(273, 36);
            this.cbRoomTypes.TabIndex = 226;
            this.cbRoomTypes.Visible = false;
            this.cbRoomTypes.SelectedIndexChanged += new System.EventHandler(this.cbRoomTypes_SelectedIndexChanged);
            // 
            // pbImage
            // 
            this.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbImage.Image = global::Hotel.Properties.Resources.rooms_dashboard;
            this.pbImage.InitialImage = null;
            this.pbImage.Location = new System.Drawing.Point(489, 12);
            this.pbImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(325, 169);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 203;
            this.pbImage.TabStop = false;
            // 
            // btnAddNewRoom
            // 
            this.btnAddNewRoom.Checked = true;
            this.btnAddNewRoom.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.btnAddNewRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewRoom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewRoom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewRoom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewRoom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewRoom.FillColor = System.Drawing.Color.White;
            this.btnAddNewRoom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddNewRoom.ForeColor = System.Drawing.Color.White;
            this.btnAddNewRoom.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnAddNewRoom.Image = global::Hotel.Properties.Resources.room_number;
            this.btnAddNewRoom.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnAddNewRoom.ImageSize = new System.Drawing.Size(55, 55);
            this.btnAddNewRoom.Location = new System.Drawing.Point(1260, 192);
            this.btnAddNewRoom.Name = "btnAddNewRoom";
            this.btnAddNewRoom.Size = new System.Drawing.Size(78, 57);
            this.btnAddNewRoom.TabIndex = 207;
            this.btnAddNewRoom.Click += new System.EventHandler(this.btnAddNewRoom_Click);
            // 
            // frmListRooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1344, 759);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.dgvRoomList);
            this.Controls.Add(this.btnAddNewRoom);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.cbRoomStatus);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbRoomTypes);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListRooms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Manage Rooms";
            this.Text = "frmListRooms";
            this.Load += new System.EventHandler(this.frmListRooms_Load);
            this.cmsEditProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.ToolStripMenuItem ReleaseFromMaintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PutUnderMaintenanceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem DeleteRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem ShowRoomDetailsToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip cmsEditProfile;
        private Guna.UI2.WinForms.Guna2DataGridView dgvRoomList;
        private Guna.UI2.WinForms.Guna2Button btnAddNewRoom;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cbRoomStatus;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbRoomTypes;
    }
}