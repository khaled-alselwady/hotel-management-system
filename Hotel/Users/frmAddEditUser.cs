using Guna.UI2.WinForms;
using Hotel.GlobalClasses;
using Hotel.Properties;
using Hotel_Business;
using System;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;
using static Hotel.People.UserControls.ucPersonCardWithFilter;

namespace Hotel.Users
{
    public partial class frmAddEditUser : Form
    {
        public Action<int?> UserIDBack;

        private enum _enMode { AddNew, Update };
        private _enMode _Mode = _enMode.AddNew;

        private int? _UserID = null;
        private clsUser _User = null;

        private int? _SelectedPersonID = null;

        public frmAddEditUser()
        {
            InitializeComponent();

            _Mode = _enMode.AddNew;
        }

        public frmAddEditUser(int? UserID)
        {
            InitializeComponent();

            _UserID = UserID;
            _Mode = _enMode.Update;
        }

        private void _ResetFields()
        {
            ucPersonCardWithFilter1.Clear();

            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            lblUserID.Text = "[????]";
            chkActiveUser.Checked = true;

            pbIsActive.Image = Resources.question_mark;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == _enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
                _User = new clsUser();

                tpLoginInfo.Enabled = false;
                ucPersonCardWithFilter1.FilterFocus();

                _ResetFields();
            }
            else
            {
                lblTitle.Text = "Update User";
            }

            this.Text = lblTitle.Text;
        }

        private void _LoadData()
        {
            _User = clsUser.FindBy(_UserID, clsUser.enFindBy.UserID);
            ucPersonCardWithFilter1.FilterEnabled = false;

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();

                return;
            }

            
            lblUserID.Text = _User.UserID.ToString();
            txtUsername.Text = _User.Username;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chkActiveUser.Checked = _User.IsActive;
            ucPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);

            // in update mode, I show the change password link label to allow the user to change his password
            panelPassword.Visible = false;
            chkActiveUser.Location = new System.Drawing.Point(406, 163);
            pbIsActive.Location = new System.Drawing.Point(358, 163);
            llChangePassword.Location = new System.Drawing.Point(401, 216);
            llChangePassword.Visible = true;
        }

        private void _FillPersonObjectWithFieldsData()
        {
            _User.Username = txtUsername.Text.Trim();
            _User.PersonID = _SelectedPersonID;
            _User.IsActive = chkActiveUser.Checked;

            if (_Mode == _enMode.AddNew)
            {
                _User.Password = clsGlobal.ComputeHash(txtPassword.Text.Trim());
            }
        }

        private void _SaveUser()
        {
            _FillPersonObjectWithFieldsData();

            if (_User.Save())
            {
                lblTitle.Text = "Update User";
                this.Text = lblTitle.Text;
                lblUserID.Text = _User.UserID.ToString();

                // change form mode to update
                _Mode = _enMode.Update;

                MessageBox.Show("Data Saved Successfully", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to the caller form
                UserIDBack?.Invoke(_User.UserID);
            }
            else
            {
                MessageBox.Show("Data Saved Failed", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucPersonCardWithFilter1_OnPersonSelected(object sender, PersonSelectedEventArgs e)
        {
            if (!e.PersonID.HasValue)
            {
                btnNext.Enabled = false;
                tpLoginInfo.Enabled = false;
                btnSave.Enabled = false;

                return;
            }

            if (_Mode == _enMode.AddNew && ucPersonCardWithFilter1.PersonInfo.IsUser)
            {
                MessageBox.Show("Selected Person already has a user, choose another one.",
                            "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ucPersonCardWithFilter1.FilterFocus();

                btnNext.Enabled = false;
                tpLoginInfo.Enabled = false;
                btnSave.Enabled = false;

                return;
            }

            _SelectedPersonID = e.PersonID;

            btnNext.Enabled = true;
            tpLoginInfo.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tcAddEditUser.SelectedTab = tcAddEditUser.TabPages["tpLoginInfo"];
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == _enMode.Update)
                _LoadData();
        }

        private void txtUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUsername, null);
            }


            if (txtUsername.Text.Trim().ToLower() != _User.Username.ToLower() &&
                clsUser.DoesUserExist(txtUsername.Text.Trim(), clsUser.enFindBy.Username))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, "username is used by another user");
            }
            else
            {
                errorProvider1.SetError(txtUsername, null);
            }
        }

        private void txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!panelPassword.Visible)
                return;

            if (string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!panelPassword.Visible)
                return;

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Confirm Password cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }

            if ((!string.IsNullOrWhiteSpace(txtConfirmPassword.Text.Trim())
                && !string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
                && (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword,
                    "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void frmAddEditUser_Activated(object sender, EventArgs e)
        {
            ucPersonCardWithFilter1.FilterFocus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _SaveUser();
        }

        private void llChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChangePassword ChangePassword = new frmChangePassword(_UserID);
            ChangePassword.ShowDialog();
        }

        private void txtPasswordAndConfirm_TextChanged(object sender, EventArgs e)
        {
            ((Guna2TextBox)sender).UseSystemPasswordChar = true;
        }
    }
}
