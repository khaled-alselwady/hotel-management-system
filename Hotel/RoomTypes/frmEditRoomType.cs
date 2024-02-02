using Guna.UI2.WinForms;
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

namespace Hotel.RoomTypes
{
    public partial class frmEditRoomType : Form
    {
        private byte? _RoomTypeID = null;
        private clsRoomType _RoomType = null;

        public frmEditRoomType(byte? RoomTypeID)
        {
            InitializeComponent();

            _RoomTypeID = RoomTypeID;
        }

        private void _LoadData()
        {
            txtDescription.BorderRadius = 17;

            _RoomType = clsRoomType.Find(_RoomTypeID);

            if (_RoomType == null)
            {
                MessageBox.Show("No Room Type with ID = " + _RoomType, "Room Type Not Found",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();

                return;
            }

            lblRoomTypeID.Text = _RoomType.RoomTypeID.ToString();
            lblRoomTypeTitle.Text = _RoomType.RoomTypeTitle;
            lblCapacity.Text = _RoomType.Capacity.ToString();
            txtPricePerNight.Text = _RoomType.PricePerNight.ToString("C");
            txtDescription.Text = _RoomType.Description;
        }

        private void _UpdateRoomType()
        {
            if (txtPricePerNight.Text.Contains("$")) // to remove the $ from the beginning of price
                _RoomType.PricePerNight = decimal.Parse(txtPricePerNight.Text.Trim().Substring(1));
            else
                _RoomType.PricePerNight = decimal.Parse(txtPricePerNight.Text.Trim());

            _RoomType.Description = txtDescription.Text.Trim();

            if (_RoomType.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Saved Failed", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmEditRoomType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPricePerNight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPricePerNight.Text.Trim()))
            {
                MessageBox.Show("Price cannot be empty!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _UpdateRoomType();
        }
    }
}
