using Hotel.GlobalClasses;
using Hotel_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.Users
{
    public partial class frmChangePassword : Form
    {
        private int? _UserID = null;
        private clsUser _User = null;

        public frmChangePassword(int? UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }

        private void _ResetFields()
        {
            txtCurrentPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();

            txtCurrentPassword.Focus();
        }

        private void _ChangePassword()
        {
            if (_User.ChangePassword(clsGlobal.ComputeHash(txtNewPassword.Text.Trim())))
            {
                MessageBox.Show("Password Changed Successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _ResetFields();
            }
            else
            {
                MessageBox.Show("An Error Occurred, Password did not change.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _TextBox_TextChanged(object sender, EventArgs e)
        {
            ((TextBox)sender).UseSystemPasswordChar = true;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetFields();

            _User = clsUser.FindBy(_UserID, clsUser.enFindBy.UserID);

            if (_User == null)
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Could not Find User with id = " + _UserID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;

            }

            ucUserCard1.LoadUserInfo(_UserID);
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }

            if (_User.Password != clsGlobal.ComputeHash(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current password is wrong!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "New Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword,
                    "Password Confirmation does not match New Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ChangePassword();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_Activated(object sender, EventArgs e)
        {
            txtCurrentPassword.Focus();
        }
    }
}
