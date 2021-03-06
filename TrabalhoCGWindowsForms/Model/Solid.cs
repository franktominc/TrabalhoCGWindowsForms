﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using TrabalhoCGWindowsForms.Utils;

namespace TrabalhoCGWindowsForms.Model {
    [Serializable]
    public class Solid : ICloneable{

        private double[,] _points;  //vertices do solido
        private int[,] _edges;  //arestas do solido
        public int[,] Faces { get; private set; }   //faces do solido

        public int[,] Edges {
            get { return _edges; }
            set { _edges = value; }

        }
        private bool[] _visibleFaces = {    //bitmap de faces visiveis
            false,
            false,
            false,
            false,
            false,
            false
        };

        private Vector[] normalFaces = new Vector[6];

        public Vector[] NormalFaces {
            get { return normalFaces; }
            set { normalFaces = value; }
        }

        

        public bool[] VisibleFaces {
            get { return _visibleFaces; }
            set { _visibleFaces = value; }
        }

        public double[,] Points {
            get { return _points; }
            set { _points = value; }
        }
        private Vector[] flatColor;

        public Vector[] FlatColor {
            get { return flatColor; }
            set { flatColor = value; }
        }

        private Vector _ka;

        public Vector Ka{
            get { return _ka; }
            set { _ka = value; }
        }

        private Vector _kd;

        public Vector Kd {
            get { return _kd; }
            set { _kd = value; }
        }

        private Vector _ks;

        public Vector Ks {
            get { return _ks; }
            set { _ks = value; }
        }

        private int n;

        public int N {
            get { return n; }
            set { n = value; }
        }
        
        
        public Solid() {    //cria um solido padrao
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
            _edges = new[,] {
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
            Faces = new[,] {
                {0,1,2,3},
                {1,5,6,2},
                {5,4,7,6},
                {0,3,7,4},
                {3,2,6,7},
                {0,4,5,1}
            };

            FlatColor = new Vector[6];
            _points = MathOperations.TransposeMatrix(_points);

            _ka = new Vector(0.3, 0.5, 0.2);
            _ks = new Vector(0.9, 0.4, 0.1);
            _kd = new Vector(0.1, 0.8, 0.3);
            n = 4;
        }

        public void XAxisRotation(double angle, double y, double z) {    //rotaciona o solido em torno do eixo x
            const double toRadian = Math.PI / 180;
            var cosTheta = Math.Cos(angle * toRadian);
            var sinTheta = Math.Sin(angle * toRadian);
            var matrix = new[,]{
                {1, 0, 0, 0}, {0, cosTheta, -sinTheta, y - y*cosTheta + z*sinTheta},
                {0, sinTheta, cosTheta, z - z*cosTheta - y*sinTheta}, {0, 0, 0, 1}
            };
            Points = MathOperations.MatrixMultiplication(matrix, Points);
        }

        public void YAxisRotation(double angle, double x, double z) {    //rotaciona o solido em torno do eixo y
            const double toRadian = Math.PI / 180;
            var cosTheta = Math.Cos(angle * toRadian);
            var sinTheta = Math.Sin(angle * toRadian);
            var matrix = new[,] {
                {cosTheta, 0, sinTheta, x - x*cosTheta - z*sinTheta}, {0, 1, 0, 0},
                {-sinTheta, 0, cosTheta, z - z*cosTheta + x*sinTheta}, {0, 0, 0, 1}
            };
            Points = MathOperations.MatrixMultiplication(matrix, Points);
        }

        public void ZAxisRotation(double angle, double x, double y) {    //rotaciona o solido em torno do eixo z
            const double toRadian = Math.PI / 180;
            var cosTheta = Math.Cos(angle * toRadian);
            var sinTheta = Math.Sin(angle * toRadian);
            var matrix = new[,] {
                {cosTheta, -sinTheta, 0, x - x*cosTheta + y*sinTheta}, {sinTheta, cosTheta, 0, y - y*cosTheta - x*sinTheta},
                {0, 0, 1, 0}, {0, 0, 0, 1}
            };
            Points = MathOperations.MatrixMultiplication(matrix, Points);
        }

        public void ZScale(double k) {  //escala em z
            var z = Points[2, 8];
            var matrix = new[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, k, z - k * z }, { 0, 0, 0, 1 } };
            Points = MathOperations.MatrixMultiplication(matrix, Points);
        }

        public void Translation(double x, double y, double z) {     //transalada o solido
            Points = MathOperations.MatrixMultiplication(MathOperations.Translation(x, y, z), Points);
        }

        public void ComputeVisibility(Vector vrp, Vector P =null) {     //processa cada face e determina sua visibilidade
            var n = new Vector();   //vetor vrp - p
            n.X = vrp.X - (P == null?Points[0, 8]:P.X);
            n.Y = vrp.Y - (P == null?Points[1, 8]:P.Y);
            n.Z = vrp.Z - (P == null?Points[2, 8]:P.Z);
            n = MathOperations.NormalizeVector(n);
            for (int i = 0; i < 6; i++) {   //processa as faces uma a uma
                var vec1 = new Vector(_points[0, Faces[i, 1]] - _points[0, Faces[i, 0]],
                    _points[1, Faces[i, 1]] - _points[1, Faces[i, 0]],
                    _points[2, Faces[i, 1]] - _points[2, Faces[i, 0]]);    //vetor 1 da face
                var vec2 = new Vector(_points[0, Faces[i, 2]] - _points[0, Faces[i, 1]],
                    _points[1, Faces[i, 2]] - _points[1, Faces[i, 1]],
                    _points[2, Faces[i, 2]] - _points[2, Faces[i, 1]]);    //vetor 2 da face
                var face = MathOperations.CrossProduct(vec1, vec2);    //vetor normal a face
               
                face = MathOperations.NormalizeVector(face);

                var visibilityK = MathOperations.DotProduct(face, n);   //coeficiente de visibilidade
                if (visibilityK > 0) {
                    _visibleFaces[i] = true;
                    normalFaces[i] = face;
                } else {
                    _visibleFaces[i] = false;
                    normalFaces[i] = face;
                }

            }
        }

        public object Clone() {
            var ms = new MemoryStream();
            var bf = new BinaryFormatter();

            bf.Serialize(ms, this);

            ms.Position = 0;
            object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }
}
