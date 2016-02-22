using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabalhoCGWindowsForms.Model;

namespace TrabalhoCGWindowsForms {
    public partial class MainView: Form {
        public MainView() {
            InitializeComponent();
        }
        private void MainView_Load(object sender, EventArgs e) {

            solidsList = new List<List<Solid>>();   //Aloca a lista de solido
            perspectiveSolidList = new List<List<Solid>>();

            selectedGuy = -1;   //configura o solido selecionado para: nenhum
            selectedSolids = new List<int>();

            amIRotating = false;

            P = new Vector(30, 20, 50);
            VRP = new Vector(300, 500, 3000);
            Y = new Vector(0, 1, 0);
            VRPiso = new Vector(300, 300, 300);
            alpha = 110;

            L = new Vector(100, 10, 150);
            iL = new Vector(150, 100, 250);
            iLa = new Vector(20, 80, 50);

            xMin = yMin = 0;
            xMax = yMax = 315;

        }

        #region Click Events

        private void topView_Click(object sender, EventArgs e) {

            var action = GetAction();

            var me = (MouseEventArgs) e;
            var coordinates = me.Location;

            switch (action) {

                    #region Add Cube

                case 0:
                    AddCube(coordinates, 0);
                    break;

                    #endregion

                    #region Group Solids

                case 1:

                    if (solidsList.Count == 0) return;

                    selectedGuy = SelectCube(coordinates, 0);

                    if (selectedGuy == -1) {
                        selectedSolids = new List<int>();
                    }
                    else {
                        if (!selectedSolids.Contains(selectedGuy))
                            selectedSolids.Add(selectedGuy);
                    }
                    break;

                    #endregion

                    #region Rotate Cube

                case 2:
                    if (!amIRotating) {
                        amIRotating = true;
                        BeginInvoke(new Action(() => Rotation(0)));
                    }
                    else {
                        amIRotating = false;
                    }
                    break;

                    #endregion

                    #region Translate Cube

                case 3:
                    if (!amITranslating) {
                        amITranslating = true;
                        BeginInvoke(new Action(() => Translation(0)));
                    }
                    else {
                        amITranslating = false;
                    }
                    break;

                    #endregion

                    #region Select Cube

                default:
                    selectedSolids = new List<int>();

                    if (solidsList.Count != 0) {
                        selectedGuy = SelectCube(coordinates, 0);
                    }
                    break;

                    #endregion

            }
            DrawSolids();
        }

        private void leftView_Click(object sender, EventArgs e) {

            var action = GetAction();

            var me = (MouseEventArgs) e;
            var coordinates = me.Location;

            switch (action) {

                    #region Add Cube

                case 0:
                    AddCube(coordinates, 1);
                    break;

                    #endregion

                    #region Group Solids

                case 1:
                    if (solidsList.Count != 0) {
                        selectedGuy = SelectCube(coordinates, 1);
                        if (selectedGuy == -1) {
                            selectedSolids = new List<int>();
                        }
                        else {
                            if (!selectedSolids.Contains(selectedGuy))
                                selectedSolids.Add(selectedGuy);
                        }
                    }
                    break;

                    #endregion

                    #region Rotate Solid

                case 2:
                    if (!amIRotating) {
                        amIRotating = true;
                        BeginInvoke(new Action(()=>Rotation(2)));
                    }
                    else {
                        amIRotating = false;
                    }
                    break;

                    #endregion

                    #region Translate Solid

                case 3:
                    if (!amITranslating) {
                        amITranslating = true;
                        BeginInvoke(new Action(() => Translation(2)));
                    }
                    else {
                        amITranslating = false;
                    }
                    break;

                    #endregion

                    #region Select Solid

                default:
                    selectedSolids = new List<int>();

                    if (solidsList.Count != 0) {
                        selectedGuy = SelectCube(coordinates, 1);

                    }
                    break;

                    #endregion

            }

            DrawSolids();
        }

