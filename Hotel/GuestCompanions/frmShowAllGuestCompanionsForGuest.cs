using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.OrderItems
{
    public partial class frmShowAllGuestCompanionsForGuest : Form
    {
        public frmShowAllGuestCompanionsForGuest(int? GuestID)
        {
            InitializeComponent();

            ucShowAllGuestCompanionsForGuest1.LoadGuestCompanionsInfo(GuestID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
