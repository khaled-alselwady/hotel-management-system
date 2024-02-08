using Hotel.Properties;
using Hotel_Business;
using System.IO;
using System.Windows.Forms;

namespace Hotel.Items.UserControls
{
    public partial class ucItemLongCard : UserControl
    {
        private int? _ItemID = null;
        private clsItem _Item = null;

        public int? ItemID => _ItemID;
        public clsItem ItemInfo => _Item;

        public ucItemLongCard()
        {
            InitializeComponent();
        }

        private void _LoadItemImage()
        {
            if (_Item.ItemImagePath != null)
                if (File.Exists(_Item.ItemImagePath))
                {
                    pbItemImage.ImageLocation = _Item.ItemImagePath;
                    pbItemImage.Cursor = Cursors.Hand;
                }
                else
                {
                    MessageBox.Show("Could not find this image: = " +
                        _Item.ItemImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pbItemImage.Cursor = Cursors.Default;
                }

            else
            {
                pbItemImage.Image = Resources.question_mark;
                pbItemImage.Cursor = Cursors.Default;
            }
        }

        private void _FillItemData()
        {
            lblItemID.Text = _Item.ItemID.ToString();
            lblItemName.Text = _Item.ItemName;
            lblItemType.Text = _Item.ItemTypeInfo.ItemTypeName;
            lblPrice.Text = _Item.ItemPrice.ToString("C");
            lblDescription.Text = _Item.Description ?? "None";

            _LoadItemImage();

            llEditItemInfo.Enabled = true;
        }

        public void Reset()
        {
            _ItemID = null;
            _Item = null;

            lblItemID.Text = "[????]";
            lblItemName.Text = "[????]";
            lblItemType.Text = "[????]";
            lblPrice.Text = "[????]";
            lblDescription.Text = "[????]";

            llEditItemInfo.Enabled = false;
        }

        public void LoadItemInfo(int? ItemID)
        {
            _ItemID = ItemID;

            if (!_ItemID.HasValue)
            {
                MessageBox.Show("There is no Item!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _Item = clsItem.Find(_ItemID);

            if (_Item == null)
            {
                MessageBox.Show($"There is no Item with ID = {_ItemID} !",
                    "Missing Item", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillItemData();
        }

        private void llEditItemInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditItem EditItem = new frmAddEditItem(_ItemID);
            EditItem.ShowDialog();

            // Refresh
            LoadItemInfo(_ItemID);
        }

        private void pbItemImage_Click(object sender, System.EventArgs e)
        {
            if (_Item.ItemImagePath == null)
            {
                pbItemImage.Cursor = Cursors.Default;
                return;
            }

            pbItemImage.Cursor = Cursors.Hand;

            frmShowItemImageWithZoom ShowItemImageWithZoom = new frmShowItemImageWithZoom(_Item.ItemImagePath, _Item.ItemName);
            ShowItemImageWithZoom.ShowDialog();
        }
    }
}
