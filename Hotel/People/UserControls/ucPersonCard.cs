using Hotel.GlobalClasses;
using Hotel.Properties;
using Hotel_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.People.UserControls
{
    public partial class ucPersonCard : UserControl
    {
        private int? _PersonID = null;
        private clsPerson _Person = null;

        public int? PersonID => _PersonID;
        public clsPerson PersonInfo => _Person;

        public ucPersonCard()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            if (_Person.Gender == clsPerson.enGender.Male)
                pbPersonImage.Image = Resources.default_male;
            else
                pbPersonImage.Image = Resources.default_female;


            if (_Person.ImagePath != null)
                if (File.Exists(_Person.ImagePath))
                    pbPersonImage.ImageLocation = _Person.ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " +
                        _Person.ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _FillPersonData()
        {
            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            lblFullName.Text = _Person.FullName;
            lblGendor.Text = _Person.GenderText;
            lblEmail.Text = _Person.Email ?? "None";
            lblPhone.Text = _Person.Phone;
            lblDateOfBirth.Text = clsFormat.DateToShort(_Person.DateOfBirth);
            lblCountry.Text = _Person.CountryInfo.CountryName;
            lblAddress.Text = _Person.Address;

            pbGendor.Image = (_Person.Gender == clsPerson.enGender.Male) ?
                              Resources.gender_male :
                              Resources.gender_female;

            _LoadPersonImage();

            llEditPersonInfo.Enabled = true;
        }

        public void Reset()
        {
            _PersonID = null;
            _Person = null;

            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblFullName.Text = "[????]";
            pbGendor.Image = Resources.gender_male;
            lblGendor.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbPersonImage.Image = Resources.default_male;

            llEditPersonInfo.Enabled = false;
        }

        public void LoadPersonInfo(int? PersonID)
        {
            _PersonID = PersonID;

            if (!_PersonID.HasValue)
            {
                MessageBox.Show("There is no person!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show($"There is no person with ID = {_PersonID} !",
                    "Missing Person", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillPersonData();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            if (string.IsNullOrWhiteSpace(NationalNo))
            {
                MessageBox.Show("There is no person!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _Person = clsPerson.Find(NationalNo);

            if (_Person == null)
            {
                MessageBox.Show($"There is no person with National No \"{NationalNo}\" !",
                    "Missing Person", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillPersonData();
        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson EditPerson = new frmAddEditPerson(_PersonID);
            EditPerson.PersonIDBack += LoadPersonInfo;
            EditPerson.ShowDialog();
        }
    }
}
