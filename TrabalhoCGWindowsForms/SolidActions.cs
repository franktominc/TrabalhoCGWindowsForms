using System;
using System.Collections.Generic;
using System.Drawing;
using TrabalhoCGWindowsForms.Model;
using TrabalhoCGWindowsForms.Utils;

namespace TrabalhoCGWindowsForms {
    public partial class MainView {

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
                rotateCubeCheckbox.Enabled = true;
                translateCubeCheckbox.Enabled = true;
                return solidInQuestion;
            }
            rotateCubeCheckbox.Enabled = false;
            translateCubeCheckbox.Enabled = false;
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

    }
}
