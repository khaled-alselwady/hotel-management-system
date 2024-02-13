using Hotel_DataAccess;
using System;
using System.Data;

namespace Hotel_Business
{
    public class clsItem
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? ItemID { get; set; }
        public byte? ItemTypeID { get; set; }
        public string ItemName { get; set; }
        public float ItemPrice { get; set; }
        public string Description { get; set; }
        public string ItemImagePath { get; set; }

        public clsItemType ItemTypeInfo { get; }

        public clsItem()
        {
            this.ItemID = null;
            this.ItemTypeID = null;
            this.ItemName = string.Empty;
            this.ItemPrice = -1f;
            this.Description = null;
            this.ItemImagePath = null;

            Mode = enMode.AddNew;
        }

        private clsItem(int? ItemID, byte? ItemTypeID, string ItemName,
            float ItemPrice, string Description, string ItemImagePath)
        {
            this.ItemID = ItemID;
            this.ItemTypeID = ItemTypeID;
            this.ItemName = ItemName;
            this.ItemPrice = ItemPrice;
            this.Description = Description;
            this.ItemImagePath = ItemImagePath;

            this.ItemTypeInfo = clsItemType.Find(ItemTypeID);

            Mode = enMode.Update;
        }

        private bool _AddNewItem()
        {
            this.ItemID = clsItemData.AddNewItem(this.ItemTypeID, this.ItemName, this.ItemPrice, this.Description, this.ItemImagePath);

            return (this.ItemID.HasValue);
        }

        private bool _UpdateItem()
        {
            return clsItemData.UpdateItem(this.ItemID, this.ItemTypeID, this.ItemName, this.ItemPrice, this.Description, this.ItemImagePath);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewItem())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateItem();
            }

            return false;
        }

        public static clsItem Find(int? ItemID)
        {
            byte? ItemTypeID = null;
            string ItemName = string.Empty;
            float ItemPrice = -1f;
            string Description = null;
            string ItemImagePath = null;

            bool IsFound = clsItemData.GetItemInfoByID(ItemID, ref ItemTypeID,
                ref ItemName, ref ItemPrice, ref Description, ref ItemImagePath);

            return (IsFound) ? (new clsItem(ItemID, ItemTypeID, ItemName,
                ItemPrice, Description, ItemImagePath)) : null;
        }

        public static bool DeleteItem(int? ItemID)
        {
            return clsItemData.DeleteItem(ItemID);
        }

        public static bool DoesItemExist(int? ItemID)
        {
            return clsItemData.DoesItemExist(ItemID);
        }

        public static bool DoesItemExist(string ItemName)
        {
            return clsItemData.DoesItemExist(ItemName);
        }

        public static DataTable GetAllItems()
        {
            return clsItemData.GetAllItems();
        }

        public static DataTable GetAllItemsWithImagePath()
        {
            return clsItemData.GetAllItemsWithImagePath();
        }

    }


}