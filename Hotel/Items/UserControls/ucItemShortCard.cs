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
        #region Declare Event
        public class UpdateItemEventArgs : EventArgs
        {
            public int? ItemID { get; }

            public UpdateItemEventArgs(int? ItemID)
            {
                this.ItemID = ItemID;
            }
        }

        public event EventHandler<UpdateItemEventArgs> OnItemUpdated;

        public void RaiseOnItemUpdated(int? ItemID)
        {
            RaiseOnItemUpdated(new UpdateItemEventArgs(ItemID));
        }

        protected void RaiseOnItemUpdated(UpdateItemEventArgs e)
        {
            OnItemUpdated?.Invoke(this, e);
        }
        #endregion

        private bool _ShowMassageNotFoundImage = true;
        private string _ItemImagePath = null;
        public string ItemImagePath
        {
            get => _ItemImagePath;
            set
            {
                _ItemImagePath = value;
                _ShowMassageNotFoundImage = false;
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

        public int? ItemID
        {
            get => _ItemID;
            set => _ItemID = value;
        }

        private int? _ItemID = null;
        private clsItem _Item = null;

        public ucItemShortCard()
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

        private void _ShowItemDetails()
        {
            frmShowItemInfo ShowItemInfo = new frmShowItemInfo(_ItemID);
            ShowItemInfo.ShowDialog();

            // Refresh
            _ShowMassageNotFoundImage = false;
            LoadItemInfo(_ItemID);

            if (OnItemUpdated != null)
                RaiseOnItemUpdated(_ItemID);
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
                    if (_ShowMassageNotFoundImage)
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
            _ItemImagePath = _Item.ItemImagePath;

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

            _ShowMassageNotFoundImage = true;
        }

        public void LoadItemInfo(int? ItemID)
        {
            _ItemID = ItemID;

            if (!_DoesItemExist())
                return;

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
            if (_ItemImagePath == null)
                return;

            frmShowItemImageWithZoom ShowItemImageWithZoom = new frmShowItemImageWithZoom(_ItemImagePath, _ItemName);
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
            _ShowMassageNotFoundImage = false;
            LoadItemInfo(_ItemID);

            if (OnItemUpdated != null)
                RaiseOnItemUpdated(_ItemID);
        }

        private void lblItemPrice_DoubleClick(object sender, EventArgs e)
        {
            _ShowItemDetails();
        }
    }
}
