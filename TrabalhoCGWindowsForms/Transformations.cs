using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TrabalhoCGWindowsForms.Model;
using TrabalhoCGWindowsForms.Utils;


namespace TrabalhoCGWindowsForms {
    public partial class MainView {
        public async void Rotation(int view) {
            if (selectedGuy < 0) return;
            var atual = new Point(Cursor.Position.X, Cursor.Position.Y);
            var desloc = new Point();
            while (amIRotating) {
                var antigo = atual;
                atual = Cursor.Position;
                desloc.X = atual.X - antigo.X;
                desloc.Y = atual.Y - antigo.Y;


                var mid = MathOperations.MidPoint(solidsList[selectedGuy]);

                foreach (var solid in solidsList[selectedGuy]) {
                    switch (view) {
                        case 0:     //Top View
                            solid.XAxisRotation(desloc.Y, mid.Y, mid.Z);
                            solid.ZAxisRotation(desloc.X, mid.X, mid.Y);
                            break;
                        case 1:     //Front View
                            solid.XAxisRotation(desloc.Y, mid.Y, mid.Z);
                            solid.YAxisRotation(desloc.X, mid.X, mid.Z);
                            break;
                        case 2:     //Left View
                            solid.YAxisRotation(desloc.X, mid.X, mid.Z);
                            solid.ZAxisRotation(desloc.Y, mid.X, mid.Y);
                            break;
                    }
                }

                DrawSolids();

                await Task.Delay(1);
            }
        }

        public async void Translation(int view) {
            var atual = new Point(Cursor.Position.X, Cursor.Position.Y);
            var desloc = new Point();
            while (amITranslating) {
                var antigo = atual;
                atual = Cursor.Position;
                desloc.X = atual.X - antigo.X;
                desloc.Y = atual.Y - antigo.Y;
                if (selectedGuy >= 0) {
                    foreach (var solid in solidsList[selectedGuy]) {
                        switch (view) {
                            case 0:     //Top View
                                solid.Translation(desloc.X, 0, desloc.Y);
                                break;
                            case 1:     //Front View
                                solid.Translation(desloc.X, desloc.Y, 0);
                                break;
                            case 2:     //Left View
                                solid.Translation(0, desloc.Y, desloc.X);
                                break;
                        }

                    }
                    DrawSolids();
                }
                await Task.Delay(1);
            }
        }

        private void PerspectiveTransformation() {

            #region Camera Transformations
            perspectiveSolidList = solidsList.Clone();
            var bigN = new Vector {
                X = VRP.X - P.X,
                Y = VRP.Y - P.Y,
                Z = VRP.Z - P.Z
            };
            var n = MathOperations.NormalizeVector(bigN);

            var n1 = new Vector();
            var aux = MathOperations.DotProduct(Y, n);
            n1.X = aux * n.X;
            n1.Y = aux * n.Y;
            n1.Z = aux * n.Z;
            var v = new Vector(Y.X - n1.X, Y.Y - n1.Y, Y.Z - n1.Z);
            v = MathOperations.NormalizeVector(v);

            var u = new Vector();
            u = MathOperations.CrossProduct(v, n);

            var M = new double[,] {
                {u.X, u.Y, u.Z, -1*MathOperations.DotProduct(VRP, u)},
                {v.X, v.Y, v.Z, -1*MathOperations.DotProduct(VRP, v)},
                {n.X, n.Y, n.Z, -1*MathOperations.DotProduct(VRP, n)},
                {0,0,0,1}
            };

            foreach (var solid in perspectiveSolidList.SelectMany(t => t)) {
                solid.Points = M.Multiply(solid.Points);
            }
            #endregion

            var dp = Math.Sqrt(Math.Pow(VRP.X - P.X, 2) +
                               Math.Pow(VRP.Y - P.Y, 2) +
                               Math.Pow(VRP.Z - P.Z, 2));
            //Transformacao perspectiva
            var perspecMatrix = new double[,] {
                {1,0,0,0},
                {0,1,0,0},
                {0,0,1,0},
                {0,0,-1/(dp*alpha/100.0),0},
            };
            foreach (var solid in perspectiveSolidList.SelectMany(t => t)) {
                solid.Points = MathOperations.MatrixMultiplication(perspecMatrix, solid.Points);
                for (var i = 0; i < solid.Points.GetLength(0); i++) {
                    for (var j = 0; j < solid.Points.GetLength(1); j++) {
                        solid.Points[i, j] /= solid.Points[solid.Points.GetLength(0) - 1, j];
                    }
                }
            }

        }

