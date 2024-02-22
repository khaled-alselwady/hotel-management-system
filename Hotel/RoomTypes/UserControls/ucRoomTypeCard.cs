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

namespace Hotel.RoomTypes.UserControls
{
    public partial class ucRoomTypeCard : UserControl
    {
        private byte? _RoomTypeID = null;
        private clsRoomType _RoomType = null;

        public byte? RoomTypeID => _RoomTypeID;
        public clsRoomType RoomTypeInfo => _RoomType;

        public ucRoomTypeCard()
        {
            InitializeComponent();
        }

        private void _FillRoomTypeData()
        {
            int TotalAllRooms = clsRoom.Count();
            int TotalRoomsWithSpecificRoomType = clsRoomType.CountByRoomTypeID(_RoomType.RoomTypeID);

            lblRoomTypeID.Text = _RoomType.RoomTypeID.ToString();
            lblRoomTypeTitle.Text = _RoomType.RoomTypeTitle;
            lblCapacity.Text = _RoomType.Capacity.ToString();
            lblDescription.Text = _RoomType.Description ?? "N/A"; 
            lblPricePerNight.Text = _RoomType.PricePerNight.ToString("C");
            lblRoomCount.Text = TotalRoomsWithSpecificRoomType.ToString() + "/" + TotalAllRooms.ToString();
        }

        public void Reset()
        {
            _RoomTypeID = null;
            _RoomType = null;

            lblRoomTypeID.Text = "[????]";
            lblRoomTypeTitle.Text = "[????]";
            lblCapacity.Text = "[????]";
            lblDescription.Text = "[????]";
            lblPricePerNight.Text = "[????]";
            lblRoomCount.Text = "[????]";
        }

        public void LoadRoomTypeInfo(byte? RoomTypeID)
        {
            _RoomTypeID = RoomTypeID;

            if (!_RoomTypeID.HasValue)
            {
                MessageBox.Show("There is no Room Type!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _RoomType = clsRoomType.Find(_RoomTypeID);

            if (_RoomType == null)
            {
                MessageBox.Show($"There is no Room Type with ID = {_RoomTypeID} !",
                    "Missing RoomType", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillRoomTypeData();
        }

    }
}
