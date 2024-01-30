using Hotel.People;
using Hotel_Business;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Hotel.GuestCompanions.UserControls
{
    public partial class ucShowAllGuestCompanionsForGuest : UserControl
    {
        private int? _GuestID = null;

        public ucShowAllGuestCompanionsForGuest()
        {
            InitializeComponent();
        }

        private void _RefreshGuestCompanionsList()
        {
            dgvGuestCompanionsList.DataSource = clsGuestCompanion.GetAllGuestCompanionsForGuest(_GuestID);
            lblNumberOfRecords.Text = dgvGuestCompanionsList.Rows.Count.ToString();

            if (dgvGuestCompanionsList.Rows.Count > 0)
            {
                dgvGuestCompanionsList.Columns[0].HeaderText = "Guest Companion ID";
                dgvGuestCompanionsList.Columns[0].Width = 125;

                dgvGuestCompanionsList.Columns[1].HeaderText = "Person ID";
                dgvGuestCompanionsList.Columns[1].Width = 120;

                dgvGuestCompanionsList.Columns[2].HeaderText = "National Number";
                dgvGuestCompanionsList.Columns[2].Width = 150;

                dgvGuestCompanionsList.Columns[3].HeaderText = "Name";
                dgvGuestCompanionsList.Columns[3].Width = 220;

                dgvGuestCompanionsList.Columns[4].HeaderText = "Gender";
                dgvGuestCompanionsList.Columns[4].Width = 100;

                dgvGuestCompanionsList.Columns[5].HeaderText = "Date Of Birth";
                dgvGuestCompanionsList.Columns[5].Width = 130;

                dgvGuestCompanionsList.Columns[6].HeaderText = "Nationality";
                dgvGuestCompanionsList.Columns[6].Width = 100;
            }

        }

        private int? _GetPersonIDFromDGV()
        {
            return (int?)dgvGuestCompanionsList.CurrentRow.Cells["PersonID"].Value;
        }

        public void LoadGuestCompanionsInfo(int? GuestID)
        {
            _GuestID = GuestID;

            _RefreshGuestCompanionsList();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (dgvGuestCompanionsList.Rows.Count > 0);
        }

        private void ShowGuestCompanionDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo ShowPersonInfo = new frmShowPersonInfo(_GetPersonIDFromDGV());
            ShowPersonInfo.ShowDialog();

            _RefreshGuestCompanionsList();
        }

        private void EditGuestCompanionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson EditPerson = new frmAddEditPerson(_GetPersonIDFromDGV());
            EditPerson.ShowDialog();

            _RefreshGuestCompanionsList();
        }

        private void dgvGuestCompanionsList_DoubleClick(object sender, EventArgs e)
        {
            frmShowPersonInfo ShowPersonInfo = new frmShowPersonInfo(_GetPersonIDFromDGV());
            ShowPersonInfo.ShowDialog();

            _RefreshGuestCompanionsList();
        }
    }
}

