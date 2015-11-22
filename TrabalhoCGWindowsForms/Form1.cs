using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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
            
            DrawView(solid, topView, 0);
            // MatrixOperations.DebugMatrix(solid.Points);
            DrawView(solid, frontView, 1);
            // MatrixOperations.DebugMatrix(solid.Points);
            DrawView(solid, leftView, 2);

            
            
        }


        private void DrawView(Solid solid, PictureBox pc, int ipc) {
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
            var height = (pc.Height / 2.0) - solid.Points[y, 8];
            var width = (pc.Width / 2.0) - solid.Points[x, 8];
            var bmp = new Bitmap(pc.Width, pc.Height);
            var graphics = Graphics.FromImage(bmp);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var myPen = new Pen(Color.Black, 1);
            double[,] matrix = MatrixOperations.AddMatrix(height, MatrixOperations.AddMatrix(width, solid.Points, x), y);
            for (int i = 0; i < 12; i++) {
                graphics.DrawLine(myPen, (float)matrix[x, solid.Edges[i, 0]],
                                         (float)matrix[y, solid.Edges[i, 0]], 
                                         (float)matrix[x, solid.Edges[i, 1]], 
                                         (float)matrix[y, solid.Edges[i, 1]]);
            }
            
            pc.Image = bmp;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e) {
            solid.Points = MatrixOperations.MatrixMultiplication(MatrixOperations.XAxisRotation(5*(trackBar1.Value/Math.Abs(trackBar1.Value))),
                solid.Points);
            DrawView(solid, topView, 0);
           // MatrixOperations.DebugMatrix(solid.Points);
            DrawView(solid, frontView, 1);
           // MatrixOperations.DebugMatrix(solid.Points);
            DrawView(solid, leftView, 2);
            //MatrixOperations.DebugMatrix(solid.Points);
            topView.Update();
            frontView.Update();
            leftView.Update();
        }

        private void button1_Click(object sender, EventArgs e) {
            for (int i = 0; i < int.MaxValue; i++) {
                solid.Points = MatrixOperations.MatrixMultiplication(MatrixOperations.XAxisRotation(5), solid.Points);
                solid.Points = MatrixOperations.MatrixMultiplication(MatrixOperations.YAxisRotation(5), solid.Points); 
                solid.Points = MatrixOperations.MatrixMultiplication(MatrixOperations.ZAxisRotation(5),solid.Points);
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
        }


       
    }
}
