using Hotel_DataAccess;
using System;
using System.Data;
using System.Linq;

namespace Hotel_Business
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enFindBy
        {
            UserID,
            PersonID,
            Username,
            UsernameAndPassword
        };

        public int? UserID { get; set; }
        public int? PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public clsPerson PersonInfo { get; }

        public clsUser()
        {
            this.UserID = null;
            this.PersonID = null;
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.IsActive = false;

            Mode = enMode.AddNew;
        }

        private clsUser(int? UserID, int? PersonID, string Username,
            string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;

            this.PersonInfo = clsPerson.Find(PersonID);

            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.Username, this.Password,
                this.IsActive);

            return (this.UserID.HasValue);
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.Username,
                this.Password, this.IsActive);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }

        private static clsUser _FindByUserID(int? UserID)
        {
            int? PersonID = null;
            string Username = string.Empty;
            string Password = string.Empty;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUserID(UserID, ref PersonID,
                ref Username, ref Password, ref IsActive);

            return (IsFound) ? (new clsUser(UserID, PersonID, Username, Password, IsActive)) : null;
        }

        private static clsUser _FindByPersonID(int? PersonID)
        {
            int? UserID = null;
            string Username = string.Empty;
            string Password = string.Empty;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByPersonID(PersonID, ref UserID,
                ref Username, ref Password, ref IsActive);

            return (IsFound) ? (new clsUser(UserID, PersonID, Username, Password, IsActive)) : null;
        }

        private static clsUser _FindByUsername(string Username)
        {
            int? UserID = null;
            int? PersonID = null;
            string Password = string.Empty;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUsername(ref UserID, ref PersonID,
                Username, ref Password, ref IsActive);

            return (IsFound) ? (new clsUser(UserID, PersonID, Username, Password, IsActive)) : null;
        }

        private static clsUser _FindByUsernameAndPassword(string Username, string Password)
        {
            int? UserID = null;
            int? PersonID = null;
            bool IsActive = false;
            bool IsFound = clsUserData.GetUserInfoByUsernameAndPassword(ref UserID, ref PersonID, Username, Password, ref IsActive);

            return (IsFound) ? (new clsUser(UserID, PersonID, Username, Password, IsActive)) : null;
        }

        public static clsUser FindBy(object Data, enFindBy ItemToFindBy)
        {
            switch (ItemToFindBy)
            {
                case enFindBy.UserID:
                    return _FindByUserID((int?)Data ?? null);

                case enFindBy.PersonID:
                    return _FindByPersonID((int?)Data ?? null);

                case enFindBy.Username:
                    return _FindByUsername((string)Data ?? null);

                default:
                    return null;
            }
        }

        public static clsUser FindBy(object Data1, object Data2, enFindBy ItemToFindBy = enFindBy.UsernameAndPassword)
        {
            switch (ItemToFindBy)
            {
                case enFindBy.UsernameAndPassword:
                    return _FindByUsernameAndPassword((string)Data1 ?? null, (string)Data2 ?? null);

                default:
                    return null;
            }
        }

        public static bool DeleteUser(int? UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        private static bool _DoesUserExistByUserID(int? UserID)
        {
            return clsUserData.DoesUserExistByUserID(UserID);
        }

        private static bool _DoesUserExistByPersonID(int? PersonID)
        {
            return clsUserData.DoesUserExistByPersonID(PersonID);
        }

        private static bool _DoesUserExistByUsername(string Username)
        {
            return clsUserData.DoesUserExistByUsername(Username);
        }

        private static bool _DoesUserExistByUsernameAndPassword(string Username, string Password)
        {
            return clsUserData.DoesUserExistByUsernameAndPassword(Username, Password);
        }

        public static bool DoesUserExist(object Data, enFindBy ItemToFindBy)
        {
            switch (ItemToFindBy)
            {
                case enFindBy.UserID:
                    return _DoesUserExistByUserID((int?)Data ?? null);

                case enFindBy.PersonID:
                    return _DoesUserExistByPersonID((int?)Data ?? null);

                case enFindBy.Username:
                    return _DoesUserExistByUsername((string)Data ?? null);

                default:
                    return false;
            }
        }

        public static bool DoesUserExist(object Data1, object Data2, enFindBy ItemToFindBy = enFindBy.UsernameAndPassword)
        {
            switch (ItemToFindBy)
            {
                case enFindBy.UsernameAndPassword:
                    return _DoesUserExistByUsernameAndPassword((string)Data1 ?? null, (string)Data2 ?? null);

                default:
                    return false;
            }
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static int Count()
        {
            return clsUserData.GetUsersCount();
        }

        public bool ChangePassword(string NewPassword)
        {
            return ChangePassword(this.UserID, NewPassword);
        }

        public static bool ChangePassword(int? UserID, string NewPassword)
        {
            return clsUserData.ChangePassword(UserID, NewPassword);
        }
    }

}