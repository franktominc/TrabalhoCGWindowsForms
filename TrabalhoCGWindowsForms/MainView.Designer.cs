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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.frontView = new System.Windows.Forms.PictureBox();
            this.topView = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setVRPAndPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftView = new System.Windows.Forms.PictureBox();
            this.perspectiveBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.addCubeBox = new System.Windows.Forms.CheckBox();
            this.btScalePlus = new System.Windows.Forms.Button();
            this.btScaleMinus = new System.Windows.Forms.Button();
            this.hideFacesBox = new System.Windows.Forms.CheckBox();
            this.groupSolidsCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.removeView = new System.Windows.Forms.Button();
            this.removeAllButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.rotateCubeCheckbox = new System.Windows.Forms.CheckBox();
            this.translateCubeCheckbox = new System.Windows.Forms.CheckBox();
            this.isometricCheckBox = new System.Windows.Forms.CheckBox();
            this.flatBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.frontView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perspectiveBox)).BeginInit();
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
            this.File,
            this.configToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1350, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
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
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setVRPAndPToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // setVRPAndPToolStripMenuItem
            // 
            this.setVRPAndPToolStripMenuItem.Name = "setVRPAndPToolStripMenuItem";
            this.setVRPAndPToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.setVRPAndPToolStripMenuItem.Text = "Object Properties";
            this.setVRPAndPToolStripMenuItem.Click += new System.EventHandler(this.setPropertiesMenuItem_Click);
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
            // perspectiveBox
            // 
            this.perspectiveBox.BackColor = System.Drawing.SystemColors.GrayText;
            this.perspectiveBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.perspectiveBox.Location = new System.Drawing.Point(467, 401);
            this.perspectiveBox.Name = "perspectiveBox";
            this.perspectiveBox.Size = new System.Drawing.Size(449, 315);
            this.perspectiveBox.TabIndex = 5;
            this.perspectiveBox.TabStop = false;
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
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Perspective View";
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
            // addCubeBox
            // 
            this.addCubeBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.addCubeBox.BackColor = System.Drawing.SystemColors.GrayText;
            this.addCubeBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addCubeBox.Image = ((System.Drawing.Image)(resources.GetObject("addCubeBox.Image")));
            this.addCubeBox.Location = new System.Drawing.Point(931, 332);
            this.addCubeBox.Name = "addCubeBox";
            this.addCubeBox.Size = new System.Drawing.Size(40, 40);
            this.addCubeBox.TabIndex = 25;
            this.addCubeBox.UseVisualStyleBackColor = false;
            this.addCubeBox.Click += new System.EventHandler(this.addCubeBox_Click);
            // 
            // btScalePlus
            // 
            this.btScalePlus.BackColor = System.Drawing.SystemColors.GrayText;
            this.btScalePlus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btScalePlus.Image = ((System.Drawing.Image)(resources.GetObject("btScalePlus.Image")));
            this.btScalePlus.Location = new System.Drawing.Point(931, 378);
            this.btScalePlus.Name = "btScalePlus";
            this.btScalePlus.Size = new System.Drawing.Size(40, 40);
            this.btScalePlus.TabIndex = 27;
            this.btScalePlus.UseVisualStyleBackColor = false;
            this.btScalePlus.Click += new System.EventHandler(this.ZScalePlus_Click);
            // 
            // btScaleMinus
            // 
            this.btScaleMinus.BackColor = System.Drawing.SystemColors.GrayText;
            this.btScaleMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btScaleMinus.Image = ((System.Drawing.Image)(resources.GetObject("btScaleMinus.Image")));
            this.btScaleMinus.Location = new System.Drawing.Point(974, 378);
            this.btScaleMinus.Name = "btScaleMinus";
            this.btScaleMinus.Size = new System.Drawing.Size(40, 40);
            this.btScaleMinus.TabIndex = 28;
            this.btScaleMinus.Text = "-";
            this.btScaleMinus.UseVisualStyleBackColor = false;
            this.btScaleMinus.Click += new System.EventHandler(this.ZScaleMinus_Click);
            // 
            // hideFacesBox
            // 
            this.hideFacesBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.hideFacesBox.BackColor = System.Drawing.SystemColors.GrayText;
            this.hideFacesBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.hideFacesBox.Image = ((System.Drawing.Image)(resources.GetObject("hideFacesBox.Image")));
            this.hideFacesBox.Location = new System.Drawing.Point(974, 516);
            this.hideFacesBox.Name = "hideFacesBox";
            this.hideFacesBox.Size = new System.Drawing.Size(40, 40);
            this.hideFacesBox.TabIndex = 30;
            this.hideFacesBox.UseVisualStyleBackColor = false;
            this.hideFacesBox.Click += new System.EventHandler(this.HideFacesBox_Click);
            // 
            // groupSolidsCheckBox
            // 
            this.groupSolidsCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.groupSolidsCheckBox.BackColor = System.Drawing.SystemColors.GrayText;
            this.groupSolidsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupSolidsCheckBox.Image = ((System.Drawing.Image)(resources.GetObject("groupSolidsCheckBox.Image")));
            this.groupSolidsCheckBox.Location = new System.Drawing.Point(931, 470);
            this.groupSolidsCheckBox.Name = "groupSolidsCheckBox";
            this.groupSolidsCheckBox.Size = new System.Drawing.Size(40, 40);
            this.groupSolidsCheckBox.TabIndex = 31;
            this.groupSolidsCheckBox.UseVisualStyleBackColor = false;
            this.groupSolidsCheckBox.Click += new System.EventHandler(this.groupSolidsCheckBox_Click);
            // 
            // groupBt
            // 
            this.groupBt.BackColor = System.Drawing.SystemColors.GrayText;
            this.groupBt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBt.Image = ((System.Drawing.Image)(resources.GetObject("groupBt.Image")));
            this.groupBt.Location = new System.Drawing.Point(931, 424);
            this.groupBt.Name = "groupBt";
            this.groupBt.Size = new System.Drawing.Size(40, 40);
            this.groupBt.TabIndex = 32;
            this.groupBt.UseVisualStyleBackColor = false;
            this.groupBt.Click += new System.EventHandler(this.groupBt_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GrayText;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(974, 424);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 33;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.UngroupSolidsBt_Click);
            // 
            // removeView
            // 
            this.removeView.BackColor = System.Drawing.SystemColors.GrayText;
            this.removeView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.removeView.Image = ((System.Drawing.Image)(resources.GetObject("removeView.Image")));
            this.removeView.Location = new System.Drawing.Point(974, 332);
            this.removeView.Name = "removeView";
            this.removeView.Size = new System.Drawing.Size(40, 40);
            this.removeView.TabIndex = 34;
            this.removeView.UseVisualStyleBackColor = false;
            this.removeView.Click += new System.EventHandler(this.removeSolidBt_Click);
            // 
            // removeAllButton
            // 
            this.removeAllButton.BackColor = System.Drawing.SystemColors.GrayText;
            this.removeAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.removeAllButton.Image = ((System.Drawing.Image)(resources.GetObject("removeAllButton.Image")));
            this.removeAllButton.Location = new System.Drawing.Point(931, 516);
            this.removeAllButton.Name = "removeAllButton";
            this.removeAllButton.Size = new System.Drawing.Size(40, 40);
            this.removeAllButton.TabIndex = 35;
            this.removeAllButton.UseVisualStyleBackColor = false;
            this.removeAllButton.Click += new System.EventHandler(this.removeAllButton_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GrayText;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(974, 470);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 36;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.SelectAllSolidsBt_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Adicionar Cubo";
            // 
            // rotateCubeCheckbox
            // 
            this.rotateCubeCheckbox.AutoSize = true;
            this.rotateCubeCheckbox.Location = new System.Drawing.Point(1019, 332);
            this.rotateCubeCheckbox.Name = "rotateCubeCheckbox";
            this.rotateCubeCheckbox.Size = new System.Drawing.Size(66, 17);
            this.rotateCubeCheckbox.TabIndex = 37;
            this.rotateCubeCheckbox.Text = "Rotation";
            this.rotateCubeCheckbox.UseVisualStyleBackColor = true;
            // 
            // translateCubeCheckbox
            // 
            this.translateCubeCheckbox.AutoSize = true;
            this.translateCubeCheckbox.Location = new System.Drawing.Point(1020, 355);
            this.translateCubeCheckbox.Name = "translateCubeCheckbox";
            this.translateCubeCheckbox.Size = new System.Drawing.Size(78, 17);
            this.translateCubeCheckbox.TabIndex = 38;
            this.translateCubeCheckbox.Text = "Translation";
            this.translateCubeCheckbox.UseVisualStyleBackColor = true;
            // 
            // isometricCheckBox
            // 
            this.isometricCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.isometricCheckBox.BackColor = System.Drawing.SystemColors.GrayText;
            this.isometricCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.isometricCheckBox.Image = ((System.Drawing.Image)(resources.GetObject("isometricCheckBox.Image")));
            this.isometricCheckBox.Location = new System.Drawing.Point(1020, 516);
            this.isometricCheckBox.Name = "isometricCheckBox";
            this.isometricCheckBox.Size = new System.Drawing.Size(40, 40);
            this.isometricCheckBox.TabIndex = 52;
            this.isometricCheckBox.UseVisualStyleBackColor = false;
            this.isometricCheckBox.Click += new System.EventHandler(this.isometricCheckBox_Click);
            // 
            // flatBox
            // 
            this.flatBox.AutoSize = true;
            this.flatBox.Location = new System.Drawing.Point(994, 214);
            this.flatBox.Name = "flatBox";
            this.flatBox.Size = new System.Drawing.Size(43, 17);
            this.flatBox.TabIndex = 53;
            this.flatBox.Text = "Flat";
            this.flatBox.UseVisualStyleBackColor = true;
            this.flatBox.Click += new System.EventHandler(this.flatBox_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.flatBox);
            this.Controls.Add(this.isometricCheckBox);
            this.Controls.Add(this.translateCubeCheckbox);
            this.Controls.Add(this.rotateCubeCheckbox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.removeAllButton);
            this.Controls.Add(this.removeView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBt);
            this.Controls.Add(this.groupSolidsCheckBox);
            this.Controls.Add(this.hideFacesBox);
            this.Controls.Add(this.btScaleMinus);
            this.Controls.Add(this.btScalePlus);
            this.Controls.Add(this.addCubeBox);
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
            this.Controls.Add(this.perspectiveBox);
            this.Controls.Add(this.topView);
            this.Controls.Add(this.frontView);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainView";
            this.Text = "Desanim8or";
            this.Load += new System.EventHandler(this.MainView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.frontView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perspectiveBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox frontView;
        private System.Windows.Forms.PictureBox topView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.PictureBox leftView;
        private System.Windows.Forms.PictureBox perspectiveBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        private List<List<Solid>> perspectiveSolidList;
        private List<List<Solid>> solidsList;
        private List<int> selectedSolids; 
        private int selectedGuy;

        private bool amIRotating;
        private bool amITranslating;
        public Vector VRP;
        public Vector VRPiso;
        public Vector P;
        public  int alpha;
        public Vector ka;
        public Vector kd;
        public Vector ks;
        public Vector L;
        public Vector iLa;
        public Vector iL;
        public Vector Y;
        public int n;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox addCubeBox;
        private System.Windows.Forms.Button btScalePlus;
        private System.Windows.Forms.Button btScaleMinus;
        private System.Windows.Forms.CheckBox hideFacesBox;
        private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.CheckBox groupSolidsCheckBox;
        private System.Windows.Forms.Button groupBt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button removeView;
        private System.Windows.Forms.Button removeAllButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox rotateCubeCheckbox;
        private System.Windows.Forms.CheckBox translateCubeCheckbox;
        private System.Windows.Forms.CheckBox isometricCheckBox;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setVRPAndPToolStripMenuItem;
        private System.Windows.Forms.CheckBox flatBox;

    }
}

