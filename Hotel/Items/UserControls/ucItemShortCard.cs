using Hotel.Properties;
using Hotel_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.Items.UserControls
{
    public partial class ucItemShortCard : UserControl
    {
        private string _ItemImagePath = null;
        public string ItemImagePath
        {
            get => _ItemImagePath;
            //set => _ItemImagePath = value;
        }

        public string _ItemName = "Item Name";
        public string ItemName
        {
            get => _ItemName;
            //set => _ItemName = value;
        }

        public float _ItemPrice = 0.00f;
        public float ItemPrice
        {
            get => _ItemPrice;
            //set => _ItemPrice = value;
        }

        private int? _ItemID = null;
        private clsItem _Item = null;

        public ucItemShortCard()
        {
            InitializeComponent();
        }

        private void _ShowItemDetails()
        {
            frmShowItemInfo ShowItemInfo = new frmShowItemInfo(_ItemID);
            ShowItemInfo.ShowDialog();

            // Refresh
            LoadItemInfo(_ItemID);
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

        private void ShowItemDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _ShowItemDetails();
        }

        private void ucItemShortCard_DoubleClick(object sender, EventArgs e)
        {
            _ShowItemDetails();
        }

        private void pbItemImage_Click(object sender, EventArgs e)
        {
            if (_Item.ItemImagePath == null)
                return;

            frmShowItemImageWithZoom ShowItemImageWithZoom = new frmShowItemImageWithZoom(_Item.ItemImagePath, _ItemName);
            ShowItemImageWithZoom.ShowDialog();
        }

        private void lblItemName_DoubleClick(object sender, EventArgs e)
        {
            _ShowItemDetails();
        }

        private void lblItemPrice_Click(object sender, EventArgs e)
        {
            _ShowItemDetails();
        }

        private void EditItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditItem EditItem = new frmAddEditItem(_ItemID);
            EditItem.ShowDialog();

            // Refresh
            LoadItemInfo(_ItemID);
        }
    }
}
