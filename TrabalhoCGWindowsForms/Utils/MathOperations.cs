using System;
using System.Collections.Generic;
using System.Linq;
using TrabalhoCGWindowsForms.Model;

namespace TrabalhoCGWindowsForms.Utils {
    public static class MathOperations {

        public static double[,] MatrixMultiplication(double[,] a, double[,] b) { 

            var c = new double[a.GetLength(0), b.GetLength(1)];
            var la = a.GetLength(0);    //linha da matriz a
            var ca = a.GetLength(1);    //coluda da matriz a
            var lb = b.GetLength(0);    //linha da matriz b
            var cb = b.GetLength(1);    //coluna da matriz b
            if (ca != lb) {
                Console.WriteLine(@"As matrizes possuem dimensoes incompativeis");
            }
            for (var i = 0; i < la; i++) {
                for (var j = 0; j < cb; j++) {
                    c[i, j] = 0;
                    for (var k = 0; k < ca; k++) {
                        c[i, j] = c[i, j] + (a[i, k] * b[k, j]);
                    }
                }
            }
            return c;
        }
        public static double[,] Multiply(this double[,] a, double[,] b) {

            var c = new double[a.GetLength(0), b.GetLength(1)];
            var la = a.GetLength(0);    //linha da matriz a
            var ca = a.GetLength(1);    //coluda da matriz a
            var lb = b.GetLength(0);    //linha da matriz b
            var cb = b.GetLength(1);    //coluna da matriz b
            if (ca != lb) {
                Console.WriteLine(@"As matrizes possuem dimensoes incompativeis");
            }
            for (var i = 0; i < la; i++) {
                for (var j = 0; j < cb; j++) {
                    c[i, j] = 0;
                    for (var k = 0; k < ca; k++) {
                        c[i, j] = c[i, j] + (a[i, k] * b[k, j]);
                    }
                }
            }
            return c;
        }

        public static double[,] Translation(double x, double y, double z) {
            return new[,] { { 1, 0, 0, x }, { 0, 1, 0, y }, { 0, 0, 1, z }, { 0, 0, 0, 1 } };
        }

        public static Vector NormalizeVector(Vector x) {
            var module = Math.Sqrt(x.X * x.X + x.Y * x.Y + x.Z * x.Z);
            return new Vector(x.X / module, x.Y / module, x.Z / module);
        }

        public static Vector CrossProduct(Vector a, Vector b) {
            var x = new Vector(a.Y * b.Z - a.Z * b.Y,
                                  a.Z * b.X - b.Z * a.X,
                                  a.X * b.Y - a.Y * b.X);
            x = NormalizeVector(x);
            return x;
        }

        public static double DotProduct(Vector a, Vector b) {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        public static double[,] TransposeMatrix(double[,] a) {
            var aux = new double[a.GetLength(1), a.GetLength(0)];
            for (var i = 0; i < aux.GetLength(0); i++) {
                for (var j = 0; j < aux.GetLength(1); j++) {
                    aux[i, j] = a[j, i];
                }
            }
            return aux;
        }

        public static Vector MidPoint(List<Solid> solids) { //Calcula o ponto medio entre os solidos agrupados
            var sumX = 0.0;
            var sumY = 0.0;
            var sumZ = 0.0;
            foreach (var solid in solids) {
                sumX += solid.Points[0, 8];
                sumY += solid.Points[1, 8];
                sumZ += solid.Points[2, 8];
            }
            return new Vector(sumX/solids.Count, sumY/solids.Count, sumZ/solids.Count);
        }
            
        public static void DebugMatrix(double[,] x) {
            for (var i = 0; i < x.GetLength(0); i++) {
                for (var j = 0; j < x.GetLength(1); j++) {
                    Console.Write(@"{0} ", x[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static List<List<Solid>> Clone(this List<List<Solid>> sourceList) {
            var result = new List<List<Solid>>();
            foreach (var innerList in sourceList) {
                var innerResult = new List<Solid>();
                foreach (Solid item in innerList) {
                    var clone = (Solid)(item.Clone());
                    innerResult.Add(clone);
                }

                result.Add(innerResult);
            }

            return result;
        }

        public static double[,] ConvertToCamera(double[,] pontos, Vector VRP, Vector P) {
            
            Vector bigN = new Vector();
            bigN.X = VRP.X - P.X;
            bigN.Y = VRP.Y - P.Y;
            bigN.Z = VRP.Z - P.Z;
            Vector vectorN = NormalizeVector(bigN);

            Vector Y = new Vector(0, 1, 0);
            Vector n1 = new Vector();
            double aux = DotProduct(Y, vectorN);
            n1.X = aux*vectorN.X;
            n1.Y = aux*vectorN.Y;
            n1.Z = aux*vectorN.Z;
            Vector v = new Vector(Y.X - n1.X, Y.Y - n1.Y, Y.Z - n1.Z);
            v = NormalizeVector(v);

            Vector u = new Vector();
            u = CrossProduct(v, vectorN);

            double[,] M = new double[,] {
                {u.X, u.Y, u.Z, -1*DotProduct(VRP, u)},
                {v.X, v.Y, v.Z, -1*DotProduct(VRP, v)},
                {vectorN.X, vectorN.Y, vectorN.Z, -1*DotProduct(VRP, vectorN)},
                {0, 0, 0, 1}
            };

            return MatrixMultiplication(M, pontos);
        }

        public static double[,] SRTMatrix(double uMax, double uMin, double vMax, double vMin, double xMax, double xMin,
            double yMax, double yMin) {
            return new double[,] {
                {(uMax-uMin)/(xMax-xMin), 0,0,(-xMin*((uMax-uMin)/(xMax-xMin)))+uMin}, 
                {0, (vMax-vMin)/(yMax-yMin), 0, (yMin*((vMax-vMin)/(yMax-yMin))+vMin)},
                {0,0,1,0},
                {0,0,0,1}
            };
        }
    }
}
