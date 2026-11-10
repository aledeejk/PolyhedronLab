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
            tabRotation = new TabPage();
            btnUndoRot = new Button();
            txtParamsRot = new TextBox();
            cmbOpRot = new ComboBox();
            btnApplyRot = new Button();
            btnResetRot = new Button();
            label1 = new Label();
            lblOpRotation = new Label();
            btnSaveRotation = new Button();
            btnLoadRotation = new Button();
            lblGeneratrix = new Label();
            txtGeneratrix = new TextBox();
            cmbAxis = new ComboBox();
            txtSegments = new TextBox();
            btnBuildRotation = new Button();
            tabSurface = new TabPage();
            btnApplySurf = new Button();
            btnResetSurf = new Button();
            btnUndoSurf = new Button();
            txtParamsSurf = new TextBox();
            label2 = new Label();
            cmbOpSurf = new ComboBox();
            label3 = new Label();
            btnSaveSurface = new Button();
            btnLoadSurface = new Button();
            cmbFunction = new ComboBox();
            txtRange = new TextBox();
            txtDivs = new TextBox();
            btnBuildSurface = new Button();
            grpProjection = new GroupBox();
            rbAxonometric = new RadioButton();
            rbPerspective = new RadioButton();
            chkEdgesOnly = new CheckBox();
            canvas = new PictureBox();
            panelLeft.SuspendLayout();
            tabControl.SuspendLayout();
            tabMain.SuspendLayout();
            tabRotation.SuspendLayout();
            tabSurface.SuspendLayout();
            grpProjection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = SystemColors.Control;
            panelLeft.Controls.Add(lblStatus);
            panelLeft.Controls.Add(tabControl);
            panelLeft.Controls.Add(grpProjection);
            panelLeft.Controls.Add(chkEdgesOnly);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Margin = new Padding(3, 4, 3, 4);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(10, 12, 10, 12);
            panelLeft.Size = new Size(320, 875);
            panelLeft.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.LightGray;
            lblStatus.Dock = DockStyle.Top;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.Location = new Point(10, 638);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(300, 38);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Готово";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabMain);
            tabControl.Controls.Add(tabRotation);
            tabControl.Controls.Add(tabSurface);
            tabControl.Dock = DockStyle.Top;
            tabControl.Location = new Point(10, 12);
            tabControl.Margin = new Padding(3, 4, 3, 4);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(300, 626);
            tabControl.TabIndex = 1;
            // 
            // tabMain
            // 
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
            tabMain.Location = new Point(4, 29);
            tabMain.Margin = new Padding(3, 4, 3, 4);
            tabMain.Name = "tabMain";
            tabMain.Size = new Size(292, 593);
            tabMain.TabIndex = 0;
            tabMain.Text = "Многогранники";
            // 
            // lblShape
            // 
            lblShape.Location = new Point(10, 19);
            lblShape.Name = "lblShape";
            lblShape.Size = new Size(100, 25);
            lblShape.TabIndex = 0;
            lblShape.Text = "Многогранник:";
            // 
            // cmbShape
            // 
            cmbShape.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbShape.Items.AddRange(new object[] { "Тетраэдр", "Гексаэдр (куб)", "Октаэдр", "Икосаэдр", "Додекаэдр" });
            cmbShape.Location = new Point(10, 48);
            cmbShape.Margin = new Padding(3, 4, 3, 4);
            cmbShape.Name = "cmbShape";
            cmbShape.Size = new Size(150, 28);
            cmbShape.TabIndex = 1;
            cmbShape.SelectedIndexChanged += cmbShape_SelectedIndexChanged;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(170, 48);
            btnLoad.Margin = new Padding(3, 4, 3, 4);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(60, 30);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Загрузить...";
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(235, 48);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(60, 30);
            btnSave.TabIndex = 3;
            btnSave.Text = "Сохранить...";
            btnSave.Click += btnSave_Click;
            // 
            // lblOp
            // 
            lblOp.Location = new Point(10, 94);
            lblOp.Name = "lblOp";
            lblOp.Size = new Size(150, 25);
            lblOp.TabIndex = 4;
            lblOp.Text = "Преобразование:";
            // 
            // cmbOp
            // 
            cmbOp.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOp.Items.AddRange(new object[] { "Смещение (dx,dy,dz)", "Масштаб (sx,sy,sz)", "Масштаб отн. центра (k)", "Поворот вокруг X (угол°)", "Поворот вокруг Y (угол°)", "Поворот вокруг Z (угол°)", "Поворот оси || X через центр", "Поворот оси || Y через центр", "Поворот оси || Z через центр", "Поворот вокруг произвольной прямой", "Отражение отн. плоскости (X|Y|Z)" });
            cmbOp.Location = new Point(10, 122);
            cmbOp.Margin = new Padding(3, 4, 3, 4);
            cmbOp.Name = "cmbOp";
            cmbOp.Size = new Size(285, 28);
            cmbOp.TabIndex = 5;
            // 
            // lblParams
            // 
            lblParams.Location = new Point(10, 169);
            lblParams.Name = "lblParams";
            lblParams.Size = new Size(270, 25);
            lblParams.TabIndex = 6;
            lblParams.Text = "Параметры (через запятую):";
            // 
            // txtParams
            // 
            txtParams.Location = new Point(10, 198);
            txtParams.Margin = new Padding(3, 4, 3, 4);
            txtParams.Name = "txtParams";
            txtParams.Size = new Size(285, 27);
            txtParams.TabIndex = 7;
            txtParams.Text = "0,0,0";
            // 
            // btnApply
            // 
            btnApply.Location = new Point(10, 244);
            btnApply.Margin = new Padding(3, 4, 3, 4);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(130, 40);
            btnApply.TabIndex = 8;
            btnApply.Text = "Применить";
            btnApply.Click += btnApply_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(150, 244);
            btnReset.Margin = new Padding(3, 4, 3, 4);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(130, 40);
            btnReset.TabIndex = 9;
            btnReset.Text = "Сброс";
            btnReset.Click += btnReset_Click;
            // 
            // btnUndo
            // 
            btnUndo.Location = new Point(10, 294);
            btnUndo.Margin = new Padding(3, 4, 3, 4);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(270, 40);
            btnUndo.TabIndex = 10;
            btnUndo.Text = "Отменить последнее действие";
            btnUndo.Click += btnUndo_Click;
            // 
            // tabRotation
            // 
            tabRotation.Controls.Add(btnUndoRot);
            tabRotation.Controls.Add(txtParamsRot);
            tabRotation.Controls.Add(cmbOpRot);
            tabRotation.Controls.Add(btnApplyRot);
            tabRotation.Controls.Add(btnResetRot);
            tabRotation.Controls.Add(label1);
            tabRotation.Controls.Add(lblOpRotation);
            tabRotation.Controls.Add(btnSaveRotation);
            tabRotation.Controls.Add(btnLoadRotation);
            tabRotation.Controls.Add(lblGeneratrix);
            tabRotation.Controls.Add(txtGeneratrix);
            tabRotation.Controls.Add(cmbAxis);
            tabRotation.Controls.Add(txtSegments);
            tabRotation.Controls.Add(btnBuildRotation);
            tabRotation.Location = new Point(4, 29);
            tabRotation.Margin = new Padding(3, 4, 3, 4);
            tabRotation.Name = "tabRotation";
            tabRotation.Size = new Size(292, 593);
            tabRotation.TabIndex = 1;
            tabRotation.Text = "Фигура вращения";
            // 
            // btnUndoRot
            // 
            btnUndoRot.Location = new Point(10, 502);
            btnUndoRot.Margin = new Padding(3, 4, 3, 4);
            btnUndoRot.Name = "btnUndoRot";
            btnUndoRot.Size = new Size(270, 40);
            btnUndoRot.TabIndex = 21;
            btnUndoRot.Text = "Отменить последнее действие";
            btnUndoRot.Click += btnUndo_Click;
            // 
            // txtParamsRot
            // 
            txtParamsRot.Location = new Point(8, 405);
            txtParamsRot.Margin = new Padding(3, 4, 3, 4);
            txtParamsRot.Name = "txtParamsRot";
            txtParamsRot.Size = new Size(285, 27);
            txtParamsRot.TabIndex = 20;
            txtParamsRot.Text = "0,0,0";
            // 
            // cmbOpRot
            // 
            cmbOpRot.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOpRot.Items.AddRange(new object[] { "Смещение (dx,dy,dz)", "Масштаб (sx,sy,sz)", "Масштаб отн. центра (k)", "Поворот вокруг X (угол°)", "Поворот вокруг Y (угол°)", "Поворот вокруг Z (угол°)", "Поворот оси || X через центр", "Поворот оси || Y через центр", "Поворот оси || Z через центр", "Поворот вокруг произвольной прямой", "Отражение отн. плоскости (X|Y|Z)" });
            cmbOpRot.Location = new Point(8, 331);
            cmbOpRot.Margin = new Padding(3, 4, 3, 4);
            cmbOpRot.Name = "cmbOpRot";
            cmbOpRot.Size = new Size(285, 28);
            cmbOpRot.TabIndex = 18;
            // 
            // btnApplyRot
            // 
            btnApplyRot.Location = new Point(10, 454);
            btnApplyRot.Margin = new Padding(3, 4, 3, 4);
            btnApplyRot.Name = "btnApplyRot";
            btnApplyRot.Size = new Size(130, 40);
            btnApplyRot.TabIndex = 14;
            btnApplyRot.Text = "Применить";
            btnApplyRot.Click += btnApplyRot_Click;
            // 
            // btnResetRot
            // 
            btnResetRot.Location = new Point(150, 454);
            btnResetRot.Margin = new Padding(3, 4, 3, 4);
            btnResetRot.Name = "btnResetRot";
            btnResetRot.Size = new Size(130, 40);
            btnResetRot.TabIndex = 15;
            btnResetRot.Text = "Сброс";
            btnResetRot.Click += btnReset_Click;
            // 
            // label1
            // 
            label1.Location = new Point(10, 376);
            label1.Name = "label1";
            label1.Size = new Size(270, 25);
            label1.TabIndex = 9;
            label1.Text = "Параметры (через запятую):";
            // 
            // lblOpRotation
            // 
            lblOpRotation.Location = new Point(10, 302);
            lblOpRotation.Name = "lblOpRotation";
            lblOpRotation.Size = new Size(150, 25);
            lblOpRotation.TabIndex = 7;
            lblOpRotation.Text = "Преобразование:";
            // 
            // btnSaveRotation
            // 
            btnSaveRotation.Location = new Point(160, 235);
            btnSaveRotation.Name = "btnSaveRotation";
            btnSaveRotation.Size = new Size(120, 34);
            btnSaveRotation.TabIndex = 6;
            btnSaveRotation.Text = "Сохранить";
            btnSaveRotation.UseVisualStyleBackColor = true;
            btnSaveRotation.Click += btnSave_Click;
            // 
            // btnLoadRotation
            // 
            btnLoadRotation.Location = new Point(10, 235);
            btnLoadRotation.Name = "btnLoadRotation";
            btnLoadRotation.Size = new Size(120, 34);
            btnLoadRotation.TabIndex = 5;
            btnLoadRotation.Text = "Загрузить";
            btnLoadRotation.UseVisualStyleBackColor = true;
            btnLoadRotation.Click += btnLoad_Click;
            // 
            // lblGeneratrix
            // 
            lblGeneratrix.Location = new Point(10, 19);
            lblGeneratrix.Name = "lblGeneratrix";
            lblGeneratrix.Size = new Size(250, 25);
            lblGeneratrix.TabIndex = 0;
            lblGeneratrix.Text = "Образующая (x,y,z; x,y,z...):";
            // 
            // txtGeneratrix
            // 
            txtGeneratrix.Location = new Point(10, 48);
            txtGeneratrix.Margin = new Padding(3, 4, 3, 4);
            txtGeneratrix.Multiline = true;
            txtGeneratrix.Name = "txtGeneratrix";
            txtGeneratrix.Size = new Size(285, 74);
            txtGeneratrix.TabIndex = 1;
            txtGeneratrix.Text = "1,0,0; 2,0,0; 2,0,1; 1,0,1";
            // 
            // cmbAxis
            // 
            cmbAxis.Items.AddRange(new object[] { "Ось X", "Ось Y", "Ось Z" });
            cmbAxis.Location = new Point(10, 138);
            cmbAxis.Margin = new Padding(3, 4, 3, 4);
            cmbAxis.Name = "cmbAxis";
            cmbAxis.Size = new Size(100, 28);
            cmbAxis.TabIndex = 2;
            // 
            // txtSegments
            // 
            txtSegments.Location = new Point(120, 138);
            txtSegments.Margin = new Padding(3, 4, 3, 4);
            txtSegments.Name = "txtSegments";
            txtSegments.Size = new Size(50, 27);
            txtSegments.TabIndex = 3;
            txtSegments.Text = "20";
            // 
            // btnBuildRotation
            // 
            btnBuildRotation.Location = new Point(10, 188);
            btnBuildRotation.Margin = new Padding(3, 4, 3, 4);
            btnBuildRotation.Name = "btnBuildRotation";
            btnBuildRotation.Size = new Size(270, 40);
            btnBuildRotation.TabIndex = 4;
            btnBuildRotation.Text = "Построить фигуру вращения";
            btnBuildRotation.Click += btnBuildRotation_Click;
            // 
            // tabSurface
            // 
            tabSurface.Controls.Add(btnApplySurf);
            tabSurface.Controls.Add(btnResetSurf);
            tabSurface.Controls.Add(btnUndoSurf);
            tabSurface.Controls.Add(txtParamsSurf);
            tabSurface.Controls.Add(label2);
            tabSurface.Controls.Add(cmbOpSurf);
            tabSurface.Controls.Add(label3);
            tabSurface.Controls.Add(btnSaveSurface);
            tabSurface.Controls.Add(btnLoadSurface);
            tabSurface.Controls.Add(cmbFunction);
            tabSurface.Controls.Add(txtRange);
            tabSurface.Controls.Add(txtDivs);
            tabSurface.Controls.Add(btnBuildSurface);
            tabSurface.Location = new Point(4, 29);
            tabSurface.Margin = new Padding(3, 4, 3, 4);
            tabSurface.Name = "tabSurface";
            tabSurface.Size = new Size(292, 593);
            tabSurface.TabIndex = 2;
            tabSurface.Text = "График функции";
            // 
            // btnApplySurf
            // 
            btnApplySurf.Location = new Point(10, 401);
            btnApplySurf.Margin = new Padding(3, 4, 3, 4);
            btnApplySurf.Name = "btnApplySurf";
            btnApplySurf.Size = new Size(130, 40);
            btnApplySurf.TabIndex = 21;
            btnApplySurf.Text = "Применить";
            btnApplySurf.Click += btnApplySurf_Click;
            // 
            // btnResetSurf
            // 
            btnResetSurf.Location = new Point(150, 401);
            btnResetSurf.Margin = new Padding(3, 4, 3, 4);
            btnResetSurf.Name = "btnResetSurf";
            btnResetSurf.Size = new Size(130, 40);
            btnResetSurf.TabIndex = 22;
            btnResetSurf.Text = "Сброс";
            // 
            // btnUndoSurf
            // 
            btnUndoSurf.Location = new Point(10, 449);
            btnUndoSurf.Margin = new Padding(3, 4, 3, 4);
            btnUndoSurf.Name = "btnUndoSurf";
            btnUndoSurf.Size = new Size(270, 40);
            btnUndoSurf.TabIndex = 20;
            btnUndoSurf.Text = "Отменить последнее действие";
            btnUndoSurf.Click += btnUndo_Click;
            // 
            // txtParamsSurf
            // 
            txtParamsSurf.Location = new Point(10, 352);
            txtParamsSurf.Margin = new Padding(3, 4, 3, 4);
            txtParamsSurf.Name = "txtParamsSurf";
            txtParamsSurf.Size = new Size(285, 27);
            txtParamsSurf.TabIndex = 19;
            txtParamsSurf.Text = "0,0,0";
            // 
            // label2
            // 
            label2.Location = new Point(10, 323);
            label2.Name = "label2";
            label2.Size = new Size(270, 25);
            label2.TabIndex = 18;
            label2.Text = "Параметры (через запятую):";
            // 
            // cmbOpSurf
            // 
            cmbOpSurf.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOpSurf.Items.AddRange(new object[] { "Смещение (dx,dy,dz)", "Масштаб (sx,sy,sz)", "Масштаб отн. центра (k)", "Поворот вокруг X (угол°)", "Поворот вокруг Y (угол°)", "Поворот вокруг Z (угол°)", "Поворот оси || X через центр", "Поворот оси || Y через центр", "Поворот оси || Z через центр", "Поворот вокруг произвольной прямой", "Отражение отн. плоскости (X|Y|Z)" });
            cmbOpSurf.Location = new Point(10, 278);
            cmbOpSurf.Margin = new Padding(3, 4, 3, 4);
            cmbOpSurf.Name = "cmbOpSurf";
            cmbOpSurf.Size = new Size(285, 28);
            cmbOpSurf.TabIndex = 17;
            // 
            // label3
            // 
            label3.Location = new Point(10, 249);
            label3.Name = "label3";
            label3.Size = new Size(150, 25);
            label3.TabIndex = 16;
            label3.Text = "Преобразование:";
            // 
            // btnSaveSurface
            // 
            btnSaveSurface.Location = new Point(160, 191);
            btnSaveSurface.Name = "btnSaveSurface";
            btnSaveSurface.Size = new Size(120, 34);
            btnSaveSurface.TabIndex = 5;
            btnSaveSurface.Text = "Сохранить";
            btnSaveSurface.UseVisualStyleBackColor = true;
            btnSaveSurface.Click += btnSave_Click;
            // 
            // btnLoadSurface
            // 
            btnLoadSurface.Location = new Point(10, 191);
            btnLoadSurface.Name = "btnLoadSurface";
            btnLoadSurface.Size = new Size(120, 34);
            btnLoadSurface.TabIndex = 4;
            btnLoadSurface.Text = "Загрузить";
            btnLoadSurface.UseVisualStyleBackColor = true;
            btnLoadSurface.Click += btnLoad_Click;
            // 
            // cmbFunction
            // 
            cmbFunction.Items.AddRange(new object[] { "z = sin(x) * cos(y)", "z = x^2 - y^2", "z = sin(sqrt(x^2 + y^2))" });
            cmbFunction.Location = new Point(10, 19);
            cmbFunction.Margin = new Padding(3, 4, 3, 4);
            cmbFunction.Name = "cmbFunction";
            cmbFunction.Size = new Size(285, 28);
            cmbFunction.TabIndex = 0;
            // 
            // txtRange
            // 
            txtRange.Location = new Point(10, 62);
            txtRange.Margin = new Padding(3, 4, 3, 4);
            txtRange.Name = "txtRange";
            txtRange.Size = new Size(285, 27);
            txtRange.TabIndex = 1;
            txtRange.Text = "-3, 3, -3, 3";
            // 
            // txtDivs
            // 
            txtDivs.Location = new Point(10, 100);
            txtDivs.Margin = new Padding(3, 4, 3, 4);
            txtDivs.Name = "txtDivs";
            txtDivs.Size = new Size(100, 27);
            txtDivs.TabIndex = 2;
            txtDivs.Text = "20";
            // 
            // btnBuildSurface
            // 
            btnBuildSurface.Location = new Point(10, 144);
            btnBuildSurface.Margin = new Padding(3, 4, 3, 4);
            btnBuildSurface.Name = "btnBuildSurface";
            btnBuildSurface.Size = new Size(270, 40);
            btnBuildSurface.TabIndex = 3;
            btnBuildSurface.Text = "Построить график";
            btnBuildSurface.Click += btnBuildSurface_Click;
            // 
            // grpProjection
            // 
            grpProjection.Controls.Add(rbAxonometric);
            grpProjection.Controls.Add(rbPerspective);
            grpProjection.Location = new Point(14, 696);
            grpProjection.Margin = new Padding(3, 4, 3, 4);
            grpProjection.Name = "grpProjection";
            grpProjection.Padding = new Padding(3, 4, 3, 4);
            grpProjection.Size = new Size(270, 88);
            grpProjection.TabIndex = 2;
            grpProjection.TabStop = false;
            grpProjection.Text = "Проекция";
            // 
            // rbAxonometric
            // 
            rbAxonometric.Checked = true;
            rbAxonometric.Location = new Point(10, 25);
            rbAxonometric.Margin = new Padding(3, 4, 3, 4);
            rbAxonometric.Name = "rbAxonometric";
            rbAxonometric.Size = new Size(180, 25);
            rbAxonometric.TabIndex = 0;
            rbAxonometric.TabStop = true;
            rbAxonometric.Text = "Аксонометрическая";
            rbAxonometric.CheckedChanged += rbProjection_CheckedChanged;
            // 
            // rbPerspective
            // 
            rbPerspective.Location = new Point(10, 52);
            rbPerspective.Margin = new Padding(3, 4, 3, 4);
            rbPerspective.Name = "rbPerspective";
            rbPerspective.Size = new Size(180, 25);
            rbPerspective.TabIndex = 1;
            rbPerspective.Text = "Перспективная";
            rbPerspective.CheckedChanged += rbProjection_CheckedChanged;
            // 
            // chkEdgesOnly
            // 
            chkEdgesOnly.Location = new Point(14, 796);
            chkEdgesOnly.Margin = new Padding(3, 4, 3, 4);
            chkEdgesOnly.Name = "chkEdgesOnly";
            chkEdgesOnly.Size = new Size(250, 28);
            chkEdgesOnly.TabIndex = 3;
            chkEdgesOnly.Text = "Только рёбра (каркас)";
            chkEdgesOnly.CheckedChanged += chkEdgesOnly_CheckedChanged;
            // 
            // canvas
            // 
            canvas.BackColor = Color.White;
            canvas.Dock = DockStyle.Fill;
            canvas.Location = new Point(320, 0);
            canvas.Margin = new Padding(3, 4, 3, 4);
            canvas.Name = "canvas";
            canvas.Size = new Size(780, 875);
            canvas.TabIndex = 0;
            canvas.TabStop = false;
            canvas.Paint += canvas_Paint;
            canvas.Resize += canvas_Resize;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 875);
            Controls.Add(canvas);
            Controls.Add(panelLeft);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "ЛР7 — Построение трёхмерных моделей";
            panelLeft.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabMain.ResumeLayout(false);
            tabMain.PerformLayout();
            tabRotation.ResumeLayout(false);
            tabRotation.PerformLayout();
            tabSurface.ResumeLayout(false);
            tabSurface.PerformLayout();
            grpProjection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            ResumeLayout(false);
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
        private Button button2;
        private Button btnLoadRotation;
        private Button btnSaveRotation;
        private Button btnLoadSurface;
        private Button btnSaveSurface;
        private Button button1;
        private Button btnUndoSurf;
        private Button btnR;
        private TextBox textBox1;
        private Label label1;
        private ComboBox comboBox1;
        private Label lblOpRotation;
        private Button btnApplyRot;
        private Button btnResetRot;
        private TextBox txtParamsSurf;
        private Label label2;
        private ComboBox cmbOpSurf;
        private Label label3;
        private ComboBox cmbOpRot;
        private TextBox txtParamsRot;
        private Button btnUndoRot;
        private Button btnApplySurf;
        private Button btnResetSurf;
    }
}