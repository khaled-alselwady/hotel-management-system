using Hotel.Properties;
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

namespace Hotel.Users.UserControls
{
    public partial class ucUserCard : UserControl
    {
        private int? _UserID = null;
        private clsUser _User = null;

        public int? UserID => _UserID;
        public clsUser UserInfo => _User;

        public int? PersonID => ucPersonCard1.PersonID;
        public clsPerson PersonInfo => ucPersonCard1.PersonInfo;

        public ucUserCard()
        {
            InitializeComponent();
        }

        private void _FillUserInfo()
        {
            ucPersonCard1.LoadPersonInfo(_User.PersonID);

            lblUserID.Text = _User.UserID.ToString();
            lblUsername.Text = _User.Username;
            lblIsActive.Text = (_User.IsActive) ? "Yes" : "No";
            pbIsActive.Image = (_User.IsActive) ? Resources.active_user : Resources.inactive_user;
        }

        public void Reset()
        {
            _UserID = null;
            _User = null;

            ucPersonCard1.Reset();

            lblUserID.Text = "[????]";
            lblUsername.Text = "[????]";
            lblIsActive.Text = "[????]";

            pbIsActive.Image = Resources.question_mark;
        }

        public void LoadUserInfo(int? UserID)
        {
            _UserID = UserID;

            if (!_UserID.HasValue)
            {
                MessageBox.Show("There is no user!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _User = clsUser.FindBy(_UserID, clsUser.enFindBy.UserID);

            if (_User == null)
            {
                MessageBox.Show($"There is no user with ID = {_UserID} !",
                    "Missing User", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillUserInfo();
        }
    }
}
