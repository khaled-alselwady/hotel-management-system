using Hotel_Business;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Hotel.Dashboard
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();

            _CountElements();

            int AvailableRooms = clsRoom.GetAvailableRoomsCount();
            int BookedRooms = clsRoom.GetBookedRoomsCount();
            int UnderMaintenanceRooms = clsRoom.GetUnderMaintenanceRoomsCount();

            string[] arrCategoriesName = { "UnderMaintenance", "Booked", "Available" };
            int[] arrCategoriesCount =
            {
                UnderMaintenanceRooms,
                BookedRooms,
                AvailableRooms
            };
            DataPoint DataPointCategory;

            chartVehiclesStatus.Titles.Add("");
            chartVehiclesStatus.Series["s1"].IsValueShownAsLabel = true;

            for (byte i = 0; i < arrCategoriesName.Length; i++)
            {
                DataPointCategory = new DataPoint();
                DataPointCategory.SetValueXY(arrCategoriesName[i], arrCategoriesCount[i]);
                DataPointCategory.LegendText = arrCategoriesName[i];

                chartVehiclesStatus.Series["s1"].Points.Add(DataPointCategory);
            }

            //lblHiUsername.Text = $"Hi {clsGlobal.CurrentUser.Username}";
        }

        private void _CountElements()
        {
            lblNumberOfGuests.Text = clsGuest.Count().ToString();
            lblNumberOfUsers.Text = clsUser.Count().ToString();
            lblNumberOfRooms.Text = clsRoom.Count().ToString();
            lblNumberOfReservations.Text = clsReservation.Count().ToString();
            lblNumberOfBookings.Text = clsBooking.Count().ToString();
            lblNumberOfPayments.Text = clsPayment.Count().ToString();
        }

        private void btnShowSubMenu_Click(object sender, EventArgs e)
        {
            // this method will show the context menu by clicking on the left click instead of the right click

            // Get the location of the button on the screen
            Point location = btnShowSubMenu.PointToScreen(new Point(0, btnShowSubMenu.Height));

            // Show the context menu at the calculated location
            cmsEditProfile.Show(location);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not available yet!");
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not available yet!");
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not available yet!");
        }
    }
}
