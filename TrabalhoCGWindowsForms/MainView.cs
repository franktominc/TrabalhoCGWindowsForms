using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using TrabalhoCGWindowsForms.Model;
using TrabalhoCGWindowsForms.Utils;

namespace TrabalhoCGWindowsForms {
    public partial class MainView : Form {
        public MainView() {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {
            solidsList = new List<List<Solid>>();   //Cria a lista de solido
            selectedGuy = -1;   //configura o solido selecionado para: nenhum
            selectedSolids = new List<int>();
            amIRotating = false;
            P = new Vector(30, 20, 50);
            VRP = new Vector(300, 500, 3000);
            VRPiso = new Vector(100,100,100);
            alpha = 50;

        }

        private void topView_Click(object sender, EventArgs e) {
            if (addCubeBox.Checked) {
                var me = (MouseEventArgs)e;
                var coordinates = me.Location;
                AddCube(coordinates, 0);

            } else if (groupSolidsCheckBox.Checked) {
                if (solidsList.Count == 0) return;
                var me = (MouseEventArgs)e;
                var coordinates = me.Location;
                selectedGuy = SelectCube(coordinates, 0);
                if (selectedGuy == -1) {
                    selectedSolids = new List<int>();
                } else {
                    if (!selectedSolids.Contains(selectedGuy))
                        selectedSolids.Add(selectedGuy);
                }

                DrawSolids();
            } else if (rotateCubeCheckbox.Checked) {
                if (!amIRotating) {
                    amIRotating = true;
                    BeginInvoke(new Action(() => TopViewRotation()));
                } else {
                    amIRotating = false;
                }
            } else if (translateCubeCheckbox.Checked) {
                if (!amITranlating) {
                    amITranlating = true;
                    BeginInvoke(new Action(() => TopViewTranslation()));
                } else {
                    amITranlating = false;
                }
            } else {
                selectedSolids = new List<int>();
                var me = (MouseEventArgs)e;
                var coordinates = me.Location;
                if (solidsList.Count != 0) {
                    selectedGuy = SelectCube(coordinates, 0);
                    DrawSolids();
                }
                view = 0;
            }

        }

        private void topView_Paint(object sender, PaintEventArgs e) {

            var myPen = new Pen(Color.Black, 1);
            e.Graphics.DrawLine(myPen, 10, 10, 10, 40);
            e.Graphics.DrawLine(myPen, 10, 10, 40, 10);
            /*var auxz = new Point[3];
            auxz[0] = new Point(0, 0);
            auxz[1] = new Point(0, 50);
            auxz[2] = new Point(50, 50);
            e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(80, 0, 0)), auxz);
            //Console.WriteLine("Ue");
            */
        }

        private void leftView_Click(object sender, EventArgs e) {
            if (addCubeBox.Checked) {
                var me = (MouseEventArgs)e;
                var coordinates = me.Location;
                AddCube(coordinates, 1);

            } else if (groupSolidsCheckBox.Checked) {
                if (solidsList.Count != 0) {
                    var me = (MouseEventArgs)e;
                    var coordinates = me.Location;
                    selectedGuy = SelectCube(coordinates, 1);
                    if (selectedGuy == -1) {
                        selectedSolids = new List<int>();
                    } else {
                        if (!selectedSolids.Contains(selectedGuy))
                            selectedSolids.Add(selectedGuy);
                    }

                    DrawSolids();
                }
            } else if (rotateCubeCheckbox.Checked) {
                if (!amIRotating) {
                    amIRotating = true;
                    BeginInvoke(new Action(() => LeftViewRotation()));
                } else {
                    amIRotating = false;
                }
            } else if (translateCubeCheckbox.Checked) {
                if (!amITranlating) {
                    amITranlating = true;
                    BeginInvoke(new Action(() => LeftViewTranslation()));
                } else {
                    amITranlating = false;
                }
            } else {
                selectedSolids = new List<int>();
                var me = (MouseEventArgs)e;
                var coordinates = me.Location;
                if (solidsList.Count != 0) {
                    selectedGuy = SelectCube(coordinates, 1);
                    DrawSolids();
                }
                view = 1;
            }
        }

        private void leftView_Paint(object sender, PaintEventArgs e) {
            var myPen = new Pen(Color.Black, 1);
            e.Graphics.DrawLine(myPen, 10, 10, 10, 40);
            e.Graphics.DrawLine(myPen, 10, 10, 40, 10);
        }

        private void frontView_Click(object sender, EventArgs e) {
            if (addCubeBox.Checked) {
                var me = (MouseEventArgs)e;
                var coordinates = me.Location;
                AddCube(coordinates, 2);

            } else if (groupSolidsCheckBox.Checked) {
                if (solidsList.Count != 0) {
                    var me = (MouseEventArgs)e;
                    var coordinates = me.Location;
                    selectedGuy = SelectCube(coordinates, 2);
                    if (selectedGuy == -1) {
                        selectedSolids = new List<int>();
                    } else {
                        if (!selectedSolids.Contains(selectedGuy))
                            selectedSolids.Add(selectedGuy);
                    }

                    DrawSolids();
                }
            } else if (rotateCubeCheckbox.Checked) {
                if (!amIRotating) {
                    amIRotating = true;
                    BeginInvoke(new Action(() => FrontViewRotation()));
                } else {
                    amIRotating = false;
                }
            } else if (translateCubeCheckbox.Checked) {
                if (!amITranlating) {
                    amITranlating = true;
                    BeginInvoke(new Action(() => FrontViewTranslation()));
                } else {
                    amITranlating = false;
                }
            } else {
                selectedSolids = new List<int>();
                var me = (MouseEventArgs)e;
                var coordinates = me.Location;
                if (solidsList.Count != 0) {
                    selectedGuy = SelectCube(coordinates, 2);
                    DrawSolids();
                }
                view = 2;
            }
        }

        private void frontView_Paint(object sender, PaintEventArgs e) {
            var myPen = new Pen(Color.Black, 1);
            e.Graphics.DrawLine(myPen, 10, 10, 10, 40);
            e.Graphics.DrawLine(myPen, 10, 10, 40, 10);
        }

        private void button2_Click(object sender, EventArgs e) {
            if (selectedGuy < 0)
                return;
            if (solidsList[selectedGuy].Count == 1) {
                foreach (var solid in solidsList[selectedGuy]) {
                    solid.ZScale(1.1);
                }
                DrawSolids();
            }

        }

        private void button3_Click(object sender, EventArgs e) {
            if (selectedGuy < 0)
                return;
            if (solidsList[selectedGuy].Count == 1) {
                foreach (var solid in solidsList[selectedGuy]) {
                    solid.ZScale(0.9);
                }
                DrawSolids();
            }
        }

        private void checkBox2_Click(object sender, EventArgs e) {
            DrawSolids();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save to File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "") {
                // Saves the Image via a FileStream created by the OpenFile method.
                FileStream fs =
                   (FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(fs, solidsList);

                fs.Close();
            }


        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open File";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "") {
                // Saves the Image via a FileStream created by the OpenFile method.
                FileStream fs =
                   (FileStream)openFileDialog.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                BinaryFormatter bin = new BinaryFormatter();
                solidsList = (List<List<Solid>>)bin.Deserialize(fs);
                fs.Close();
                DrawSolids();
            }
        }

