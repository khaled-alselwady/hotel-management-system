using Hotel_DataAccess;
using System;
using System.Data;

namespace Hotel_Business
{
    public class clsItemType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? ItemTypeID { get; set; }
        public string ItemTypeName { get; set; }

        public clsItemType()
        {
            this.ItemTypeID = null;
            this.ItemTypeName = string.Empty;
            Mode = enMode.AddNew;
        }

        private clsItemType(int? ItemTypeID, string ItemTypeName)
        {
            this.ItemTypeID = ItemTypeID;
            this.ItemTypeName = ItemTypeName;
            Mode = enMode.Update;
        }

        private bool _AddNewItemType()
        {
            this.ItemTypeID = clsItemTypeData.AddNewItemType(this.ItemTypeName);

            return (this.ItemTypeID.HasValue);
        }

        private bool _UpdateItemType()
        {
            return clsItemTypeData.UpdateItemType(this.ItemTypeID, this.ItemTypeName);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewItemType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateItemType();
            }

            return false;
        }

        public static clsItemType Find(int? ItemTypeID)
        {
            string ItemTypeName = string.Empty;

            bool IsFound = clsItemTypeData.GetItemTypeInfoByID(ItemTypeID, ref ItemTypeName);

            return IsFound ? new clsItemType(ItemTypeID, ItemTypeName) : null;
        }

        public static bool DeleteItemType(int? ItemTypeID)
        {
            return clsItemTypeData.DeleteItemType(ItemTypeID);
        }

        public static bool DoesItemTypeExist(int? ItemTypeID)
        {
            return clsItemTypeData.DoesItemTypeExist(ItemTypeID);
        }

        public static DataTable GetAllItemTypes()
        {
            return clsItemTypeData.GetAllItemTypes();
        }

    }

}