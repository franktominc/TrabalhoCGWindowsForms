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
        }

        private void DrawSolids() {     //Desenha um solido
            if (solidsList == null) return;
            
            frontView.Image = new Bitmap(frontView.Width, frontView.Height);
            leftView.Image = new Bitmap(leftView.Width, leftView.Height);
            topView.Image = new Bitmap(topView.Width, topView.Height);
            if (!hideFacesBox.Checked) {
                for (var i = 0; i < solidsList.Count; i++) {
                    foreach (var solid in solidsList[i]) {
                        if (i == selectedGuy || selectedSolids.Contains(i)) {
                            DrawView(solid, topView, 0, true, new Pen(Color.Yellow, 1));
                            //MathOperations.DebugMatrix(solid.Points);
                            DrawView(solid, frontView, 1, true, new Pen(Color.Yellow, 1));
                            // MathOperations.DebugMatrix(solid.Points);
                            DrawView(solid, leftView, 2, true, new Pen(Color.Yellow, 1));
                        }else if (solidsList[i].Count > 1) {
                            DrawView(solid, topView, 0, true, new Pen(Color.Aquamarine,1));
                            //MathOperations.DebugMatrix(solid.Points);
                            DrawView(solid, frontView, 1, true, new Pen(Color.Aquamarine, 1));
                            // MathOperations.DebugMatrix(solid.Points);
                            DrawView(solid, leftView, 2, true, new Pen(Color.Aquamarine, 1));       
                        }
                        else {
                            DrawView(solid, topView, 0);
                            //MathOperations.DebugMatrix(solid.Points);
                            DrawView(solid, frontView, 1);
                            // MathOperations.DebugMatrix(solid.Points);
                            DrawView(solid, leftView, 2);
                        }
                    }
                }
            }
            else {
                for (var i = 0; i < solidsList.Count; i++) {
                    foreach (var solid in solidsList[i]) {
                        if (i == selectedGuy || selectedSolids.Contains(i)) {
                            DrawVisibleFaces(solid, topView, 0, true, new Pen(Color.Yellow, 1));
                            //MathOperations.DebugMatrix(solid.Points);
                            DrawVisibleFaces(solid, frontView, 1, true, new Pen(Color.Yellow, 1));
                            // MathOperations.DebugMatrix(solid.Points);
                            DrawVisibleFaces(solid, leftView, 2, true, new Pen(Color.Yellow, 1));
                        } else if (solidsList[i].Count > 1) {
                            DrawVisibleFaces(solid, topView, 0, true, new Pen(Color.Aquamarine, 1));
                            //MathOperations.DebugMatrix(solid.Points);
                            DrawVisibleFaces(solid, frontView, 1, true, new Pen(Color.Aquamarine, 1));
                            // MathOperations.DebugMatrix(solid.Points);
                            DrawVisibleFaces(solid, leftView, 2, true, new Pen(Color.Aquamarine, 1));
                        } else {
                            DrawVisibleFaces(solid, topView, 0);
                            //MathOperations.DebugMatrix(solid.Points);
                            DrawVisibleFaces(solid, frontView, 1);
                            // MathOperations.DebugMatrix(solid.Points);
                            DrawVisibleFaces(solid, leftView, 2);
                        }
                    }
                }
            }
            
            //foreach (var solid in solidsList.SelectMany(list => list.Select(solid => solid))) {
                
                
            //}
        }

        private void DrawView(Solid solid, PictureBox pc, int ipc, bool selected = false, Pen myPen = null) {
            var x = 0;
            var y = 0;
            switch (ipc) {
                case 0:        //Top View
                    x = 0;
                    y = 2;
                    break;
                case 1:       //Front View
                    x = 0;
                    y = 1;
                    break;
                case 2:       //Left View
                    x = 2;
                    y = 1;
                    break;
            }
            //var height = (pc.Height / 2.0) - solid.Points[y, 8];
            //var width = (pc.Width / 2.0) - solid.Points[x, 8];
           // Console.WriteLine("{0} {1}",pc.Width, pc.Height);

            var g = Graphics.FromImage(pc.Image);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if(myPen == null)
                myPen = new Pen(Color.Black, 1);
            
            

            var matrix = solid.Points;//MathOperations.AddMatrix(height, MathOperations.AddMatrix(width, solid.Points, x), y);
            for (var i = 0; i < 12; i++) {
                g.DrawLine(myPen, (float)matrix[x, solid.Edges[i, 0]],
                                         (float)matrix[y, solid.Edges[i, 0]], 
                                         (float)matrix[x, solid.Edges[i, 1]], 
                                         (float)matrix[y, solid.Edges[i, 1]]);
            }
            g.DrawLine(myPen,10,10,10,40);
            g.DrawLine(myPen,10,10,40,10);
            pc.Invalidate();
            //pc.Refresh();
        }

        private void DrawVisibleFaces(Solid solid, PictureBox pc, int ipc, bool selected = false, Pen myPen = null) {
            var x = 0;
            var y = 0;
            switch (ipc) {
                case 0:        //Top View
                    x = 0;
                    y = 2;
                    solid.ComputeVisibility(new Vector(solid.Points[0, 8], 1, solid.Points[2, 8]));
                    break;
                case 1:       //Front View
                    x = 0;
                    y = 1;
                    solid.ComputeVisibility(new Vector(solid.Points[0, 8], solid.Points[1, 8], 1));
                    break;
                case 2:       //Left View
                    x = 2;
                    y = 1;
                    solid.ComputeVisibility(new Vector(1, solid.Points[1, 8], solid.Points[2, 8]));
                    break;
            }
            var g = Graphics.FromImage(pc.Image);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (myPen == null) {
                myPen = new Pen(Color.Black, 1);
            }
            
            var matrix = solid.Points;//MathOperations.AddMatrix(height, MathOperations.AddMatrix(width, solid.Points, x), y);
            for (var i = 0; i < 6; i++) {
                if (!solid.VisibleFaces[i]) continue;
                for (int j = 0; j < 3; j++) {
                    g.DrawLine(myPen, (float)matrix[x, solid.Faces[i,j]],
                        (float)matrix[y, solid.Faces[i, j]],
                        (float)matrix[x, solid.Faces[i, j+1]],
                        (float)matrix[y, solid.Faces[i, j+1]]);
                }
                g.DrawLine(myPen, (float)matrix[x, solid.Faces[i, 3]],
                    (float)matrix[y, solid.Faces[i, 3]],
                    (float)matrix[x, solid.Faces[i, 0]],
                    (float)matrix[y, solid.Faces[i, 0]]);
            }
            g.DrawLine(myPen, 10, 10, 10, 40);
            g.DrawLine(myPen, 10, 10, 40, 10);
            pc.Invalidate();

        }
        private void trackBar1_ValueChanged(object sender, EventArgs e) {
            if (selectedGuy >= 0) {
                if (solidsList[selectedGuy].Count > 1) {
                    var mid = MathOperations.MidPoint(solidsList[selectedGuy]);
                    foreach (var solid in solidsList[selectedGuy]) {
                        solid.XAxisRotation(xRotationBar.Value, mid.Y, mid.Z);
                    }
                   
                }else if (xRotationBar.Value != 0) {
                    solidsList[selectedGuy][0].XAxisRotation(xRotationBar.Value, solidsList[selectedGuy][0].Points[1, 8], solidsList[selectedGuy][0].Points[2, 8]);
                }
                DrawSolids();
            }
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e) {
            if (selectedGuy >= 0) {
                if (solidsList[selectedGuy].Count > 1) {
                    var mid = MathOperations.MidPoint(solidsList[selectedGuy]);
                    foreach (var solid in solidsList[selectedGuy]) {
                        solid.YAxisRotation(yRotationBar.Value, mid.X, mid.Z);
                    }

                } else if (yRotationBar.Value != 0) {
                    solidsList[selectedGuy][0].YAxisRotation(yRotationBar.Value, solidsList[selectedGuy][0].Points[0, 8], solidsList[selectedGuy][0].Points[2, 8]);
                }
                DrawSolids();
            }

        }

        private void trackBar3_ValueChanged(object sender, EventArgs e) {
            if (selectedGuy >= 0) {
                if (solidsList[selectedGuy].Count > 1) {
                    var mid = MathOperations.MidPoint(solidsList[selectedGuy]);
                    foreach (var solid in solidsList[selectedGuy]) {
                        solid.ZAxisRotation(zRotationBar.Value, mid.X, mid.Y);
                    }

                } else if (zRotationBar.Value != 0) {
                    solidsList[selectedGuy][0].ZAxisRotation(zRotationBar.Value, solidsList[selectedGuy][0].Points[0, 8], solidsList[selectedGuy][0].Points[1, 8]);
                }
                DrawSolids();
            }
        }

        private void topView_Click(object sender, EventArgs e) {
            if (addCubeBox.Checked) {
                var me = (MouseEventArgs) e;
                var coordinates = me.Location;
                AddCube(coordinates,0);
               
            }
            else if (groupSolidsCheckBox.Checked) {
                var me = (MouseEventArgs)e;
                var coordinates = me.Location;
                selectedGuy = SelectCube(coordinates, 0);
                if (selectedGuy == -1) {
                    selectedSolids = new List<int>();
                }
                else {
                    selectedSolids.Add(selectedGuy); 
                }
                
                DrawSolids();
            }else{
                var me = (MouseEventArgs)e;
                var coordinates = me.Location;
                if(solidsList.Count != 0){
                    selectedGuy = SelectCube(coordinates, 0);
                    DrawSolids();
                }
                view = 0;
            }
        }

        private int SelectCube(Point coordinates,  int index) {
            var maiorX = 0.0;
            var maiorY = 0.0;
            var menorX = double.MaxValue;
            var menorY = double.MaxValue;
            var flag = false;
            double distance;
            var solidInQuestion = 0;
            var menor = double.MaxValue;
            double x, y;
            //Choosing the nearest cube from the click
            switch (index) {
                case 0:
                    for (var i = 0; i < solidsList.Count; i++) {
                        foreach (var solid in solidsList[i]) {
                            x = solid.Points[0, 8];
                            y = solid.Points[2, 8];
                            distance = Math.Sqrt(Math.Pow((x - coordinates.X), 2) + Math.Pow((y - coordinates.Y), 2));
                            if (!(menor > distance)) continue;
                            menor = distance;
                            solidInQuestion = i;
                            
                        }   
                    }
                    break;
                case 1:
                    for (var i = 0; i < solidsList.Count; i++) {
                        foreach (var solid in solidsList[i]) {
                            x = solid.Points[2, 8];
                            y = solid.Points[1, 8];
                            distance = Math.Sqrt(Math.Pow((x - coordinates.X), 2) + Math.Pow((y - coordinates.Y), 2));
                            if (!(menor > distance)) continue;
                            menor = distance;
                            solidInQuestion = i;
                            
                        }   
                    }
                    break;
                case 2:
                    for (int i = 0; i < solidsList.Count; i++) {
                        foreach (var solid in solidsList[i]) {
                            x = solid.Points[0, 8];
                            y = solid.Points[1, 8];
                            distance = Math.Sqrt(Math.Pow((x - coordinates.X), 2) + Math.Pow((y - coordinates.Y), 2));
                            if (menor > distance) {
                                menor = distance;
                                solidInQuestion = i;
                                
                            }
                        }
                    }
                    break;
            }
            foreach (var solid in solidsList[solidInQuestion]) {
                for (int i = 0; i < 8; i++) {

                    switch (index) {
                        case 0:
                            if (maiorX < solid.Points[0, i]) {
                                maiorX = solid.Points[0, i];
                            }
                            if (menorX > solid.Points[0, i]) {
                                menorX = solid.Points[0, i];
                            }
                            if (maiorY < solid.Points[2, i]) {
                                maiorY = solid.Points[2, i];
                            }
                            if (menorY > solid.Points[2, i]) {
                                menorY = solid.Points[2, i];
                            }
                            break;
                        case 1:
                            if (maiorX < solid.Points[2, i]) {
                                maiorX = solid.Points[2, i];
                            }
                            if (menorX > solid.Points[2, i]) {
                                menorX = solid.Points[2, i];
                            }
                            if (maiorY < solid.Points[1, i]) {
                                maiorY = solid.Points[1, i];
                            }
                            if (menorY > solid.Points[1, i]) {
                                menorY = solid.Points[1, i];
                            }
                            break;
                        case 2:
                            if (maiorX < solid.Points[0, i]) {
                                maiorX = solid.Points[0, i];
                            }
                            if (menorX > solid.Points[0, i]) {
                                menorX = solid.Points[0, i];
                            }
                            if (maiorY < solid.Points[1, i]) {
                                maiorY = solid.Points[1, i];
                            }
                            if (menorY > solid.Points[1, i]) {
                                menorY = solid.Points[1, i];
                            }
                            break;
                    }

                }
                
                if (maiorX >= coordinates.X && maiorY >= coordinates.Y && menorX <= coordinates.X && menorY <= coordinates.Y) {
                    flag = true;
                    break;
                }
                maiorX = 0;
                maiorY = 0;
                menorX = double.MaxValue;
                menorY = double.MaxValue;
            }

            if (flag) {
                return solidInQuestion;
            }
            return -1;

        }

        private void AddCube(Point coordinates, int index) {
            var l = new List<Solid>();
            var k = new Solid();
            //MathOperations.DebugMatrix(k.Points);
            switch (index) {
                case 0:
                    k.Points = MathOperations.MatrixMultiplication(
                        MathOperations.Translation(coordinates.X, 0, coordinates.Y), k.Points);
                    k.ComputeVisibility(new Vector(0,1,0));
                    break;
                case 1:
                    k.Points = MathOperations.MatrixMultiplication(
                        MathOperations.Translation(0, coordinates.Y, coordinates.X), k.Points);
                    k.ComputeVisibility(new Vector(1,0,0));
                    break;
                case 2:
                    k.Points = MathOperations.MatrixMultiplication(
                        MathOperations.Translation(coordinates.X, coordinates.Y, 0), k.Points);
                    k.ComputeVisibility(new Vector(0,0,1));
                    break;
            }
            
            //MathOperations.DebugMatrix(k.Points);
            l.Add(k);

            solidsList.Add(l);
            //Console.WriteLine(l[0]);
            DrawSolids();
        }

        private void topView_Paint(object sender, PaintEventArgs e) {
            var myPen = new Pen(Color.Black,1);
            e.Graphics.DrawLine(myPen, 10, 10, 10, 40);
            e.Graphics.DrawLine(myPen, 10, 10, 40, 10);
            //Console.WriteLine("Ue");
            
        }

        private void leftView_Click(object sender, EventArgs e) {
            if (addCubeBox.Checked) {
                var me = (MouseEventArgs)e;
                var coordinates = me.Location;
                AddCube(coordinates, 1);

            } else {
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

            } else {
                var me = (MouseEventArgs)e;
                var coordinates = me.Location;
                if (solidsList.Count != 0){
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
            foreach (var solid in solidsList[selectedGuy]) {
                solid.ZScale(1.1);
            }
            DrawSolids();
        }

        private void button3_Click(object sender, EventArgs e) {
            foreach (var solid in solidsList[selectedGuy]) {
                solid.ZScale(0.9);
            }
            DrawSolids();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e) {
            const int desloc = 5;
            switch (view) {
                case 0:
                    switch (e.KeyChar) {
                        case 'w':
                        case 'W':
                            foreach (var solid in solidsList[selectedGuy]) {
                                solid.Translation(0, 0, -desloc);
                            }
                            DrawSolids();
                            break;
                        case 's':
                        case 'S':
                            foreach (var solid in solidsList[selectedGuy]) {
                                solid.Translation(0, 0, desloc);
                            }
                            DrawSolids();
                            break;
                        case 'd':
                        case 'D':
                            foreach (var solid in solidsList[selectedGuy]) {
                                solid.Translation(desloc, 0, 0);
                            }
                            DrawSolids();
                            break;
                        case 'a':
                        case 'A':
                            foreach (var solid in solidsList[selectedGuy]) {
                                solid.Translation(-desloc, 0, 0);
                            }
                            DrawSolids();
                            break;
                    }
                    break;
                case 1:
                    switch (e.KeyChar) {
                        case 'w':
                        case 'W':
                            foreach (var solid in solidsList[selectedGuy]) {
                                solid.Translation(0, -desloc, 0);
                            }
                            DrawSolids();
                            break;
                        case 's':
                        case 'S':
                            foreach (var solid in solidsList[selectedGuy]) {
                                solid.Translation(0, desloc, 0);
                            }
                            DrawSolids();
                            break;
                        case 'd':
                        case 'D':
                            foreach (var solid in solidsList[selectedGuy]) {
                                solid.Translation(0, 0, desloc);
                            }
                            DrawSolids();
                            break;
                        case 'a':
                        case 'A':
                            foreach (var solid in solidsList[selectedGuy]) {
                                solid.Translation(0, 0, -desloc);
                            }
                            DrawSolids();
                            break;
                    }
                    break;
                case 2:
                    switch (e.KeyChar) {
                        case 'w':
                        case 'W':
                            foreach (var solid in solidsList[selectedGuy]) {
                                solid.Translation(0, -desloc, 0);
                            }
                            DrawSolids();
                            break;
                        case 's':
                        case 'S':
                            foreach (var solid in solidsList[selectedGuy]) {
                                solid.Translation(0, desloc, 0);
                            }
                            DrawSolids();
                            break;
                        case 'd':
                        case 'D':
                            foreach (var solid in solidsList[selectedGuy]) {
                                solid.Translation(desloc, 0, 0);
                            }
                            DrawSolids();
                            break;
                        case 'a':
                        case 'A':
                            foreach (var solid in solidsList[selectedGuy]) {
                                solid.Translation(-desloc, 0, 0);
                            }
                            DrawSolids();
                            break;
                    }
                    break;
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
                solidsList = (List<List<Solid>>) bin.Deserialize(fs);
                fs.Close();
                DrawSolids();
            }
        }

        private void groupBt_Click(object sender, EventArgs e) {
            if (selectedSolids.Count >= 1) {
                selectedSolids.Sort((a, b) => -1*a.CompareTo(b));
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
    }
}
