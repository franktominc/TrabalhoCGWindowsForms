using System;
using TrabalhoCGWindowsForms.Utils;

namespace TrabalhoCGWindowsForms.Model {
    class Solid {

        private double[,] _points;
        private int[,] _edges;
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public Vector Faces { get; private set; }

        public int[,] Edges {
            get { return _edges; }
            set { _edges = value; }

        }
        public double[,] Points{
            get { return _points; }
            set { _points = value; }
        }
        public Solid() {
            Faces = new Vector(0,0,0);
            _points = new double[,] {
                {0,0,50,1},
                {50,0,50,1},
                {50,50,50,1},
                {0,50,50,1},
                {0,0,0,1},
                {50,0,0,1},
                {50,50,0,1},
                {0,50,0,1},
                {25,25,25,1}
            };
            _edges=new[,] {
                {0,1},
                {1,2},
                {2,3},
                {3,0},
                {1,5},
                {5,6},
                {6,2},
                {5,4},
                {4,7},
                {7,6},
                {4,0},
                {3,7}
            };
            
            
            _points = MatrixOperations.TransposeMatrix(_points);
        }

        

        public void XAxisRotation(float angle) {
            const double toRadian = Math.PI/180;
            var y = Points[1, 8];
            var z = Points[2, 8];
            var cosTheta = Math.Cos(angle*toRadian);
            var sinTheta = Math.Sin(angle*toRadian);
            var matrix = new[,]{
                {1, 0, 0, 0}, {0, cosTheta, -sinTheta, y - y*cosTheta + z*sinTheta},
                {0, sinTheta, cosTheta, z - z*cosTheta - y*sinTheta}, {0, 0, 0, 1}
            };
            Points = MatrixOperations.MatrixMultiplication(matrix, Points);
        }

        public void YAxisRotation(float angle) {
            const double toRadian = Math.PI/180;
            var x = Points[0, 8];
            var z = Points[2, 8];
            var cosTheta = Math.Cos(angle*toRadian);
            var sinTheta = Math.Sin(angle*toRadian);
            var matrix = new[,] {
                {cosTheta, 0, sinTheta, x - x*cosTheta - z*sinTheta}, {0, 1, 0, 0},
                {-sinTheta, 0, cosTheta, z - z*cosTheta + x*sinTheta}, {0, 0, 0, 1}
            };
            Points = MatrixOperations.MatrixMultiplication(matrix, Points);
        }

        public void ZAxisRotation(float angle) {
            const double toRadian = Math.PI/180;
            var x = Points[0, 8];
            var y = Points[1, 8];
            var cosTheta = Math.Cos(angle*toRadian);
            var sinTheta = Math.Sin(angle*toRadian);
            var matrix = new[,] {
                {cosTheta, -sinTheta, 0, x - x*cosTheta + y*sinTheta}, {sinTheta, cosTheta, 0, y - y*cosTheta - x*sinTheta},
                {0, 0, 1, 0}, {0, 0, 0, 1}
            };
            Points = MatrixOperations.MatrixMultiplication(matrix, Points);
        }

        public void ZScale(double k) {
            var z = Points[2, 8];
            var matrix = new[,] {{1, 0, 0, 0}, {0, 1, 0, 0}, {0, 0, k, z - k*z}, {0, 0, 0, 1}};
            Points = MatrixOperations.MatrixMultiplication(matrix, Points);
        }

        public void Translation(double x, double y, double z) {
            Points = MatrixOperations.MatrixMultiplication(MatrixOperations.Translation(x, y, z), Points);
        }

        /*
        public double[,] GeraCubo() {

            var a = new Vector(0, 0, 1);
            var b = new Vector(1, 0, 1);
            var c = new Vector(1, 1, 1);
            var d = new Vector(0, 1, 1);
            var ee = new Vector(0, 0, 0);
            var f = new Vector(1, 0, 0);
            var g = new Vector(1, 1, 0);
            var h = new Vector(0, 1, 0);

            var A = new Edge(a, b);
            var B = new Edge(b, c);
            var C = new Edge(c, d);
            var D = new Edge(d, a);
            var E = new Edge(f, ee);
            var F = new Edge(ee, h);
            var G = new Edge(h, g);
            var H = new Edge(g, f);
            var I = new Edge(b, f);
            var J = new Edge(g, c);
            var K = new Edge(ee, a);
            var L = new Edge(d, h);

            var P1 = new Model.Polygon();
            P1.AddEdge(A);
            P1.AddEdge(B);
            P1.AddEdge(C);
            P1.AddEdge(D);
            P1.FaceNumber = 1;
            var P2 = new Model.Polygon();
            P2.AddEdge(C);
            P2.AddEdge(L);
            P2.AddEdge(G);
            P2.AddEdge(J);
            P2.FaceNumber = 2;
            var P3 = new Model.Polygon();
            P3.AddEdge(B);
            P3.AddEdge(J);
            P3.AddEdge(H);
            P3.AddEdge(I);
            P3.FaceNumber = 3;
            var P4 = new Model.Polygon();
            P4.AddEdge(D);
            P4.AddEdge(K);
            P4.AddEdge(F);
            P4.AddEdge(L);
            P4.FaceNumber = 4;
            var P5 = new Model.Polygon();
            P5.AddEdge(E);
            P5.AddEdge(I);
            P5.AddEdge(A);
            P5.AddEdge(K);
            P5.FaceNumber = 5;
            var P6 = new Model.Polygon();
            P6.AddEdge(H);
            P6.AddEdge(E);
            P6.AddEdge(F);
            P6.AddEdge(G);
            P6.FaceNumber = 6;

            var solid = new Solid();
            solid.addPolygon(P1);
            solid.addPolygon(P2);
            solid.addPolygon(P3);
            solid.addPolygon(P4);
            solid.addPolygon(P5);
            solid.addPolygon(P6);
            var x = solid.AsMatrix();
            return x;
        }
        */
    }
}
