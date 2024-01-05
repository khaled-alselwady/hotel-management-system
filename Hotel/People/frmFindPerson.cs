using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.People
{
    public partial class frmFindPerson : Form
    {
        public frmFindPerson()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void frmFindPerson_Activated(object sender, EventArgs e)
        {
            ucPersonCardWithFilter1.FilterFocus();
        }
    }
}
