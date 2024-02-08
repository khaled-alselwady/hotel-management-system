using Hotel.Properties;
using System.Windows.Forms;

namespace Hotel.Items
{
    public partial class frmShowItemImageWithZoom : Form
    {
        public frmShowItemImageWithZoom(string ItemImagePath, string ItemName)
        {
            InitializeComponent();

            if (ItemImagePath != null)
                pbItemImage.ImageLocation = ItemImagePath;
            else
                pbItemImage.Image = Resources.question_mark;

            this.Text = ItemName;
        }

    }
}
