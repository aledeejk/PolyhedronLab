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
            this.lblShape = new System.Windows.Forms.Label();
            this.cmbShape = new System.Windows.Forms.ComboBox();
            this.lblOp = new System.Windows.Forms.Label();
            this.cmbOp = new System.Windows.Forms.ComboBox();
            this.lblParams = new System.Windows.Forms.Label();
            this.txtParams = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button(); // НОВАЯ КНОПКА
            this.grpProjection = new System.Windows.Forms.GroupBox();
            this.rbAxonometric = new System.Windows.Forms.RadioButton();
            this.rbPerspective = new System.Windows.Forms.RadioButton();
            this.chkEdgesOnly = new System.Windows.Forms.CheckBox();
            this.lblHint = new System.Windows.Forms.Label();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelLeft.SuspendLayout();
            this.grpProjection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();

            // panelLeft
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Width = 300;
            this.panelLeft.Padding = new System.Windows.Forms.Padding(10);
            this.panelLeft.BackColor = System.Drawing.SystemColors.Control;
            this.panelLeft.Controls.Add(this.lblShape);
            this.panelLeft.Controls.Add(this.cmbShape);
            this.panelLeft.Controls.Add(this.lblOp);
            this.panelLeft.Controls.Add(this.cmbOp);
            this.panelLeft.Controls.Add(this.lblParams);
            this.panelLeft.Controls.Add(this.txtParams);
            this.panelLeft.Controls.Add(this.btnApply);
            this.panelLeft.Controls.Add(this.btnReset);
            this.panelLeft.Controls.Add(this.btnUndo); // Добавили на панель
            this.panelLeft.Controls.Add(this.grpProjection);
            this.panelLeft.Controls.Add(this.chkEdgesOnly);
            this.panelLeft.Controls.Add(this.lblHint);

            // lblShape
            this.lblShape.Text = "Многогранник:";
            this.lblShape.Location = new System.Drawing.Point(10, 15);
            this.lblShape.Size = new System.Drawing.Size(200, 20);

            // cmbShape
            this.cmbShape.Location = new System.Drawing.Point(10, 38);
            this.cmbShape.Size = new System.Drawing.Size(270, 24);
            this.cmbShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShape.Items.AddRange(new object[] { "Тетраэдр", "Гексаэдр (куб)", "Октаэдр", "Икосаэдр", "Додекаэдр" });
            this.cmbShape.SelectedIndex = 1;
            this.cmbShape.SelectedIndexChanged += new System.EventHandler(this.cmbShape_SelectedIndexChanged);

            // lblOp
            this.lblOp.Text = "Преобразование:";
            this.lblOp.Location = new System.Drawing.Point(10, 75);
            this.lblOp.Size = new System.Drawing.Size(200, 20);

            // cmbOp
            this.cmbOp.Location = new System.Drawing.Point(10, 98);
            this.cmbOp.Size = new System.Drawing.Size(270, 24);
            this.cmbOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOp.Items.AddRange(new object[] {
                "Смещение (dx,dy,dz)", "Масштаб (sx,sy,sz)", "Масштаб отн. центра (k)",
                "Поворот вокруг X (угол°)", "Поворот вокруг Y (угол°)", "Поворот вокруг Z (угол°)",
                "Поворот оси || X через центр", "Поворот оси || Y через центр", "Поворот оси || Z через центр",
                "Поворот вокруг произвольной прямой", "Отражение отн. плоскости (X|Y|Z)" });
            this.cmbOp.SelectedIndex = 0;

            // lblParams
            this.lblParams.Text = "Параметры (через запятую):";
            this.lblParams.Location = new System.Drawing.Point(10, 135);
            this.lblParams.Size = new System.Drawing.Size(250, 20);

            // txtParams
            this.txtParams.Location = new System.Drawing.Point(10, 158);
            this.txtParams.Size = new System.Drawing.Size(270, 22);
            this.txtParams.Text = "0,0,0";

            // btnApply
            this.btnApply.Location = new System.Drawing.Point(10, 195);
            this.btnApply.Size = new System.Drawing.Size(130, 32);
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);

            // btnReset
            this.btnReset.Location = new System.Drawing.Point(150, 195);
            this.btnReset.Size = new System.Drawing.Size(130, 32);
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // btnUndo
            this.btnUndo.Location = new System.Drawing.Point(10, 235);
            this.btnUndo.Size = new System.Drawing.Size(270, 32);
            this.btnUndo.Text = "Отменить последнее действие";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);

            // grpProjection
            this.grpProjection.Text = "Проекция";
            this.grpProjection.Location = new System.Drawing.Point(10, 280); // Сдвинули вниз
            this.grpProjection.Size = new System.Drawing.Size(270, 70);
            this.grpProjection.Controls.Add(this.rbAxonometric);
            this.grpProjection.Controls.Add(this.rbPerspective);

            // rbAxonometric
            this.rbAxonometric.Text = "Аксонометрическая";
            this.rbAxonometric.Location = new System.Drawing.Point(10, 20);
            this.rbAxonometric.Size = new System.Drawing.Size(180, 20);
            this.rbAxonometric.Checked = true;
            this.rbAxonometric.CheckedChanged += new System.EventHandler(this.rbProjection_CheckedChanged);

            // rbPerspective
            this.rbPerspective.Text = "Перспективная";
            this.rbPerspective.Location = new System.Drawing.Point(10, 42);
            this.rbPerspective.Size = new System.Drawing.Size(180, 20);
            this.rbPerspective.CheckedChanged += new System.EventHandler(this.rbProjection_CheckedChanged);

            // chkEdgesOnly
            this.chkEdgesOnly.Text = "Только рёбра (каркас)";
            this.chkEdgesOnly.Location = new System.Drawing.Point(10, 360); // Сдвинули вниз
            this.chkEdgesOnly.Size = new System.Drawing.Size(250, 22);
            this.chkEdgesOnly.CheckedChanged += new System.EventHandler(this.chkEdgesOnly_CheckedChanged);

            // lblHint
            this.lblHint.Location = new System.Drawing.Point(10, 395); // Сдвинули вниз
            this.lblHint.Size = new System.Drawing.Size(275, 220);
            this.lblHint.Text = "Подсказки:\r\n• Смещение: dx,dy,dz\r\n• Масштаб: sx,sy,sz\r\n• Масштаб отн. центра: k\r\n• Повороты осей: угол°\r\n• Ось || X/Y/Z: угол°\r\n• Произвольная прямая: x1,y1,z1,x2,y2,z2,угол°\r\n• Отражение: X, Y или Z";

            // canvas
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.Resize += new System.EventHandler(this.canvas_Resize);

            // lblStatus
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Height = 30;
            this.lblStatus.Text = "Выберите операцию";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.BackColor = System.Drawing.Color.LightGray;
            this.lblStatus.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panelLeft);
            this.Text = "ЛР6 — Многогранники и аффинные преобразования";
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.grpProjection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblShape;
        private System.Windows.Forms.ComboBox cmbShape;
        private System.Windows.Forms.Label lblOp;
        private System.Windows.Forms.ComboBox cmbOp;
        private System.Windows.Forms.Label lblParams;
        private System.Windows.Forms.TextBox txtParams;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnUndo; // Объявили переменную
        private System.Windows.Forms.GroupBox grpProjection;
        private System.Windows.Forms.RadioButton rbAxonometric;
        private System.Windows.Forms.RadioButton rbPerspective;
        private System.Windows.Forms.CheckBox chkEdgesOnly;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Label lblStatus;
    }
}