        private void frontView_Click(object sender, EventArgs e) {

            var action = GetAction();

            var me = (MouseEventArgs) e;
            var coordinates = me.Location;

            switch (action) {

                    #region Add Cube

                case 0:
                    AddCube(coordinates, 2);
                    break;

                    #endregion

                    #region Group Solids

                case 1:
                    if (solidsList.Count != 0) {

                        selectedGuy = SelectCube(coordinates, 2);
                        if (selectedGuy == -1) {
                            selectedSolids = new List<int>();
                        }
                        else {
                            if (!selectedSolids.Contains(selectedGuy))
                                selectedSolids.Add(selectedGuy);
                        }
                    }
                    break;

                    #endregion

                    #region Rotate Solids

                case 2:
                    if (!amIRotating) {
                        amIRotating = true;
                        BeginInvoke(new Action(() => Rotation(1)));
                    }
                    else {
                        amIRotating = false;
                    }
                    break;

                    #endregion

                    #region Translate Solids

                case 3:
                    if (!amITranslating) {
                        amITranslating = true;
                        BeginInvoke(new Action(() => Translation(1)));
                    }
                    else {
                        amITranslating = false;
                    }
                    break;

                    #endregion

                    #region Select Solid

                default:
                    selectedSolids = new List<int>();

                    if (solidsList.Count != 0) {
                        selectedGuy = SelectCube(coordinates, 2);
                    }
                    break;
                    
                    #endregion

            }

            DrawSolids();
        }

        #endregion

        #region Paint Events
        private void topView_Paint(object sender, PaintEventArgs e) {

            var myPen = new Pen(Color.Black, 1);
            e.Graphics.DrawLine(myPen, 10, 10, 10, 40);
            e.Graphics.DrawLine(myPen, 10, 10, 40, 10);

        }

        private void leftView_Paint(object sender, PaintEventArgs e) {
            var myPen = new Pen(Color.Black, 1);
            e.Graphics.DrawLine(myPen, 10, 10, 10, 40);
            e.Graphics.DrawLine(myPen, 10, 10, 40, 10);
        }

        private void frontView_Paint(object sender, PaintEventArgs e) {
            var myPen = new Pen(Color.Black, 1);
            e.Graphics.DrawLine(myPen, 10, 10, 10, 40);
            e.Graphics.DrawLine(myPen, 10, 10, 40, 10);
        }
        #endregion

        #region Button Actions

        private void ZScalePlus_Click(object sender, EventArgs e) {
            if (selectedGuy < 0)
                return;
            if (solidsList[selectedGuy].Count != 1) return;
            foreach (var solid in solidsList[selectedGuy]) {
                solid.ZScale(1.1);
            }
            DrawSolids();
        }

        private void ZScaleMinus_Click(object sender, EventArgs e) {
            if (selectedGuy < 0)
                return;
            if (solidsList[selectedGuy].Count != 1) return;
            foreach (var solid in solidsList[selectedGuy]) {
                solid.ZScale(0.9);
            }
            DrawSolids();
        }

        private void HideFacesBox_Click(object sender, EventArgs e) {
            DrawSolids();
        }

        private void groupBt_Click(object sender, EventArgs e) {

            if (selectedSolids.Count >= 1) {

                selectedSolids.Sort((a, b) => -1*a.CompareTo(b));

                var k = selectedSolids[selectedSolids.Count - 1];

                for (var i = 0; i < selectedSolids.Count - 1; i++) {
                    for (var j = 0; j < solidsList[selectedSolids[i]].Count; j++) {

                        solidsList[k].Add(solidsList[selectedSolids[i]][j]);
                    }
                    solidsList.RemoveAt(selectedSolids[i]);
                }
                selectedSolids = new List<int>();
            }
            selectedGuy = -1;
            DrawSolids();
        }

        private void UngroupSolidsBt_Click(object sender, EventArgs e) {
            var k = selectedGuy;
            if (selectedGuy == -1) return;
            for (var i = 1; i < solidsList[k].Count; i++) {
                var l = new List<Solid> {solidsList[k][i]};
                solidsList.Add(l);
                solidsList[k].RemoveAt(i);
                i--;
            }
        }

        private void removeSolidBt_Click(object sender, EventArgs e) {
            if (selectedGuy == -1) return;
            solidsList.RemoveAt(selectedGuy);
            selectedGuy = -1;
            DrawSolids();
        }

        private void removeAllButton_Click(object sender, EventArgs e) {
            solidsList = new List<List<Solid>>();
            perspectiveSolidList = new List<List<Solid>>();
            DrawSolids();
        }

        private void SelectAllSolidsBt_Click(object sender, EventArgs e) {
            var k = Enumerable.Range(0, solidsList.Count);
            foreach (var i in k) {
                selectedSolids.Add(i);
            }
            DrawSolids();
        }

