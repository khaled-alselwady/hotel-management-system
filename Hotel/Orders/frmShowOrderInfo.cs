using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.Orders
{
    public partial class frmShowOrderInfo : Form
    {
        public frmShowOrderInfo(int? OrderID)
        {
            InitializeComponent();

            ucOrderCard1.LoadOrderInfo(OrderID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