        private void groupBt_Click(object sender, EventArgs e) {
            if (selectedSolids.Count >= 1) {
                selectedSolids.Sort((a, b) => -1 * a.CompareTo(b));
                var k = selectedSolids[selectedSolids.Count - 1];
                for (int i = 0; i < selectedSolids.Count - 1; i++) {
                    for (int j = 0; j < solidsList[selectedSolids[i]].Count; j++) {

                        solidsList[k].Add(solidsList[selectedSolids[i]][j]);
                    }
                    solidsList.RemoveAt(selectedSolids[i]);
                }
                selectedSolids = new List<int>();
            }
            selectedGuy = -1;
            DrawSolids();
        }

        private void button1_Click(object sender, EventArgs e) {
            var k = selectedGuy;
            if (selectedGuy != -1) {
                for (int i = 1; i < solidsList[k].Count; i++) {
                    var l = new List<Solid> { solidsList[k][i] };
                    solidsList.Add(l);
                    solidsList[k].RemoveAt(i);
                    i--;
                }
            }
        }

        private void removeView_Click(object sender, EventArgs e) {
            if (selectedGuy != -1) {
                solidsList.RemoveAt(selectedGuy);
                selectedGuy = -1;
                DrawSolids();

            }
        }

        private void removeAllButton_Click(object sender, EventArgs e) {
            solidsList = new List<List<Solid>>();
            DrawSolids();
        }

        private void addCubeBox_Click(object sender, EventArgs e) {
            groupSolidsCheckBox.Checked = false;
        }

        private void groupSolidsCheckBox_Click(object sender, EventArgs e) {
            addCubeBox.Checked = false;
        }

        private void button2_Click_1(object sender, EventArgs e) {
            var k = Enumerable.Range(0, solidsList.Count);
            foreach (var i in k) {
                selectedSolids.Add(i);
            }
            DrawSolids();
        }

        private void translateCubeCheckbox_CheckedChanged(object sender, EventArgs e) {

        }

        private void button3_Click_1(object sender, EventArgs e) {
            //Console.WriteLine(VRP);
            //Console.WriteLine(P);
            VRP.X = Int32.Parse(vrpTfX.Text);
            VRP.Y = Int32.Parse(vrpTfY.Text);
            VRP.Z = Int32.Parse(vrpTfZ.Text);
            P.X = Int32.Parse(pTfX.Text);
            P.Y = Int32.Parse(pTfY.Text);
            P.Z = Int32.Parse(pTfZ.Text);
            //Console.WriteLine(VRP);
            //Console.WriteLine(P);
            DrawSolids();
        }

        private void button4_Click(object sender, EventArgs e) {
            alpha = Int32.Parse(alphaTF.Text);
            DrawSolids();
        }

        private void isometricCheckBox_Click(object sender, EventArgs e) {
            DrawSolids();
        }
    }
}
