using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Utils;

namespace WpfApplication1.Model {
    internal class Polygon {
        private List<Edge> _edges;
        private short _faceNumber; // 1 - Front, 2 - Top, 3 - Right, 4 - Left, 5 - Botton, 6 - Back
        private Vector _normalVector;


        public Vector NormalVector {
            get { return _normalVector; }
            set { _normalVector = value; }
        }


        public short FaceNumber {
            get { return _faceNumber; }
            set { _faceNumber = value; }
        }


        public List<Edge> Edges {
            get { return _edges; }
            set { _edges = value; }
        }

        public Polygon() {
            _edges = new List<Edge>();
        }

        public void AddEdge(Edge e) {
            _edges.Add(e);
        }

        public void SetNormalVector() {
            var a = _edges[0].FinishVector - _edges[0].StartVector;
            var b = _edges[3].StartVector - _edges[3].FinishVector;
            
            
            NormalVector = MatrixOperations.CrossProduct(a, b);
        }
    }
}
