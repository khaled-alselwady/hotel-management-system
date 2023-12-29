using Hotel_DataAccess;
using System;
using System.Data;

namespace Hotel_Business
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? UserID { get; set; }
        public int? PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsUser()
        {
            this.UserID = null;
            this.PersonID = null;
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.IsActive = false;
            Mode = enMode.AddNew;
        }

        private clsUser(int? UserID, int? PersonID, string Username, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;
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

        public static clsUser Find(int? UserID)
        {
            int? PersonID = null;
            string Username = string.Empty;
            string Password = string.Empty;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByID(UserID, ref PersonID, ref Username, ref Password, ref IsActive);

            if (IsFound)
            {
                return new clsUser(UserID, PersonID, Username, Password, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static clsUser Find(string Username)
        {
            int? UserID = null;
            int? PersonID = null;
            string Password = string.Empty;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUsername(ref UserID, ref PersonID, Username, ref Password, ref IsActive);

            if (IsFound)
            {

                return new clsUser(UserID, PersonID, Username, Password, IsActive);
            }

            else
            {

                return null;
            }

        }

        public static clsUser Find(string Username, string Password)
        {
            int? UserID = null;
            int? PersonID = null;
            bool IsActive = false;
            bool IsFound = clsUserData.GetUserInfoByUsernameAndPassword(ref UserID, ref PersonID, Username, Password, ref IsActive);
            if (IsFound)
            {
                return new clsUser(UserID, PersonID, Username, Password, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteUser(int? UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public static bool DoesUserExist(int? UserID)
        {
            return clsUserData.DoesUserExist(UserID);
        }

        public static bool DoesUserExist(string Username)
        {
            return clsUserData.DoesUserExist(Username);
        }

        public static bool DoesUserExist(string Username, string Password)
        {
            return clsUserData.DoesUserExist(Username, Password);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static int Count()
        {
            return clsUserData.GetUsersCount();
        }
    }

}