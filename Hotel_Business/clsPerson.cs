using Hotel_DataAccess;
using System;
using System.Data;

namespace Hotel_Business
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enGender { Male = 0, Female = 1 }

        public int? PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public enGender Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public string FullName => (ThirdName != null) ?
            (FirstName + ' ' + SecondName + ' ' + ThirdName + ' ' + LastName) :
            (FirstName + ' ' + SecondName + ' ' + LastName);

        public string GenderText => (Gender == enGender.Male) ? "Male" : "Female";

        public clsCountry CountryInfo { get; }

        public bool IsUser => clsUser.DoesUserExist(this.PersonID, clsUser.enFindBy.PersonID);

        public clsPerson()
        {
            this.PersonID = null;
            this.NationalNo = string.Empty;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
            this.ThirdName = null;
            this.LastName = string.Empty;
            this.DateOfBirth = DateTime.Now;
            this.Gender = enGender.Male;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Email = null;
            this.NationalityCountryID = -1;
            this.ImagePath = null;

            Mode = enMode.AddNew;
        }

        private clsPerson(int? PersonID, string NationalNo, string FirstName,
            string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
            enGender Gender, string Address, string Phone, string Email, int? NationalityCountryID,
            string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;

            this.CountryInfo = clsCountry.Find(NationalityCountryID);

            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName,
                this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, (byte)this.Gender,
                this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

            return (this.PersonID.HasValue);
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName,
                this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, (byte)this.Gender,
                this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePerson();
            }

            return false;
        }

        public static clsPerson Find(int? PersonID)
        {
            string NationalNo = string.Empty;
            string FirstName = string.Empty;
            string SecondName = string.Empty;
            string ThirdName = null;
            string LastName = string.Empty;
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 0;
            string Address = string.Empty;
            string Phone = string.Empty;
            string Email = null;
            int? NationalityCountryID = -1;
            string ImagePath = null;

            bool IsFound = clsPersonData.GetPersonInfoByID(PersonID, ref NationalNo, ref FirstName,
                ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address,
                ref Phone, ref Email, ref NationalityCountryID, ref ImagePath);

            return IsFound
                ? new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                    DateOfBirth, (enGender)Gender, Address, Phone, Email, NationalityCountryID, ImagePath)
                : null;
        }

        public static clsPerson Find(string NationalNo)
        {
            int? PersonID = null;
            string FirstName = string.Empty;
            string SecondName = string.Empty;
            string ThirdName = null;
            string LastName = string.Empty;
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 0;
            string Address = string.Empty;
            string Phone = string.Empty;
            string Email = null;
            int? NationalityCountryID = -1;
            string ImagePath = null;

            bool IsFound = clsPersonData.GetPersonInfoByNationalNo(NationalNo,
                ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                 ref DateOfBirth, ref Gender, ref Address, ref Phone,
                ref Email, ref NationalityCountryID, ref ImagePath);

            return IsFound
                ? new clsPerson(PersonID, NationalNo, FirstName, SecondName,
                    ThirdName, LastName, DateOfBirth, (enGender)Gender, Address,
                     Phone, Email, NationalityCountryID, ImagePath)
                : null;
        }

        public static bool DeletePerson(int? PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }

        public static bool DoesPersonExist(int? PersonID)
        {
            return clsPersonData.DoesPersonExist(PersonID);
        }

        public static bool DoesPersonExist(string NationalNo)
        {
            return clsPersonData.DoesPersonExist(NationalNo);
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }
    }

}