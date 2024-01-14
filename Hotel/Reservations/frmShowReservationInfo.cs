using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.Reservations
{
    public partial class frmShowReservationInfo : Form
    {
        public frmShowReservationInfo(int? ReservationID)
        {
            InitializeComponent();

            ucReservationsCard1.LoadReservationInfo(ReservationID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
