namespace Hotel.Items
{
    partial class frmListItems
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
            this.dgvItemsList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cmsEditProfile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbItemTypes = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTypeOfViewItems = new Guna.UI2.WinForms.Guna2ComboBox();
            this.flpItems = new System.Windows.Forms.FlowLayoutPanel();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.ShowItemDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewItemToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewItemToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewItemTypeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.EditItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditItemTypeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewItem = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsList)).BeginInit();
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
            this.txtSearch.Location = new System.Drawing.Point(332, 211);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(273, 36);
            this.txtSearch.TabIndex = 231;
            this.txtSearch.Visible = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // dgvItemsList
            // 
            this.dgvItemsList.AllowUserToAddRows = false;
            this.dgvItemsList.AllowUserToDeleteRows = false;
            this.dgvItemsList.AllowUserToOrderColumns = true;
            this.dgvItemsList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItemsList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItemsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvItemsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItemsList.ColumnHeadersHeight = 40;
            this.dgvItemsList.ContextMenuStrip = this.cmsEditProfile;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(133)))), ((int)(((byte)(147)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemsList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvItemsList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvItemsList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.dgvItemsList.Location = new System.Drawing.Point(13, 254);
            this.dgvItemsList.Name = "dgvItemsList";
            this.dgvItemsList.ReadOnly = true;
            this.dgvItemsList.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItemsList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvItemsList.RowTemplate.Height = 33;
            this.dgvItemsList.ShowCellToolTips = false;
            this.dgvItemsList.Size = new System.Drawing.Size(1318, 469);
            this.dgvItemsList.TabIndex = 235;
            this.dgvItemsList.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.WetAsphalt;
            this.dgvItemsList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.dgvItemsList.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItemsList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvItemsList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvItemsList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvItemsList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvItemsList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.dgvItemsList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.dgvItemsList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvItemsList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItemsList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvItemsList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItemsList.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvItemsList.ThemeStyle.ReadOnly = true;
            this.dgvItemsList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dgvItemsList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvItemsList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItemsList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvItemsList.ThemeStyle.RowsStyle.Height = 33;
            this.dgvItemsList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(133)))), ((int)(((byte)(147)))));
            this.dgvItemsList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvItemsList.DoubleClick += new System.EventHandler(this.dgvItemsList_DoubleClick);
            // 
            // cmsEditProfile
            // 
            this.cmsEditProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmsEditProfile.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsEditProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowItemDetailsToolStripMenuItem1,
            this.AddNewItemToolStripMenuItem1,
            this.toolStripSeparator2,
            this.AddNewItemToolStripMenuItem2,
            this.AddNewItemTypeToolStripMenuItem1,
            this.toolStripSeparator1,
            this.EditItemToolStripMenuItem,
            this.EditItemTypeToolStripMenuItem1,
            this.toolStripSeparator6,
            this.DeleteItemToolStripMenuItem});
            this.cmsEditProfile.Name = "contextMenuStrip1";
            this.cmsEditProfile.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsEditProfile.Size = new System.Drawing.Size(234, 288);
            this.cmsEditProfile.Opening += new System.ComponentModel.CancelEventHandler(this.cmsEditProfile_Opening);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(230, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(230, 6);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(230, 6);
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
            "Item ID",
            "Item Name",
            "Item Type"});
            this.cbFilter.Location = new System.Drawing.Point(91, 211);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(218, 36);
            this.cbFilter.StartIndex = 0;
            this.cbFilter.TabIndex = 233;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // cbItemTypes
            // 
            this.cbItemTypes.BackColor = System.Drawing.Color.Transparent;
            this.cbItemTypes.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbItemTypes.BorderRadius = 17;
            this.cbItemTypes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbItemTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemTypes.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbItemTypes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbItemTypes.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbItemTypes.ForeColor = System.Drawing.Color.Black;
            this.cbItemTypes.ItemHeight = 30;
            this.cbItemTypes.Location = new System.Drawing.Point(332, 211);
            this.cbItemTypes.Name = "cbItemTypes";
            this.cbItemTypes.Size = new System.Drawing.Size(253, 36);
            this.cbItemTypes.TabIndex = 232;
            this.cbItemTypes.Visible = false;
            this.cbItemTypes.SelectedIndexChanged += new System.EventHandler(this.cbItemTypes_SelectedIndexChanged);
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(111, 727);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(27, 20);
            this.lblNumberOfRecords.TabIndex = 229;
            this.lblNumberOfRecords.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 727);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 228;
            this.label2.Text = "# Records:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 227;
            this.label1.Text = "Filter By:";
            // 
            // cbTypeOfViewItems
            // 
            this.cbTypeOfViewItems.BackColor = System.Drawing.Color.Transparent;
            this.cbTypeOfViewItems.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbTypeOfViewItems.BorderRadius = 17;
            this.cbTypeOfViewItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTypeOfViewItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeOfViewItems.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbTypeOfViewItems.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbTypeOfViewItems.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbTypeOfViewItems.ForeColor = System.Drawing.Color.Black;
            this.cbTypeOfViewItems.ItemHeight = 30;
            this.cbTypeOfViewItems.Items.AddRange(new object[] {
            "List",
            "Flow"});
            this.cbTypeOfViewItems.Location = new System.Drawing.Point(923, 211);
            this.cbTypeOfViewItems.Name = "cbTypeOfViewItems";
            this.cbTypeOfViewItems.Size = new System.Drawing.Size(218, 36);
            this.cbTypeOfViewItems.StartIndex = 0;
            this.cbTypeOfViewItems.TabIndex = 236;
            this.cbTypeOfViewItems.SelectedIndexChanged += new System.EventHandler(this.cbTypeOfViewItems_SelectedIndexChanged);
            // 
            // flpItems
            // 
            this.flpItems.AutoScroll = true;
            this.flpItems.Location = new System.Drawing.Point(23, 274);
            this.flpItems.Name = "flpItems";
            this.flpItems.Size = new System.Drawing.Size(1315, 449);
            this.flpItems.TabIndex = 237;
            this.flpItems.Visible = false;
            // 
            // pbImage
            // 
            this.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbImage.Image = global::Hotel.Properties.Resources.Items;
            this.pbImage.InitialImage = null;
            this.pbImage.Location = new System.Drawing.Point(503, 12);
            this.pbImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(325, 169);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 230;
            this.pbImage.TabStop = false;
            // 
            // ShowItemDetailsToolStripMenuItem1
            // 
            this.ShowItemDetailsToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.ShowItemDetailsToolStripMenuItem1.Image = global::Hotel.Properties.Resources.show_reservation_32;
            this.ShowItemDetailsToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowItemDetailsToolStripMenuItem1.Name = "ShowItemDetailsToolStripMenuItem1";
            this.ShowItemDetailsToolStripMenuItem1.Size = new System.Drawing.Size(233, 38);
            this.ShowItemDetailsToolStripMenuItem1.Text = "Show Item Details";
            this.ShowItemDetailsToolStripMenuItem1.Click += new System.EventHandler(this.ShowItemDetailsToolStripMenuItem1_Click);
            // 
            // AddNewItemToolStripMenuItem1
            // 
            this.AddNewItemToolStripMenuItem1.BackColor = System.Drawing.SystemColors.Control;
            this.AddNewItemToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.AddNewItemToolStripMenuItem1.Image = global::Hotel.Properties.Resources.add_item_32;
            this.AddNewItemToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddNewItemToolStripMenuItem1.Name = "AddNewItemToolStripMenuItem1";
            this.AddNewItemToolStripMenuItem1.Size = new System.Drawing.Size(233, 38);
            this.AddNewItemToolStripMenuItem1.Text = "Add New Item";
            this.AddNewItemToolStripMenuItem1.Visible = false;
            // 
            // AddNewItemToolStripMenuItem2
            // 
            this.AddNewItemToolStripMenuItem2.ForeColor = System.Drawing.Color.White;
            this.AddNewItemToolStripMenuItem2.Image = global::Hotel.Properties.Resources.add_item_32;
            this.AddNewItemToolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddNewItemToolStripMenuItem2.Name = "AddNewItemToolStripMenuItem2";
            this.AddNewItemToolStripMenuItem2.Size = new System.Drawing.Size(233, 38);
            this.AddNewItemToolStripMenuItem2.Text = "Add New Item";
            this.AddNewItemToolStripMenuItem2.Click += new System.EventHandler(this.AddNewItemToolStripMenuItem2_Click);
            // 
            // AddNewItemTypeToolStripMenuItem1
            // 
            this.AddNewItemTypeToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.AddNewItemTypeToolStripMenuItem1.Image = global::Hotel.Properties.Resources.add_item_32;
            this.AddNewItemTypeToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddNewItemTypeToolStripMenuItem1.Name = "AddNewItemTypeToolStripMenuItem1";
            this.AddNewItemTypeToolStripMenuItem1.Size = new System.Drawing.Size(233, 38);
            this.AddNewItemTypeToolStripMenuItem1.Text = "Add New Item Type";
            this.AddNewItemTypeToolStripMenuItem1.Click += new System.EventHandler(this.AddNewItemTypeToolStripMenuItem1_Click);
            // 
            // EditItemToolStripMenuItem
            // 
            this.EditItemToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.EditItemToolStripMenuItem.Image = global::Hotel.Properties.Resources.edit_reservation32;
            this.EditItemToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditItemToolStripMenuItem.Name = "EditItemToolStripMenuItem";
            this.EditItemToolStripMenuItem.Size = new System.Drawing.Size(233, 38);
            this.EditItemToolStripMenuItem.Text = "Edit Item";
            this.EditItemToolStripMenuItem.Click += new System.EventHandler(this.EditItemToolStripMenuItem_Click);
            // 
            // EditItemTypeToolStripMenuItem1
            // 
            this.EditItemTypeToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.EditItemTypeToolStripMenuItem1.Image = global::Hotel.Properties.Resources.edit_reservation32;
            this.EditItemTypeToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditItemTypeToolStripMenuItem1.Name = "EditItemTypeToolStripMenuItem1";
            this.EditItemTypeToolStripMenuItem1.Size = new System.Drawing.Size(233, 38);
            this.EditItemTypeToolStripMenuItem1.Text = "Edit Item Type";
            this.EditItemTypeToolStripMenuItem1.Click += new System.EventHandler(this.EditItemTypeToolStripMenuItem1_Click);
            // 
            // DeleteItemToolStripMenuItem
            // 
            this.DeleteItemToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.DeleteItemToolStripMenuItem.Image = global::Hotel.Properties.Resources.delete_reservation_40;
            this.DeleteItemToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DeleteItemToolStripMenuItem.Name = "DeleteItemToolStripMenuItem";
            this.DeleteItemToolStripMenuItem.Size = new System.Drawing.Size(233, 38);
            this.DeleteItemToolStripMenuItem.Text = "Delete Item";
            this.DeleteItemToolStripMenuItem.Click += new System.EventHandler(this.DeleteItemToolStripMenuItem_Click);
            // 
            // btnAddNewItem
            // 
            this.btnAddNewItem.Checked = true;
            this.btnAddNewItem.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.btnAddNewItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewItem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewItem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewItem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewItem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewItem.FillColor = System.Drawing.Color.White;
            this.btnAddNewItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddNewItem.ForeColor = System.Drawing.Color.White;
            this.btnAddNewItem.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnAddNewItem.Image = global::Hotel.Properties.Resources.add_item;
            this.btnAddNewItem.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnAddNewItem.ImageSize = new System.Drawing.Size(55, 55);
            this.btnAddNewItem.Location = new System.Drawing.Point(1260, 192);
            this.btnAddNewItem.Name = "btnAddNewItem";
            this.btnAddNewItem.Size = new System.Drawing.Size(78, 57);
            this.btnAddNewItem.TabIndex = 234;
            this.btnAddNewItem.Click += new System.EventHandler(this.btnAddNewItem_Click);
            // 
            // frmListItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1344, 759);
            this.Controls.Add(this.flpItems);
            this.Controls.Add(this.cbTypeOfViewItems);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.dgvItemsList);
            this.Controls.Add(this.btnAddNewItem);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.cbItemTypes);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Manage Items";
            this.Text = "frmListItems";
            this.Load += new System.EventHandler(this.frmListItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsList)).EndInit();
            this.cmsEditProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.PictureBox pbImage;
        private Guna.UI2.WinForms.Guna2DataGridView dgvItemsList;
        private System.Windows.Forms.ContextMenuStrip cmsEditProfile;
        private System.Windows.Forms.ToolStripMenuItem ShowItemDetailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem EditItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteItemToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2Button btnAddNewItem;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cbItemTypes;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbTypeOfViewItems;
        private System.Windows.Forms.FlowLayoutPanel flpItems;
        private System.Windows.Forms.ToolStripMenuItem EditItemTypeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem AddNewItemToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem AddNewItemToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem AddNewItemTypeToolStripMenuItem1;
    }
}