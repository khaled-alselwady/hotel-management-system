using Hotel.People;
using Hotel_Business;
using System.Data;
using System.Windows.Forms;

namespace Hotel.Guests
{
    public partial class frmListGuests : Form
    {
        private DataTable _dtGuests;

        public frmListGuests()
        {
            InitializeComponent();
        }

        private void _FillCountryComboBox()
        {
            cbNationality.Items.Add("All");

            DataTable dtCountries = clsCountry.GetAllCountriesName();

            foreach (DataRow Country in dtCountries.Rows)
            {
                cbNationality.Items.Add(Country["CountryName"].ToString());
            }
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Guest ID":
                    return "GuestID";

                case "Person ID":
                    return "PersonID";

                case "National Number":
                    return "NationalNo";

                case "Name":
                    return "FullName";

                case "Gender":
                    return "Gender";

                case "Phone":
                    return "Phone";

                case "Email":
                    return "Email";

                case "Nationality":
                    return "CountryName";

                default:
                    return "None";
            }
        }

        private void _RefreshGuestList()
        {
            _dtGuests = clsGuest.GetAllGuests();
            dgvGuestsList.DataSource = _dtGuests;
            lblNumberOfRecords.Text = dgvGuestsList.Rows.Count.ToString();

            if (dgvGuestsList.Rows.Count > 0)
            {
                dgvGuestsList.Columns[0].HeaderText = "Guest ID";
                dgvGuestsList.Columns[0].Width = 125;

                dgvGuestsList.Columns[1].HeaderText = "Person ID";
                dgvGuestsList.Columns[1].Width = 190;

                dgvGuestsList.Columns[2].HeaderText = "National Number";
                dgvGuestsList.Columns[2].Width = 190;

                dgvGuestsList.Columns[3].HeaderText = "Name";
                dgvGuestsList.Columns[3].Width = 190;

                dgvGuestsList.Columns[4].HeaderText = "Gender";
                dgvGuestsList.Columns[4].Width = 100;

                dgvGuestsList.Columns[5].HeaderText = "Date Of Birth";
                dgvGuestsList.Columns[5].Width = 130;

                dgvGuestsList.Columns[6].HeaderText = "Nationality";
                dgvGuestsList.Columns[6].Width = 100;

                dgvGuestsList.Columns[7].HeaderText = "Phone";
                dgvGuestsList.Columns[7].Width = 110;

                dgvGuestsList.Columns[8].HeaderText = "Email";
                dgvGuestsList.Columns[8].Width = 160;
            }
        }

        private int _GetGuestIDFromDGV()
        {
            return (int)dgvGuestsList.CurrentRow.Cells["GuestID"].Value;
        }

        private void frmListGuests_Load(object sender, System.EventArgs e)
        {
            _RefreshGuestList();
            _FillCountryComboBox();
        }

        private void cbFilter_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") && (cbFilter.Text != "Gender") && (cbFilter.Text != "Nationality");

            cbNationality.Visible = (cbFilter.Text == "Nationality");

            cbGender.Visible = (cbFilter.Text == "Gender");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbNationality.Visible)
            {
                cbNationality.SelectedIndex = 0;
            }

            if (cbGender.Visible)
            {
                cbGender.SelectedIndex = 0;
            }
        }

        private void txtSearch_TextChanged(object sender, System.EventArgs e)
        {
            if (_dtGuests.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) ||
                cbFilter.Text == "None")
            {
                _dtGuests.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvGuestsList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Guest ID" || cbFilter.Text == "Person ID")
            {
                // search with numbers
                _dtGuests.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtGuests.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvGuestsList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Guest ID" || cbFilter.Text == "Person ID")
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbGender_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (_dtGuests.Rows.Count == 0)
            {
                return;
            }

            if (cbGender.Text == "All")
            {
                _dtGuests.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvGuestsList.Rows.Count.ToString();

                return;
            }

            _dtGuests.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "Gender", cbGender.Text);

            lblNumberOfRecords.Text = dgvGuestsList.Rows.Count.ToString();
        }

        private void cbNationality_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (_dtGuests.Rows.Count == 0)
            {
                return;
            }

            if (cbNationality.Text == "All")
            {
                _dtGuests.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvGuestsList.Rows.Count.ToString();

                return;
            }

            _dtGuests.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "CountryName", cbNationality.Text);

            lblNumberOfRecords.Text = dgvGuestsList.Rows.Count.ToString();
        }

        private void ShowGuestDetailsToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            frmShowPersonInfo ShowPersonInfo = new frmShowPersonInfo(_GetGuestIDFromDGV());
            ShowPersonInfo.ShowDialog();

            _RefreshGuestList();
        }

        private void EditGuestToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmAddEditPerson EditPerson = new frmAddEditPerson(_GetGuestIDFromDGV());
            EditPerson.ShowDialog();

            _RefreshGuestList();
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (dgvGuestsList.Rows.Count > 0);
        }

        private void dgvGuestsList_DoubleClick(object sender, System.EventArgs e)
        {
            frmShowPersonInfo ShowPersonInfo = new frmShowPersonInfo(_GetGuestIDFromDGV());
            ShowPersonInfo.ShowDialog();

            _RefreshGuestList();
        }
    }
}
