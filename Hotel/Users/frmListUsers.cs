using Hotel.GlobalClasses;
using Hotel_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Hotel.Users
{
    public partial class frmListUsers : Form
    {
        private DataTable _dtUsers;

        public frmListUsers()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "User ID":
                    return "UserID";

                case "Person ID":
                    return "PersonID";

                case "Name":
                    return "FullName";

                case "Username":
                    return "Username";

                case "Is Active":
                    return "IsActive";

                default:
                    return "None";
            }
        }

        private void _RefreshUsersList()
        {
            _dtUsers = clsUser.GetAllUsers();
            dgvUsersList.DataSource = _dtUsers;
            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();

            if (dgvUsersList.Rows.Count > 0)
            {
                dgvUsersList.Columns[0].HeaderText = "User ID";
                dgvUsersList.Columns[0].Width = 125;

                dgvUsersList.Columns[1].HeaderText = "Person ID";
                dgvUsersList.Columns[1].Width = 190;

                dgvUsersList.Columns[2].HeaderText = "Name";
                dgvUsersList.Columns[2].Width = 240;

                dgvUsersList.Columns[3].HeaderText = "Username";
                dgvUsersList.Columns[3].Width = 160;

                dgvUsersList.Columns[4].HeaderText = "Is Active";
                dgvUsersList.Columns[4].Width = 100;
            }
        }

        private int? _GetUserIDFromDGV()
        {
            return (int?)dgvUsersList.CurrentRow.Cells["UserID"].Value;
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _RefreshUsersList();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") && (cbFilter.Text != "Is Active");

            cbIsActive.Visible = (cbFilter.Text == "Is Active");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbIsActive.Visible)
            {
                cbIsActive.SelectedIndex = 0;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtUsers.Rows.Count == 0)
                return;

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) ||
                cbFilter.Text == "None")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "User ID" || cbFilter.Text == "Person ID")
            {
                // search with numbers
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "User ID" || cbFilter.Text == "Person ID")
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtUsers.Rows.Count == 0)
                return;

            if (cbIsActive.Text == "All")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();

                return;
            }

            _dtUsers.DefaultView.RowFilter =
                string.Format("[{0}] = {1}", "IsActive", (cbIsActive.Text == "Yes"));

            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void ShowUserDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowUserInfo ShowUserInfo = new frmShowUserInfo(_GetUserIDFromDGV());
            ShowUserInfo.ShowDialog();

            _RefreshUsersList();
        }

        private void EditUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser EditUser = new frmAddEditUser(_GetUserIDFromDGV());
            EditUser.ShowDialog();

            _RefreshUsersList();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (clsUser.DeleteUser(_GetUserIDFromDGV()))
                {
                    MessageBox.Show("Deleted Done Successfully", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshUsersList();
                }
                else
                {
                    MessageBox.Show("Deleted Failed", "Failed",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword ChangePassword = new frmChangePassword(_GetUserIDFromDGV());
            ChangePassword.ShowDialog();

            _RefreshUsersList();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser AddNewUser = new frmAddEditUser();
            AddNewUser.ShowDialog();

            _RefreshUsersList();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (dgvUsersList.Rows.Count > 0);

            DeleteToolStripMenuItem.Enabled = (clsGlobal.CurrentUser?.UserID != _GetUserIDFromDGV());
        }

        private void dgvUsersList_DoubleClick(object sender, EventArgs e)
        {
            frmShowUserInfo ShowUserInfo = new frmShowUserInfo(_GetUserIDFromDGV());
            ShowUserInfo.ShowDialog();

            _RefreshUsersList();
        }
    }
}
