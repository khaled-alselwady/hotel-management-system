using Hotel_Business;
using System.Windows.Forms;

namespace Hotel.RoomServices.UserControls
{
    public partial class ucRoomServiceCard : UserControl
    {
        private short? _RoomServiceID = null;
        private clsRoomService _RoomService = null;

        public short? RoomServiceID => _RoomServiceID;
        public clsRoomService RoomServiceInfo => _RoomService;

        public ucRoomServiceCard()
        {
            InitializeComponent();
        }

        private void _FillRoomServiceData()
        {           
            lblRoomServiceID.Text = _RoomService.RoomServiceID.ToString();
            lblRoomServiceTitle.Text = _RoomService.RoomServiceTitle;
            lblDescription.Text = _RoomService.Description ?? "No Description";
            lblFees.Text = _RoomService.Fees.ToString("C");
        }

        public void Reset()
        {
            _RoomServiceID = null;
            _RoomService = null;

            lblRoomServiceID.Text = "[????]";
            lblRoomServiceTitle.Text = "[????]";
            lblDescription.Text = "[????]";
            lblFees.Text = "[????]";
        }

        public void LoadRoomServiceInfo(short? RoomServiceID)
        {
            _RoomServiceID = RoomServiceID;

            if (!_RoomServiceID.HasValue)
            {
                MessageBox.Show("There is no Room Service!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _RoomService = clsRoomService.Find(_RoomServiceID);

            if (_RoomService == null)
            {
                MessageBox.Show($"There is no Room Service with ID = {_RoomServiceID} !",
                    "Missing RoomService", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillRoomServiceData();
        }
    }
}
