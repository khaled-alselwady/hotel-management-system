using Hotel.GlobalClasses;
using Hotel.Properties;
using Hotel_Business;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static Hotel.People.UserControls.ucPersonCardWithFilter;

namespace Hotel.Reservations
{
    public partial class frmAddEditReservation : Form
    {
        public Action<int?> ReservationIDBack;

        private enum _enMode { AddNew, Update };
        private _enMode _Mode = _enMode.AddNew;

        private int? _ReservationID = null;
        private clsReservation _Reservation = null;

        private int? _SelectedPersonID = null;

        public frmAddEditReservation()
        {
            InitializeComponent();

            _Mode = _enMode.AddNew;
        }

        public frmAddEditReservation(int? ReservationID)
        {
            InitializeComponent();

            _ReservationID = ReservationID;
            _Mode = _enMode.Update;
        }

        private void _FillComboBoxWithNumberOfPeople(byte NumberOfPeople)
        {
            cbNumberOfPeople.Items.Clear();

            for (byte i = 1; i <= NumberOfPeople; i++)
            {
                cbNumberOfPeople.Items.Add(i);
            }

            if (cbNumberOfPeople.Items.Count > 0)
                cbNumberOfPeople.SelectedIndex = 0;
        }

        private void _FillComboBoxWithRoomTypeTitles()
        {
            DataTable dtRoomTypesTitle = clsRoomType.GetAllRoomTypesTitle();

            foreach (DataRow drTitle in dtRoomTypesTitle.Rows)
            {
                cbRoomTypes.Items.Add(drTitle["RoomTypeTitle"].ToString());
            }

            if (cbRoomTypes.Items.Count > 0)
                cbRoomTypes.SelectedIndex = 0;
        }

        private void _FillComboBoxWithAvailableRooms()
        {
            if (cbRoomTypes.Items.Count <= 0)
                return;

            cbAvailableRooms.Items.Clear();

            DataTable dtAvailableRooms = new DataTable();

            switch (cbRoomTypes.Text)
            {
                case "Single":
                    dtAvailableRooms = clsRoom.GetAllAvailableRoomsBySpecificRoomType(clsRoom.enRoomTypes.Single);
                    _FillComboBoxWithNumberOfPeople(clsRoomType.KeyValueTypeTitleAndCapacity[clsRoom.enRoomTypes.Single]);
                    break;

                case "Double":
                    dtAvailableRooms = clsRoom.GetAllAvailableRoomsBySpecificRoomType(clsRoom.enRoomTypes.Double);
                    _FillComboBoxWithNumberOfPeople(clsRoomType.KeyValueTypeTitleAndCapacity[clsRoom.enRoomTypes.Double]);
                    break;

                case "Deluxe Suite":
                    dtAvailableRooms = clsRoom.GetAllAvailableRoomsBySpecificRoomType(clsRoom.enRoomTypes.DeluxeSuite);
                    _FillComboBoxWithNumberOfPeople(clsRoomType.KeyValueTypeTitleAndCapacity[clsRoom.enRoomTypes.DeluxeSuite]);
                    break;

                case "Family Room":
                    dtAvailableRooms = clsRoom.GetAllAvailableRoomsBySpecificRoomType(clsRoom.enRoomTypes.FamilyRoom);
                    _FillComboBoxWithNumberOfPeople(clsRoomType.KeyValueTypeTitleAndCapacity[clsRoom.enRoomTypes.FamilyRoom]);
                    break;
            }

            foreach (DataRow drAvailableRoom in dtAvailableRooms.Rows)
            {
                cbAvailableRooms.Items.Add(drAvailableRoom["RoomNumber"].ToString());
            }

            if (cbAvailableRooms.Items.Count > 0)
                cbAvailableRooms.SelectedIndex = 0;
        }

        private void _ResetFields()
        {
            ucPersonCardWithFilter1.Clear();

            dtpReservedForDate.Value = DateTime.Now;
            lblReservationID.Text = "[????]";
            lblStatus.Text = "Pending";
            lblCreatedByUser.Text = clsGlobal.CurrentUser.Username;
        }

