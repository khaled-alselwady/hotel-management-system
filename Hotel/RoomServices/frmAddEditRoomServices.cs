using Guna.UI2.WinForms;
using Hotel_Business;
using System;
using System.Windows.Forms;

namespace Hotel.RoomServices
{
    public partial class frmAddEditRoomServices : Form
    {
        private enum _enMode { AddNew, Update };
        private _enMode _Mode = _enMode.AddNew;

        private int? _RoomServiceID = null;
        private clsRoomService _RoomService = null;

        public frmAddEditRoomServices()
        {
            InitializeComponent();

            _Mode = _enMode.AddNew;
        }

        public frmAddEditRoomServices(int? RoomServiceID)
        {
            InitializeComponent();

            _RoomServiceID = RoomServiceID;
            _Mode = _enMode.Update;
        }

        private void _ResetFields()
        {
            lblRoomServiceID.Text = "N\\A";
            txtTitle.Clear();
            txtFees.Clear();
            txtDescription.Clear();
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == _enMode.AddNew)
            {
                lblTitle.Text = "Add New Room Service";
                _RoomService = new clsRoomService();

                _ResetFields();
            }
            else
            {
                lblTitle.Text = "Update Room Service";
            }

            this.Text = lblTitle.Text;

            txtDescription.BorderRadius = 17;
        }

        private void _LoadData()
        {
            _RoomService = clsRoomService.Find(_RoomServiceID);

            if (_RoomService == null)
            {
                MessageBox.Show("No Room Service with ID = " + _RoomService, "Room Service Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();

                return;
            }

            lblRoomServiceID.Text = _RoomService.RoomServiceID.ToString();
            txtTitle.Text = _RoomService.RoomServiceTitle;
            txtFees.Text = _RoomService.Fees.ToString("C");
            txtDescription.Text = _RoomService.Description;
        }

        private void _FillRoomObjectWithFieldsData()
        {
            _RoomService.RoomServiceTitle = txtTitle.Text.Trim();
            _RoomService.Description = txtDescription.Text.Trim();

            if (txtFees.Text.Contains("$")) // to remove the $ from the beginning of price
                _RoomService.Fees = float.Parse(txtFees.Text.Trim().Substring(1));
            else
                _RoomService.Fees = float.Parse(txtFees.Text.Trim());
        }

        private void _SaveRoomService()
        {
            _FillRoomObjectWithFieldsData();

            if (_RoomService.Save())
            {
                lblTitle.Text = "Update Room Service";
                this.Text = lblTitle.Text;
                lblRoomServiceID.Text = _RoomService.RoomServiceID.ToString();

                // change form mode to update
                _Mode = _enMode.Update;

                MessageBox.Show("Data Saved Successfully", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Saved Failed", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddEditRoomServices_Load(object sender, System.EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == _enMode.Update)
                _LoadData();
        }

        private void txtTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "This field cannot be empty!");

                return;
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }

            if (txtTitle.Text.Trim().ToLower() != _RoomService.RoomServiceTitle.ToLower() && clsRoomService.DoesRoomServiceExist(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "This title already exists!");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }
        }

        private void txtFees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "This field cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputChar = e.KeyChar;

            // Allow digits, the decimal point, and the backspace.
            bool isDigit = Char.IsDigit(inputChar);
            bool isDecimalPoint = (inputChar == '.');
            bool isBackspace = (inputChar == '\b');

            // If the input character is not a digit, decimal point, or backspace, suppress it.
            if (!isDigit && !isDecimalPoint && !isBackspace)
            {
                e.Handled = true;
            }

            // Make sure there is only one decimal point in the input.
            if (isDecimalPoint && ((sender as Guna2TextBox).Text.Contains(".") || (sender as Guna2TextBox).Text.Length == 0))
            {
                e.Handled = true;
            }
        }

        private void txtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "This field cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _SaveRoomService();
        }
    }
}
