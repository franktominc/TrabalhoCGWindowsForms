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
            Parent.VRP.X = Convert.ToDouble(VRPx.Text);
            Parent.VRP.Y = Convert.ToDouble(VRPy.Text);
            Parent.VRP.Z = Convert.ToDouble(VRPz.Text);

            Parent.P.X = Convert.ToDouble(Px.Text);
            Parent.P.Y = Convert.ToDouble(Py.Text);
            Parent.P.Z = Convert.ToDouble(Pz.Text);

            Parent.alpha = Convert.ToInt32(alphaTF.Text);

            Parent.Y.X = Convert.ToDouble(YXTf.Text);
            Parent.Y.Y = Convert.ToDouble(YYTf.Text);
            Parent.Y.Z = Convert.ToDouble(YZTf.Text);

            Parent.L.X = Convert.ToDouble(LX.Text);
            Parent.L.Y = Convert.ToDouble(LY.Text);
            Parent.L.Z = Convert.ToDouble(LZ.Text);

            Parent.iL.X = Convert.ToDouble(ILR.Text);
            Parent.iL.Y = Convert.ToDouble(ILG.Text);
            Parent.iL.Z = Convert.ToDouble(ILB.Text);

            Parent.iLa.X = Convert.ToDouble(ILaR.Text);
            Parent.iLa.Y = Convert.ToDouble(ILaG.Text);
            Parent.iLa.Z = Convert.ToDouble(ILaB.Text);

            Parent.ka.X = Convert.ToDouble(KaR.Text);
            Parent.ka.Y = Convert.ToDouble(KaG.Text);
            Parent.ka.Z = Convert.ToDouble(KaB.Text);

            Parent.kd.X = Convert.ToDouble(KdR.Text);
            Parent.kd.Y = Convert.ToDouble(KdG.Text);
            Parent.kd.Z = Convert.ToDouble(KdB.Text);

            Parent.ks.X = Convert.ToDouble(KsR.Text);
            Parent.ks.Y = Convert.ToDouble(KsG.Text);
            Parent.ks.Z = Convert.ToDouble(KsB.Text);

            Parent.n = Convert.ToInt32(n.Text);

            Dispose(true);
            Parent.DrawSolids();

        }
    }
}