        private void IsometricTransformation() {
            //Coordenadas de tela

            perspectiveSolidList = solidsList.Clone();
            Vector bigN = new Vector();
            bigN.X = VRPiso.X;
            bigN.Y = VRPiso.Y;
            bigN.Z = VRPiso.Z;
            Vector n = MathOperations.NormalizeVector(bigN);


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
            foreach (var solid in perspectiveSolidList.SelectMany(t => t)) {
                solid.Points = MathOperations.MatrixMultiplication(M, solid.Points);
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
                iA.X = iLa.X * solid.Ka.X;
                iA.Y = iLa.Y * solid.Ka.Y;
                iA.Z = iLa.Z * solid.Ka.Z;

                if (solid.VisibleFaces[i] == false) {
                    solid.FlatColor[i] = null;
                    continue;
                }


                iD = new Vector(0, 0, 0);
                iS = new Vector(0, 0, 0);
                Vector N = solid.NormalFaces[i];
                Pm = new Vector();
                Pm.X = (solid.Points[0, solid.Faces[i, 0]] + solid.Points[0, solid.Faces[i, 2]]) / 2;
                Pm.Y = (solid.Points[1, solid.Faces[i, 0]] + solid.Points[1, solid.Faces[i, 2]]) / 2;
                Pm.Z = (solid.Points[2, solid.Faces[i, 0]] + solid.Points[2, solid.Faces[i, 2]]) / 2;
                L = new Vector(L.X - Pm.X, L.Y - Pm.Y, L.Z - Pm.Z);
                L = MathOperations.NormalizeVector(L);
                double value = MathOperations.DotProduct(N, L);

                if (value > 0) {
                    iD.X = iL.X * solid.Kd.X * value;
                    iD.Y = iL.Y * solid.Kd.Y * value;
                    iD.Z = iL.Z * solid.Kd.Z * value;

                    R = new Vector();
                    R.X = (2 * value * N.X) - L.X;
                    R.Y = (2 * value * N.Y) - L.Y;
                    R.Z = (2 * value * N.Z) - L.Z;

                    S = new Vector();

                    S.X = VRP.X - Pm.X;
                    S.Y = VRP.Y - Pm.Y;
                    S.Z = VRP.Z - Pm.Z;
                    S = MathOperations.NormalizeVector(S);

                    double value2 = Math.Pow(MathOperations.DotProduct(R, S), solid.N);
                    iS.X = iL.X * solid.Ks.X * value2;
                    iS.Y = iL.Y * solid.Ks.Y * value2;
                    iS.X = iL.Z * solid.Ks.Z * value2;
                }

                iT = new Vector();
                iT.X = iA.X + iD.X + iS.X;
                iT.Y = iA.Y + iD.Y + iS.Y;
                iT.Z = iA.Z + iD.Z + iS.Z;


                solid.FlatColor[i] = new Vector(iT.X, iT.Y, iT.Z);
            }
        }

