using Hotel.GlobalClasses;
using Hotel.Properties;
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

namespace Hotel.Rooms.UserControls
{
    public partial class ucRoomCard : UserControl
    {
        private int? _RoomID = null;
        private clsRoom _Room = null;

        public int? RoomID => _RoomID;
        public clsRoom RoomInfo => _Room;

        public ucRoomCard()
        {
            InitializeComponent();
        }

        private void _FillRoomData()
        {
            lblRoomID.Text = _Room.RoomID.ToString();
            lblRoomTypeID.Text = _Room.RoomTypeID.ToString();
            lblRoomNumber.Text = _Room.RoomNumber.ToString();
            lblStatus.Text = _Room.RoomStatusName;
            lblNotes.Text = _Room.Notes ?? "N/A";
            lblRoomSize.Text = _Room.Size.ToString();
            lblRoomFloor.Text = _Room.FloorNumber.ToString();
            lblIsSomkingAllowed.Text = _Room.IsSmokingAllowed ? "Yes" : "No";
            lblIsPetFriendly.Text = _Room.IsPetFriendly ? "Yes" : "No";
        }

        public void Reset()
        {
            _RoomID = null;
            _Room = null;

            lblRoomID.Text = "[????]";
            lblRoomTypeID.Text = "[????]";
            lblRoomNumber.Text = "[????]";
            lblStatus.Text = "[????]";
            lblNotes.Text = "[????]";
            lblRoomSize.Text = "[????]";
            lblRoomFloor.Text = "[????]";
            lblIsSomkingAllowed.Text = "[????]";
            lblIsPetFriendly.Text = "[????]";
        }

        public void LoadRoomInfo(int? RoomID)
        {
            _RoomID = RoomID;

            if (!_RoomID.HasValue)
            {
                MessageBox.Show("There is no Room!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _Room = clsRoom.FindByRoomID(_RoomID);

            if (_Room == null)
            {
                MessageBox.Show($"There is no Room with ID = {_RoomID} !",
                    "Missing Room", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillRoomData();
        }
    }
}
