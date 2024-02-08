using System;
using System.Windows.Forms;

namespace Hotel.Items
{
    public partial class frmShowItemInfo : Form
    {
        public frmShowItemInfo(int? ItemID)
        {
            InitializeComponent();

            ucItemLongCard1.LoadItemInfo(ItemID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