        /*public Color[,] ZBuffer(int view, PictureBox pc) {
            var zBufferArray = new int[pc.Width,pc.Height];
            var colorArray = new Color[pc.Width,pc.Height];

            Console.Write("{0} {1}",pc.Height,pc.Width);

            zBufferArray.Fill(int.MinValue);
            colorArray.Fill(pc.BackColor);

            var x = 0;
            var y = 0;
            
            foreach (var solid in perspectiveSolidList.SelectMany(solidList => solidList)) {
                switch (view) {
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
                            solid.ComputeVisibility(new Vector(0, 0, 1), new Vector(0, 0, 0));
                        }
                        else {
                            solid.ComputeVisibility(VRP, P);
                        }
                        break;
                   }
                for (var i = 0; i < 6; i++) {
                    var d = 0.0;
                    if (!solid.VisibleFaces[i]) continue;
                    Console.WriteLine("text");
                    d = MathOperations.DotProduct(solid.NormalFaces[i], new Vector(solid.Points[0, solid.Faces[i, 0]],
                                                                                           solid.Points[1 ,solid.Faces[i, 0]],
                                                                                           solid.Points[2, solid.Faces[i, 0]]));
                    d *= -1;
          
                    int yMenor = DecideMid(solid.Points[1,solid.Faces[i, 0]], 
                                          solid.Points[1,solid.Faces[i, 1]], 
                                          solid.Points[1,solid.Faces[i, 2]], 
                                          solid.Points[1,solid.Faces[i, 3]]);

                    Vector mid = new Vector((int)solid.Points[0, solid.Faces[i, yMenor]], 
                                            (int)solid.Points[1, solid.Faces[i, yMenor]], 
                                            (int)solid.Points[2, solid.Faces[i, yMenor]]);

                    Vector prev = new Vector((int)solid.Points[0, solid.Faces[i, (yMenor + 1) % 4]], 
                                             (int)solid.Points[1, solid.Faces[i, (yMenor + 1) % 4]], 
                                             (int)solid.Points[2, solid.Faces[i,  (yMenor + 1) % 4]]);

                    Vector next = new Vector((int)solid.Points[0, solid.Faces[i, (yMenor - 1 < 0 ? 3 : yMenor - 1)]], 
                                             (int)solid.Points[1, solid.Faces[i,  (yMenor - 1 < 0 ? 3 : yMenor - 1)]], 
                                             (int)solid.Points[2, solid.Faces[i, (yMenor - 1 < 0 ? 3 : yMenor - 1)]]);

                    Vector end = new Vector( (int)solid.Points[0, solid.Faces[i, (yMenor + 2) % 4]], 
                                             (int)solid.Points[1, solid.Faces[i, (yMenor + 2) % 4]], 
                                             (int)solid.Points[2, solid.Faces[i, (yMenor + 2) % 4]]);

                    double deltaX1 = -GetDelta(mid.X, prev.X, prev.Y, mid.Y);
                    double deltaX2 = GetDelta(next.X, mid.X, next.Y, mid.Y);

                    switch (view) {
                        case 0: //Top View
                            
                            break;
                        case 3: //Perspective
                        case 1: //Front View
                            int k1 = 0;
                            int k2 = 0;
                            while (mid.Y < end.Y) {
                                if (mid.Y >= prev.Y) {
                                    deltaX1 = GetDelta(prev.X, end.X, prev.Y, end.Y);
                                    k1 = 0;
                                }
                                if (mid.Y >= next.Y) {
                                    deltaX2 = GetDelta(next.X, end.X, next.Y, end.Y);
                                    k2 = 0;
                                }
                                for (int j = (int)(mid.X+k1*deltaX1); j < mid.X+k2*deltaX2; j++) {
                                    int z = (int) ((-d - solid.NormalFaces[i].X*j -
                                            solid.NormalFaces[i].Y*mid.Y)/solid.NormalFaces[i].Z);
                                    Console.WriteLine(z);
                                    if (!(z > zBufferArray[(int) mid.Y, j])) {
                                        continue;
                                    }
                                    zBufferArray[(int) mid.Y, j] = z;
                                    //calcula cor
                                    colorArray[(int) mid.Y, j] = Color.Chocolate;
                                }
                                k1++;
                                k2++;
                                mid.Y++;
                            }
                            

                            break;
                        case 2: //Left View
                            
                            break;
                    }
                }
            }
            return colorArray;
        }*/

