namespace PolyhedronLab
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tabRotation = new System.Windows.Forms.TabPage();
            this.tabSurface = new System.Windows.Forms.TabPage();

            this.lblShape = new System.Windows.Forms.Label();
            this.cmbShape = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblOp = new System.Windows.Forms.Label();
            this.cmbOp = new System.Windows.Forms.ComboBox();
            this.lblParams = new System.Windows.Forms.Label();
            this.txtParams = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.grpProjection = new System.Windows.Forms.GroupBox();
            this.rbAxonometric = new System.Windows.Forms.RadioButton();
            this.rbPerspective = new System.Windows.Forms.RadioButton();
            this.chkEdgesOnly = new System.Windows.Forms.CheckBox();

            this.txtGeneratrix = new System.Windows.Forms.TextBox();
            this.lblGeneratrix = new System.Windows.Forms.Label();
            this.cmbAxis = new System.Windows.Forms.ComboBox();
            this.txtSegments = new System.Windows.Forms.TextBox();
            this.btnBuildRotation = new System.Windows.Forms.Button();

            this.cmbFunction = new System.Windows.Forms.ComboBox();
            this.txtRange = new System.Windows.Forms.TextBox();
            this.txtDivs = new System.Windows.Forms.TextBox();
            this.btnBuildSurface = new System.Windows.Forms.Button();

            this.canvas = new System.Windows.Forms.PictureBox();

            this.panelLeft.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabRotation.SuspendLayout();
            this.tabSurface.SuspendLayout();
            this.grpProjection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();

            // panelLeft
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Width = 320;
            this.panelLeft.Padding = new System.Windows.Forms.Padding(10);
            this.panelLeft.BackColor = System.Drawing.SystemColors.Control;
            this.panelLeft.Controls.Add(this.lblStatus);
            this.panelLeft.Controls.Add(this.tabControl);
            this.panelLeft.Controls.Add(this.grpProjection);
            this.panelLeft.Controls.Add(this.chkEdgesOnly);

            // lblStatus
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Height = 30;
            this.lblStatus.Text = "Готово";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.BackColor = System.Drawing.Color.LightGray;

            // tabControl
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Height = 420;
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Controls.Add(this.tabRotation);
            this.tabControl.Controls.Add(this.tabSurface);

            // --- ВКЛАДКА 1 ---
            this.tabMain.Text = "Многогранники";
            this.tabMain.Controls.Add(this.lblShape);
            this.tabMain.Controls.Add(this.cmbShape);
            this.tabMain.Controls.Add(this.btnLoad);
            this.tabMain.Controls.Add(this.btnSave);
            this.tabMain.Controls.Add(this.lblOp);
            this.tabMain.Controls.Add(this.cmbOp);
            this.tabMain.Controls.Add(this.lblParams);
            this.tabMain.Controls.Add(this.txtParams);
            this.tabMain.Controls.Add(this.btnApply);
            this.tabMain.Controls.Add(this.btnReset);
            this.tabMain.Controls.Add(this.btnUndo);

            this.lblShape.Text = "Многогранник:";
            this.lblShape.Location = new System.Drawing.Point(10, 15);
            this.lblShape.Size = new System.Drawing.Size(100, 20);

            this.cmbShape.Location = new System.Drawing.Point(10, 38);
            this.cmbShape.Size = new System.Drawing.Size(150, 24);
            this.cmbShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShape.Items.AddRange(new object[] { "Тетраэдр", "Гексаэдр (куб)", "Октаэдр", "Икосаэдр", "Додекаэдр" });
            this.cmbShape.SelectedIndex = 1;
            this.cmbShape.SelectedIndexChanged += new System.EventHandler(this.cmbShape_SelectedIndexChanged);

            this.btnLoad.Text = "Загрузить...";
            this.btnLoad.Location = new System.Drawing.Point(170, 38);
            this.btnLoad.Size = new System.Drawing.Size(60, 24);
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            this.btnSave.Text = "Сохранить...";
            this.btnSave.Location = new System.Drawing.Point(235, 38);
            this.btnSave.Size = new System.Drawing.Size(60, 24);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.lblOp.Text = "Преобразование:";
            this.lblOp.Location = new System.Drawing.Point(10, 75);
            this.lblOp.Size = new System.Drawing.Size(150, 20);

            this.cmbOp.Location = new System.Drawing.Point(10, 98);
            this.cmbOp.Size = new System.Drawing.Size(285, 24);
            this.cmbOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOp.Items.AddRange(new object[] {
                "Смещение (dx,dy,dz)", "Масштаб (sx,sy,sz)", "Масштаб отн. центра (k)",
                "Поворот вокруг X (угол°)", "Поворот вокруг Y (угол°)", "Поворот вокруг Z (угол°)",
                "Поворот оси || X через центр", "Поворот оси || Y через центр", "Поворот оси || Z через центр",
                "Поворот вокруг произвольной прямой", "Отражение отн. плоскости (X|Y|Z)" });
            this.cmbOp.SelectedIndex = 0;

            this.lblParams.Text = "Параметры (через запятую):";
            this.lblParams.Location = new System.Drawing.Point(10, 135);
            this.lblParams.Size = new System.Drawing.Size(200, 20);

            this.txtParams.Location = new System.Drawing.Point(10, 158);
            this.txtParams.Size = new System.Drawing.Size(285, 22);
            this.txtParams.Text = "0,0,0";

            this.btnApply.Location = new System.Drawing.Point(10, 195);
            this.btnApply.Size = new System.Drawing.Size(130, 32);
            this.btnApply.Text = "Применить";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);

            this.btnReset.Location = new System.Drawing.Point(150, 195);
            this.btnReset.Size = new System.Drawing.Size(130, 32);
            this.btnReset.Text = "Сброс";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            this.btnUndo.Location = new System.Drawing.Point(10, 235);
            this.btnUndo.Size = new System.Drawing.Size(270, 32);
            this.btnUndo.Text = "Отменить последнее действие";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);

            // --- ВКЛАДКА 2 ---
            this.tabRotation.Text = "Фигура вращения";
            this.lblGeneratrix.Text = "Образующая (x,y,z; x,y,z...):";
            this.lblGeneratrix.Location = new System.Drawing.Point(10, 15);
            this.lblGeneratrix.Size = new System.Drawing.Size(250, 20);

            this.txtGeneratrix.Location = new System.Drawing.Point(10, 38);
            this.txtGeneratrix.Size = new System.Drawing.Size(285, 60);
            this.txtGeneratrix.Multiline = true;
            this.txtGeneratrix.Text = "1,0,0; 2,0,0; 2,0,1; 1,0,1";

            this.tabRotation.Controls.Add(this.lblGeneratrix);
            this.tabRotation.Controls.Add(this.txtGeneratrix);

            this.cmbAxis.Location = new System.Drawing.Point(10, 110);
            this.cmbAxis.Size = new System.Drawing.Size(100, 24);
            this.cmbAxis.Items.AddRange(new object[] { "Ось X", "Ось Y", "Ось Z" });
            this.cmbAxis.SelectedIndex = 1;
            this.tabRotation.Controls.Add(this.cmbAxis);

            this.txtSegments.Location = new System.Drawing.Point(120, 110);
            this.txtSegments.Size = new System.Drawing.Size(50, 22);
            this.txtSegments.Text = "20";
            this.tabRotation.Controls.Add(this.txtSegments);

            this.btnBuildRotation.Location = new System.Drawing.Point(10, 150);
            this.btnBuildRotation.Size = new System.Drawing.Size(270, 32);
            this.btnBuildRotation.Text = "Построить фигуру вращения";
            this.btnBuildRotation.Click += new System.EventHandler(this.btnBuildRotation_Click);
            this.tabRotation.Controls.Add(this.btnBuildRotation);

            // --- ВКЛАДКА 3 ---
            this.tabSurface.Text = "График функции";

            this.cmbFunction.Location = new System.Drawing.Point(10, 15);
            this.cmbFunction.Size = new System.Drawing.Size(285, 24);
            this.cmbFunction.Items.AddRange(new object[] { "z = sin(x) * cos(y)", "z = x^2 - y^2", "z = sin(sqrt(x^2 + y^2))" });
            this.cmbFunction.SelectedIndex = 0;
            this.tabSurface.Controls.Add(this.cmbFunction);

            this.txtRange.Location = new System.Drawing.Point(10, 50);
            this.txtRange.Size = new System.Drawing.Size(285, 22);
            this.txtRange.Text = "-3, 3, -3, 3";
            this.tabSurface.Controls.Add(this.txtRange);

            this.txtDivs.Location = new System.Drawing.Point(10, 80);
            this.txtDivs.Size = new System.Drawing.Size(100, 22);
            this.txtDivs.Text = "20";
            this.tabSurface.Controls.Add(this.txtDivs);

            this.btnBuildSurface.Location = new System.Drawing.Point(10, 115);
            this.btnBuildSurface.Size = new System.Drawing.Size(270, 32);
            this.btnBuildSurface.Text = "Построить график";
            this.btnBuildSurface.Click += new System.EventHandler(this.btnBuildSurface_Click);
            this.tabSurface.Controls.Add(this.btnBuildSurface);

            // grpProjection
            this.grpProjection.Text = "Проекция";
            this.grpProjection.Location = new System.Drawing.Point(10, 440);
            this.grpProjection.Size = new System.Drawing.Size(270, 70);
            this.grpProjection.Controls.Add(this.rbAxonometric);
            this.grpProjection.Controls.Add(this.rbPerspective);

            this.rbAxonometric.Text = "Аксонометрическая";
            this.rbAxonometric.Location = new System.Drawing.Point(10, 20);
            this.rbAxonometric.Size = new System.Drawing.Size(180, 20);
            this.rbAxonometric.Checked = true;
            this.rbAxonometric.CheckedChanged += new System.EventHandler(this.rbProjection_CheckedChanged);

            this.rbPerspective.Text = "Перспективная";
            this.rbPerspective.Location = new System.Drawing.Point(10, 42);
            this.rbPerspective.Size = new System.Drawing.Size(180, 20);
            this.rbPerspective.CheckedChanged += new System.EventHandler(this.rbProjection_CheckedChanged);

            // chkEdgesOnly
            this.chkEdgesOnly.Text = "Только рёбра (каркас)";
            this.chkEdgesOnly.Location = new System.Drawing.Point(10, 520);
            this.chkEdgesOnly.Size = new System.Drawing.Size(250, 22);
            this.chkEdgesOnly.CheckedChanged += new System.EventHandler(this.chkEdgesOnly_CheckedChanged);

            // canvas
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.Resize += new System.EventHandler(this.canvas_Resize);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.panelLeft);
            this.Text = "ЛР7 — Построение трёхмерных моделей";

            this.panelLeft.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.tabRotation.ResumeLayout(false);
            this.tabRotation.PerformLayout();
            this.tabSurface.ResumeLayout(false);
            this.tabSurface.PerformLayout();
            this.grpProjection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabRotation;
        private System.Windows.Forms.TabPage tabSurface;

        private System.Windows.Forms.Label lblShape;
        private System.Windows.Forms.ComboBox cmbShape;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblOp;
        private System.Windows.Forms.ComboBox cmbOp;
        private System.Windows.Forms.Label lblParams;
        private System.Windows.Forms.TextBox txtParams;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnUndo;

        private System.Windows.Forms.TextBox txtGeneratrix;
        private System.Windows.Forms.Label lblGeneratrix;
        private System.Windows.Forms.ComboBox cmbAxis;
        private System.Windows.Forms.TextBox txtSegments;
        private System.Windows.Forms.Button btnBuildRotation;

        private System.Windows.Forms.ComboBox cmbFunction;
        private System.Windows.Forms.TextBox txtRange;
        private System.Windows.Forms.TextBox txtDivs;
        private System.Windows.Forms.Button btnBuildSurface;

        private System.Windows.Forms.GroupBox grpProjection;
        private System.Windows.Forms.RadioButton rbAxonometric;
        private System.Windows.Forms.RadioButton rbPerspective;
        private System.Windows.Forms.CheckBox chkEdgesOnly;
        private System.Windows.Forms.PictureBox canvas;
    }
}