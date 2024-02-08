using Hotel_DataAccess;
using System;
using System.Data;

namespace Hotel_Business
{
    public class clsItemType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public byte? ItemTypeID { get; set; }
        public string ItemTypeName { get; set; }

        public clsItemType()
        {
            this.ItemTypeID = null;
            this.ItemTypeName = string.Empty;
            Mode = enMode.AddNew;
        }

        private clsItemType(byte? ItemTypeID, string ItemTypeName)
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

        public static clsItemType Find(byte? ItemTypeID)
        {
            string ItemTypeName = string.Empty;

            bool IsFound = clsItemTypeData.GetItemTypeInfoByID(ItemTypeID, ref ItemTypeName);

            return IsFound ? new clsItemType(ItemTypeID, ItemTypeName) : null;
        }

        public static clsItemType Find(string ItemTypeName)
        {
            byte? ItemTypeID = null;

            bool IsFound = clsItemTypeData.GetItemTypeInfoByName(ItemTypeName, ref ItemTypeID);

            return IsFound ? new clsItemType(ItemTypeID, ItemTypeName) : null;
        }

        public static bool DeleteItemType(byte? ItemTypeID)
        {
            return clsItemTypeData.DeleteItemType(ItemTypeID);
        }

        public static bool DoesItemTypeExist(byte? ItemTypeID)
        {
            return clsItemTypeData.DoesItemTypeExist(ItemTypeID);
        }

        public static bool DoesItemTypeExist(string ItemTypeName)
        {
            return clsItemTypeData.DoesItemTypeExist(ItemTypeName);
        }

        public static DataTable GetAllItemTypes()
        {
            return clsItemTypeData.GetAllItemTypes();
        }

        public static DataTable GetAllItemTypesName()
        {
            return clsItemTypeData.GetAllItemTypesName();
        }

    }

}