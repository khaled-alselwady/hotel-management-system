using Hotel.Properties;
using Hotel_Business;
using System.IO;
using System.Windows.Forms;

namespace Hotel.Items.UserControls
{
    public partial class ucItemShortCardWithQuantity : UserControl
    {
        private string _ItemImagePath = null;
        public string ItemImagePath
        {
            get => _ItemImagePath;
            set
            {
                _ItemImagePath = value;
                _LoadItemImage();
            }
        }

        public string _ItemName = "Item Name";
        public string ItemName
        {
            get => _ItemName;
            set => _ItemName = lblItemName.Text = value;
        }

        public float _ItemPrice = 0.00f;
        public float ItemPrice
        {
            get => _ItemPrice;
            set
            {
                _ItemPrice = value;
                lblItemPrice.Text = _ItemPrice.ToString("C");
            }
        }

        public float TotalItemPrice => _ItemPrice * (float)numaricQuantity.Value;

        public short ItemQuantity
        {
            get => (short)numaricQuantity.Value;

            set => numaricQuantity.Value = value;
        }

        private int? _ItemID = null;
        private clsItem _Item = null;

        public int? ItemID
        {
            get => _ItemID;
            set => _ItemID = value;            
        }

        public ucItemShortCardWithQuantity()
        {
            InitializeComponent();
        }

        private bool _DoesItemExist()
        {
            if (!_ItemID.HasValue)
            {
                MessageBox.Show("There is no Item!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return false;
            }

            _Item = clsItem.Find(_ItemID);

            if (_Item == null)
            {
                MessageBox.Show($"There is no Item with ID = {_ItemID} !",
                    "Missing Item", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return false;
            }

            return true;
        }

        private void _LoadItemImage()
        {
            if (_ItemImagePath != null)
                if (File.Exists(_ItemImagePath))
                {
                    pbItemImage.ImageLocation = _ItemImagePath;
                    pbItemImage.Cursor = Cursors.Hand;
                }
                else
                {
                    MessageBox.Show("Could not find this image: = " +
                        _ItemImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            _ItemName = lblItemName.Text = _Item.ItemName;
            lblItemPrice.Text = _Item.ItemPrice.ToString("C");
            _ItemPrice = _Item.ItemPrice;

            _LoadItemImage();
        }

        public void Reset()
        {
            _ItemImagePath = null;
            _ItemName = null;
            _ItemPrice = 0.00f;

            pbItemImage.Image = Resources.question_mark;
            lblItemName.Text = "[????]";
            lblItemPrice.Text = "[????]";
        }

        public void DisableChangeQuantity()
        {
            numaricQuantity.Enabled = false;
        }

        public void LoadItemInfo(int? ItemID)
        {
            _ItemID = ItemID;

            if (!_DoesItemExist())
                return;

            _FillItemData();
        }

        private void pbItemImage_Click(object sender, System.EventArgs e)
        {
            if (_ItemImagePath == null)
                return;

            frmShowItemImageWithZoom ShowItemImageWithZoom = new frmShowItemImageWithZoom(_ItemImagePath, _ItemName);
            ShowItemImageWithZoom.ShowDialog();
        }
    }
}