        public void ZBuffer(int view, PictureBox pc) {
            switch (view) {
                case 0 : //Top view
                    MapToScreen(0);
                    break;
                case 1 : //Front view
                    MapToScreen(1);

                    #region Truncamento
                    foreach (var list in perspectiveSolidList) {
                        foreach (var solid in list) {
                            for (int i = 0; i < solid.Points.GetLength(0); i++) {
                                for (int j = 0; j < solid.Points.GetLength(1); j++) {
                                    solid.Points[i, j] = (int) solid.Points[i, j];
                                }
                            }
                        }
                    }
                    #endregion

                    foreach (var solid in perspectiveSolidList.SelectMany(solidList => solidList)) {

                        solid.ComputeVisibility(new Vector(solid.Points[0, 8], solid.Points[1, 8], 1));

                        for (int i = 0; i < 6; i++) {
                            if (!solid.VisibleFaces[i]) continue;
                            int yMenor =
                                DecideMid(
                                    new Vector(solid.Points[0, solid.Faces[i, 0]], solid.Points[1, solid.Faces[i, 0]],
                                        solid.Points[2, solid.Faces[i, 0]]),
                                    new Vector(solid.Points[0, solid.Faces[i, 1]], solid.Points[1, solid.Faces[i, 1]],
                                        solid.Points[2, solid.Faces[i, 1]]),
                                    new Vector(solid.Points[0, solid.Faces[i, 2]], solid.Points[1, solid.Faces[i, 2]],
                                        solid.Points[2, solid.Faces[i, 2]]),
                                    new Vector(solid.Points[0, solid.Faces[i, 3]], solid.Points[1, solid.Faces[i, 3]],
                                        solid.Points[2, solid.Faces[i, 3]]));

                            Vector mid = new Vector((int)solid.Points[0, solid.Faces[i, yMenor]],
                                (int)solid.Points[1, solid.Faces[i, yMenor]],
                                (int)solid.Points[2, solid.Faces[i, yMenor]]);

                            Vector prev = new Vector((int)solid.Points[0, solid.Faces[i, (yMenor + 1) % 4]],
                                (int)solid.Points[1, solid.Faces[i, (yMenor + 1) % 4]],
                                (int)solid.Points[2, solid.Faces[i, (yMenor + 1) % 4]]);

                            Vector next = new Vector((int)solid.Points[0, solid.Faces[i, (yMenor - 1 < 0 ? 3 : yMenor - 1)]],
                                    (int)solid.Points[1, solid.Faces[i, (yMenor - 1 < 0 ? 3 : yMenor - 1)]],
                                    (int)solid.Points[2, solid.Faces[i, (yMenor - 1 < 0 ? 3 : yMenor - 1)]]);

                            Vector end = new Vector((int)solid.Points[0, solid.Faces[i, (yMenor + 2) % 4]],
                                (int)solid.Points[1, solid.Faces[i, (yMenor + 2) % 4]],
                                (int)solid.Points[2, solid.Faces[i, (yMenor + 2) % 4]]);


                            double deltaX1 = 0;
                            double deltaX2 = 0;
                            double deltaZ1 = 0;
                            double deltaZ2 = 0;

                            if (!(mid.Y == prev.Y)) {
                                deltaX1 = GetDelta(mid.X, prev.X, mid.Y, prev.Y);
                                deltaZ1 = GetDelta(mid.Z, prev.Z, mid.Y, prev.Y);
                            }
                            if (!(mid.Y == next.Y)) {
                                deltaX2 = GetDelta(mid.X, next.X, mid.Y, next.Y);
                                deltaZ2 = GetDelta(mid.Z, next.Z, mid.Y, next.Y);
                            }
                            
                            Console.WriteLine("Delta x1: {0}", deltaX1);
                            Console.WriteLine("Delta z1: {0}", deltaZ1);
                            Console.WriteLine("Delta x2: {0}", deltaX2);
                            Console.WriteLine("Delta z2: {0}", deltaZ2);

                            
                            
                            int k1 = 1;
                            int k2 = 1;


                            for (int w = 0; w < (int)(end.Y-mid.Y); w++) {
                                Vector ponto1 = new Vector(mid.X+k1*deltaX1, mid.Y+k1, mid.Z+k1*deltaZ1); //MID TO PREV
                                Vector ponto2 = new Vector(mid.X+k2*deltaX2, mid.Y+k2, mid.Z+k2*deltaZ2); //MID TO NEXT

                                if (prev.Y - mid.Y == k1) {
                                    k1 = 0;
                                    deltaX1 = GetDelta(end.X, prev.X, end.Y, prev.Y);
                                    deltaZ1 = GetDelta(end.Z, prev.Z, end.Y, prev.Y);
                                }

                                if (next.Y - mid.Y == k2) {
                                    k2 = 0;
                                    deltaX2 = GetDelta(end.X, next.X, end.Y, next.Y);
                                    deltaZ2 = GetDelta(end.Z, next.Z, end.Y, next.Y);
                                }
                                double a = ponto1.X;
                                double b = ponto2.X;
                                Console.Write("Ponto1 ");
                                Console.WriteLine(a);
                                Console.Write("Ponto2 ");
                                Console.WriteLine(b);
                                Console.Write("Distancia ");
                                double distancia = a - b;
                                Console.WriteLine(distancia);

                                for (int j = (int)(ponto1.X - ponto2.X); j >= 0; j--) {
                                    Vector pontoCur = new Vector(ponto2.X+j, mid.Y+w, ((ponto1.Z - ponto2.Z)/(ponto1.X - ponto2.X)) * j + ponto2.Z);
                                    var g = Graphics.FromImage(pc.Image);
                                    g.SmoothingMode = SmoothingMode.AntiAlias;
                                    g.FillRectangle(new SolidBrush(Color.FromArgb(j,0,0)), (int)pontoCur.X, (int)pontoCur.Y, 1, 1);
                                }
                                k1++;
                                k2++;
                            }
                        }
                    }
                    break;

                case 2 : //Left view
                    MapToScreen(2);
                    break;
                case 3 : //Perspective
                    MapToScreen(3);
                    break;
            }
            
        }

