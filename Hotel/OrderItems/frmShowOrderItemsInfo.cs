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
    public partial class frmShowOrderItemsInfo : Form
    {
        public frmShowOrderItemsInfo(int? OrderID)
        {
            InitializeComponent();

            ucOrderItemsList1.LoadOrderItemsInfo(OrderID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