        private void _ResetDefaultValues()
        {
            _FillComboBoxWithRoomTypeTitles();
            _FillComboBoxWithAvailableRooms();

            if (_Mode == _enMode.AddNew)
            {
                lblTitle.Text = "Add New Reservation";
                _Reservation = new clsReservation();

                tpReservationInfo.Enabled = false;
                ucPersonCardWithFilter1.FilterFocus();

                _ResetFields();
            }
            else
            {
                lblTitle.Text = "Update Reservation";
            }

            this.Text = lblTitle.Text;

            dtpReservedForDate.MinDate = DateTime.Now;
        }

        private void _LoadData()
        {
            _Reservation = clsReservation.Find(_ReservationID);
            ucPersonCardWithFilter1.FilterEnabled = false;

            if (_Reservation == null)
            {
                MessageBox.Show("No Reservation with ID = " + _Reservation, "User Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();

                return;
            }

            lblReservationID.Text = _Reservation.ReservationID.ToString();
            dtpReservedForDate.Value = _Reservation.ReservedForDate;
            lblStatus.Text = _Reservation.ReservationStatusName;
            lblCreatedByUser.Text = _Reservation.CreatedByUserInfo.Username;
            ucPersonCardWithFilter1.LoadPersonInfo(_Reservation.PersonID);

            cbRoomTypes.SelectedIndex = cbRoomTypes.FindString(_Reservation.RoomInfo.RoomTypeID.ToString());
            cbAvailableRooms.SelectedIndex = cbAvailableRooms.FindString(_Reservation.RoomInfo.RoomNumber.ToString());
            cbNumberOfPeople.SelectedIndex = cbNumberOfPeople.FindString
                (clsRoomType.KeyValueTypeTitleAndCapacity[_Reservation.RoomInfo.RoomTypeID].ToString());

        }

        private void _FillReservationObjectWithFieldsData()
        {
            _Reservation.PersonID = _SelectedPersonID;
            _Reservation.RoomID = clsRoom.FindByRoomNumber(int.Parse(cbAvailableRooms.Text)).RoomID;
            _Reservation.ReservedForDate = dtpReservedForDate.Value;
            _Reservation.NumberOfPeople = byte.Parse(cbNumberOfPeople.Text);
            _Reservation.CreatedByUserID = clsGlobal.CurrentUser.UserID;
        }

        private void _SaveReservation()
        {
            _FillReservationObjectWithFieldsData();

            if (_Reservation.Save())
            {
                lblTitle.Text = "Update Reservation";
                this.Text = lblTitle.Text;
                lblReservationID.Text = _Reservation.ReservationID.ToString();

                // change form mode to update
                _Mode = _enMode.Update;

                MessageBox.Show("Data Saved Successfully", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to the caller form
                ReservationIDBack?.Invoke(_Reservation.ReservationID);
            }
            else
            {
                MessageBox.Show("Data Saved Failed", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddEditReservation_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == _enMode.Update)
                _LoadData();
        }

        private void cbRoomTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FillComboBoxWithAvailableRooms();
        }

        private void ucPersonCardWithFilter1_OnPersonSelected(object sender, PersonSelectedEventArgs e)
        {
            if (!e.PersonID.HasValue)
            {
                btnNext.Enabled = false;
                tpReservationInfo.Enabled = false;
                btnSave.Enabled = false;

                return;
            }

            _SelectedPersonID = e.PersonID;

            btnNext.Enabled = true;
            tpReservationInfo.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tcAddEditReservation.SelectedTab = tcAddEditReservation.TabPages["tpReservationInfo"];
        }

        private void dtpReservedForDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (clsReservation.IsRoomReserved(int.Parse(cbAvailableRooms.Text),
                dtpReservedForDate.Value.Date))
            {
                e.Cancel = true;
                errorProvider1.SetError(dtpReservedForDate, "There is already an active reservation for this room at this date !");
            }
            else
            {
                errorProvider1.SetError(dtpReservedForDate, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditReservation_Activated(object sender, EventArgs e)
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

            _SaveReservation();
        }
    }
}
