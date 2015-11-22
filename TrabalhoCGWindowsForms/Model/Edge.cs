using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model {
    class Edge {
        private Vector _start;
        private Vector _finish;
        

        public Vector FinishVector {
            get { return _finish; }
            set { _finish = value; }
        }

        public Vector StartVector {
            get { return _start; }
            set { _start = value; }
        }

        public Edge() {
        }

        public Edge(Vector start, Vector finish) {
            _start = start;
            _finish = finish;
        }

    }
}
