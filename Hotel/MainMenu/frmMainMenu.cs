using Guna.UI2.WinForms;
using Hotel.Dashboard;
using Hotel.Guests;
using Hotel_Business;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.MainMenu
{
    public partial class frmMainMenu : Form
    {
        private Guna2Button _CurrentButton;

        private Form _ActiveForm;

        private Form _frmLoginForm;

        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void _ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (_CurrentButton != (Guna2Button)btnSender)
                {
                    _DisableMenuButton();                    
                    _CurrentButton = (Guna2Button)btnSender;
                    _CurrentButton.BackColor = Color.White;             
                    _CurrentButton.ForeColor = Color.FromArgb(53, 41, 123);
                    _CurrentButton.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void _DisableMenuButton()
        {
            Guna2Button GunaButton = new Guna2Button();

            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Guna2Button))
                {
                    GunaButton = (Guna2Button)previousBtn;

                    previousBtn.BackColor = Color.FromArgb(53, 41, 123);
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private async void _OpenChildFormAsync(Form childForm, object btnSender)
        {
            await Task.Delay(100);

            if (_ActiveForm != null)
                _ActiveForm.Close();

            _ActivateButton(btnSender);
            _ActiveForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            if (childForm.Tag != null)
            {
                lblTitle.Text = childForm.Tag.ToString();
            }
            else
            {
                lblTitle.Text = childForm.Text;
            }
        }

        private void _MoveImageSlide(object sender)
        {
            Guna2Button Button1 = (Guna2Button)sender;

            pbImgaeSlide.Location = new Point(Button1.Location.X + 184, Button1.Location.Y - 20);
            pbImgaeSlide.SendToBack();
        }

        private void btn_CheckedChanged(object sender, EventArgs e)
        {
            _MoveImageSlide(sender);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            _OpenChildFormAsync(new frmDashboard(), sender);
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            _OpenChildFormAsync(new Form(), sender);
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            _OpenChildFormAsync(new Form(), sender);
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            _OpenChildFormAsync(new Form(), sender);
        }

        private void btnRoomTypes_Click(object sender, EventArgs e)
        {
            _OpenChildFormAsync(new Form(), sender);
        }

        private void btnRoomServices_Click(object sender, EventArgs e)
        {
            _OpenChildFormAsync(new Form(), sender);
        }

        private void btnDiningMenu_Click(object sender, EventArgs e)
        {
            _OpenChildFormAsync(new Form(), sender);
        }

        private void btnGuestOrders_Click(object sender, EventArgs e)
        {
            _OpenChildFormAsync(new Form(), sender);
        }

        private void btnGuests_Click(object sender, EventArgs e)
        {
            _OpenChildFormAsync(new frmListGuests(), sender);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            _OpenChildFormAsync(new Form(), sender);
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            _OpenChildFormAsync(new Form(), sender);
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            btnDashboard.PerformClick();
        }
    }
}
