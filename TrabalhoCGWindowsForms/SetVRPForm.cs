using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoCGWindowsForms {
    public partial class SetVRPForm : Form {
        public SetVRPForm() {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            Parent.VRP.X = Convert.ToInt32(VRPx.Text);
            Parent.VRP.Y = Convert.ToInt32(VRPy.Text);
            Parent.VRP.Z = Convert.ToInt32(VRPz.Text);
            this.Hide();
            Parent.DrawSolids();
        }
    }
}