        public double GetDelta(double xF, double xI, double yF, double yI) {
            return ((xF - xI)/(yF - yI));
        }

        public int DecideMid(Vector ponto1, Vector ponto2, Vector ponto3, Vector ponto4) {

            Vector[] aux = new Vector[]{ponto1, ponto2, ponto3, ponto4};
            int menor = (int)aux[0].Y;
            int j = 0;
            //Pega o menor
            for (int i = 0; i < 4; i++) {
                if (aux[i].Y < menor) {
                    menor = (int)aux[i].Y;
                    j = i;
                }
            }

            //Teste se alguem eh igual
            for (int i = 0; i < 4; i++) {
                if (aux[i].Y == menor && j != i) {
                    if (aux[i].X < aux[j].X)
                        return i;
                }
            }
            return j;
            /*if (ponto1.Y.CompareTo(ponto2.Y) <= 0) {
                if (ponto3.Y.CompareTo(ponto4) <= 0) {
                    return ponto1.Y <= ponto3.Y ? 0 : 2;
                }
                return ponto1.Y <= ponto4.Y ? 0 : 3;
            }
            if (ponto3.Y.CompareTo(ponto4) <= 0) {
                return ponto2.Y <= ponto3.Y ? 1 : 2;
            }
            return ponto2.Y <= ponto4.Y ? 1 : 3;*/

        }

        public void MapToScreen(int i) {
            switch (i) {
                case 0:
                    perspectiveSolidList = solidsList.Clone();
                    foreach (var solid in perspectiveSolidList.SelectMany(list => list)) {
                        solid.Points = MathOperations.ConvertToCamera(solid.Points, new Vector(0, 100, 0),
                            new Vector(0, 0, 0));
                        solid.Points = MathOperations.SRTMatrix(topView.Width,0,topView.Height, 0, xMax, xMin, yMax, yMin).Multiply(solid.Points);
                    }
                    break;
                case 1:
                    perspectiveSolidList = solidsList.Clone();
                    foreach (var solid in perspectiveSolidList.SelectMany(list => list)) {
                        solid.Points = MathOperations.ConvertToCamera(solid.Points, new Vector(0, 0, 100),
                            new Vector(0, 0, 0));
                        solid.Points = MathOperations.SRTMatrix(frontView.Width,0,frontView.Height, 0, xMax, xMin, yMax, yMin).Multiply(solid.Points);
                    }
                    break;
                case 2:
                    perspectiveSolidList = solidsList.Clone();
                    foreach (var solid in perspectiveSolidList.SelectMany(list => list)) {
                        solid.Points = MathOperations.ConvertToCamera(solid.Points, new Vector(100, 0, 0),
                            new Vector(0, 0, 0));
                        solid.Points = MathOperations.SRTMatrix(leftView.Width, 0, leftView.Height, 0, xMax, xMin, yMax, yMin).Multiply(solid.Points);
                    }
                    break;
                case 3:
                    perspectiveSolidList = solidsList.Clone();
                    PerspectiveTransformation();
                    foreach (var solid in perspectiveSolidList.SelectMany(list => list)) {
                        solid.Points = MathOperations.SRTMatrix(perspectiveBox.Width, 0, perspectiveBox.Height, 0, xMax, xMin, yMax, yMin).Multiply(solid.Points);
                    }
                    break;
            }
        }
    }
}
