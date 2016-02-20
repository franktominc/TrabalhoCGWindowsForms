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

namespace TrabalhoCGWindowsForms {
    public partial class MainView {

        public void ResetViews() {
            frontView.Image = new Bitmap(frontView.Width, frontView.Height);
            leftView.Image = new Bitmap(leftView.Width, leftView.Height);
            topView.Image = new Bitmap(topView.Width, topView.Height);
            perspectiveBox.Image = new Bitmap(perspectiveBox.Width, perspectiveBox.Height);
        }

        public void DrawSelectedSolid(Solid solid, Solid perspectiveSolid,Pen pen = null) {
            DrawSolidFaces(solid, topView, 0, pen);

            DrawSolidFaces(solid, frontView, 1, pen);

            DrawSolidFaces(solid, leftView, 2, pen);

            DrawSolidFaces(perspectiveSolid, perspectiveBox, 3, pen ?? new Pen(Color.Black, 1));
            
             
        }

        
        public void DrawSolids() {
            if (solidsList == null) return;

            ResetViews();

            if (isometricCheckBox.Checked) IsometricTransformation();
            else PerspectiveTransformation();


            for (var i = 0; i < solidsList.Count; i++) {
                for (var j = 0; j < solidsList[i].Count; j++) {

                    var normalSolid = solidsList[i][j];
                    var perspectiveSolid = perspectiveSolidList[i][j];

                    if (i == selectedGuy || selectedSolids.Contains(i)) {
                        DrawSelectedSolid(normalSolid, perspectiveSolid, new Pen(Color.Yellow, 1));
                    } else if (solidsList[i].Count > 1) {
                        DrawSelectedSolid(normalSolid, perspectiveSolid, new Pen(Color.Aquamarine, 1));
                    } else {
                        DrawSelectedSolid(normalSolid, perspectiveSolid);
                    }
                }
            }
            if (!flatBox.Checked) return;
            perspectiveBox.Image = new Bitmap(perspectiveBox.Width, perspectiveBox.Height);

            foreach (var solid in solidsList[selectedGuy]) {
                solid.ComputeVisibility(new Vector(1, solid.Points[1, 8], solid.Points[2, 8]));
                FlatShading(solid, leftView);
                FlatPaint(leftView, solid, 2, 1);

                solid.ComputeVisibility(new Vector(solid.Points[0, 8], solid.Points[1, 8], 1));
                FlatShading(solid, frontView);
                FlatPaint(frontView, solid, 0, 1);

                solid.ComputeVisibility(new Vector(solid.Points[0, 8], 1, solid.Points[2, 8]));
                FlatShading(solid, topView);
                FlatPaint(topView, solid, 0, 2);

                solid.ComputeVisibility(VRP, P);
                FlatShading(solid, perspectiveBox);
                   
            }
            foreach (var solid in perspectiveSolidList[selectedGuy]) {
                    
                FlatPaint(perspectiveBox, solid, 0, 1);
            }
        }

        private void DrawSolidFaces(Solid solid, PictureBox pc, int ipc, Pen myPen = null) {
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
                        solid.ComputeVisibility(new Vector(0, 0, 1), new Vector(0, 0, 0));
                    } else {
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

            var matrix = solid.Points;
            for (var i = 0; i < 6; i++) {
                if (!solid.VisibleFaces[i] && hideFacesBox.Checked) continue;
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
    }
}
