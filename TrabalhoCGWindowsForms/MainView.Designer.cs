using System.Collections.Generic;
using System.Drawing;
using System.Net.Configuration;
using TrabalhoCGWindowsForms.Model;

namespace TrabalhoCGWindowsForms {
    partial class MainView {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.frontView = new System.Windows.Forms.PictureBox();
            this.topView = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftView = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.xRotationBar = new System.Windows.Forms.TrackBar();
            this.yRotationBar = new System.Windows.Forms.TrackBar();
            this.zRotationBar = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addCubeBox = new System.Windows.Forms.CheckBox();
            this.btScalePlus = new System.Windows.Forms.Button();
            this.btScaleMinus = new System.Windows.Forms.Button();
            this.hideFacesBox = new System.Windows.Forms.CheckBox();
            this.groupSolidsCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.frontView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xRotationBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRotationBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zRotationBar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // frontView
            // 
            this.frontView.BackColor = System.Drawing.SystemColors.GrayText;
            this.frontView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frontView.Image = ((System.Drawing.Image)(resources.GetObject("frontView.Image")));
            this.frontView.Location = new System.Drawing.Point(12, 401);
            this.frontView.Name = "frontView";
            this.frontView.Size = new System.Drawing.Size(449, 315);
            this.frontView.TabIndex = 2;
            this.frontView.TabStop = false;
            this.frontView.Click += new System.EventHandler(this.frontView_Click);
            this.frontView.Paint += new System.Windows.Forms.PaintEventHandler(this.frontView_Paint);
            // 
            // topView
            // 
            this.topView.BackColor = System.Drawing.SystemColors.GrayText;
            this.topView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.topView.Image = ((System.Drawing.Image)(resources.GetObject("topView.Image")));
            this.topView.Location = new System.Drawing.Point(12, 57);
            this.topView.Name = "topView";
            this.topView.Size = new System.Drawing.Size(449, 315);
            this.topView.TabIndex = 3;
            this.topView.TabStop = false;
            this.topView.Click += new System.EventHandler(this.topView_Click);
            this.topView.Paint += new System.Windows.Forms.PaintEventHandler(this.topView_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GrayText;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1350, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // File
            // 
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.salvarToolStripMenuItem});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(37, 20);
            this.File.Text = "File";
            this.File.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.abrirToolStripMenuItem.Text = "Open";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // salvarToolStripMenuItem
            // 
            this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
            this.salvarToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.salvarToolStripMenuItem.Text = "Save";
            this.salvarToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // leftView
            // 
            this.leftView.BackColor = System.Drawing.SystemColors.GrayText;
            this.leftView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftView.Image = ((System.Drawing.Image)(resources.GetObject("leftView.Image")));
            this.leftView.Location = new System.Drawing.Point(467, 57);
            this.leftView.Name = "leftView";
            this.leftView.Size = new System.Drawing.Size(449, 315);
            this.leftView.TabIndex = 6;
            this.leftView.TabStop = false;
            this.leftView.Click += new System.EventHandler(this.leftView_Click);
            this.leftView.Paint += new System.Windows.Forms.PaintEventHandler(this.leftView_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.GrayText;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(467, 401);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(449, 315);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Top View";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(464, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Left View";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(464, 385);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Front View";
            // 
            // xRotationBar
            // 
            this.xRotationBar.Location = new System.Drawing.Point(12, 25);
            this.xRotationBar.Maximum = 72;
            this.xRotationBar.Minimum = -72;
            this.xRotationBar.Name = "xRotationBar";
            this.xRotationBar.Size = new System.Drawing.Size(316, 45);
            this.xRotationBar.TabIndex = 11;
            this.xRotationBar.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // yRotationBar
            // 
            this.yRotationBar.Location = new System.Drawing.Point(12, 87);
            this.yRotationBar.Maximum = 72;
            this.yRotationBar.Minimum = -72;
            this.yRotationBar.Name = "yRotationBar";
            this.yRotationBar.Size = new System.Drawing.Size(316, 45);
            this.yRotationBar.TabIndex = 13;
            this.yRotationBar.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // zRotationBar
            // 
            this.zRotationBar.Location = new System.Drawing.Point(12, 149);
            this.zRotationBar.Maximum = 72;
            this.zRotationBar.Minimum = -72;
            this.zRotationBar.Name = "zRotationBar";
            this.zRotationBar.Size = new System.Drawing.Size(316, 45);
            this.zRotationBar.TabIndex = 14;
            this.zRotationBar.ValueChanged += new System.EventHandler(this.trackBar3_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GrayText;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(511, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "Z";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.GrayText;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(474, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.GrayText;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "Z";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.GrayText;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(55, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "X";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.GrayText;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 443);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.GrayText;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(55, 406);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "X";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(144, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "X Rotation";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(144, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Y Rotation";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(144, 130);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Z Rotation";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.xRotationBar);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.yRotationBar);
            this.panel1.Controls.Add(this.zRotationBar);
            this.panel1.Location = new System.Drawing.Point(962, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 213);
            this.panel1.TabIndex = 24;
            // 
            // addCubeBox
            // 
            this.addCubeBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.addCubeBox.BackColor = System.Drawing.SystemColors.GrayText;
            this.addCubeBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addCubeBox.Image = ((System.Drawing.Image)(resources.GetObject("addCubeBox.Image")));
            this.addCubeBox.Location = new System.Drawing.Point(962, 356);
            this.addCubeBox.Name = "addCubeBox";
            this.addCubeBox.Size = new System.Drawing.Size(40, 40);
            this.addCubeBox.TabIndex = 25;
            this.addCubeBox.UseVisualStyleBackColor = false;
            // 
            // btScalePlus
            // 
            this.btScalePlus.Location = new System.Drawing.Point(961, 437);
            this.btScalePlus.Name = "btScalePlus";
            this.btScalePlus.Size = new System.Drawing.Size(34, 31);
            this.btScalePlus.TabIndex = 27;
            this.btScalePlus.Text = "+";
            this.btScalePlus.UseVisualStyleBackColor = true;
            this.btScalePlus.Click += new System.EventHandler(this.button2_Click);
            // 
            // btScaleMinus
            // 
            this.btScaleMinus.Location = new System.Drawing.Point(1027, 437);
            this.btScaleMinus.Name = "btScaleMinus";
            this.btScaleMinus.Size = new System.Drawing.Size(34, 31);
            this.btScaleMinus.TabIndex = 28;
            this.btScaleMinus.Text = "-";
            this.btScaleMinus.UseVisualStyleBackColor = true;
            this.btScaleMinus.Click += new System.EventHandler(this.button3_Click);
            // 
            // hideFacesBox
            // 
            this.hideFacesBox.AutoSize = true;
            this.hideFacesBox.Location = new System.Drawing.Point(974, 303);
            this.hideFacesBox.Name = "hideFacesBox";
            this.hideFacesBox.Size = new System.Drawing.Size(92, 17);
            this.hideFacesBox.TabIndex = 30;
            this.hideFacesBox.Text = "Ocultar Faces";
            this.hideFacesBox.UseVisualStyleBackColor = true;
            this.hideFacesBox.Click += new System.EventHandler(this.checkBox2_Click);
            // 
            // groupSolidsCheckBox
            // 
            this.groupSolidsCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.groupSolidsCheckBox.AutoSize = true;
            this.groupSolidsCheckBox.Location = new System.Drawing.Point(1094, 380);
            this.groupSolidsCheckBox.Name = "groupSolidsCheckBox";
            this.groupSolidsCheckBox.Size = new System.Drawing.Size(121, 23);
            this.groupSolidsCheckBox.TabIndex = 31;
            this.groupSolidsCheckBox.Text = "groupSolidsCheckBox";
            this.groupSolidsCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBt
            // 
            this.groupBt.Location = new System.Drawing.Point(1119, 433);
            this.groupBt.Name = "groupBt";
            this.groupBt.Size = new System.Drawing.Size(55, 34);
            this.groupBt.TabIndex = 32;
            this.groupBt.Text = "grup";
            this.groupBt.UseVisualStyleBackColor = true;
            this.groupBt.Click += new System.EventHandler(this.groupBt_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.groupBt);
            this.Controls.Add(this.groupSolidsCheckBox);
            this.Controls.Add(this.hideFacesBox);
            this.Controls.Add(this.btScaleMinus);
            this.Controls.Add(this.btScalePlus);
            this.Controls.Add(this.addCubeBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.leftView);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.topView);
            this.Controls.Add(this.frontView);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainView";
            this.Text = "Desanim8or";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.frontView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xRotationBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRotationBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zRotationBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox frontView;
        private System.Windows.Forms.PictureBox topView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.PictureBox leftView;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar xRotationBar;
        private List<List<Solid>> solidsList;
        private List<int> selectedSolids; 
        private int selectedGuy;
        private int view;
        private System.Windows.Forms.TrackBar yRotationBar;
        private System.Windows.Forms.TrackBar zRotationBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox addCubeBox;
        private System.Windows.Forms.Button btScalePlus;
        private System.Windows.Forms.Button btScaleMinus;
        private System.Windows.Forms.CheckBox hideFacesBox;
        private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.CheckBox groupSolidsCheckBox;
        private System.Windows.Forms.Button groupBt;

    }
}

