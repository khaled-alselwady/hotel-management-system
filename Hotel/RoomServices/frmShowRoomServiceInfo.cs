using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.RoomServices
{
    public partial class frmShowRoomServiceInfo : Form
    {
        public frmShowRoomServiceInfo(short? RoomServiceID)
        {
            InitializeComponent();

            ucRoomServiceCard1.LoadRoomServiceInfo(RoomServiceID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
