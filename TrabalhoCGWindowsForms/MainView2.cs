using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabalhoCGWindowsForms.Model;
using TrabalhoCGWindowsForms.Utils;

namespace TrabalhoCGWindowsForms {
    public partial class MainView {
        private void DrawSolids() {
            //Desenha um solido
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
                        }
                        else if (solidsList[i].Count > 1) {
                            DrawView(solid, topView, 0, true, new Pen(Color.Aquamarine, 1));
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
                        }
                        else if (solidsList[i].Count > 1) {
                            DrawVisibleFaces(solid, topView, 0, true, new Pen(Color.Aquamarine, 1));
                            //MathOperations.DebugMatrix(solid.Points);
                            DrawVisibleFaces(solid, frontView, 1, true, new Pen(Color.Aquamarine, 1));
                            // MathOperations.DebugMatrix(solid.Points);
                            DrawVisibleFaces(solid, leftView, 2, true, new Pen(Color.Aquamarine, 1));
                        }
                        else {
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
            DrawPerpectiveSolids();

            //}
        }

        private void DrawPerpectiveSolids() {
            PerspectiveTransformation();
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            for (var i = 0; i < perspectiveSolidList.Count; i++) {
                foreach (var solid in perspectiveSolidList[i]) {
                    DrawFourthView(solid, pictureBox2, new Pen(Color.Black, 1));
                }
            }
        }

        private void DrawFourthView(Solid solid, PictureBox pc, Pen myPen = null) {
            var x = 0;
            var y = 1;
            var g = Graphics.FromImage(pc.Image);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (myPen == null)
                myPen = new Pen(Color.Black, 1);



            var matrix = solid.Points;//MathOperations.AddMatrix(height, MathOperations.AddMatrix(width, solid.Points, x), y);
            for (var i = 0; i < 12; i++) {
                g.DrawLine(myPen, (float)matrix[x, solid.Edges[i, 0]],
                                         (float)matrix[y, solid.Edges[i, 0]],
                                         (float)matrix[x, solid.Edges[i, 1]],
                                         (float)matrix[y, solid.Edges[i, 1]]);
            }
            g.DrawLine(myPen, 10, 10, 10, 40);
            g.DrawLine(myPen, 10, 10, 40, 10);
            pc.Invalidate();
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
            if (myPen == null)
                myPen = new Pen(Color.Black, 1);



            var matrix = solid.Points;//MathOperations.AddMatrix(height, MathOperations.AddMatrix(width, solid.Points, x), y);
            for (var i = 0; i < 12; i++) {
                g.DrawLine(myPen, (float)matrix[x, solid.Edges[i, 0]],
                                         (float)matrix[y, solid.Edges[i, 0]],
                                         (float)matrix[x, solid.Edges[i, 1]],
                                         (float)matrix[y, solid.Edges[i, 1]]);
            }
            g.DrawLine(myPen, 10, 10, 10, 40);
            g.DrawLine(myPen, 10, 10, 40, 10);
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
                    g.DrawLine(myPen, (float)matrix[x, solid.Faces[i, j]],
                        (float)matrix[y, solid.Faces[i, j]],
                        (float)matrix[x, solid.Faces[i, j + 1]],
                        (float)matrix[y, solid.Faces[i, j + 1]]);
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

        private int SelectCube(Point coordinates, int index) {
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
                    k.ComputeVisibility(new Vector(0, 1, 0));
                    break;
                case 1:
                    k.Points = MathOperations.MatrixMultiplication(
                        MathOperations.Translation(0, coordinates.Y, coordinates.X), k.Points);
                    k.ComputeVisibility(new Vector(1, 0, 0));
                    break;
                case 2:
                    k.Points = MathOperations.MatrixMultiplication(
                        MathOperations.Translation(coordinates.X, coordinates.Y, 0), k.Points);
                    k.ComputeVisibility(new Vector(0, 0, 1));
                    break;
            }

            //MathOperations.DebugMatrix(k.Points);
            l.Add(k);

            solidsList.Add(l);
            //Console.WriteLine(l[0]);
            DrawSolids();
        }

        async public void TopViewRotation() {
            Point antigo = new Point();
            Point atual = new Point(Cursor.Position.X, Cursor.Position.Y);
            Point desloc = new Point();
            while (amIRotating) {
                antigo = atual;
                atual = Cursor.Position;
                desloc.X = atual.X - antigo.X;
                desloc.Y = atual.Y - antigo.Y;
                if (selectedGuy >= 0) {
                    if (solidsList[selectedGuy].Count > 1) {
                        var mid = MathOperations.MidPoint(solidsList[selectedGuy]);
                        foreach (var solid in solidsList[selectedGuy]) {
                            solid.XAxisRotation(2*desloc.Y, mid.Y, mid.Z);
                            solid.ZAxisRotation(2*desloc.X, mid.X, mid.Y);
                        }

                    } else{
                        solidsList[selectedGuy][0].XAxisRotation(2*desloc.Y, solidsList[selectedGuy][0].Points[1, 8], solidsList[selectedGuy][0].Points[2, 8]);
                        solidsList[selectedGuy][0].ZAxisRotation(2*desloc.X, solidsList[selectedGuy][0].Points[0, 8], solidsList[selectedGuy][0].Points[1, 8]);
                    }
                    DrawSolids();
                }


                await Task.Delay(1);
            }
        }

