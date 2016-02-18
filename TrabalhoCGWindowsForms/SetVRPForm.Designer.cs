namespace TrabalhoCGWindowsForms {
    partial class SetVRPForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.VRPx = new System.Windows.Forms.TextBox();
            this.VRPy = new System.Windows.Forms.TextBox();
            this.VRPz = new System.Windows.Forms.TextBox();
            this.Pz = new System.Windows.Forms.TextBox();
            this.Py = new System.Windows.Forms.TextBox();
            this.Px = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VRPx
            // 
            this.VRPx.Location = new System.Drawing.Point(39, 22);
            this.VRPx.Name = "VRPx";
            this.VRPx.Size = new System.Drawing.Size(86, 20);
            this.VRPx.TabIndex = 41;
            // 
            // VRPy
            // 
            this.VRPy.Location = new System.Drawing.Point(141, 22);
            this.VRPy.Name = "VRPy";
            this.VRPy.Size = new System.Drawing.Size(86, 20);
            this.VRPy.TabIndex = 42;
            // 
            // VRPz
            // 
            this.VRPz.Location = new System.Drawing.Point(243, 22);
            this.VRPz.Name = "VRPz";
            this.VRPz.Size = new System.Drawing.Size(86, 20);
            this.VRPz.TabIndex = 43;
            // 
            // Pz
            // 
            this.Pz.Location = new System.Drawing.Point(243, 48);
            this.Pz.Name = "Pz";
            this.Pz.Size = new System.Drawing.Size(86, 20);
            this.Pz.TabIndex = 44;
            // 
            // Py
            // 
            this.Py.Location = new System.Drawing.Point(141, 48);
            this.Py.Name = "Py";
            this.Py.Size = new System.Drawing.Size(86, 20);
            this.Py.TabIndex = 45;
            // 
            // Px
            // 
            this.Px.Location = new System.Drawing.Point(39, 48);
            this.Px.Name = "Px";
            this.Px.Size = new System.Drawing.Size(86, 20);
            this.Px.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "VRP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "P";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Z";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "X";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 52;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SetVRPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 275);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Px);
            this.Controls.Add(this.Py);
            this.Controls.Add(this.Pz);
            this.Controls.Add(this.VRPz);
            this.Controls.Add(this.VRPy);
            this.Controls.Add(this.VRPx);
            this.Name = "SetVRPForm";
            this.Text = "SetVRPForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox VRPx;
        public System.Windows.Forms.TextBox VRPy;
        public System.Windows.Forms.TextBox VRPz;
        public System.Windows.Forms.TextBox Pz;
        public System.Windows.Forms.TextBox Py;
        public System.Windows.Forms.TextBox Px;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        public MainView Parent;
    }
}