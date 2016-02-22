using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using TrabalhoCGWindowsForms.Model;
using TrabalhoCGWindowsForms.Utils;

namespace TrabalhoCGWindowsForms {
    public partial class MainView : Form {




        private void zBufferBt_Click(object sender, EventArgs e) {
            frontView.Image = new Bitmap(frontView.Width, frontView.Height);
            DrawZbuffer(frontView);
            frontView.Invalidate();
            
        }


    }
}
