namespace Hotel
{
    partial class frmTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucBookingAndReservationCardWithFilter1 = new Hotel.Bookings.UserControls.ucBookingAndReservationCardWithFilter();
            this.SuspendLayout();
            // 
            // ucBookingAndReservationCardWithFilter1
            // 
            this.ucBookingAndReservationCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ucBookingAndReservationCardWithFilter1.FilterEnabled = true;
            this.ucBookingAndReservationCardWithFilter1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucBookingAndReservationCardWithFilter1.Location = new System.Drawing.Point(23, 49);
            this.ucBookingAndReservationCardWithFilter1.Name = "ucBookingAndReservationCardWithFilter1";
            this.ucBookingAndReservationCardWithFilter1.Size = new System.Drawing.Size(862, 595);
            this.ucBookingAndReservationCardWithFilter1.TabIndex = 0;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 700);
            this.Controls.Add(this.ucBookingAndReservationCardWithFilter1);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.ResumeLayout(false);

        }

        #endregion

        private Bookings.UserControls.ucBookingAndReservationCardWithFilter ucBookingAndReservationCardWithFilter1;
    }
}