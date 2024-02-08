using Hotel.Items.UserControls;
using Hotel_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Hotel.Items
{
    public partial class frmListItems : Form
    {
        private DataTable _dtItem;

        public frmListItems()
        {
            InitializeComponent();
        }

        private void _FillComboBoxWithItemTypeName()
        {
            cbItemTypes.Items.Clear();

            cbItemTypes.Items.Add("All");

            DataTable dtItemTypesTitle = clsItemType.GetAllItemTypesName();

            foreach (DataRow drTitle in dtItemTypesTitle.Rows)
            {
                cbItemTypes.Items.Add(drTitle["ItemTypeName"].ToString());
            }
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Item ID":
                    return "ItemID";

                case "Item Name":
                    return "ItemName";

                case "Item Type":
                    return "ItemTypeName";

                default:
                    return "None";
            }
        }

        private void _RefreshItemList()
        {
            _dtItem = clsItem.GetAllItems();
            dgvItemsList.DataSource = _dtItem;
            lblNumberOfRecords.Text = dgvItemsList.Rows.Count.ToString();

            if (dgvItemsList.Rows.Count > 0)
            {
                dgvItemsList.Columns[0].HeaderText = "Item ID";
                dgvItemsList.Columns[0].Width = 110;

                dgvItemsList.Columns[1].HeaderText = "Item Name";
                dgvItemsList.Columns[1].Width = 190;

                dgvItemsList.Columns[2].HeaderText = "Item Type";
                dgvItemsList.Columns[2].Width = 130;

                dgvItemsList.Columns[3].HeaderText = "Item Price";
                dgvItemsList.Columns[3].Width = 130;
            }
        }

        private int? _GetItemIDFromDGV()
        {
            return (int?)dgvItemsList.CurrentRow.Cells["ItemID"].Value;
        }

        private void _FillFlowLayoutPanelWithItems()
        {
            flpItems.Controls.Clear();

            ucItemShortCard ItemCard = new ucItemShortCard();

            foreach (DataGridViewRow Row in dgvItemsList.Rows)
            {
                if (!Row.IsNewRow) // Check if the row is not the new row
                {
                    ItemCard = new ucItemShortCard();
                    ItemCard.LoadItemInfo((int?)Row.Cells["ItemID"].Value);
                    flpItems.Controls.Add(ItemCard);
                }
            }

        }

        private void frmListItems_Load(object sender, EventArgs e)
        {
            _RefreshItemList();
            _FillComboBoxWithItemTypeName();

            // refresh the flpItems control
            flpItems.Visible = true;
            flpItems.Visible = false;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") && (cbFilter.Text != "Item Type");

            cbItemTypes.Visible = (cbFilter.Text == "Item Type");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbItemTypes.Visible)
            {
                cbItemTypes.SelectedIndex = 0;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtItem.Rows.Count == 0)
                return;

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) ||
                cbFilter.Text == "None")
            {
                _dtItem.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvItemsList.Rows.Count.ToString();
                _FillFlowLayoutPanelWithItems();

                return;
            }

            if (cbFilter.Text == "Item ID")
            {
                // search with numbers
                _dtItem.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtItem.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvItemsList.Rows.Count.ToString();
            _FillFlowLayoutPanelWithItems();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Item ID")
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbItemTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtItem.Rows.Count == 0)
                return;

            if (cbItemTypes.Text == "All")
            {
                _dtItem.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvItemsList.Rows.Count.ToString();
                _FillFlowLayoutPanelWithItems();
                return;
            }

            _dtItem.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "ItemTypeName", cbItemTypes.Text);

            lblNumberOfRecords.Text = dgvItemsList.Rows.Count.ToString();
            _FillFlowLayoutPanelWithItems();
        }

        private void ShowItemDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowItemInfo ShowItemInfo = new frmShowItemInfo(_GetItemIDFromDGV());
            ShowItemInfo.ShowDialog();

            _RefreshItemList();
        }

        private void dgvItemsList_DoubleClick(object sender, EventArgs e)
        {
            frmShowItemInfo ShowItemInfo = new frmShowItemInfo(_GetItemIDFromDGV());
            ShowItemInfo.ShowDialog();

            _RefreshItemList();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (dgvItemsList.Rows.Count > 0);
        }

        private void cbTypeOfViewItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTypeOfViewItems.Text == "Flow")
            {
                _FillFlowLayoutPanelWithItems();
                dgvItemsList.Visible = false;
                flpItems.Visible = true;
            }
            else
            {
                dgvItemsList.Visible = true;
                flpItems.Visible = false;
            }
        }

        private void AddNewItemToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmAddEditItem AddNewItem = new frmAddEditItem();
            AddNewItem.ShowDialog();

            frmListItems_Load(null, null);
        }

        private void AddNewItemTypeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditItemType AddNewItemType = new frmAddEditItemType();
            AddNewItemType.ShowDialog();

            frmListItems_Load(null, null);
        }

        private void EditItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditItem EditItem = new frmAddEditItem(_GetItemIDFromDGV());
            EditItem.ShowDialog();

            frmListItems_Load(null, null);
        }

        private void EditItemTypeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditItemType EditItemType = new frmAddEditItemType((string)dgvItemsList.CurrentRow.Cells["ItemTypeName"].Value);
            EditItemType.ShowDialog();

            frmListItems_Load(null, null);
        }

        private void DeleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this item?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                == DialogResult.No)
                return;

            if (clsItem.DeleteItem(_GetItemIDFromDGV()))
            {
                MessageBox.Show("Item Deleted Successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _RefreshItemList();
            }
            else
            {
                MessageBox.Show("The item cannot be deleted because it is linked to other tables!",
                    "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddNewItem_Click(object sender, EventArgs e)
        {
            frmAddEditItem AddNewItem = new frmAddEditItem();
            AddNewItem.ShowDialog();

            frmListItems_Load(null, null);
        }
    }
}