        async public void LeftViewRotation() {
            Point antigo = new Point();
            Point atual = new Point(Cursor.Position.X, Cursor.Position.Y);
            Point desloc = new Point();
            while (amIRotating) {
                antigo = atual;
                atual = Cursor.Position;
                desloc.X = atual.X - antigo.X;
                desloc.Y = atual.Y - antigo.Y;
                if (selectedGuy >= 0) {
                    if (solidsList[selectedGuy].Count > 1) {
                        var mid = MathOperations.MidPoint(solidsList[selectedGuy]);
                        foreach (var solid in solidsList[selectedGuy]) {
                            solid.YAxisRotation(2 * desloc.X, mid.X, mid.Z);
                            solid.ZAxisRotation(2 * desloc.Y, mid.X, mid.Y);
                        }

                    } else {
                        solidsList[selectedGuy][0].YAxisRotation(2 * desloc.X, solidsList[selectedGuy][0].Points[0, 8], solidsList[selectedGuy][0].Points[2, 8]);
                        solidsList[selectedGuy][0].ZAxisRotation(2 * desloc.Y, solidsList[selectedGuy][0].Points[0, 8], solidsList[selectedGuy][0].Points[1, 8]);
                    }
                    DrawSolids();
                }


                await Task.Delay(1);
            }
        }

        async public void FrontViewRotation() {
            Point antigo = new Point();
            Point atual = new Point(Cursor.Position.X, Cursor.Position.Y);
            Point desloc = new Point();
            while (amIRotating) {
                antigo = atual;
                atual = Cursor.Position;
                desloc.X = atual.X - antigo.X;
                desloc.Y = atual.Y - antigo.Y;
                if (selectedGuy >= 0) {
                    if (solidsList[selectedGuy].Count > 1) {
                        var mid = MathOperations.MidPoint(solidsList[selectedGuy]);
                        foreach (var solid in solidsList[selectedGuy]) {
                            solid.XAxisRotation(2 * desloc.Y, mid.Y, mid.Z);
                            solid.YAxisRotation(2 * desloc.X, mid.X, mid.Z);
                        }

                    } else {
                        solidsList[selectedGuy][0].XAxisRotation(2 * desloc.Y, solidsList[selectedGuy][0].Points[1, 8], solidsList[selectedGuy][0].Points[2, 8]);
                        solidsList[selectedGuy][0].YAxisRotation(2 * desloc.X, solidsList[selectedGuy][0].Points[0, 8], solidsList[selectedGuy][0].Points[2, 8]);
                    }
                    DrawSolids();
                }


                await Task.Delay(1);
            }
        }

        private void PerspectiveTransformation() {

            //Coordenadas de tela
            perspectiveSolidList = solidsList;
            Vector P = new Vector(0, 0, 0);
            Vector VRP = new Vector(150, 150, 150);

            Vector n = MathOperations.NormalizeVector(VRP);

            Vector Y = new Vector(0, 1, 0);
            double aux = MathOperations.DotProduct(Y, n);
            n.X = aux*n.X;
            n.Y = aux*n.Y;
            n.Z = aux*n.Z;
            Vector v = new Vector(Y.X - n.X, Y.Y - n.Y, Y.Z - n.Z);
            v = MathOperations.NormalizeVector(v);

            Vector u = new Vector();
            u = MathOperations.CrossProduct(v, n);

            double[,] M = new double[,] {
                {u.X, u.Y, u.Z, -1*MathOperations.DotProduct(VRP, u)},
                {v.X, v.Y, v.Z, -1*MathOperations.DotProduct(VRP, v)},
                {n.X, n.Y, n.Z, -1*MathOperations.DotProduct(VRP, n)},
                {1,1,1,1}
            };
            foreach (List<Solid> t in perspectiveSolidList) {
                foreach (var solid in t) {
                    solid.Points = MathOperations.MatrixMultiplication(M, solid.Points);
                }
            }

            //Transformacao perspectiva
            double[,] perspecMatrix = new double[,] {
                {1,0,0,0},
                {0,1,0,0},
                {0,0,1,0},
                {0,0,-1/(VRP.Z-P.Z),0},
            };
            foreach (List<Solid> t in perspectiveSolidList) {
                foreach (var solid in t) {
                    solid.Points = MathOperations.MatrixMultiplication(perspecMatrix, solid.Points);
                    for (int j = 0; j < perspecMatrix.GetLength(1); j++) {
                        for (int i = 0; i < perspecMatrix.GetLength(0); i++) {
                            solid.Points[i,j]/= solid.Points[perspecMatrix.GetLength(1)-1, j];
                        }
                    }
                }
            }

        }
    }
}
