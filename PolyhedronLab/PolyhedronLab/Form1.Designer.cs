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

            // ================= ВКЛАДКА 1: МНОГОГРАННИКИ =================
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

            // ================= ВКЛАДКА 2: ВРАЩЕНИЕ =================
            tabRotation = new TabPage();
            lblGeneratrix = new Label();
            txtGeneratrix = new TextBox();
            cmbAxis = new ComboBox();
            txtSegments = new TextBox();
            btnBuildRotation = new Button();
            btnLoadRotation = new Button();
            btnSaveRotation = new Button();
            lblOpRot = new Label();
            cmbOpRot = new ComboBox();
            lblParamsRot = new Label();
            txtParamsRot = new TextBox();
            btnApplyRot = new Button();
            btnResetRot = new Button();
            btnUndoRot = new Button();

            // ================= ВКЛАДКА 3: ГРАФИК =================
            tabSurface = new TabPage();
            cmbFunction = new ComboBox();
            txtRange = new TextBox();
            txtDivs = new TextBox();
            btnBuildSurface = new Button();
            btnLoadSurface = new Button();
            btnSaveSurface = new Button();
            lblOpSurf = new Label();
            cmbOpSurf = new ComboBox();
            lblParamsSurf = new Label();
            txtParamsSurf = new TextBox();
            btnApplySurf = new Button();
            btnResetSurf = new Button();
            btnUndoSurf = new Button();

            // ================= ВКЛАДКА 4: ОТСЕЧЕНИЕ =================
            tabCulling = new TabPage();
            lblCullingInfo = new Label();
            btnTestCulling = new Button();
            txtViewVector = new TextBox();
            lblViewVector = new Label();
            lblOpCull = new Label();
            cmbOpCull = new ComboBox();
            lblParamsCull = new Label();
            txtParamsCull = new TextBox();
            btnApplyCull = new Button();
            btnResetCull = new Button();
            btnUndoCull = new Button();

            // ================= ВКЛАДКА 5: Z-БУФЕР =================
            tabZBuffer = new TabPage();
            lblZBufferInfo = new Label();
            cmbZBufferShape = new ComboBox();
            btnAddSecondObject = new Button();
            lblOpZBuffer = new Label();
            cmbOpZBuffer = new ComboBox();
            lblParamsZBuffer = new Label();
            txtParamsZBuffer = new TextBox();
            btnApplyZBuffer = new Button();
            btnResetZBuffer = new Button();
            btnUndoZBuffer = new Button();

            // ================= ВКЛАДКА 6: КАМЕРА =================
            tabCamera = new TabPage();
            lblCameraInfo = new Label();
            btnRotateCamera = new Button();
            trbCameraAngle = new TrackBar();
            lblOpCam = new Label();
            cmbOpCam = new ComboBox();
            lblParamsCam = new Label();
            txtParamsCam = new TextBox();
            btnApplyCam = new Button();
            btnResetCam = new Button();
            btnUndoCam = new Button();

            // ================= ОБЩИЕ ЭЛЕМЕНТЫ =================
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
            tabCulling.SuspendLayout();
            tabZBuffer.SuspendLayout();
            tabCamera.SuspendLayout();
            grpProjection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            SuspendLayout();

            // panelLeft
            panelLeft.BackColor = SystemColors.Control;
            panelLeft.Controls.Add(lblStatus);
            panelLeft.Controls.Add(tabControl);
            panelLeft.Controls.Add(grpProjection);
            panelLeft.Controls.Add(chkEdgesOnly);
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
            tabControl.Controls.Add(tabRotation);
            tabControl.Controls.Add(tabSurface);
            tabControl.Controls.Add(tabCulling);
            tabControl.Controls.Add(tabZBuffer);
            tabControl.Controls.Add(tabCamera);
            tabControl.Dock = DockStyle.Top;
            tabControl.Location = new Point(10, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(300, 626);
            tabControl.TabIndex = 1;

            // ================= ВКЛАДКА 1: МНОГОГРАННИКИ =================
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
            tabMain.Name = "tabMain";
            tabMain.Size = new Size(292, 593);
            tabMain.Text = "Многогранники";

            lblShape.Location = new Point(10, 19); lblShape.Size = new Size(100, 25); lblShape.Text = "Многогранник:";
            cmbShape.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbShape.Items.AddRange(new object[] { "Тетраэдр", "Гексаэдр (куб)", "Октаэдр", "Икосаэдр", "Додекаэдр" });
            cmbShape.Location = new Point(10, 48); cmbShape.Size = new Size(150, 28); cmbShape.SelectedIndexChanged += cmbShape_SelectedIndexChanged;
            btnLoad.Location = new Point(170, 48); btnLoad.Size = new Size(60, 30); btnLoad.Text = "Загрузить..."; btnLoad.Click += btnLoad_Click;
            btnSave.Location = new Point(235, 48); btnSave.Size = new Size(60, 30); btnSave.Text = "Сохранить..."; btnSave.Click += btnSave_Click;
            lblOp.Location = new Point(10, 94); lblOp.Size = new Size(150, 25); lblOp.Text = "Преобразование:";
            cmbOp.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOp.Items.AddRange(new object[] { "Смещение (dx,dy,dz)", "Масштаб (sx,sy,sz)", "Масштаб отн. центра (k)", "Поворот вокруг X (угол°)", "Поворот вокруг Y (угол°)", "Поворот вокруг Z (угол°)", "Поворот оси || X через центр", "Поворот оси || Y через центр", "Поворот оси || Z через центр", "Поворот вокруг произвольной прямой", "Отражение отн. плоскости (X|Y|Z)" });
            cmbOp.Location = new Point(10, 122); cmbOp.Size = new Size(285, 28);
            lblParams.Location = new Point(10, 169); lblParams.Size = new Size(270, 25); lblParams.Text = "Параметры (через запятую):";
            txtParams.Location = new Point(10, 198); txtParams.Size = new Size(285, 27); txtParams.Text = "0,0,0";
            btnApply.Location = new Point(10, 244); btnApply.Size = new Size(130, 40); btnApply.Text = "Применить"; btnApply.Click += btnApply_Click;
            btnReset.Location = new Point(150, 244); btnReset.Size = new Size(130, 40); btnReset.Text = "Сброс"; btnReset.Click += btnReset_Click;
            btnUndo.Location = new Point(10, 294); btnUndo.Size = new Size(270, 40); btnUndo.Text = "Отменить последнее действие"; btnUndo.Click += btnUndo_Click;

            // ================= ВКЛАДКА 2: ВРАЩЕНИЕ =================
            tabRotation.Controls.Add(lblGeneratrix);
            tabRotation.Controls.Add(txtGeneratrix);
            tabRotation.Controls.Add(cmbAxis);
            tabRotation.Controls.Add(txtSegments);
            tabRotation.Controls.Add(btnBuildRotation);
            tabRotation.Controls.Add(btnLoadRotation);
            tabRotation.Controls.Add(btnSaveRotation);
            tabRotation.Controls.Add(lblOpRot);
            tabRotation.Controls.Add(cmbOpRot);
            tabRotation.Controls.Add(lblParamsRot);
            tabRotation.Controls.Add(txtParamsRot);
            tabRotation.Controls.Add(btnApplyRot);
            tabRotation.Controls.Add(btnResetRot);
            tabRotation.Controls.Add(btnUndoRot);
            tabRotation.Location = new Point(4, 29);
            tabRotation.Name = "tabRotation";
            tabRotation.Size = new Size(292, 593);
            tabRotation.Text = "Фигура вращения";

            lblGeneratrix.Location = new Point(10, 19); lblGeneratrix.Size = new Size(250, 25); lblGeneratrix.Text = "Образующая (x,y,z; x,y,z...):";
            txtGeneratrix.Location = new Point(10, 48); txtGeneratrix.Multiline = true; txtGeneratrix.Size = new Size(285, 74); txtGeneratrix.Text = "1,0,0; 2,0,0; 2,0,1; 1,0,1";
            cmbAxis.Items.AddRange(new object[] { "Ось X", "Ось Y", "Ось Z" }); cmbAxis.Location = new Point(10, 138); cmbAxis.Size = new Size(100, 28);
            txtSegments.Location = new Point(120, 138); txtSegments.Size = new Size(50, 27); txtSegments.Text = "20";
            btnBuildRotation.Location = new Point(10, 188); btnBuildRotation.Size = new Size(270, 40); btnBuildRotation.Text = "Построить фигуру вращения"; btnBuildRotation.Click += btnBuildRotation_Click;
            btnLoadRotation.Location = new Point(10, 235); btnLoadRotation.Size = new Size(120, 34); btnLoadRotation.Text = "Загрузить"; btnLoadRotation.Click += btnLoad_Click;
            btnSaveRotation.Location = new Point(160, 235); btnSaveRotation.Size = new Size(120, 34); btnSaveRotation.Text = "Сохранить"; btnSaveRotation.Click += btnSave_Click;
            lblOpRot.Location = new Point(10, 280); lblOpRot.Size = new Size(150, 25); lblOpRot.Text = "Преобразование:";
            cmbOpRot.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOpRot.Items.AddRange(new object[] { "Смещение (dx,dy,dz)", "Масштаб (sx,sy,sz)", "Масштаб отн. центра (k)", "Поворот вокруг X (угол°)", "Поворот вокруг Y (угол°)", "Поворот вокруг Z (угол°)", "Поворот оси || X через центр", "Поворот оси || Y через центр", "Поворот оси || Z через центр", "Поворот вокруг произвольной прямой", "Отражение отн. плоскости (X|Y|Z)" });
            cmbOpRot.Location = new Point(10, 308); cmbOpRot.Size = new Size(285, 28);
            lblParamsRot.Location = new Point(10, 350); lblParamsRot.Size = new Size(270, 25); lblParamsRot.Text = "Параметры (через запятую):";
            txtParamsRot.Location = new Point(10, 378); txtParamsRot.Size = new Size(285, 27); txtParamsRot.Text = "0,0,0";
            btnApplyRot.Location = new Point(10, 420); btnApplyRot.Size = new Size(130, 40); btnApplyRot.Text = "Применить"; btnApplyRot.Click += btnApplyRot_Click;
            btnResetRot.Location = new Point(150, 420); btnResetRot.Size = new Size(130, 40); btnResetRot.Text = "Сброс"; btnResetRot.Click += btnReset_Click;
            btnUndoRot.Location = new Point(10, 470); btnUndoRot.Size = new Size(270, 40); btnUndoRot.Text = "Отменить последнее действие"; btnUndoRot.Click += btnUndo_Click;

            // ================= ВКЛАДКА 3: ГРАФИК =================
            tabSurface.Controls.Add(cmbFunction);
            tabSurface.Controls.Add(txtRange);
            tabSurface.Controls.Add(txtDivs);
            tabSurface.Controls.Add(btnBuildSurface);
            tabSurface.Controls.Add(btnLoadSurface);
            tabSurface.Controls.Add(btnSaveSurface);
            tabSurface.Controls.Add(lblOpSurf);
            tabSurface.Controls.Add(cmbOpSurf);
            tabSurface.Controls.Add(lblParamsSurf);
            tabSurface.Controls.Add(txtParamsSurf);
            tabSurface.Controls.Add(btnApplySurf);
            tabSurface.Controls.Add(btnResetSurf);
            tabSurface.Controls.Add(btnUndoSurf);
            tabSurface.Location = new Point(4, 29);
            tabSurface.Name = "tabSurface";
            tabSurface.Size = new Size(292, 593);
            tabSurface.Text = "График функции";

            cmbFunction.Items.AddRange(new object[] { "z = sin(x) * cos(y)", "z = x^2 - y^2", "z = sin(sqrt(x^2 + y^2))" }); cmbFunction.Location = new Point(10, 19); cmbFunction.Size = new Size(285, 28);
            txtRange.Location = new Point(10, 62); txtRange.Size = new Size(285, 27); txtRange.Text = "-3, 3, -3, 3";
            txtDivs.Location = new Point(10, 100); txtDivs.Size = new Size(100, 27); txtDivs.Text = "20";
            btnBuildSurface.Location = new Point(10, 144); btnBuildSurface.Size = new Size(270, 40); btnBuildSurface.Text = "Построить график"; btnBuildSurface.Click += btnBuildSurface_Click;
            btnLoadSurface.Location = new Point(10, 191); btnLoadSurface.Size = new Size(120, 34); btnLoadSurface.Text = "Загрузить"; btnLoadSurface.Click += btnLoad_Click;
            btnSaveSurface.Location = new Point(160, 191); btnSaveSurface.Size = new Size(120, 34); btnSaveSurface.Text = "Сохранить"; btnSaveSurface.Click += btnSave_Click;
            lblOpSurf.Location = new Point(10, 240); lblOpSurf.Size = new Size(150, 25); lblOpSurf.Text = "Преобразование:";
            cmbOpSurf.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOpSurf.Items.AddRange(new object[] { "Смещение (dx,dy,dz)", "Масштаб (sx,sy,sz)", "Масштаб отн. центра (k)", "Поворот вокруг X (угол°)", "Поворот вокруг Y (угол°)", "Поворот вокруг Z (угол°)", "Поворот оси || X через центр", "Поворот оси || Y через центр", "Поворот оси || Z через центр", "Поворот вокруг произвольной прямой", "Отражение отн. плоскости (X|Y|Z)" });
            cmbOpSurf.Location = new Point(10, 268); cmbOpSurf.Size = new Size(285, 28);
            lblParamsSurf.Location = new Point(10, 310); lblParamsSurf.Size = new Size(270, 25); lblParamsSurf.Text = "Параметры (через запятую):";
            txtParamsSurf.Location = new Point(10, 338); txtParamsSurf.Size = new Size(285, 27); txtParamsSurf.Text = "0,0,0";
            btnApplySurf.Location = new Point(10, 380); btnApplySurf.Size = new Size(130, 40); btnApplySurf.Text = "Применить"; btnApplySurf.Click += btnApplySurf_Click;
            btnResetSurf.Location = new Point(150, 380); btnResetSurf.Size = new Size(130, 40); btnResetSurf.Text = "Сброс"; btnResetSurf.Click += btnReset_Click;
            btnUndoSurf.Location = new Point(10, 430); btnUndoSurf.Size = new Size(270, 40); btnUndoSurf.Text = "Отменить последнее действие"; btnUndoSurf.Click += btnUndo_Click;

            // ================= ВКЛАДКА 4: ОТСЕЧЕНИЕ =================
            tabCulling.Controls.Add(lblCullingInfo);
            tabCulling.Controls.Add(btnTestCulling);
            tabCulling.Controls.Add(txtViewVector);
            tabCulling.Controls.Add(lblViewVector);
            tabCulling.Controls.Add(lblOpCull);
            tabCulling.Controls.Add(cmbOpCull);
            tabCulling.Controls.Add(lblParamsCull);
            tabCulling.Controls.Add(txtParamsCull);
            tabCulling.Controls.Add(btnApplyCull);
            tabCulling.Controls.Add(btnResetCull);
            tabCulling.Controls.Add(btnUndoCull);
            tabCulling.Location = new Point(4, 29);
            tabCulling.Name = "tabCulling";
            tabCulling.Size = new Size(292, 593);
            tabCulling.Text = "Отсечение";

            lblCullingInfo.Location = new Point(10, 10); lblCullingInfo.Size = new Size(270, 40); lblCullingInfo.Text = "Демонстрация отсечения нелицевых граней.";
            lblViewVector.Location = new Point(10, 60); lblViewVector.Size = new Size(200, 25); lblViewVector.Text = "Вектор обзора (x,y,z):";
            txtViewVector.Location = new Point(10, 85); txtViewVector.Size = new Size(285, 27); txtViewVector.Text = "0, 0, -1";
            btnTestCulling.Location = new Point(10, 120); btnTestCulling.Size = new Size(270, 30); btnTestCulling.Text = "Применить вектор обзора"; btnTestCulling.Click += btnTestCulling_Click;

            lblOpCull.Location = new Point(10, 170); lblOpCull.Size = new Size(150, 25); lblOpCull.Text = "Преобразование:";
            cmbOpCull.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOpCull.Items.AddRange(new object[] { "Смещение (dx,dy,dz)", "Масштаб (sx,sy,sz)", "Поворот вокруг X", "Поворот вокруг Y", "Поворот вокруг Z" });
            cmbOpCull.Location = new Point(10, 198); cmbOpCull.Size = new Size(285, 28);
            lblParamsCull.Location = new Point(10, 240); lblParamsCull.Size = new Size(270, 25); lblParamsCull.Text = "Параметры (через запятую):";
            txtParamsCull.Location = new Point(10, 268); txtParamsCull.Size = new Size(285, 27); txtParamsCull.Text = "0,0,0";
            btnApplyCull.Location = new Point(10, 310); btnApplyCull.Size = new Size(130, 40); btnApplyCull.Text = "Применить"; btnApplyCull.Click += btnApplyCull_Click;
            btnResetCull.Location = new Point(150, 310); btnResetCull.Size = new Size(130, 40); btnResetCull.Text = "Сброс"; btnResetCull.Click += btnReset_Click;
            btnUndoCull.Location = new Point(10, 360); btnUndoCull.Size = new Size(270, 40); btnUndoCull.Text = "Отменить последнее действие"; btnUndoCull.Click += btnUndo_Click;

            // ================= ВКЛАДКА 5: Z-БУФЕР =================
            tabZBuffer.Controls.Add(lblZBufferInfo);
            tabZBuffer.Controls.Add(cmbZBufferShape);
            tabZBuffer.Controls.Add(btnAddSecondObject);
            tabZBuffer.Controls.Add(lblOpZBuffer);
            tabZBuffer.Controls.Add(cmbOpZBuffer);
            tabZBuffer.Controls.Add(lblParamsZBuffer);
            tabZBuffer.Controls.Add(txtParamsZBuffer);
            tabZBuffer.Controls.Add(btnApplyZBuffer);
            tabZBuffer.Controls.Add(btnResetZBuffer);
            tabZBuffer.Controls.Add(btnUndoZBuffer);
            tabZBuffer.Location = new Point(4, 29);
            tabZBuffer.Name = "tabZBuffer";
            tabZBuffer.Size = new Size(292, 593);
            tabZBuffer.Text = "Z-буфер";

            lblZBufferInfo.Location = new Point(10, 10); lblZBufferInfo.Size = new Size(270, 40); lblZBufferInfo.Text = "Перекрытие двух объектов.";
            cmbZBufferShape.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbZBufferShape.Items.AddRange(new object[] { "Куб", "Октаэдр", "Тетраэдр" });
            cmbZBufferShape.Location = new Point(10, 55); cmbZBufferShape.Size = new Size(150, 28); cmbZBufferShape.SelectedIndexChanged += cmbZBufferShape_SelectedIndexChanged;
            btnAddSecondObject.Location = new Point(170, 55); btnAddSecondObject.Size = new Size(120, 30); btnAddSecondObject.Text = "Второй объект"; btnAddSecondObject.Click += btnAddSecondObject_Click;

            lblOpZBuffer.Location = new Point(10, 110); lblOpZBuffer.Size = new Size(150, 25); lblOpZBuffer.Text = "Преобразование:";
            cmbOpZBuffer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOpZBuffer.Items.AddRange(new object[] { "Смещение (dx,dy,dz)", "Масштаб (sx,sy,sz)", "Поворот вокруг X", "Поворот вокруг Y", "Поворот вокруг Z" });
            cmbOpZBuffer.Location = new Point(10, 138); cmbOpZBuffer.Size = new Size(285, 28);
            lblParamsZBuffer.Location = new Point(10, 180); lblParamsZBuffer.Size = new Size(270, 25); lblParamsZBuffer.Text = "Параметры (через запятую):";
            txtParamsZBuffer.Location = new Point(10, 208); txtParamsZBuffer.Size = new Size(285, 27); txtParamsZBuffer.Text = "0,0,0";
            btnApplyZBuffer.Location = new Point(10, 250); btnApplyZBuffer.Size = new Size(130, 40); btnApplyZBuffer.Text = "Применить"; btnApplyZBuffer.Click += btnApplyZBuffer_Click;
            btnResetZBuffer.Location = new Point(150, 250); btnResetZBuffer.Size = new Size(130, 40); btnResetZBuffer.Text = "Сброс"; btnResetZBuffer.Click += btnReset_Click;
            btnUndoZBuffer.Location = new Point(10, 300); btnUndoZBuffer.Size = new Size(270, 40); btnUndoZBuffer.Text = "Отменить последнее действие"; btnUndoZBuffer.Click += btnUndo_Click;

            // ================= ВКЛАДКА 6: КАМЕРА =================
            tabCamera.Controls.Add(lblCameraInfo);
            tabCamera.Controls.Add(btnRotateCamera);
            tabCamera.Controls.Add(trbCameraAngle);
            tabCamera.Controls.Add(lblOpCam);
            tabCamera.Controls.Add(cmbOpCam);
            tabCamera.Controls.Add(lblParamsCam);
            tabCamera.Controls.Add(txtParamsCam);
            tabCamera.Controls.Add(btnApplyCam);
            tabCamera.Controls.Add(btnResetCam);
            tabCamera.Controls.Add(btnUndoCam);
            tabCamera.Location = new Point(4, 29);
            tabCamera.Name = "tabCamera";
            tabCamera.Size = new Size(292, 593);
            tabCamera.Text = "Камера";

            lblCameraInfo.Location = new Point(10, 10); lblCameraInfo.Size = new Size(270, 40); lblCameraInfo.Text = "Камера вращается вокруг объекта.";
            btnRotateCamera.Location = new Point(10, 55); btnRotateCamera.Size = new Size(270, 30); btnRotateCamera.Text = "Включить/остановить вращение"; btnRotateCamera.Click += btnRotateCamera_Click;
            trbCameraAngle.Location = new Point(10, 95); trbCameraAngle.Size = new Size(270, 45); trbCameraAngle.Minimum = 0; trbCameraAngle.Maximum = 360; trbCameraAngle.Value = 0;

            lblOpCam.Location = new Point(10, 150); lblOpCam.Size = new Size(150, 25); lblOpCam.Text = "Преобразование:";
            cmbOpCam.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOpCam.Items.AddRange(new object[] { "Смещение (dx,dy,dz)", "Масштаб (sx,sy,sz)", "Поворот вокруг X", "Поворот вокруг Y", "Поворот вокруг Z" });
            cmbOpCam.Location = new Point(10, 178); cmbOpCam.Size = new Size(285, 28);
            lblParamsCam.Location = new Point(10, 220); lblParamsCam.Size = new Size(270, 25); lblParamsCam.Text = "Параметры (через запятую):";
            txtParamsCam.Location = new Point(10, 248); txtParamsCam.Size = new Size(285, 27); txtParamsCam.Text = "0,0,0";
            btnApplyCam.Location = new Point(10, 290); btnApplyCam.Size = new Size(130, 40); btnApplyCam.Text = "Применить"; btnApplyCam.Click += btnApplyCam_Click;
            btnResetCam.Location = new Point(150, 290); btnResetCam.Size = new Size(130, 40); btnResetCam.Text = "Сброс"; btnResetCam.Click += btnReset_Click;
            btnUndoCam.Location = new Point(10, 340); btnUndoCam.Size = new Size(270, 40); btnUndoCam.Text = "Отменить последнее действие"; btnUndoCam.Click += btnUndo_Click;

            // ================= ОБЩИЕ ЭЛЕМЕНТЫ =================
            grpProjection.Controls.Add(rbAxonometric);
            grpProjection.Controls.Add(rbPerspective);
            grpProjection.Location = new Point(14, 696);
            grpProjection.Size = new Size(270, 88);
            grpProjection.Text = "Проекция";
            rbAxonometric.Checked = true; rbAxonometric.Location = new Point(10, 25); rbAxonometric.Size = new Size(180, 25); rbAxonometric.Text = "Аксонометрическая"; rbAxonometric.CheckedChanged += rbProjection_CheckedChanged;
            rbPerspective.Location = new Point(10, 52); rbPerspective.Size = new Size(180, 25); rbPerspective.Text = "Перспективная"; rbPerspective.CheckedChanged += rbProjection_CheckedChanged;

            chkEdgesOnly.Location = new Point(14, 796);
            chkEdgesOnly.Size = new Size(250, 28);
            chkEdgesOnly.Text = "Только рёбра (каркас)";
            chkEdgesOnly.CheckedChanged += chkEdgesOnly_CheckedChanged;

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
            Text = "ЛР8 — Удаление невидимых граней";

            panelLeft.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabMain.ResumeLayout(false); tabMain.PerformLayout();
            tabRotation.ResumeLayout(false); tabRotation.PerformLayout();
            tabSurface.ResumeLayout(false); tabSurface.PerformLayout();
            tabCulling.ResumeLayout(false); tabCulling.PerformLayout();
            tabZBuffer.ResumeLayout(false); tabZBuffer.PerformLayout();
            tabCamera.ResumeLayout(false); tabCamera.PerformLayout();
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

        private TabPage tabRotation;
        private Label lblGeneratrix;
        private TextBox txtGeneratrix;
        private ComboBox cmbAxis;
        private TextBox txtSegments;
        private Button btnBuildRotation;
        private Button btnLoadRotation;
        private Button btnSaveRotation;
        private Label lblOpRot;
        private ComboBox cmbOpRot;
        private Label lblParamsRot;
        private TextBox txtParamsRot;
        private Button btnApplyRot;
        private Button btnResetRot;
        private Button btnUndoRot;

        private TabPage tabSurface;
        private ComboBox cmbFunction;
        private TextBox txtRange;
        private TextBox txtDivs;
        private Button btnBuildSurface;
        private Button btnLoadSurface;
        private Button btnSaveSurface;
        private Label lblOpSurf;
        private ComboBox cmbOpSurf;
        private Label lblParamsSurf;
        private TextBox txtParamsSurf;
        private Button btnApplySurf;
        private Button btnResetSurf;
        private Button btnUndoSurf;

        private TabPage tabCulling;
        private Label lblCullingInfo;
        private Button btnTestCulling;
        private TextBox txtViewVector;
        private Label lblViewVector;
        private Label lblOpCull;
        private ComboBox cmbOpCull;
        private Label lblParamsCull;
        private TextBox txtParamsCull;
        private Button btnApplyCull;
        private Button btnResetCull;
        private Button btnUndoCull;

        private TabPage tabZBuffer;
        private Label lblZBufferInfo;
        private ComboBox cmbZBufferShape;
        private Button btnAddSecondObject;
        private Label lblOpZBuffer;
        private ComboBox cmbOpZBuffer;
        private Label lblParamsZBuffer;
        private TextBox txtParamsZBuffer;
        private Button btnApplyZBuffer;
        private Button btnResetZBuffer;
        private Button btnUndoZBuffer;

        private TabPage tabCamera;
        private Label lblCameraInfo;
        private Button btnRotateCamera;
        private TrackBar trbCameraAngle;
        private Label lblOpCam;
        private ComboBox cmbOpCam;
        private Label lblParamsCam;
        private TextBox txtParamsCam;
        private Button btnApplyCam;
        private Button btnResetCam;
        private Button btnUndoCam;

        private GroupBox grpProjection;
        private RadioButton rbAxonometric;
        private RadioButton rbPerspective;
        private CheckBox chkEdgesOnly;
        private PictureBox canvas;
    }
}