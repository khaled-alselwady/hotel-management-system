using System;
using System.Windows.Forms;

namespace Hotel.Items
{
    public partial class frmShowItemInfo : Form
    {
        public frmShowItemInfo(int? ItemID, bool EnableUpdateInfo = true)
        {
            InitializeComponent();

            ucItemLongCard1.LoadItemInfo(ItemID);
            ucItemLongCard1.EnableUpdateInfo = EnableUpdateInfo;
        }       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
