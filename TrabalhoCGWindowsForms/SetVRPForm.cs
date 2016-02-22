using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using TrabalhoCGWindowsForms.Model;

namespace TrabalhoCGWindowsForms {
    public partial class SetVRPForm : Form {
        public SetVRPForm() {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e) {

        }

        private void setButton_Click(object sender, EventArgs e) {
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

            Parent.xMax = Convert.ToDouble(xMax.Text);
            Parent.xMin = Convert.ToDouble(xMin.Text);
            Parent.yMax = Convert.ToDouble(yMax.Text);
            Parent.yMin = Convert.ToDouble(yMin.Text);
            
            Parent.L.X = Convert.ToDouble(LX.Text);
            Parent.L.Y = Convert.ToDouble(LY.Text);
            Parent.L.Z = Convert.ToDouble(LZ.Text);

            Parent.iL.X = Convert.ToDouble(ILR.Text);
            Parent.iL.Y = Convert.ToDouble(ILG.Text);
            Parent.iL.Z = Convert.ToDouble(ILB.Text);

            Parent.iLa.X = Convert.ToDouble(ILaR.Text);
            Parent.iLa.Y = Convert.ToDouble(ILaG.Text);
            Parent.iLa.Z = Convert.ToDouble(ILaB.Text);
            if (Parent.selectedGuy >= 0) {
                foreach (var solid in Parent.solidsList[Parent.selectedGuy]) {
                    solid.Ka = new Vector(Convert.ToDouble(KaR.Text),
                                          Convert.ToDouble(KaG.Text),
                                          Convert.ToDouble(KaB.Text));
                    solid.Kd = new Vector(Convert.ToDouble(KdR.Text),
                                          Convert.ToDouble(KdG.Text),
                                          Convert.ToDouble(KdB.Text));
                    solid.Ks = new Vector(Convert.ToDouble(KsR.Text),
                                          Convert.ToDouble(KsG.Text),
                                          Convert.ToDouble(KsB.Text));
                    solid.N = Convert.ToInt32(n.Text);

                }
            }
            
            Dispose(true);
            Parent.DrawSolids();
        }
    }
}
