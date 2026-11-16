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
            panelLeft = new Panel();
            lblStatus = new Label();
            tabControl = new TabControl();

            // Единственная вкладка — ЛАБ 11
            tabMain = new TabPage();
            lblShape = new Label();
            cmbShape = new ComboBox();
            btnLoad = new Button();
            btnSave = new Button();
            lblOp = new Label();
            cmbOp = new ComboBox();
            lblParams = new Label();
            txtParams = new TextBox();
            btnApply = new Button();
            btnReset = new Button();
            btnUndo = new Button();

            // Источник света
            lblLightPos = new Label();
            txtLightPos = new TextBox();
            lblLightColor = new Label();
            txtLightColor = new TextBox();
            lblObjectColor = new Label();
            txtObjectColor = new TextBox();
            btnApplyLight = new Button();

            // Общие
            grpProjection = new GroupBox();
            rbAxonometric = new RadioButton();
            rbPerspective = new RadioButton();
            canvas = new PictureBox();

            panelLeft.SuspendLayout();
            tabControl.SuspendLayout();
            tabMain.SuspendLayout();
            grpProjection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            SuspendLayout();

            // panelLeft
            panelLeft.BackColor = SystemColors.Control;
            panelLeft.Controls.Add(lblStatus);
            panelLeft.Controls.Add(tabControl);
            panelLeft.Controls.Add(grpProjection);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(10, 12, 10, 12);
            panelLeft.Size = new Size(320, 875);
            panelLeft.TabIndex = 1;

            // lblStatus
            lblStatus.BackColor = Color.LightGray;
            lblStatus.Dock = DockStyle.Top;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.Location = new Point(10, 638);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(300, 38);
            lblStatus.Text = "Готово";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;

            // tabControl
            tabControl.Controls.Add(tabMain);
            tabControl.Dock = DockStyle.Top;
            tabControl.Location = new Point(10, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(300, 626);
            tabControl.TabIndex = 1;

            // ================= ВКЛАДКА 1 (ЛАБ 11) =================
            tabMain.Controls.Add(lblShape);
            tabMain.Controls.Add(cmbShape);
            tabMain.Controls.Add(btnLoad);
            tabMain.Controls.Add(btnSave);
            tabMain.Controls.Add(lblOp);
            tabMain.Controls.Add(cmbOp);
            tabMain.Controls.Add(lblParams);
            tabMain.Controls.Add(txtParams);
            tabMain.Controls.Add(btnApply);
            tabMain.Controls.Add(btnReset);
            tabMain.Controls.Add(btnUndo);
            tabMain.Controls.Add(lblLightPos);
            tabMain.Controls.Add(txtLightPos);
            tabMain.Controls.Add(lblLightColor);
            tabMain.Controls.Add(txtLightColor);
            tabMain.Controls.Add(lblObjectColor);
            tabMain.Controls.Add(txtObjectColor);
            tabMain.Controls.Add(btnApplyLight);
            tabMain.Location = new Point(4, 29);
            tabMain.Name = "tabMain";
            tabMain.Size = new Size(292, 593);
            tabMain.Text = "Освещение (Гуро + Ламберт)";

            lblShape.Location = new Point(10, 19); lblShape.Size = new Size(100, 25); lblShape.Text = "Многогранник:";
            cmbShape.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbShape.Items.AddRange(new object[] { "Тетраэдр", "Гексаэдр (куб)", "Октаэдр", "Икосаэдр", "Додекаэдр" });
            cmbShape.Location = new Point(10, 48); cmbShape.Size = new Size(150, 28);
            cmbShape.SelectedIndexChanged += cmbShape_SelectedIndexChanged;
            btnLoad.Location = new Point(170, 48); btnLoad.Size = new Size(60, 30); btnLoad.Text = "Загрузить..."; btnLoad.Click += btnLoad_Click;
            btnSave.Location = new Point(235, 48); btnSave.Size = new Size(60, 30); btnSave.Text = "Сохранить..."; btnSave.Click += btnSave_Click;
            lblOp.Location = new Point(10, 94); lblOp.Size = new Size(150, 25); lblOp.Text = "Преобразование:";
            cmbOp.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOp.Items.AddRange(new object[] { "Смещение (dx,dy,dz)", "Масштаб (sx,sy,sz)", "Масштаб отн. центра (k)", "Поворот вокруг X (угол°)", "Поворот вокруг Y (угол°)", "Поворот вокруг Z (угол°)" });
            cmbOp.Location = new Point(10, 122); cmbOp.Size = new Size(285, 28);
            lblParams.Location = new Point(10, 169); lblParams.Size = new Size(270, 25); lblParams.Text = "Параметры (через запятую):";
            txtParams.Location = new Point(10, 198); txtParams.Size = new Size(285, 27); txtParams.Text = "0,0,0";
            btnApply.Location = new Point(10, 244); btnApply.Size = new Size(130, 40); btnApply.Text = "Применить"; btnApply.Click += btnApply_Click;
            btnReset.Location = new Point(150, 244); btnReset.Size = new Size(130, 40); btnReset.Text = "Сброс"; btnReset.Click += btnReset_Click;
            btnUndo.Location = new Point(10, 294); btnUndo.Size = new Size(270, 40); btnUndo.Text = "Отменить последнее действие"; btnUndo.Click += btnUndo_Click;

            // Источник света
            lblLightPos.Location = new Point(10, 350); lblLightPos.Size = new Size(200, 25); lblLightPos.Text = "Позиция источника (x,y,z):";
            txtLightPos.Location = new Point(10, 378); txtLightPos.Size = new Size(285, 27); txtLightPos.Text = "5,5,5";
            lblLightColor.Location = new Point(10, 410); lblLightColor.Size = new Size(200, 25); lblLightColor.Text = "Цвет источника (R,G,B):";
            txtLightColor.Location = new Point(10, 438); txtLightColor.Size = new Size(285, 27); txtLightColor.Text = "255,255,255";
            lblObjectColor.Location = new Point(10, 470); lblObjectColor.Size = new Size(200, 25); lblObjectColor.Text = "Цвет объекта (R,G,B):";
            txtObjectColor.Location = new Point(10, 498); txtObjectColor.Size = new Size(285, 27); txtObjectColor.Text = "70,130,180";
            btnApplyLight.Location = new Point(10, 535); btnApplyLight.Size = new Size(270, 40); btnApplyLight.Text = "Применить свет и цвет"; btnApplyLight.Click += btnApplyLight_Click;

            // ================= ОБЩИЕ =================
            grpProjection.Controls.Add(rbAxonometric);
            grpProjection.Controls.Add(rbPerspective);
            grpProjection.Location = new Point(14, 696);
            grpProjection.Size = new Size(270, 88);
            grpProjection.Text = "Проекция";
            rbAxonometric.Checked = true; rbAxonometric.Location = new Point(10, 25); rbAxonometric.Size = new Size(180, 25); rbAxonometric.Text = "Аксонометрическая"; rbAxonometric.CheckedChanged += rbProjection_CheckedChanged;
            rbPerspective.Location = new Point(10, 52); rbPerspective.Size = new Size(180, 25); rbPerspective.Text = "Перспективная"; rbPerspective.CheckedChanged += rbProjection_CheckedChanged;

            canvas.BackColor = Color.White;
            canvas.Dock = DockStyle.Fill;
            canvas.Location = new Point(320, 0);
            canvas.Size = new Size(780, 875);
            canvas.Paint += canvas_Paint;
            canvas.Resize += canvas_Resize;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 875);
            Controls.Add(canvas);
            Controls.Add(panelLeft);
            Text = "ЛР11 — Освещение (Гуро + Ламберт)";

            panelLeft.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabMain.ResumeLayout(false); tabMain.PerformLayout();
            grpProjection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            ResumeLayout(false);
        }

        private Panel panelLeft;
        private Label lblStatus;
        private TabControl tabControl;

        private TabPage tabMain;
        private Label lblShape;
        private ComboBox cmbShape;
        private Button btnLoad;
        private Button btnSave;
        private Label lblOp;
        private ComboBox cmbOp;
        private Label lblParams;
        private TextBox txtParams;
        private Button btnApply;
        private Button btnReset;
        private Button btnUndo;

        private Label lblLightPos;
        private TextBox txtLightPos;
        private Label lblLightColor;
        private TextBox txtLightColor;
        private Label lblObjectColor;
        private TextBox txtObjectColor;
        private Button btnApplyLight;

        private GroupBox grpProjection;
        private RadioButton rbAxonometric;
        private RadioButton rbPerspective;
        private PictureBox canvas;
    }
}