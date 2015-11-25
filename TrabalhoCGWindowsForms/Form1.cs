using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfApplication1.Model;
using WpfApplication1.Utils;

namespace TrabalhoCGWindowsForms {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }


        private void Form1_Load(object sender, EventArgs e) {
            solidsList = new List<List<Solid>>();
            selectedGuy = -1;
        }

        private void DrawSolids() {
            if (solidsList == null) return;
            frontView.Image = new Bitmap(frontView.Width, frontView.Height);
            leftView.Image = new Bitmap(leftView.Width, leftView.Height);
            topView.Image = new Bitmap(topView.Width, topView.Height);
            for (int i = 0; i < solidsList.Count; i++) {
                foreach (var solid in solidsList[i]) {
                    if (i == selectedGuy) {
                        DrawView(solid, topView, 0, true);
                        //MatrixOperations.DebugMatrix(solid.Points);
                        DrawView(solid, frontView, 1, true);
                        // MatrixOperations.DebugMatrix(solid.Points);
                        DrawView(solid, leftView, 2,true);
                    }
                    else {
                        DrawView(solid, topView, 0);
                        //MatrixOperations.DebugMatrix(solid.Points);
                        DrawView(solid, frontView, 1);
                        // MatrixOperations.DebugMatrix(solid.Points);
                        DrawView(solid, leftView, 2);
                    }
                }     
            }
            
            //foreach (var solid in solidsList.SelectMany(list => list.Select(solid => solid))) {
                
                
            //}
        }

        private void DrawView(Solid solid, PictureBox pc, int ipc, bool select = false) {
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

            Graphics g = Graphics.FromImage(pc.Image);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var myPen = new Pen(Color.Black, 1);
            if (select) {
                myPen = new Pen(Color.Yellow, 1);
            }
            double[,] matrix = solid.Points;//MatrixOperations.AddMatrix(height, MatrixOperations.AddMatrix(width, solid.Points, x), y);
            for (int i = 0; i < 12; i++) {
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

        private void trackBar1_ValueChanged(object sender, EventArgs e) {
            foreach (var solid in solidsList[selectedGuy]) {
                if (trackBar1.Value != 0)
                    solid.XAxisRotation(trackBar1.Value);
            }
            DrawSolids();
        }

        private void button1_Click(object sender, EventArgs e) {
            /*
                for (int i = 0; i < int.MaxValue; i++) {

                    solid.Points = MatrixOperations.MatrixMultiplication(MatrixOperations.XAxisRotation(5), solid.Points);
                    solid.Points = MatrixOperations.MatrixMultiplication(MatrixOperations.YAxisRotation(5), solid.Points);
                    solid.Points = MatrixOperations.MatrixMultiplication(MatrixOperations.ZAxisRotation(5), solid.Points);
                    DrawView(solid, topView, 0);
                    // MatrixOperations.DebugMatrix(solid.Points);
                    DrawView(solid, frontView, 1);
                    // MatrixOperations.DebugMatrix(solid.Points);
                    DrawView(solid, leftView, 2);
                    //MatrixOperations.DebugMatrix(solid.Points);
                    topView.Update();
                    frontView.Update();
                    leftView.Update();
                    Thread.SpinWait(4000000);
                }
            */
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e) {
            foreach (var solid in solidsList[selectedGuy]) {
                if (trackBar2.Value != 0)
                    solid.YAxisRotation(trackBar1.Value);
            }
            DrawSolids();

        }

        private void trackBar3_ValueChanged(object sender, EventArgs e) {
            foreach (var solid in solidsList[selectedGuy]) {
                if (trackBar3.Value != 0)
                    solid.ZAxisRotation(trackBar1.Value);
            }
            DrawSolids();
        }

        private void topView_Click(object sender, EventArgs e) {
            if (checkBox1.Checked) {
                MouseEventArgs me = (MouseEventArgs) e;
                Point coordinates = me.Location;
                addCube(coordinates,0);
               
            }
            else {
                MouseEventArgs me = (MouseEventArgs)e;
                Point coordinates = me.Location;
               if(solidsList.Count != 0){
                    selectedGuy = selectCube(coordinates, 0);
                    DrawSolids();
                }
                view = 0;
            }
        }

        private int selectCube(Point coordinates,  int index) {
            double maiorX = 0;
            double maiorY = 0;
            double menorX = double.MaxValue;
            double menorY = double.MaxValue;
            bool flag = false;
            double distance = 0;
            int solidInQuestion = 0;
            double menor = double.MaxValue;
            double x, y;
            //Choosing the nearest cube from the click
            switch (index) {
                case 0:
                    for (int i = 0; i < solidsList.Count; i++) {
                        foreach (var solid in solidsList[i]) {
                            x = solid.Points[0, 8];
                            y = solid.Points[2, 8];
                            distance = Math.Sqrt(Math.Pow((x - coordinates.X), 2) + Math.Pow((y - coordinates.Y), 2));
                            if (menor > distance) {
                                menor = distance;
                                solidInQuestion = i;
                            }   
                        }   
                    }
                    break;
                case 1:
                    for (int i = 0; i < solidsList.Count; i++) {
                        foreach (var solid in solidsList[i]) {
                            x = solid.Points[2, 8];
                            y = solid.Points[1, 8];
                            distance = Math.Sqrt(Math.Pow((x - coordinates.X), 2) + Math.Pow((y - coordinates.Y), 2));
                            if (menor > distance) {
                                menor = distance;
                                solidInQuestion = i;
                            }   
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

        private void addCube(Point coordinates, int index) {
            var l = new List<Solid>();
            var k = new Solid();
            //MatrixOperations.DebugMatrix(k.Points);
            switch (index) {
                case 0:
                    k.Points = MatrixOperations.MatrixMultiplication(
                    MatrixOperations.Translation(coordinates.X, 0, coordinates.Y), k.Points);
                    break;
                case 1:
                    k.Points = MatrixOperations.MatrixMultiplication(
                        MatrixOperations.Translation(0, coordinates.Y, coordinates.X), k.Points);
                    break;
                case 2:
                    k.Points = MatrixOperations.MatrixMultiplication(
                        MatrixOperations.Translation(coordinates.X, coordinates.Y, 0), k.Points);
                    break;
            }
            
            //MatrixOperations.DebugMatrix(k.Points);
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
            if (checkBox1.Checked) {
                MouseEventArgs me = (MouseEventArgs)e;
                Point coordinates = me.Location;
                addCube(coordinates, 1);

            } else {
                MouseEventArgs me = (MouseEventArgs)e;
                Point coordinates = me.Location;
                if (solidsList.Count != 0) {
                    selectedGuy = selectCube(coordinates, 1);
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
            if (checkBox1.Checked) {
                MouseEventArgs me = (MouseEventArgs)e;
                Point coordinates = me.Location;
                addCube(coordinates, 2);

            } else {
                MouseEventArgs me = (MouseEventArgs)e;
                Point coordinates = me.Location;
                if (solidsList.Count != 0){
                    selectedGuy = selectCube(coordinates, 2);
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
            switch (view) {
                case 0:
                    if (e.KeyChar == 'w' || e.KeyChar == 'W') {
                        foreach (var solid in solidsList[selectedGuy]) {
                            solid.Translation(0, 0, -1);
                        }
                        DrawSolids();
                    }else if (e.KeyChar == 's' || e.KeyChar == 'S') {
                        foreach (var solid in solidsList[selectedGuy]) {
                            solid.Translation(0, 0, 1);
                        }
                        DrawSolids();
                    } else if (e.KeyChar == 'd' || e.KeyChar == 'D') {
                        foreach (var solid in solidsList[selectedGuy]) {
                            solid.Translation(1, 0, 0);
                        }
                        DrawSolids();
                    } else if (e.KeyChar == 'a' || e.KeyChar == 'A') {
                        foreach (var solid in solidsList[selectedGuy]) {
                            solid.Translation(-1, 0, 0);
                        }
                        DrawSolids();
                    }
                    break;
                case 1:
                    if (e.KeyChar == 'w' || e.KeyChar == 'W') {
                        foreach (var solid in solidsList[selectedGuy]) {
                            solid.Translation(0, -1, 0);
                        }
                        DrawSolids();
                    } else if (e.KeyChar == 's' || e.KeyChar == 'S') {
                        foreach (var solid in solidsList[selectedGuy]) {
                            solid.Translation(0, 1, 0);
                        }
                        DrawSolids();
                    } else if (e.KeyChar == 'd' || e.KeyChar == 'D') {
                        foreach (var solid in solidsList[selectedGuy]) {
                            solid.Translation(0, 0, 1);
                        }
                        DrawSolids();
                    } else if (e.KeyChar == 'a' || e.KeyChar == 'A') {
                        foreach (var solid in solidsList[selectedGuy]) {
                            solid.Translation(0, 0, -1);
                        }
                        DrawSolids();
                    }
                    break;
                case 2:
                    if (e.KeyChar == 'w' || e.KeyChar == 'W') {
                        foreach (var solid in solidsList[selectedGuy]) {
                            solid.Translation(0, -1, 0);
                        }
                        DrawSolids();
                    } else if (e.KeyChar == 's' || e.KeyChar == 'S') {
                        foreach (var solid in solidsList[selectedGuy]) {
                            solid.Translation(0, 1, 0);
                        }
                        DrawSolids();
                    } else if (e.KeyChar == 'd' || e.KeyChar == 'D') {
                        foreach (var solid in solidsList[selectedGuy]) {
                            solid.Translation(1, 0, 0);
                        }
                        DrawSolids();
                    } else if (e.KeyChar == 'a' || e.KeyChar == 'A') {
                        foreach (var solid in solidsList[selectedGuy]) {
                            solid.Translation(-1, 0, 0);
                        }
                        DrawSolids();
                    }
                    break;
            }
            
            
        }

    }
}
