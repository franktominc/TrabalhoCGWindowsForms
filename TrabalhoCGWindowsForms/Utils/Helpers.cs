using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoCGWindowsForms.Utils {
    public static class Helpers {
        public static void Fill<T>(this T[,] originalArray, T value) {
            for (var i = 0; i < originalArray.GetLength(0); i++) {
                for (var j = 0; j < originalArray.GetLength(1); j++) {
                    originalArray[i,j] = value;
                }
            }
        }
    }
}
