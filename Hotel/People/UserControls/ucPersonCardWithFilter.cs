using Hotel_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.People.UserControls
{
    public partial class ucPersonCardWithFilter : UserControl
    {
        #region Declare Event
        public class PersonSelectedEventArgs : EventArgs
        {
            public int? PersonID { get; }
            public string NotionalNo { get; }

            public PersonSelectedEventArgs(int? personID, string notionalNo)
            {
                this.PersonID = personID;
                this.NotionalNo = notionalNo;
            }
        }

        public event EventHandler<PersonSelectedEventArgs> OnPersonSelected;

        public void RaiseOnPersonSelected(int? PersonID, string NotionalNo)
        {
            RaiseOnPersonSelected(new PersonSelectedEventArgs(PersonID, NotionalNo));
        }

        protected void RaiseOnPersonSelected(PersonSelectedEventArgs e)
        {
            OnPersonSelected?.Invoke(this, e);
        }
        #endregion

        private bool _ShowAddPersonButton = true;
        public bool ShowAddPersonButton
        {
            get => _ShowAddPersonButton;
            set => btnAddNewPerson.Visible = _ShowAddPersonButton = value;
        }

        private bool _FilterEnable = true;
        public bool FilterEnable
        {
            get => _FilterEnable;
            set => gbFilter.Enabled = _FilterEnable = value;
        }

        public int? PersonID => ucPersonCard1.PersonID;
        public clsPerson PersonInfo => ucPersonCard1.PersonInfo;

        public ucPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int? PersonID)
        {
            txtSearch.Text = PersonID.ToString();
            ucPersonCard1.LoadPersonInfo(PersonID);

            if (OnPersonSelected != null)
                RaiseOnPersonSelected(ucPersonCard1.PersonID, ucPersonCard1.PersonInfo.NationalNo);
        }

        public void LoadPersonInfo(string NationalNo)
        {
            txtSearch.Text = NationalNo;
            ucPersonCard1.LoadPersonInfo(NationalNo);

            if (OnPersonSelected != null)
                RaiseOnPersonSelected(ucPersonCard1.PersonID, ucPersonCard1.PersonInfo.NationalNo);
        }

        public void FilterFocus()
        {
            txtSearch.Focus();
        }

        public void Clear()
        {
            ucPersonCard1.Reset();
        }

        private void txtSearch_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSearch, "This field cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtSearch, null);
            }
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (cbFindBy.Text == "Person ID")
                LoadPersonInfo(int.Parse(txtSearch.Text.Trim()));
            else
                LoadPersonInfo(txtSearch.Text.Trim());
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                btnFindPerson.PerformClick();
            }

            // to make sure that the user can enter only numbers in case searching by Person ID
            if (cbFindBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ucPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSearch.Focus();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson AddPerson = new frmAddEditPerson();
            AddPerson.PersonIDBack += LoadPersonInfo;
            AddPerson.ShowDialog();
        }
    }
}
