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
            perspectiveBox.Image = new Bitmap(perspectiveBox.Width, perspectiveBox.Height);
            
            if (!hideFacesBox.Checked) {
                for (var i = 0; i < solidsList.Count; i++) {
                    foreach (var solid in solidsList[i]) {
                        if (i == selectedGuy || selectedSolids.Contains(i)) {
                            DrawView(solid, topView, 0, true, new Pen(Color.Yellow, 1));
                            //MathOperations.DebugMatrix(solid.Points);
                            DrawView(solid, frontView, 1, true, new Pen(Color.Yellow, 1));
                            // MathOperations.DebugMatrix(solid.Points);
                            DrawView(solid, leftView, 2, true, new Pen(Color.Yellow, 1));
                             DrawPerpectiveSolids(new Pen(Color.Yellow, 1));

                        } else if (solidsList[i].Count > 1) {
                            DrawView(solid, topView, 0, true, new Pen(Color.Aquamarine, 1));
                            //MathOperations.DebugMatrix(solid.Points);
                            DrawView(solid, frontView, 1, true, new Pen(Color.Aquamarine, 1));
                            // MathOperations.DebugMatrix(solid.Points);
                            DrawView(solid, leftView, 2, true, new Pen(Color.Aquamarine, 1));
                            DrawPerpectiveSolids(new Pen(Color.Aquamarine, 1));
                        } else {
                            DrawView(solid, topView, 0);
                            //MathOperations.DebugMatrix(solid.Points);
                            DrawView(solid, frontView, 1);
                            // MathOperations.DebugMatrix(solid.Points);
                            DrawView(solid, leftView, 2);
                            DrawPerpectiveSolids();
                        }
                    }
                }
               

            } else {
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
                    if (isometricCheckBox.Checked) {
                        IsometricTransformation();
                        foreach (var solid in isometricSolidList[i]) {
                            if (i == selectedGuy || selectedSolids.Contains(i)) {
                                DrawVisibleFaces(solid, perspectiveBox, 3, true, new Pen(Color.Yellow, 1));
                            } else if (solidsList[i].Count > 1) {
                                DrawVisibleFaces(solid, perspectiveBox, 3, true, new Pen(Color.Aquamarine, 1));
                            } else {
                                DrawVisibleFaces(solid, perspectiveBox, 3);
                            }
                        }
                    } else {
                        PerspectiveTransformation();
                        foreach (var solid in perspectiveSolidList[i]) {
                            if (i == selectedGuy || selectedSolids.Contains(i)) {
                                DrawVisibleFaces(solid, perspectiveBox, 3, true, new Pen(Color.Yellow, 1));
                            } else if (solidsList[i].Count > 1) {
                                DrawVisibleFaces(solid, perspectiveBox, 3, true, new Pen(Color.Aquamarine, 1));
                            } else {
                                DrawVisibleFaces(solid, perspectiveBox, 3);
                            }
                        }
                    }
                   
                }
            }
        }

        private void DrawPerpectiveSolids(Pen myPen = null) {
            perspectiveBox.Image = new Bitmap(perspectiveBox.Width, perspectiveBox.Height);
            if (isometricCheckBox.Checked) {
                Vector temp = new Vector();
                IsometricTransformation();
                for (var i = 0; i < isometricSolidList.Count; i++) {
                    foreach (var solid in isometricSolidList[i]) {
                        if (myPen == null)
                            DrawFourthView(solid, perspectiveBox, new Pen(Color.Black, 1));
                        else {
                            DrawFourthView(solid, perspectiveBox, myPen);
                        }
                    }
                }
            }
            else {
                PerspectiveTransformation();
                for (var i = 0; i < perspectiveSolidList.Count; i++) {
                    foreach (var solid in perspectiveSolidList[i]) {
                        if (myPen == null)
                            DrawFourthView(solid, perspectiveBox, new Pen(Color.Black, 1));
                        else {
                            DrawFourthView(solid, perspectiveBox, myPen);
                        }
                    }
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
                case 3:     //Perspective
                    x = 0;
                    y = 1;
                    if (isometricCheckBox.Checked) {
                        solid.ComputeVisibility(VRPiso, new Vector(0,0,0));
                    }
                    else {
                        solid.ComputeVisibility(VRP, P);
                    }
                    
                    pc.Invalidate();
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
                            solid.XAxisRotation(2 * desloc.Y, mid.Y, mid.Z);
                            solid.ZAxisRotation(2 * desloc.X, mid.X, mid.Y);
                        }

                    } else {
                        solidsList[selectedGuy][0].XAxisRotation(2 * desloc.Y, solidsList[selectedGuy][0].Points[1, 8], solidsList[selectedGuy][0].Points[2, 8]);
                        solidsList[selectedGuy][0].ZAxisRotation(2 * desloc.X, solidsList[selectedGuy][0].Points[0, 8], solidsList[selectedGuy][0].Points[1, 8]);
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

        public async void TopViewTranslation() {
            Point antigo = new Point();
            Point atual = new Point(Cursor.Position.X, Cursor.Position.Y);
            Point desloc = new Point();
            while (amITranlating) {
                antigo = atual;
                atual = Cursor.Position;
                desloc.X = atual.X - antigo.X;
                desloc.Y = atual.Y - antigo.Y;
                if (selectedGuy >= 0) {
                    foreach (var solid in solidsList[selectedGuy]) {
                        //Console.WriteLine(atual);
                        solid.Translation(desloc.X, 0, desloc.Y);
                    }
                    DrawSolids();
                }
                await Task.Delay(1);
            }
        }

        public async void FrontViewTranslation() {
            Point antigo = new Point();
            Point atual = new Point(Cursor.Position.X, Cursor.Position.Y);
            Point desloc = new Point();
            while (amITranlating) {
                antigo = atual;
                atual = Cursor.Position;
                desloc.X = atual.X - antigo.X;
                desloc.Y = atual.Y - antigo.Y;
                if (selectedGuy >= 0) {
                    foreach (var solid in solidsList[selectedGuy]) {
                        //Console.WriteLine(atual);
                        solid.Translation(desloc.X, desloc.Y, 0);
                    }
                    DrawSolids();
                }
                await Task.Delay(1);
            }
        }

        public async void LeftViewTranslation() {
            Point antigo = new Point();
            Point atual = new Point(Cursor.Position.X, Cursor.Position.Y);
            Point desloc = new Point();
            while (amITranlating) {
                antigo = atual;
                atual = Cursor.Position;
                desloc.X = atual.X - antigo.X;
                desloc.Y = atual.Y - antigo.Y;
                if (selectedGuy >= 0) {
                    foreach (var solid in solidsList[selectedGuy]) {
                        //Console.WriteLine(atual);
                        solid.Translation(0, desloc.Y, desloc.X);
                    }
                    DrawSolids();
                }
                await Task.Delay(1);
            }
        }

        private void PerspectiveTransformation() {
            //Console.WriteLine(VRP);
            //Console.WriteLine(P);
            //Coordenadas de tela
            perspectiveSolidList = solidsList.Clone();
            Vector Xico = new Vector();
            Xico.X = VRP.X - P.X;
            Xico.Y = VRP.Y - P.Y;
            Xico.Z = VRP.Z - P.Z;
            Vector n = MathOperations.NormalizeVector(Xico);



            Vector Y = new Vector(0, 1, 0);
            Vector n1 = new Vector();
            double aux = MathOperations.DotProduct(Y, n);
            n1.X = aux * n.X;
            n1.Y = aux * n.Y;
            n1.Z = aux * n.Z;
            Vector v = new Vector(Y.X - n1.X, Y.Y - n1.Y, Y.Z - n1.Z);
            v = MathOperations.NormalizeVector(v);

            Vector u = new Vector();
            u = MathOperations.CrossProduct(v, n);

            double[,] M = new double[,] {
                {u.X, u.Y, u.Z, -1*MathOperations.DotProduct(VRP, u)},
                {v.X, v.Y, v.Z, -1*MathOperations.DotProduct(VRP, v)},
                {n.X, n.Y, n.Z, -1*MathOperations.DotProduct(VRP, n)},
                {0,0,0,1}
            };
            /*Console.WriteLine(Xico);
            Console.WriteLine(n);
            Console.WriteLine(u);
            Console.WriteLine(v);
            MathOperations.DebugMatrix(M);

            double[,] solid = {
                {-10.00, 10.00, 7.00, -7.00, -10.00, 10.00, 7.00, -7.00},
                {-20, -20 ,	20,	20,	-20, -20, 20, 20},
                {10, 10, 10, 10, -10, -10, -10, -10},
                {1,1,1,1,1,1,1,1}
            };
            solid = MathOperations.MatrixMultiplication(M, solid);
            MathOperations.DebugMatrix(solid);
            */
            foreach (List<Solid> t in perspectiveSolidList) {
                foreach (var solid in t) {
                    solid.Points = MathOperations.MatrixMultiplication(M, solid.Points);
                }
            }

            var dp = Math.Sqrt(Math.Pow(VRP.X - P.X, 2) +
                               Math.Pow(VRP.Y - P.Y, 2) +
                               Math.Pow(VRP.Z - P.Z, 2));
            //Transformacao perspectiva
            double[,] perspecMatrix = new double[,] {
                {1,0,0,0},
                {0,1,0,0},
                {0,0,1,0},
                {0,0,-1/(dp*alpha/100.0),0},
            };
            foreach (List<Solid> t in perspectiveSolidList) {
                foreach (var solid in t) {
                    solid.Points = MathOperations.MatrixMultiplication(perspecMatrix, solid.Points);
                    for (int i = 0; i < solid.Points.GetLength(0); i++) {
                        for (int j = 0; j < solid.Points.GetLength(1); j++) {
                            solid.Points[i, j] /= solid.Points[solid.Points.GetLength(0) - 1, j];
                        }
                    }
                }
            }

        }

        private void IsometricTransformation() {
            //Coordenadas de tela

            isometricSolidList = solidsList.Clone();
            Vector Xico = new Vector();
            Xico.X = VRPiso.X;
            Xico.Y = VRPiso.Y;
            Xico.Z = VRPiso.Z;
            Vector n = MathOperations.NormalizeVector(Xico);



            Vector Y = new Vector(0, 1, 0);
            Vector n1 = new Vector();
            double aux = MathOperations.DotProduct(Y, n);
            n1.X = aux * n.X;
            n1.Y = aux * n.Y;
            n1.Z = aux * n.Z;
            Vector v = new Vector(Y.X - n1.X, Y.Y - n1.Y, Y.Z - n1.Z);
            v = MathOperations.NormalizeVector(v);

            Vector u = new Vector();
            u = MathOperations.CrossProduct(v, n);

            double[,] M = new double[,] {
                {u.X, u.Y, u.Z, -1*MathOperations.DotProduct(VRPiso, u)},
                {v.X, v.Y, v.Z, -1*MathOperations.DotProduct(VRPiso, v)},
                {n.X, n.Y, n.Z, -1*MathOperations.DotProduct(VRPiso, n)},
                {0,0,0,1}
            };
            foreach (List<Solid> t in isometricSolidList) {
                foreach (var solid in t) {
                    solid.Points = MathOperations.MatrixMultiplication(M, solid.Points);
                }
            }
        }

    }
}
