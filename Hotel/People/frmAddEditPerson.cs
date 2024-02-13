using CarRental.GlobalClasses;
using Guna.UI2.WinForms;
using Hotel.GlobalClasses;
using Hotel.Properties;
using Hotel_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Hotel.People
{
    public partial class frmAddEditPerson : Form
    {
        public Action<int?> PersonIDBack;

        private enum _enMode { AddNew, Update };
        private _enMode _Mode = _enMode.AddNew;

        private int? _PersonID = null;
        private clsPerson _Person = null;

        public frmAddEditPerson()
        {
            InitializeComponent();

            _Mode = _enMode.AddNew;
        }

        public frmAddEditPerson(int? PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
            _Mode = _enMode.Update;
        }

        private void _FillCountryComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountriesName();

            foreach (DataRow Country in dtCountries.Rows)
            {
                cbCountry.Items.Add(Country["CountryName"].ToString());
            }
        }

        private void _ResetFields()
        {
            foreach (Control item in this.Controls)
            {

                if (item is Guna2TextBox txtGuna)
                    txtGuna.Clear();

                if (item is Guna2ComboBox comboGuna)
                    comboGuna.SelectedIndex = 0;
            }

            rbMale.Checked = true;
            pbGender.Image = Resources.gender_male;
            pbPersonImage.Image = Resources.default_male;
        }

        private void _ResetDefaultValues()
        {
            _FillCountryComboBox();

            if (_Mode == _enMode.AddNew)
            {
                lblTitle.Text = "Add New Person";
                _Person = new clsPerson();
                _ResetFields();
            }
            else
            {
                lblTitle.Text = "Update Person";
            }

            this.Text = lblTitle.Text;

            //set default image for the customer
            if (rbMale.Checked)
                pbPersonImage.Image = Resources.default_male;
            else
                pbPersonImage.Image = Resources.default_female;

            //hide/show the remove link in case there is no image for the customer
            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            //should not allow adding age more than 130 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-130);

            //this will set default country to Jordan
            cbCountry.SelectedIndex = cbCountry.FindString("Jordan");
        }

        private void _FillFieldsWithPersonInfo()
        {
            lblPersonID.Text = _Person.PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtEmail.Text = _Person.Email;
            txtNationalNo.Text = _Person.NationalNo;
            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            cbCountry.SelectedIndex = cbCountry.FindString(_Person.CountryInfo.CountryName);

            if (_Person.Gender == (byte)clsPerson.enGender.Male)
            {
                rbMale.Checked = true;
                pbPersonImage.Image = Resources.default_male;
            }

            else
            {
                rbFemale.Checked = true;
                pbPersonImage.Image = Resources.default_female;
            }
        }

        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show($"There is no person with ID = {_PersonID} !",
                  "Missing Person", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
                return;
            }

            _FillFieldsWithPersonInfo();

            //load person image in case it was set.
            if (_Person.ImagePath != null)
                pbPersonImage.ImageLocation = _Person.ImagePath;

            //hide/show the remove link in case there is no image for the person
            llRemoveImage.Visible = (_Person.ImagePath != null);
        }

        private void _ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((Guna2TextBox)sender).Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(((Guna2TextBox)sender), "This field is required!");
            }
            else
            {
                errorProvider1.SetError(((Guna2TextBox)sender), null);
            }
        }

        private bool _HandlePersonImage()
        {
            // this procedure will handle the person image,
            // it will take care of deleting the old image from the folder
            // in case the image changed, and it will rename the new image with guid and 
            // place it in the images folder.

            // _Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {

                if (_Person.ImagePath != null)
                {
                    // first we delete the old image from the folder in case there is any.
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException iox)
                    {
                        clsLogError.LogError("IO Exception", iox);
                        return false;
                    }
                    catch (Exception ex)
                    {
                        clsLogError.LogError("General Exception", ex);
                        return false;
                    }
                }

                if (pbPersonImage.ImageLocation != null)
                {
                    // then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        private void _FillPersonObjectWithFieldsData()
        {
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = string.IsNullOrWhiteSpace(txtThirdName.Text.Trim()) ? null : txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.Email = string.IsNullOrWhiteSpace(txtEmail.Text.Trim()) ? null : txtEmail.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.Address = string.IsNullOrWhiteSpace(txtAddress.Text.Trim()) ? null : txtAddress.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.NationalityCountryID = clsCountry.Find(cbCountry.Text).CountryID;
            _Person.Gender = (rbMale.Checked) ? clsPerson.enGender.Male : clsPerson.enGender.Female;
            _Person.DateOfBirth = dtpDateOfBirth.Value;

            if (pbPersonImage.ImageLocation != null)
                _Person.ImagePath = pbPersonImage.ImageLocation;
            else
                _Person.ImagePath = null;
        }

        private void _SavePerson()
        {
            _FillPersonObjectWithFieldsData();

            if (_Person.Save())
            {
                lblTitle.Text = "Update Person";
                this.Text = lblTitle.Text;
                lblPersonID.Text = _Person.PersonID.ToString();

                // change form mode to update
                _Mode = _enMode.Update;

                MessageBox.Show("Data Saved Successfully", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to the caller form
                PersonIDBack?.Invoke(_Person.PersonID);
            }
            else
            {
                MessageBox.Show("Data Saved Failed", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == _enMode.Update)
                _LoadData();

            txtAddress.BorderRadius = 17;
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }

            //validate email format
            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This field is required!");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNo, null);
            }

            // Make sure the national number is not used by another person
            if (txtNationalNo.Text.Trim().ToLower() != _Person.NationalNo.ToLower() &&
                clsPerson.DoesPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                txtNationalNo.Focus();
                errorProvider1.SetError(txtNationalNo, "National Number is used for another person!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNo, null);
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            pbGender.Image = Resources.gender_female;

            // change the default image to female in case there is no image set.
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.default_female;
        }

        private void lblFemale_Click(object sender, EventArgs e)
        {
            rbFemale.Checked = true;

            pbGender.Image = Resources.gender_female;

            // change the default image to female in case there is no image set.
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.default_female;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            pbGender.Image = Resources.gender_male;

            // change the default image to male in case there is no image set.
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.default_male;
        }

        private void lblMale_Click(object sender, EventArgs e)
        {
            rbMale.Checked = true;

            pbGender.Image = Resources.gender_male;

            // change the default image to male in case there is no image set.
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.default_male;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
                // ...
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.default_male;
            else
                pbPersonImage.Image = Resources.default_female;

            llRemoveImage.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandlePersonImage())
                return;

            _SavePerson();
        }

        private void frmAddEditPerson_Activated(object sender, EventArgs e)
        {
            txtFirstName.Focus();
        }
    }
}
