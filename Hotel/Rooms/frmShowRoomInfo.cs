using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.Rooms
{
    public partial class frmShowRoomInfo : Form
    {
        public frmShowRoomInfo(int? RoomID)
        {
            InitializeComponent();

            ucRoomCard1.LoadRoomInfo(RoomID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
