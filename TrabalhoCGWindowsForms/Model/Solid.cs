﻿using System;
using System.Xml;
using TrabalhoCGWindowsForms.Utils;

namespace TrabalhoCGWindowsForms.Model {
    [Serializable]
    class Solid {

        private double[,] _points;
        private int[,] _edges;
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int[,] Faces { get; private set; }

        public int[,] Edges {
            get { return _edges; }
            set { _edges = value; }

        }
        private bool[] _visibleFaces = {
            false,
            false,
            false,
            false,
            false,
            false
        };

        public bool[] VisibleFaces{
            get { return _visibleFaces; }
            set { _visibleFaces = value; }
        }

        public double[,] Points{
            get { return _points; }
            set { _points = value; }
        }
        public Solid() {
            
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
            Faces = new[,] {
                {0,1,2,3},
                {1,5,6,2},
                {5,4,7,6},
                {0,3,7,4},
                {3,2,6,7},
                {0,4,5,1}
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

        public void ComputeVisibility(Vector vrp) {
            var N = new Vector();
            N.X = vrp.X - Points[0, 8];
            N.Y = vrp.Y - Points[1, 8];
            N.Z = vrp.Z - Points[2, 8];
            N = MatrixOperations.NormalizeVector(N);
            //Console.WriteLine(@"VRP - P = {0},{1},{2}",N.X,N.Y,N.Z);
            Vector vec1;
            Vector vec2;
            for (int i = 0; i < 6; i++) {
                 vec1 = new Vector(_points[0, Faces[i, 1]] - _points[0, Faces[i, 0]],
                                  _points[1, Faces[i, 1]] - _points[1, Faces[i, 0]],
                                  _points[2, Faces[i, 1]] - _points[2, Faces[i, 0]]);
                 vec2 = new Vector(_points[0, Faces[i, 2]] - _points[0, Faces[i, 1]],
                                      _points[1, Faces[i, 2]] - _points[1, Faces[i, 1]],
                                      _points[2, Faces[i, 2]] - _points[2, Faces[i, 1]]);
                 var face = MatrixOperations.CrossProduct(vec1, vec2);
                 face = MatrixOperations.NormalizeVector(face);
                // Console.WriteLine("{0} {1} {2}", face.X, face.Y, face.Z);
                    
                 double flag = MatrixOperations.DotProduct(face, N);
                if (flag>0) {
                    _visibleFaces[i] = true;
                }
                else {
                    _visibleFaces[i] = false;
                }
                 //Console.WriteLine("{0} ", _visibleFaces[i]);
            }

            
                        
            

        }
    }
}
