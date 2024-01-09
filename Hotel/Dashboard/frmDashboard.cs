using Hotel.GlobalClasses;
using Hotel.Properties;
using Hotel.Users;
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
        private Form _frmLoginForm;
        private Form _frmMainMenu;

        public frmDashboard(Form frmLoginForm, Form frmMainMenu)
        {
            InitializeComponent();

            _CountElements();
            _PrintChart();
            _RefreshUserInfo();

            _frmLoginForm = frmLoginForm;
            _frmMainMenu = frmMainMenu;
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

        private void _PrintChart()
        {
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
        }

        private void _HandleUserImage()
        {
            if (clsGlobal.CurrentUser?.PersonInfo?.ImagePath != null)
            {
                pbUserImage.ImageLocation = clsGlobal.CurrentUser.PersonInfo?.ImagePath;
            }
            else
            {
                if (clsGlobal.CurrentUser.PersonInfo?.Gender == clsPerson.enGender.Male)
                    pbUserImage.Image = Resources.default_male;
                else
                    pbUserImage.Image = Resources.default_female;
            }
        }

        private void _RefreshUserInfo()
        {
            clsGlobal.CurrentUser = clsUser.FindBy(clsGlobal.CurrentUser?.UserID, clsUser.enFindBy.UserID);

            lblFullName.Text = clsGlobal.CurrentUser?.PersonInfo?.FullName;
            lblEmail.Text = clsGlobal.CurrentUser?.PersonInfo?.Email;
            lblHiUsername.Text = $"Hi {clsGlobal.CurrentUser?.Username}";

            _HandleUserImage();
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
            frmShowUserInfo ShowUserInfo = new frmShowUserInfo(clsGlobal.CurrentUser?.UserID);
            ShowUserInfo.ShowDialog();

            _RefreshUserInfo();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword ChangePassword = new frmChangePassword(clsGlobal.CurrentUser?.UserID);
            ChangePassword.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmMainMenu.Hide();
            _frmLoginForm.Show();
            this.Close();
        }
    }
}
