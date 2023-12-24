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
public int ItemTypeID { get; set; }
public string ItemName { get; set; }
public decimal ItemPrice { get; set; }
public string Description { get; set; }

public clsItem()
{
    this.ItemID = null;
    this.ItemTypeID = -1;
    this.ItemName = string.Empty;
    this.ItemPrice = -1M;
    this.Description = null;
    Mode = enMode.AddNew;
}

private clsItem(int? ItemID, int ItemTypeID, string ItemName, decimal ItemPrice, string Description)
{
    this.ItemID = ItemID;
    this.ItemTypeID = ItemTypeID;
    this.ItemName = ItemName;
    this.ItemPrice = ItemPrice;
    this.Description = Description;
    Mode = enMode.Update;
}

private bool _AddNewItem()
{
    this.ItemID = clsItemData.AddNewItem(this.ItemTypeID, this.ItemName, this.ItemPrice, this.Description);

    return (this.ItemID.HasValue);
}

private bool _UpdateItem()
{
return clsItemData.UpdateItem(this.ItemID, this.ItemTypeID, this.ItemName, this.ItemPrice, this.Description);
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
int ItemTypeID = -1;
string ItemName = string.Empty;
decimal ItemPrice = -1M;
string Description = null;

bool IsFound = clsItemData.GetItemInfoByID(ItemID, ref ItemTypeID, ref ItemName, ref ItemPrice, ref Description);

if (IsFound)
{
return new clsItem(ItemID, ItemTypeID, ItemName, ItemPrice, Description);
}
else
{
return null;
}
}

public static bool DeleteItem(int? ItemID)
{
return clsItemData.DeleteItem(ItemID);
}

public static bool DoesItemExist(int? ItemID)
{
return clsItemData.DoesItemExist(ItemID);
}

public static DataTable GetAllItems()
{
return clsItemData.GetAllItems();
}

}

}