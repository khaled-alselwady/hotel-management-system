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
    public partial class frmShowRoomTypeInfo : Form
    {
        public frmShowRoomTypeInfo(byte? RoomTypeID)
        {
            InitializeComponent();

            ucRoomTypeCard1.LoadRoomTypeInfo(RoomTypeID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