        private void addCubeBox_Click(object sender, EventArgs e) {
            groupSolidsCheckBox.Checked = false;
        }

        private void groupSolidsCheckBox_Click(object sender, EventArgs e) {
            addCubeBox.Checked = false;
        }

        private void isometricCheckBox_Click(object sender, EventArgs e) {
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            DrawSolids();
        }

        private void flatBox_Click(object sender, EventArgs e) {
            
        }

        private void flatBox_CheckedChanged(object sender, EventArgs e) {
            DrawSolids();
        }

        #endregion

        #region Menu Actions

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            var saveFileDialog1 = new SaveFileDialog {Title = "Save to File"};
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName == "") return;
            // Saves the Image via a FileStream created by the OpenFile method.
            var fs =
                (FileStream) saveFileDialog1.OpenFile();
            // Saves the Image in the appropriate ImageFormat based upon the
            // File type selected in the dialog box.
            // NOTE that the FilterIndex property is one-based.
            var bin = new BinaryFormatter();
            bin.Serialize(fs, solidsList);

            fs.Close();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) {
            var openFileDialog = new OpenFileDialog {Title = "Open File"};
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName == "") return;
            // Saves the Image via a FileStream created by the OpenFile method.
            var fs =
                (FileStream) openFileDialog.OpenFile();
            // Saves the Image in the appropriate ImageFormat based upon the
            // File type selected in the dialog box.
            // NOTE that the FilterIndex property is one-based.
            var bin = new BinaryFormatter();
            solidsList = (List<List<Solid>>) bin.Deserialize(fs);
            fs.Close();
            DrawSolids();
        }

        private void setPropertiesMenuItem_Click(object sender, EventArgs e) {
            var myForm = new SetVRPForm {
                VRPx = {Text = VRP.X.ToString()},
                VRPy = {Text = VRP.Y.ToString()},
                VRPz = {Text = VRP.Z.ToString()},
                Px = {Text = P.X.ToString()},
                Py = {Text = P.Y.ToString()},
                Pz = {Text = P.Z.ToString()},
                YXTf = {Text = Y.X.ToString()},
                YYTf = {Text = Y.Y.ToString()},
                YZTf = {Text = Y.Z.ToString()},
                alphaTF = {Text = alpha.ToString()},
                xMax = {Text = xMax.ToString()},
                xMin = {Text = xMin.ToString()},
                yMax = {Text = yMax.ToString()},
                yMin=  {Text = yMin.ToString()},
                ILaR = {Text = iLa.X.ToString()},
                ILaG = {Text = iLa.Y.ToString()},
                ILaB = {Text = iLa.Z.ToString()},
                ILR = {Text = iL.X.ToString()},
                ILG = {Text = iL.Y.ToString()},
                ILB = {Text = iL.Z.ToString()},
                LX = {Text = L.X.ToString()},
                LY = {Text = L.Y.ToString()},
                LZ = {Text = L.Z.ToString()},
                Parent = this
            };

            if (selectedGuy >= 0) {
                myForm.KaR.Text = solidsList[selectedGuy][0].Ka.X.ToString();
                myForm.KaG.Text = solidsList[selectedGuy][0].Ka.Y.ToString();
                myForm.KaB.Text = solidsList[selectedGuy][0].Ka.Z.ToString();
                myForm.KdR.Text = solidsList[selectedGuy][0].Kd.X.ToString();
                myForm.KdG.Text = solidsList[selectedGuy][0].Kd.Y.ToString();
                myForm.KdB.Text = solidsList[selectedGuy][0].Kd.Z.ToString();
                myForm.KsR.Text = solidsList[selectedGuy][0].Ks.X.ToString();
                myForm.KsG.Text = solidsList[selectedGuy][0].Ks.Y.ToString();
                myForm.KsB.Text = solidsList[selectedGuy][0].Ks.Z.ToString();
                myForm.n.Text = solidsList[selectedGuy][0].N.ToString();
            }
            
            myForm.Show();
        }

        #endregion

        private int GetAction() {
            var action = int.MaxValue;

            if (addCubeBox.Checked) action = 0;
            else if (groupSolidsCheckBox.Checked) action = 1;
            else if (rotateCubeCheckbox.Checked) action = 2;
            else if (translateCubeCheckbox.Checked) action = 3;

            return action;
        }

    }
}
