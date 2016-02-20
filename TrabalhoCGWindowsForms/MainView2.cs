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
        

        private void FlatPaint(PictureBox pc, Solid solid, int x, int y) {
            Console.WriteLine();
            for (int i = 0; i < 6; i++) {
                var g = Graphics.FromImage(pc.Image);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                var face = new Point[4];
                face[0] = new Point((int)solid.Points[x, solid.Faces[i, 0]], (int)solid.Points[y, solid.Faces[i, 0]]);
                face[1] = new Point((int)solid.Points[x, solid.Faces[i, 1]], (int)solid.Points[y, solid.Faces[i, 1]]);
                face[2] = new Point((int)solid.Points[x, solid.Faces[i, 2]], (int)solid.Points[y, solid.Faces[i, 2]]);
                face[3] = new Point((int)solid.Points[x, solid.Faces[i, 3]], (int)solid.Points[y, solid.Faces[i, 3]]);
                if (solid.FlatColor[i] == null) {
                    continue;
                }
                g.FillPolygon(new SolidBrush(Color.FromArgb((int)solid.FlatColor[i].X, (int)solid.FlatColor[i].Y, (int)solid.FlatColor[i].Z)), face);
            }

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

            #region Camera Transformations
            perspectiveSolidList = solidsList.Clone();
            Vector bigN = new Vector();
            bigN.X = VRP.X - P.X;
            bigN.Y = VRP.Y - P.Y;
            bigN.Z = VRP.Z - P.Z;
            Vector n = MathOperations.NormalizeVector(bigN);

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
            #endregion

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

            perspectiveSolidList = solidsList.Clone();
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
            foreach (List<Solid> t in perspectiveSolidList) {
                foreach (var solid in t) {
                    solid.Points = MathOperations.MatrixMultiplication(M, solid.Points);
                }
            }
        }

        
        public void FlatShading(Solid solid, PictureBox pc) {
            Vector iT;
            Vector iA;
            Vector iD;
            Vector iS;
            Vector R;
            Vector S;
            Vector Pm;
         

            for (int i = 0; i < 6; i++) {

                iA = new Vector();
                iA.X = iLa.X * ka.X;
                iA.Y = iLa.Y * ka.Y;
                iA.Z = iLa.Z * ka.Z;

                if (solid.VisibleFaces[i] == false) {
                    solid.FlatColor[i] = null;
                    continue;
                }
                    

                iD = new Vector(0,0,0);
                iS = new Vector(0,0,0);
                Vector N = solid.NormalFaces[i];
                Pm = new Vector();
                Pm.X = (solid.Points[0, solid.Faces[i, 0]] + solid.Points[0, solid.Faces[i, 2]]) / 2;
                Pm.Y = (solid.Points[1, solid.Faces[i, 0]] + solid.Points[1, solid.Faces[i, 2]]) / 2;
                Pm.Z = (solid.Points[2, solid.Faces[i, 0]] + solid.Points[2, solid.Faces[i, 2]]) / 2;
                L = new Vector(L.X - Pm.X, L.Y - Pm.Y, L.Z - Pm.Z);
                L = MathOperations.NormalizeVector(L);
                double value = MathOperations.DotProduct(N, L);

                if (value > 0) {
                    iD.X = iL.X * kd.X * value;
                    iD.Y = iL.Y * kd.Y * value;
                    iD.Z = iL.Z * kd.Z * value;

                    R = new Vector();
                    R.X = (2 * value * N.X) - L.X;
                    R.Y = (2 * value * N.Y) - L.Y;
                    R.Z = (2 * value * N.Z) - L.Z;

                    S = new Vector();

                    S.X = VRP.X - Pm.X;
                    S.Y = VRP.Y - Pm.Y;
                    S.Z = VRP.Z - Pm.Z;
                    S = MathOperations.NormalizeVector(S);

                    double value2 = Math.Pow(MathOperations.DotProduct(R, S), n);
                    iS.X = iL.X * ks.X * value2;
                    iS.Y = iL.Y * ks.Y * value2;
                    iS.X = iL.Z * ks.Z * value2;
                }
                
                iT = new Vector();
                iT.X = iA.X + iD.X + iS.X;
                iT.Y = iA.Y + iD.Y + iS.Y;
                iT.Z = iA.Z + iD.Z + iS.Z;

  
                solid.FlatColor[i] = new Vector(iT.X, iT.Y, iT.Z);
            }
        }

    }
}
