namespace Hexapod
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.uiHexapodGroupBox = new System.Windows.Forms.GroupBox();
            this.uiRailsMaxLengthLabel = new System.Windows.Forms.Label();
            this.uiСardanLabel = new System.Windows.Forms.Label();
            this.uiRailsLabel = new System.Windows.Forms.Label();
            this.uiRailsMinLengthLabel = new System.Windows.Forms.Label();
            this.uiRailsRadiusLabel = new System.Windows.Forms.Label();
            this.uiRailsMaxLengthTextBox = new System.Windows.Forms.TextBox();
            this.uiRailsMinLengthTextBox = new System.Windows.Forms.TextBox();
            this.uiRailsRadiusTextBox = new System.Windows.Forms.TextBox();
            this.uiCardanHeightLabel = new System.Windows.Forms.Label();
            this.uiCardanAngleTextBox = new System.Windows.Forms.TextBox();
            this.uiCardanAngleLabel = new System.Windows.Forms.Label();
            this.uiCardanHeightTextBox = new System.Windows.Forms.TextBox();
            this.uiCardanToCenterLenghtLabel = new System.Windows.Forms.Label();
            this.uiCardanRadiusLabel = new System.Windows.Forms.Label();
            this.uiCardanRadiusTextBox = new System.Windows.Forms.TextBox();
            this.uiCardanToCenterLenghtTextBox = new System.Windows.Forms.TextBox();
            this.uiPlatformHeightLabel = new System.Windows.Forms.Label();
            this.uiPlatformHeightTextBox = new System.Windows.Forms.TextBox();
            this.uiPlatformLabel = new System.Windows.Forms.Label();
            this.uiPlatformRadiusTextBox = new System.Windows.Forms.TextBox();
            this.uiPlatformRadiusLabel = new System.Windows.Forms.Label();
            this.uiSelectTrackGroupBox = new System.Windows.Forms.GroupBox();
            this.uiTrackTimeTextBox = new System.Windows.Forms.TextBox();
            this.uiTrackStepCountTextBox = new System.Windows.Forms.TextBox();
            this.uiTrackAxeComboBox = new System.Windows.Forms.ComboBox();
            this.uiTrackByTurnRadioButton = new System.Windows.Forms.RadioButton();
            this.uiTrackSimultaneouslyRadioButton = new System.Windows.Forms.RadioButton();
            this.uiTrackStepCountLabel = new System.Windows.Forms.Label();
            this.uiTrackTimeLabel = new System.Windows.Forms.Label();
            this.uiPlayDataGroupBox = new System.Windows.Forms.GroupBox();
            this.uiPlayButtonsPanel = new System.Windows.Forms.Panel();
            this.uiTrackPlayToEndButton = new System.Windows.Forms.Button();
            this.uiTrackPlayToStartButton = new System.Windows.Forms.Button();
            this.uiTrackBackStartButton = new System.Windows.Forms.Button();
            this.uiTrackStartButton = new System.Windows.Forms.Button();
            this.uiTrackPauseButton = new System.Windows.Forms.Button();
            this.uiTrackTrackBar = new System.Windows.Forms.TrackBar();
            this.uiTrackDataGridView = new System.Windows.Forms.DataGridView();
            this.uiTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiX0DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiY0DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiZ0DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiFiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiThetaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiPsiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiRail1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiRail2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiRail3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiRail4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiRail5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiRail6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiStartPositionX0TextBox = new System.Windows.Forms.TextBox();
            this.uiStartPositionX0Label = new System.Windows.Forms.Label();
            this.uiStartPositionY0TextBox = new System.Windows.Forms.TextBox();
            this.uiStartPositionY0Label = new System.Windows.Forms.Label();
            this.uiStartPositionZ0TextBox = new System.Windows.Forms.TextBox();
            this.uiStartPositionZ0Label = new System.Windows.Forms.Label();
            this.uiStartPositionGroupBox = new System.Windows.Forms.GroupBox();
            this.uiStartPositionDirectionCosineZValueLabel = new System.Windows.Forms.Label();
            this.uiStartPositionDirectionCosineYValueLabel = new System.Windows.Forms.Label();
            this.uiStartPositionDirectionCosineXValueLabel = new System.Windows.Forms.Label();
            this.uiStartPositionDirectionCosineZLabel = new System.Windows.Forms.Label();
            this.uiStartPositionDirectionCosineYLabel = new System.Windows.Forms.Label();
            this.uiStartPositionDirectionCosineXLabel = new System.Windows.Forms.Label();
            this.uiStartPositionPsiLabel = new System.Windows.Forms.Label();
            this.uiStartPositionPsiTextBox = new System.Windows.Forms.TextBox();
            this.uiStartPositionThetaLabel = new System.Windows.Forms.Label();
            this.uiStartPositionThetaTextBox = new System.Windows.Forms.TextBox();
            this.uiStartPositionFiLabel = new System.Windows.Forms.Label();
            this.uiStartPositionFiTextBox = new System.Windows.Forms.TextBox();
            this.uiFinishPostionGroupBox = new System.Windows.Forms.GroupBox();
            this.uiFinishPositionDirectionCosineZValueLabel = new System.Windows.Forms.Label();
            this.uiFinishPositionDirectionCosineYValueLabel = new System.Windows.Forms.Label();
            this.uiFinishPositionDirectionCosineXValueLabel = new System.Windows.Forms.Label();
            this.uiFinishPositionDirectionCosineZLabel = new System.Windows.Forms.Label();
            this.uiFinishPositionDirectionCosineYLabel = new System.Windows.Forms.Label();
            this.uiFinishPositionDirectionCosineXLabel = new System.Windows.Forms.Label();
            this.uiFinishPositionPsiLabel = new System.Windows.Forms.Label();
            this.uiFinishPositionPsiTextBox = new System.Windows.Forms.TextBox();
            this.uiFinishPositionThetaLabel = new System.Windows.Forms.Label();
            this.uiFinishPositionThetaTextBox = new System.Windows.Forms.TextBox();
            this.uiFinishPositionFiLabel = new System.Windows.Forms.Label();
            this.uiFinishPositionFiTextBox = new System.Windows.Forms.TextBox();
            this.uiFinishPositionZ0Label = new System.Windows.Forms.Label();
            this.uiFinishPositionZ0TextBox = new System.Windows.Forms.TextBox();
            this.uiFinishPositionY0Label = new System.Windows.Forms.Label();
            this.uiFinishPositionY0TextBox = new System.Windows.Forms.TextBox();
            this.uiFinishPositionX0Label = new System.Windows.Forms.Label();
            this.uiFinishPositionX0TextBox = new System.Windows.Forms.TextBox();
            this.uiUpdateSceneTimer = new System.Windows.Forms.Timer(this.components);
            this.uiMainPanel = new System.Windows.Forms.Panel();
            this.uiSettingsPanel = new System.Windows.Forms.Panel();
            this.uiSettingsVisibleButton = new System.Windows.Forms.Button();
            this.uiMoveYUpButton = new System.Windows.Forms.Button();
            this.uiMoveXDownButton = new System.Windows.Forms.Button();
            this.uiShowRotateZUpButton = new System.Windows.Forms.Button();
            this.uiMoveXUpButton = new System.Windows.Forms.Button();
            this.uiShowRotateZDownButton = new System.Windows.Forms.Button();
            this.uiMoveYDownButton = new System.Windows.Forms.Button();
            this.uiShowRotateYUpButton = new System.Windows.Forms.Button();
            this.uiShowRotateYDownButton = new System.Windows.Forms.Button();
            this.uiMoveZDownButton = new System.Windows.Forms.Button();
            this.uiShowRotateXUpButton = new System.Windows.Forms.Button();
            this.uiMoveZUpButton = new System.Windows.Forms.Button();
            this.uiShowRotateXDownButton = new System.Windows.Forms.Button();
            this.uiShowZoomUpButton = new System.Windows.Forms.Button();
            this.uiShowZoomDownButton = new System.Windows.Forms.Button();
            this.uiSimpleOpenGlControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.uiPlatformPositionPanel = new System.Windows.Forms.Panel();
            this.uiHexapodPanel = new System.Windows.Forms.Panel();
            this.uiSelectTrackPanel = new System.Windows.Forms.Panel();
            this.uiShowWayCheckBox = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.uiHexapodGroupBox.SuspendLayout();
            this.uiSelectTrackGroupBox.SuspendLayout();
            this.uiPlayDataGroupBox.SuspendLayout();
            this.uiPlayButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTrackTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTrackDataGridView)).BeginInit();
            this.uiStartPositionGroupBox.SuspendLayout();
            this.uiFinishPostionGroupBox.SuspendLayout();
            this.uiMainPanel.SuspendLayout();
            this.uiSettingsPanel.SuspendLayout();
            this.uiPlatformPositionPanel.SuspendLayout();
            this.uiHexapodPanel.SuspendLayout();
            this.uiSelectTrackPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiHexapodGroupBox
            // 
            this.uiHexapodGroupBox.Controls.Add(this.uiRailsMaxLengthLabel);
            this.uiHexapodGroupBox.Controls.Add(this.uiСardanLabel);
            this.uiHexapodGroupBox.Controls.Add(this.uiRailsLabel);
            this.uiHexapodGroupBox.Controls.Add(this.uiRailsMinLengthLabel);
            this.uiHexapodGroupBox.Controls.Add(this.uiRailsRadiusLabel);
            this.uiHexapodGroupBox.Controls.Add(this.uiRailsMaxLengthTextBox);
            this.uiHexapodGroupBox.Controls.Add(this.uiRailsMinLengthTextBox);
            this.uiHexapodGroupBox.Controls.Add(this.uiRailsRadiusTextBox);
            this.uiHexapodGroupBox.Controls.Add(this.uiCardanHeightLabel);
            this.uiHexapodGroupBox.Controls.Add(this.uiCardanAngleTextBox);
            this.uiHexapodGroupBox.Controls.Add(this.uiCardanAngleLabel);
            this.uiHexapodGroupBox.Controls.Add(this.uiCardanHeightTextBox);
            this.uiHexapodGroupBox.Controls.Add(this.uiCardanToCenterLenghtLabel);
            this.uiHexapodGroupBox.Controls.Add(this.uiCardanRadiusLabel);
            this.uiHexapodGroupBox.Controls.Add(this.uiCardanRadiusTextBox);
            this.uiHexapodGroupBox.Controls.Add(this.uiCardanToCenterLenghtTextBox);
            this.uiHexapodGroupBox.Controls.Add(this.uiPlatformHeightLabel);
            this.uiHexapodGroupBox.Controls.Add(this.uiPlatformHeightTextBox);
            this.uiHexapodGroupBox.Controls.Add(this.uiPlatformLabel);
            this.uiHexapodGroupBox.Controls.Add(this.uiPlatformRadiusTextBox);
            this.uiHexapodGroupBox.Controls.Add(this.uiPlatformRadiusLabel);
            this.uiHexapodGroupBox.Location = new System.Drawing.Point(0, 0);
            this.uiHexapodGroupBox.Name = "uiHexapodGroupBox";
            this.uiHexapodGroupBox.Size = new System.Drawing.Size(136, 268);
            this.uiHexapodGroupBox.TabIndex = 0;
            this.uiHexapodGroupBox.TabStop = false;
            this.uiHexapodGroupBox.Text = "Гексапод";
            // 
            // uiRailsMaxLengthLabel
            // 
            this.uiRailsMaxLengthLabel.AutoSize = true;
            this.uiRailsMaxLengthLabel.Location = new System.Drawing.Point(65, 222);
            this.uiRailsMaxLengthLabel.Name = "uiRailsMaxLengthLabel";
            this.uiRailsMaxLengthLabel.Size = new System.Drawing.Size(69, 13);
            this.uiRailsMaxLengthLabel.TabIndex = 20;
            this.uiRailsMaxLengthLabel.Text = "макс. длина";
            // 
            // uiСardanLabel
            // 
            this.uiСardanLabel.AutoSize = true;
            this.uiСardanLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uiСardanLabel.Location = new System.Drawing.Point(7, 74);
            this.uiСardanLabel.Name = "uiСardanLabel";
            this.uiСardanLabel.Size = new System.Drawing.Size(58, 13);
            this.uiСardanLabel.TabIndex = 19;
            this.uiСardanLabel.Text = "карданы";
            // 
            // uiRailsLabel
            // 
            this.uiRailsLabel.AutoSize = true;
            this.uiRailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uiRailsLabel.Location = new System.Drawing.Point(7, 170);
            this.uiRailsLabel.Name = "uiRailsLabel";
            this.uiRailsLabel.Size = new System.Drawing.Size(49, 13);
            this.uiRailsLabel.TabIndex = 18;
            this.uiRailsLabel.Text = "штанги";
            // 
            // uiRailsMinLengthLabel
            // 
            this.uiRailsMinLengthLabel.AutoSize = true;
            this.uiRailsMinLengthLabel.Location = new System.Drawing.Point(4, 222);
            this.uiRailsMinLengthLabel.Name = "uiRailsMinLengthLabel";
            this.uiRailsMinLengthLabel.Size = new System.Drawing.Size(63, 13);
            this.uiRailsMinLengthLabel.TabIndex = 13;
            this.uiRailsMinLengthLabel.Text = "мин. длина";
            // 
            // uiRailsRadiusLabel
            // 
            this.uiRailsRadiusLabel.AutoSize = true;
            this.uiRailsRadiusLabel.Location = new System.Drawing.Point(12, 183);
            this.uiRailsRadiusLabel.Name = "uiRailsRadiusLabel";
            this.uiRailsRadiusLabel.Size = new System.Drawing.Size(50, 13);
            this.uiRailsRadiusLabel.TabIndex = 13;
            this.uiRailsRadiusLabel.Text = "радиусы";
            // 
            // uiRailsMaxLengthTextBox
            // 
            this.uiRailsMaxLengthTextBox.Location = new System.Drawing.Point(68, 238);
            this.uiRailsMaxLengthTextBox.Name = "uiRailsMaxLengthTextBox";
            this.uiRailsMaxLengthTextBox.Size = new System.Drawing.Size(52, 20);
            this.uiRailsMaxLengthTextBox.TabIndex = 12;
            this.uiRailsMaxLengthTextBox.Text = "400";
            this.uiRailsMaxLengthTextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiRailsMinLengthTextBox
            // 
            this.uiRailsMinLengthTextBox.Location = new System.Drawing.Point(10, 238);
            this.uiRailsMinLengthTextBox.Name = "uiRailsMinLengthTextBox";
            this.uiRailsMinLengthTextBox.Size = new System.Drawing.Size(52, 20);
            this.uiRailsMinLengthTextBox.TabIndex = 12;
            this.uiRailsMinLengthTextBox.Text = "100";
            this.uiRailsMinLengthTextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiRailsRadiusTextBox
            // 
            this.uiRailsRadiusTextBox.Location = new System.Drawing.Point(10, 199);
            this.uiRailsRadiusTextBox.Name = "uiRailsRadiusTextBox";
            this.uiRailsRadiusTextBox.Size = new System.Drawing.Size(52, 20);
            this.uiRailsRadiusTextBox.TabIndex = 12;
            this.uiRailsRadiusTextBox.Text = "10";
            this.uiRailsRadiusTextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiCardanHeightLabel
            // 
            this.uiCardanHeightLabel.AutoSize = true;
            this.uiCardanHeightLabel.Location = new System.Drawing.Point(68, 88);
            this.uiCardanHeightLabel.Name = "uiCardanHeightLabel";
            this.uiCardanHeightLabel.Size = new System.Drawing.Size(44, 13);
            this.uiCardanHeightLabel.TabIndex = 11;
            this.uiCardanHeightLabel.Text = "высота";
            // 
            // uiCardanAngleTextBox
            // 
            this.uiCardanAngleTextBox.Location = new System.Drawing.Point(68, 143);
            this.uiCardanAngleTextBox.Name = "uiCardanAngleTextBox";
            this.uiCardanAngleTextBox.Size = new System.Drawing.Size(52, 20);
            this.uiCardanAngleTextBox.TabIndex = 10;
            this.uiCardanAngleTextBox.Text = "145";
            this.uiCardanAngleTextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiCardanAngleLabel
            // 
            this.uiCardanAngleLabel.AutoSize = true;
            this.uiCardanAngleLabel.Location = new System.Drawing.Point(68, 127);
            this.uiCardanAngleLabel.Name = "uiCardanAngleLabel";
            this.uiCardanAngleLabel.Size = new System.Drawing.Size(29, 13);
            this.uiCardanAngleLabel.TabIndex = 9;
            this.uiCardanAngleLabel.Text = "угол";
            // 
            // uiCardanHeightTextBox
            // 
            this.uiCardanHeightTextBox.Location = new System.Drawing.Point(68, 104);
            this.uiCardanHeightTextBox.Name = "uiCardanHeightTextBox";
            this.uiCardanHeightTextBox.Size = new System.Drawing.Size(52, 20);
            this.uiCardanHeightTextBox.TabIndex = 8;
            this.uiCardanHeightTextBox.Text = "5";
            this.uiCardanHeightTextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiCardanToCenterLenghtLabel
            // 
            this.uiCardanToCenterLenghtLabel.AutoSize = true;
            this.uiCardanToCenterLenghtLabel.Location = new System.Drawing.Point(8, 127);
            this.uiCardanToCenterLenghtLabel.Name = "uiCardanToCenterLenghtLabel";
            this.uiCardanToCenterLenghtLabel.Size = new System.Drawing.Size(57, 13);
            this.uiCardanToCenterLenghtLabel.TabIndex = 7;
            this.uiCardanToCenterLenghtLabel.Text = "до центра";
            // 
            // uiCardanRadiusLabel
            // 
            this.uiCardanRadiusLabel.AutoSize = true;
            this.uiCardanRadiusLabel.Location = new System.Drawing.Point(12, 87);
            this.uiCardanRadiusLabel.Name = "uiCardanRadiusLabel";
            this.uiCardanRadiusLabel.Size = new System.Drawing.Size(42, 13);
            this.uiCardanRadiusLabel.TabIndex = 7;
            this.uiCardanRadiusLabel.Text = "радиус";
            // 
            // uiCardanRadiusTextBox
            // 
            this.uiCardanRadiusTextBox.Location = new System.Drawing.Point(10, 103);
            this.uiCardanRadiusTextBox.Name = "uiCardanRadiusTextBox";
            this.uiCardanRadiusTextBox.Size = new System.Drawing.Size(52, 20);
            this.uiCardanRadiusTextBox.TabIndex = 6;
            this.uiCardanRadiusTextBox.Text = "15";
            this.uiCardanRadiusTextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiCardanToCenterLenghtTextBox
            // 
            this.uiCardanToCenterLenghtTextBox.Location = new System.Drawing.Point(10, 143);
            this.uiCardanToCenterLenghtTextBox.Name = "uiCardanToCenterLenghtTextBox";
            this.uiCardanToCenterLenghtTextBox.Size = new System.Drawing.Size(52, 20);
            this.uiCardanToCenterLenghtTextBox.TabIndex = 6;
            this.uiCardanToCenterLenghtTextBox.Text = "70";
            this.uiCardanToCenterLenghtTextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiPlatformHeightLabel
            // 
            this.uiPlatformHeightLabel.AutoSize = true;
            this.uiPlatformHeightLabel.Location = new System.Drawing.Point(68, 29);
            this.uiPlatformHeightLabel.Name = "uiPlatformHeightLabel";
            this.uiPlatformHeightLabel.Size = new System.Drawing.Size(44, 13);
            this.uiPlatformHeightLabel.TabIndex = 5;
            this.uiPlatformHeightLabel.Text = "высота";
            // 
            // uiPlatformHeightTextBox
            // 
            this.uiPlatformHeightTextBox.Location = new System.Drawing.Point(68, 45);
            this.uiPlatformHeightTextBox.Name = "uiPlatformHeightTextBox";
            this.uiPlatformHeightTextBox.Size = new System.Drawing.Size(52, 20);
            this.uiPlatformHeightTextBox.TabIndex = 4;
            this.uiPlatformHeightTextBox.Text = "10";
            this.uiPlatformHeightTextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiPlatformLabel
            // 
            this.uiPlatformLabel.AutoSize = true;
            this.uiPlatformLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uiPlatformLabel.Location = new System.Drawing.Point(9, 16);
            this.uiPlatformLabel.Name = "uiPlatformLabel";
            this.uiPlatformLabel.Size = new System.Drawing.Size(75, 13);
            this.uiPlatformLabel.TabIndex = 3;
            this.uiPlatformLabel.Text = "платформы";
            // 
            // uiPlatformRadiusTextBox
            // 
            this.uiPlatformRadiusTextBox.Location = new System.Drawing.Point(10, 45);
            this.uiPlatformRadiusTextBox.Name = "uiPlatformRadiusTextBox";
            this.uiPlatformRadiusTextBox.Size = new System.Drawing.Size(52, 20);
            this.uiPlatformRadiusTextBox.TabIndex = 1;
            this.uiPlatformRadiusTextBox.Text = "100";
            this.uiPlatformRadiusTextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiPlatformRadiusLabel
            // 
            this.uiPlatformRadiusLabel.AutoSize = true;
            this.uiPlatformRadiusLabel.Location = new System.Drawing.Point(12, 29);
            this.uiPlatformRadiusLabel.Name = "uiPlatformRadiusLabel";
            this.uiPlatformRadiusLabel.Size = new System.Drawing.Size(42, 13);
            this.uiPlatformRadiusLabel.TabIndex = 2;
            this.uiPlatformRadiusLabel.Text = "радиус";
            // 
            // uiSelectTrackGroupBox
            // 
            this.uiSelectTrackGroupBox.Controls.Add(this.uiTrackTimeTextBox);
            this.uiSelectTrackGroupBox.Controls.Add(this.uiTrackStepCountTextBox);
            this.uiSelectTrackGroupBox.Controls.Add(this.uiTrackAxeComboBox);
            this.uiSelectTrackGroupBox.Controls.Add(this.uiTrackByTurnRadioButton);
            this.uiSelectTrackGroupBox.Controls.Add(this.uiTrackSimultaneouslyRadioButton);
            this.uiSelectTrackGroupBox.Controls.Add(this.uiTrackStepCountLabel);
            this.uiSelectTrackGroupBox.Controls.Add(this.uiTrackTimeLabel);
            this.uiSelectTrackGroupBox.Location = new System.Drawing.Point(0, 0);
            this.uiSelectTrackGroupBox.Name = "uiSelectTrackGroupBox";
            this.uiSelectTrackGroupBox.Size = new System.Drawing.Size(120, 267);
            this.uiSelectTrackGroupBox.TabIndex = 18;
            this.uiSelectTrackGroupBox.TabStop = false;
            this.uiSelectTrackGroupBox.Text = "Выбор траектории";
            // 
            // uiTrackTimeTextBox
            // 
            this.uiTrackTimeTextBox.Location = new System.Drawing.Point(6, 105);
            this.uiTrackTimeTextBox.Name = "uiTrackTimeTextBox";
            this.uiTrackTimeTextBox.Size = new System.Drawing.Size(102, 20);
            this.uiTrackTimeTextBox.TabIndex = 21;
            this.uiTrackTimeTextBox.Text = "5";
            this.uiTrackTimeTextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiTrackStepCountTextBox
            // 
            this.uiTrackStepCountTextBox.Location = new System.Drawing.Point(6, 144);
            this.uiTrackStepCountTextBox.Name = "uiTrackStepCountTextBox";
            this.uiTrackStepCountTextBox.Size = new System.Drawing.Size(102, 20);
            this.uiTrackStepCountTextBox.TabIndex = 10;
            this.uiTrackStepCountTextBox.Text = "20";
            this.uiTrackStepCountTextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiTrackAxeComboBox
            // 
            this.uiTrackAxeComboBox.Enabled = false;
            this.uiTrackAxeComboBox.FormattingEnabled = true;
            this.uiTrackAxeComboBox.Items.AddRange(new object[] {
            "X0",
            "Y0",
            "Z0",
            "Fi",
            "Theta",
            "Psi"});
            this.uiTrackAxeComboBox.Location = new System.Drawing.Point(6, 65);
            this.uiTrackAxeComboBox.Name = "uiTrackAxeComboBox";
            this.uiTrackAxeComboBox.Size = new System.Drawing.Size(102, 21);
            this.uiTrackAxeComboBox.TabIndex = 9;
            // 
            // uiTrackByTurnRadioButton
            // 
            this.uiTrackByTurnRadioButton.AutoSize = true;
            this.uiTrackByTurnRadioButton.Enabled = false;
            this.uiTrackByTurnRadioButton.Location = new System.Drawing.Point(9, 42);
            this.uiTrackByTurnRadioButton.Name = "uiTrackByTurnRadioButton";
            this.uiTrackByTurnRadioButton.Size = new System.Drawing.Size(81, 17);
            this.uiTrackByTurnRadioButton.TabIndex = 6;
            this.uiTrackByTurnRadioButton.Text = "по очереди";
            this.uiTrackByTurnRadioButton.UseVisualStyleBackColor = true;
            // 
            // uiTrackSimultaneouslyRadioButton
            // 
            this.uiTrackSimultaneouslyRadioButton.AutoSize = true;
            this.uiTrackSimultaneouslyRadioButton.Checked = true;
            this.uiTrackSimultaneouslyRadioButton.Enabled = false;
            this.uiTrackSimultaneouslyRadioButton.Location = new System.Drawing.Point(9, 19);
            this.uiTrackSimultaneouslyRadioButton.Name = "uiTrackSimultaneouslyRadioButton";
            this.uiTrackSimultaneouslyRadioButton.Size = new System.Drawing.Size(99, 17);
            this.uiTrackSimultaneouslyRadioButton.TabIndex = 5;
            this.uiTrackSimultaneouslyRadioButton.TabStop = true;
            this.uiTrackSimultaneouslyRadioButton.Text = "одновременно";
            this.uiTrackSimultaneouslyRadioButton.UseVisualStyleBackColor = true;
            // 
            // uiTrackStepCountLabel
            // 
            this.uiTrackStepCountLabel.AutoSize = true;
            this.uiTrackStepCountLabel.Location = new System.Drawing.Point(12, 128);
            this.uiTrackStepCountLabel.Name = "uiTrackStepCountLabel";
            this.uiTrackStepCountLabel.Size = new System.Drawing.Size(100, 13);
            this.uiTrackStepCountLabel.TabIndex = 3;
            this.uiTrackStepCountLabel.Text = "Количество шагов";
            // 
            // uiTrackTimeLabel
            // 
            this.uiTrackTimeLabel.AutoSize = true;
            this.uiTrackTimeLabel.Location = new System.Drawing.Point(12, 89);
            this.uiTrackTimeLabel.Name = "uiTrackTimeLabel";
            this.uiTrackTimeLabel.Size = new System.Drawing.Size(70, 13);
            this.uiTrackTimeLabel.TabIndex = 2;
            this.uiTrackTimeLabel.Text = "Время (сек.)";
            // 
            // uiPlayDataGroupBox
            // 
            this.uiPlayDataGroupBox.Controls.Add(this.uiPlayButtonsPanel);
            this.uiPlayDataGroupBox.Controls.Add(this.uiTrackTrackBar);
            this.uiPlayDataGroupBox.Controls.Add(this.uiTrackDataGridView);
            this.uiPlayDataGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiPlayDataGroupBox.Location = new System.Drawing.Point(0, 267);
            this.uiPlayDataGroupBox.Name = "uiPlayDataGroupBox";
            this.uiPlayDataGroupBox.Size = new System.Drawing.Size(784, 295);
            this.uiPlayDataGroupBox.TabIndex = 20;
            this.uiPlayDataGroupBox.TabStop = false;
            this.uiPlayDataGroupBox.Text = "groupBox5";
            // 
            // uiPlayButtonsPanel
            // 
            this.uiPlayButtonsPanel.Controls.Add(this.uiTrackPlayToEndButton);
            this.uiPlayButtonsPanel.Controls.Add(this.uiTrackPlayToStartButton);
            this.uiPlayButtonsPanel.Controls.Add(this.uiTrackBackStartButton);
            this.uiPlayButtonsPanel.Controls.Add(this.uiTrackStartButton);
            this.uiPlayButtonsPanel.Controls.Add(this.uiTrackPauseButton);
            this.uiPlayButtonsPanel.Location = new System.Drawing.Point(316, 263);
            this.uiPlayButtonsPanel.Name = "uiPlayButtonsPanel";
            this.uiPlayButtonsPanel.Size = new System.Drawing.Size(158, 31);
            this.uiPlayButtonsPanel.TabIndex = 5;
            // 
            // uiTrackPlayToEndButton
            // 
            this.uiTrackPlayToEndButton.Image = ((System.Drawing.Image)(resources.GetObject("uiTrackPlayToEndButton.Image")));
            this.uiTrackPlayToEndButton.Location = new System.Drawing.Point(128, 3);
            this.uiTrackPlayToEndButton.Name = "uiTrackPlayToEndButton";
            this.uiTrackPlayToEndButton.Size = new System.Drawing.Size(25, 23);
            this.uiTrackPlayToEndButton.TabIndex = 3;
            this.uiTrackPlayToEndButton.UseVisualStyleBackColor = true;
            this.uiTrackPlayToEndButton.Click += new System.EventHandler(this.uiTrackPlayToEndButton_Click);
            // 
            // uiTrackPlayToStartButton
            // 
            this.uiTrackPlayToStartButton.Image = ((System.Drawing.Image)(resources.GetObject("uiTrackPlayToStartButton.Image")));
            this.uiTrackPlayToStartButton.Location = new System.Drawing.Point(4, 3);
            this.uiTrackPlayToStartButton.Name = "uiTrackPlayToStartButton";
            this.uiTrackPlayToStartButton.Size = new System.Drawing.Size(25, 23);
            this.uiTrackPlayToStartButton.TabIndex = 2;
            this.uiTrackPlayToStartButton.UseVisualStyleBackColor = true;
            this.uiTrackPlayToStartButton.Click += new System.EventHandler(this.uiTrackPlayToStartButton_Click);
            // 
            // uiTrackBackStartButton
            // 
            this.uiTrackBackStartButton.Image = ((System.Drawing.Image)(resources.GetObject("uiTrackBackStartButton.Image")));
            this.uiTrackBackStartButton.Location = new System.Drawing.Point(35, 3);
            this.uiTrackBackStartButton.Name = "uiTrackBackStartButton";
            this.uiTrackBackStartButton.Size = new System.Drawing.Size(25, 23);
            this.uiTrackBackStartButton.TabIndex = 3;
            this.uiTrackBackStartButton.UseVisualStyleBackColor = true;
            this.uiTrackBackStartButton.Click += new System.EventHandler(this.uiTrackBackStartButton_Click);
            // 
            // uiTrackStartButton
            // 
            this.uiTrackStartButton.Image = ((System.Drawing.Image)(resources.GetObject("uiTrackStartButton.Image")));
            this.uiTrackStartButton.Location = new System.Drawing.Point(97, 3);
            this.uiTrackStartButton.Name = "uiTrackStartButton";
            this.uiTrackStartButton.Size = new System.Drawing.Size(25, 23);
            this.uiTrackStartButton.TabIndex = 3;
            this.uiTrackStartButton.UseVisualStyleBackColor = true;
            this.uiTrackStartButton.Click += new System.EventHandler(this.uiTrackStartButton_Click);
            // 
            // uiTrackPauseButton
            // 
            this.uiTrackPauseButton.Image = ((System.Drawing.Image)(resources.GetObject("uiTrackPauseButton.Image")));
            this.uiTrackPauseButton.Location = new System.Drawing.Point(66, 3);
            this.uiTrackPauseButton.Name = "uiTrackPauseButton";
            this.uiTrackPauseButton.Size = new System.Drawing.Size(25, 23);
            this.uiTrackPauseButton.TabIndex = 3;
            this.uiTrackPauseButton.UseVisualStyleBackColor = true;
            this.uiTrackPauseButton.Click += new System.EventHandler(this.uiTrackPauseButton_Click);
            // 
            // uiTrackTrackBar
            // 
            this.uiTrackTrackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTrackTrackBar.Location = new System.Drawing.Point(3, 232);
            this.uiTrackTrackBar.Maximum = 508;
            this.uiTrackTrackBar.Name = "uiTrackTrackBar";
            this.uiTrackTrackBar.Size = new System.Drawing.Size(778, 45);
            this.uiTrackTrackBar.TabIndex = 1;
            this.uiTrackTrackBar.Scroll += new System.EventHandler(this.uiTrackTrackBar_Scroll);
            this.uiTrackTrackBar.ValueChanged += new System.EventHandler(this.uiTrackTrackBar_ValueChanged);
            // 
            // uiTrackDataGridView
            // 
            this.uiTrackDataGridView.AllowUserToAddRows = false;
            this.uiTrackDataGridView.AllowUserToDeleteRows = false;
            this.uiTrackDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiTrackDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uiTimeDataGridViewTextBoxColumn,
            this.uiX0DataGridViewTextBoxColumn,
            this.uiY0DataGridViewTextBoxColumn,
            this.uiZ0DataGridViewTextBoxColumn,
            this.uiFiDataGridViewTextBoxColumn,
            this.uiThetaDataGridViewTextBoxColumn,
            this.uiPsiDataGridViewTextBoxColumn,
            this.uiRail1DataGridViewTextBoxColumn,
            this.uiRail2DataGridViewTextBoxColumn,
            this.uiRail3DataGridViewTextBoxColumn,
            this.uiRail4DataGridViewTextBoxColumn,
            this.uiRail5DataGridViewTextBoxColumn,
            this.uiRail6DataGridViewTextBoxColumn});
            this.uiTrackDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTrackDataGridView.Location = new System.Drawing.Point(3, 16);
            this.uiTrackDataGridView.Name = "uiTrackDataGridView";
            this.uiTrackDataGridView.ReadOnly = true;
            this.uiTrackDataGridView.Size = new System.Drawing.Size(778, 216);
            this.uiTrackDataGridView.TabIndex = 4;
            this.uiTrackDataGridView.SizeChanged += new System.EventHandler(this.uiTrackDataGridView_SizeChanged);
            // 
            // uiTimeDataGridViewTextBoxColumn
            // 
            this.uiTimeDataGridViewTextBoxColumn.HeaderText = "time";
            this.uiTimeDataGridViewTextBoxColumn.Name = "uiTimeDataGridViewTextBoxColumn";
            this.uiTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.uiTimeDataGridViewTextBoxColumn.Width = 51;
            // 
            // uiX0DataGridViewTextBoxColumn
            // 
            this.uiX0DataGridViewTextBoxColumn.HeaderText = "X0";
            this.uiX0DataGridViewTextBoxColumn.Name = "uiX0DataGridViewTextBoxColumn";
            this.uiX0DataGridViewTextBoxColumn.ReadOnly = true;
            this.uiX0DataGridViewTextBoxColumn.Width = 45;
            // 
            // uiY0DataGridViewTextBoxColumn
            // 
            this.uiY0DataGridViewTextBoxColumn.HeaderText = "Y0";
            this.uiY0DataGridViewTextBoxColumn.Name = "uiY0DataGridViewTextBoxColumn";
            this.uiY0DataGridViewTextBoxColumn.ReadOnly = true;
            this.uiY0DataGridViewTextBoxColumn.Width = 45;
            // 
            // uiZ0DataGridViewTextBoxColumn
            // 
            this.uiZ0DataGridViewTextBoxColumn.HeaderText = "Z0";
            this.uiZ0DataGridViewTextBoxColumn.Name = "uiZ0DataGridViewTextBoxColumn";
            this.uiZ0DataGridViewTextBoxColumn.ReadOnly = true;
            this.uiZ0DataGridViewTextBoxColumn.Width = 45;
            // 
            // uiFiDataGridViewTextBoxColumn
            // 
            this.uiFiDataGridViewTextBoxColumn.HeaderText = "Fi";
            this.uiFiDataGridViewTextBoxColumn.Name = "uiFiDataGridViewTextBoxColumn";
            this.uiFiDataGridViewTextBoxColumn.ReadOnly = true;
            this.uiFiDataGridViewTextBoxColumn.Width = 40;
            // 
            // uiThetaDataGridViewTextBoxColumn
            // 
            this.uiThetaDataGridViewTextBoxColumn.HeaderText = "Theta";
            this.uiThetaDataGridViewTextBoxColumn.Name = "uiThetaDataGridViewTextBoxColumn";
            this.uiThetaDataGridViewTextBoxColumn.ReadOnly = true;
            this.uiThetaDataGridViewTextBoxColumn.Width = 60;
            // 
            // uiPsiDataGridViewTextBoxColumn
            // 
            this.uiPsiDataGridViewTextBoxColumn.HeaderText = "Psi";
            this.uiPsiDataGridViewTextBoxColumn.Name = "uiPsiDataGridViewTextBoxColumn";
            this.uiPsiDataGridViewTextBoxColumn.ReadOnly = true;
            this.uiPsiDataGridViewTextBoxColumn.Width = 46;
            // 
            // uiRail1DataGridViewTextBoxColumn
            // 
            this.uiRail1DataGridViewTextBoxColumn.HeaderText = "Rail1";
            this.uiRail1DataGridViewTextBoxColumn.Name = "uiRail1DataGridViewTextBoxColumn";
            this.uiRail1DataGridViewTextBoxColumn.ReadOnly = true;
            this.uiRail1DataGridViewTextBoxColumn.Width = 72;
            // 
            // uiRail2DataGridViewTextBoxColumn
            // 
            this.uiRail2DataGridViewTextBoxColumn.HeaderText = "Rail2";
            this.uiRail2DataGridViewTextBoxColumn.Name = "uiRail2DataGridViewTextBoxColumn";
            this.uiRail2DataGridViewTextBoxColumn.ReadOnly = true;
            this.uiRail2DataGridViewTextBoxColumn.Width = 72;
            // 
            // uiRail3DataGridViewTextBoxColumn
            // 
            this.uiRail3DataGridViewTextBoxColumn.HeaderText = "Rail3";
            this.uiRail3DataGridViewTextBoxColumn.Name = "uiRail3DataGridViewTextBoxColumn";
            this.uiRail3DataGridViewTextBoxColumn.ReadOnly = true;
            this.uiRail3DataGridViewTextBoxColumn.Width = 72;
            // 
            // uiRail4DataGridViewTextBoxColumn
            // 
            this.uiRail4DataGridViewTextBoxColumn.HeaderText = "Rail4";
            this.uiRail4DataGridViewTextBoxColumn.Name = "uiRail4DataGridViewTextBoxColumn";
            this.uiRail4DataGridViewTextBoxColumn.ReadOnly = true;
            this.uiRail4DataGridViewTextBoxColumn.Width = 72;
            // 
            // uiRail5DataGridViewTextBoxColumn
            // 
            this.uiRail5DataGridViewTextBoxColumn.HeaderText = "Rail5";
            this.uiRail5DataGridViewTextBoxColumn.Name = "uiRail5DataGridViewTextBoxColumn";
            this.uiRail5DataGridViewTextBoxColumn.ReadOnly = true;
            this.uiRail5DataGridViewTextBoxColumn.Width = 72;
            // 
            // uiRail6DataGridViewTextBoxColumn
            // 
            this.uiRail6DataGridViewTextBoxColumn.HeaderText = "Rail6";
            this.uiRail6DataGridViewTextBoxColumn.Name = "uiRail6DataGridViewTextBoxColumn";
            this.uiRail6DataGridViewTextBoxColumn.ReadOnly = true;
            this.uiRail6DataGridViewTextBoxColumn.Width = 72;
            // 
            // uiStartPositionX0TextBox
            // 
            this.uiStartPositionX0TextBox.Location = new System.Drawing.Point(3, 32);
            this.uiStartPositionX0TextBox.Name = "uiStartPositionX0TextBox";
            this.uiStartPositionX0TextBox.Size = new System.Drawing.Size(52, 20);
            this.uiStartPositionX0TextBox.TabIndex = 1;
            this.uiStartPositionX0TextBox.Text = "50";
            this.uiStartPositionX0TextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiStartPositionX0Label
            // 
            this.uiStartPositionX0Label.AutoSize = true;
            this.uiStartPositionX0Label.Location = new System.Drawing.Point(21, 16);
            this.uiStartPositionX0Label.Name = "uiStartPositionX0Label";
            this.uiStartPositionX0Label.Size = new System.Drawing.Size(20, 13);
            this.uiStartPositionX0Label.TabIndex = 3;
            this.uiStartPositionX0Label.Text = "X0";
            // 
            // uiStartPositionY0TextBox
            // 
            this.uiStartPositionY0TextBox.Location = new System.Drawing.Point(64, 32);
            this.uiStartPositionY0TextBox.Name = "uiStartPositionY0TextBox";
            this.uiStartPositionY0TextBox.Size = new System.Drawing.Size(52, 20);
            this.uiStartPositionY0TextBox.TabIndex = 4;
            this.uiStartPositionY0TextBox.Text = "50";
            this.uiStartPositionY0TextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiStartPositionY0Label
            // 
            this.uiStartPositionY0Label.AutoSize = true;
            this.uiStartPositionY0Label.Location = new System.Drawing.Point(78, 16);
            this.uiStartPositionY0Label.Name = "uiStartPositionY0Label";
            this.uiStartPositionY0Label.Size = new System.Drawing.Size(20, 13);
            this.uiStartPositionY0Label.TabIndex = 5;
            this.uiStartPositionY0Label.Text = "Y0";
            // 
            // uiStartPositionZ0TextBox
            // 
            this.uiStartPositionZ0TextBox.Location = new System.Drawing.Point(122, 32);
            this.uiStartPositionZ0TextBox.Name = "uiStartPositionZ0TextBox";
            this.uiStartPositionZ0TextBox.Size = new System.Drawing.Size(52, 20);
            this.uiStartPositionZ0TextBox.TabIndex = 6;
            this.uiStartPositionZ0TextBox.Text = "50";
            this.uiStartPositionZ0TextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiStartPositionZ0Label
            // 
            this.uiStartPositionZ0Label.AutoSize = true;
            this.uiStartPositionZ0Label.Location = new System.Drawing.Point(136, 16);
            this.uiStartPositionZ0Label.Name = "uiStartPositionZ0Label";
            this.uiStartPositionZ0Label.Size = new System.Drawing.Size(20, 13);
            this.uiStartPositionZ0Label.TabIndex = 7;
            this.uiStartPositionZ0Label.Text = "Z0";
            // 
            // uiStartPositionGroupBox
            // 
            this.uiStartPositionGroupBox.Controls.Add(this.uiStartPositionDirectionCosineZValueLabel);
            this.uiStartPositionGroupBox.Controls.Add(this.uiStartPositionDirectionCosineYValueLabel);
            this.uiStartPositionGroupBox.Controls.Add(this.uiStartPositionDirectionCosineXValueLabel);
            this.uiStartPositionGroupBox.Controls.Add(this.uiStartPositionDirectionCosineZLabel);
            this.uiStartPositionGroupBox.Controls.Add(this.uiStartPositionDirectionCosineYLabel);
            this.uiStartPositionGroupBox.Controls.Add(this.uiStartPositionDirectionCosineXLabel);
            this.uiStartPositionGroupBox.Controls.Add(this.uiStartPositionPsiLabel);
            this.uiStartPositionGroupBox.Controls.Add(this.uiStartPositionPsiTextBox);
            this.uiStartPositionGroupBox.Controls.Add(this.uiStartPositionThetaLabel);
            this.uiStartPositionGroupBox.Controls.Add(this.uiStartPositionThetaTextBox);
            this.uiStartPositionGroupBox.Controls.Add(this.uiStartPositionFiLabel);
            this.uiStartPositionGroupBox.Controls.Add(this.uiStartPositionFiTextBox);
            this.uiStartPositionGroupBox.Controls.Add(this.uiStartPositionZ0Label);
            this.uiStartPositionGroupBox.Controls.Add(this.uiStartPositionZ0TextBox);
            this.uiStartPositionGroupBox.Controls.Add(this.uiStartPositionY0Label);
            this.uiStartPositionGroupBox.Controls.Add(this.uiStartPositionY0TextBox);
            this.uiStartPositionGroupBox.Controls.Add(this.uiStartPositionX0Label);
            this.uiStartPositionGroupBox.Controls.Add(this.uiStartPositionX0TextBox);
            this.uiStartPositionGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiStartPositionGroupBox.Location = new System.Drawing.Point(0, 0);
            this.uiStartPositionGroupBox.Name = "uiStartPositionGroupBox";
            this.uiStartPositionGroupBox.Size = new System.Drawing.Size(200, 137);
            this.uiStartPositionGroupBox.TabIndex = 14;
            this.uiStartPositionGroupBox.TabStop = false;
            this.uiStartPositionGroupBox.Text = "Начальное положение";
            // 
            // uiStartPositionDirectionCosineZValueLabel
            // 
            this.uiStartPositionDirectionCosineZValueLabel.AutoSize = true;
            this.uiStartPositionDirectionCosineZValueLabel.Location = new System.Drawing.Point(119, 114);
            this.uiStartPositionDirectionCosineZValueLabel.Name = "uiStartPositionDirectionCosineZValueLabel";
            this.uiStartPositionDirectionCosineZValueLabel.Size = new System.Drawing.Size(10, 13);
            this.uiStartPositionDirectionCosineZValueLabel.TabIndex = 29;
            this.uiStartPositionDirectionCosineZValueLabel.Text = "-";
            // 
            // uiStartPositionDirectionCosineYValueLabel
            // 
            this.uiStartPositionDirectionCosineYValueLabel.AutoSize = true;
            this.uiStartPositionDirectionCosineYValueLabel.Location = new System.Drawing.Point(61, 114);
            this.uiStartPositionDirectionCosineYValueLabel.Name = "uiStartPositionDirectionCosineYValueLabel";
            this.uiStartPositionDirectionCosineYValueLabel.Size = new System.Drawing.Size(10, 13);
            this.uiStartPositionDirectionCosineYValueLabel.TabIndex = 28;
            this.uiStartPositionDirectionCosineYValueLabel.Text = "-";
            // 
            // uiStartPositionDirectionCosineXValueLabel
            // 
            this.uiStartPositionDirectionCosineXValueLabel.AutoSize = true;
            this.uiStartPositionDirectionCosineXValueLabel.Location = new System.Drawing.Point(4, 114);
            this.uiStartPositionDirectionCosineXValueLabel.Name = "uiStartPositionDirectionCosineXValueLabel";
            this.uiStartPositionDirectionCosineXValueLabel.Size = new System.Drawing.Size(10, 13);
            this.uiStartPositionDirectionCosineXValueLabel.TabIndex = 27;
            this.uiStartPositionDirectionCosineXValueLabel.Text = "-";
            // 
            // uiStartPositionDirectionCosineZLabel
            // 
            this.uiStartPositionDirectionCosineZLabel.AutoSize = true;
            this.uiStartPositionDirectionCosineZLabel.Location = new System.Drawing.Point(133, 94);
            this.uiStartPositionDirectionCosineZLabel.Name = "uiStartPositionDirectionCosineZLabel";
            this.uiStartPositionDirectionCosineZLabel.Size = new System.Drawing.Size(47, 13);
            this.uiStartPositionDirectionCosineZLabel.TabIndex = 26;
            this.uiStartPositionDirectionCosineZLabel.Text = "cos(k,k\')";
            // 
            // uiStartPositionDirectionCosineYLabel
            // 
            this.uiStartPositionDirectionCosineYLabel.AutoSize = true;
            this.uiStartPositionDirectionCosineYLabel.Location = new System.Drawing.Point(75, 94);
            this.uiStartPositionDirectionCosineYLabel.Name = "uiStartPositionDirectionCosineYLabel";
            this.uiStartPositionDirectionCosineYLabel.Size = new System.Drawing.Size(39, 13);
            this.uiStartPositionDirectionCosineYLabel.TabIndex = 25;
            this.uiStartPositionDirectionCosineYLabel.Text = "cos(j,j\')";
            // 
            // uiStartPositionDirectionCosineXLabel
            // 
            this.uiStartPositionDirectionCosineXLabel.AutoSize = true;
            this.uiStartPositionDirectionCosineXLabel.Location = new System.Drawing.Point(18, 94);
            this.uiStartPositionDirectionCosineXLabel.Name = "uiStartPositionDirectionCosineXLabel";
            this.uiStartPositionDirectionCosineXLabel.Size = new System.Drawing.Size(39, 13);
            this.uiStartPositionDirectionCosineXLabel.TabIndex = 24;
            this.uiStartPositionDirectionCosineXLabel.Text = "cos(i,i\')";
            // 
            // uiStartPositionPsiLabel
            // 
            this.uiStartPositionPsiLabel.AutoSize = true;
            this.uiStartPositionPsiLabel.Location = new System.Drawing.Point(136, 55);
            this.uiStartPositionPsiLabel.Name = "uiStartPositionPsiLabel";
            this.uiStartPositionPsiLabel.Size = new System.Drawing.Size(21, 13);
            this.uiStartPositionPsiLabel.TabIndex = 23;
            this.uiStartPositionPsiLabel.Text = "Psi";
            // 
            // uiStartPositionPsiTextBox
            // 
            this.uiStartPositionPsiTextBox.Location = new System.Drawing.Point(122, 71);
            this.uiStartPositionPsiTextBox.Name = "uiStartPositionPsiTextBox";
            this.uiStartPositionPsiTextBox.Size = new System.Drawing.Size(52, 20);
            this.uiStartPositionPsiTextBox.TabIndex = 22;
            this.uiStartPositionPsiTextBox.Text = "10";
            this.uiStartPositionPsiTextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiStartPositionThetaLabel
            // 
            this.uiStartPositionThetaLabel.AutoSize = true;
            this.uiStartPositionThetaLabel.Location = new System.Drawing.Point(78, 55);
            this.uiStartPositionThetaLabel.Name = "uiStartPositionThetaLabel";
            this.uiStartPositionThetaLabel.Size = new System.Drawing.Size(35, 13);
            this.uiStartPositionThetaLabel.TabIndex = 21;
            this.uiStartPositionThetaLabel.Text = "Theta";
            // 
            // uiStartPositionThetaTextBox
            // 
            this.uiStartPositionThetaTextBox.Location = new System.Drawing.Point(64, 71);
            this.uiStartPositionThetaTextBox.Name = "uiStartPositionThetaTextBox";
            this.uiStartPositionThetaTextBox.Size = new System.Drawing.Size(52, 20);
            this.uiStartPositionThetaTextBox.TabIndex = 20;
            this.uiStartPositionThetaTextBox.Text = "10";
            this.uiStartPositionThetaTextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiStartPositionFiLabel
            // 
            this.uiStartPositionFiLabel.AutoSize = true;
            this.uiStartPositionFiLabel.Location = new System.Drawing.Point(21, 55);
            this.uiStartPositionFiLabel.Name = "uiStartPositionFiLabel";
            this.uiStartPositionFiLabel.Size = new System.Drawing.Size(15, 13);
            this.uiStartPositionFiLabel.TabIndex = 19;
            this.uiStartPositionFiLabel.Text = "Fi";
            // 
            // uiStartPositionFiTextBox
            // 
            this.uiStartPositionFiTextBox.Location = new System.Drawing.Point(3, 71);
            this.uiStartPositionFiTextBox.Name = "uiStartPositionFiTextBox";
            this.uiStartPositionFiTextBox.Size = new System.Drawing.Size(52, 20);
            this.uiStartPositionFiTextBox.TabIndex = 18;
            this.uiStartPositionFiTextBox.Text = "10";
            this.uiStartPositionFiTextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiFinishPostionGroupBox
            // 
            this.uiFinishPostionGroupBox.Controls.Add(this.uiFinishPositionDirectionCosineZValueLabel);
            this.uiFinishPostionGroupBox.Controls.Add(this.uiFinishPositionDirectionCosineYValueLabel);
            this.uiFinishPostionGroupBox.Controls.Add(this.uiFinishPositionDirectionCosineXValueLabel);
            this.uiFinishPostionGroupBox.Controls.Add(this.uiFinishPositionDirectionCosineZLabel);
            this.uiFinishPostionGroupBox.Controls.Add(this.uiFinishPositionDirectionCosineYLabel);
            this.uiFinishPostionGroupBox.Controls.Add(this.uiFinishPositionDirectionCosineXLabel);
            this.uiFinishPostionGroupBox.Controls.Add(this.uiFinishPositionPsiLabel);
            this.uiFinishPostionGroupBox.Controls.Add(this.uiFinishPositionPsiTextBox);
            this.uiFinishPostionGroupBox.Controls.Add(this.uiFinishPositionThetaLabel);
            this.uiFinishPostionGroupBox.Controls.Add(this.uiFinishPositionThetaTextBox);
            this.uiFinishPostionGroupBox.Controls.Add(this.uiFinishPositionFiLabel);
            this.uiFinishPostionGroupBox.Controls.Add(this.uiFinishPositionFiTextBox);
            this.uiFinishPostionGroupBox.Controls.Add(this.uiFinishPositionZ0Label);
            this.uiFinishPostionGroupBox.Controls.Add(this.uiFinishPositionZ0TextBox);
            this.uiFinishPostionGroupBox.Controls.Add(this.uiFinishPositionY0Label);
            this.uiFinishPostionGroupBox.Controls.Add(this.uiFinishPositionY0TextBox);
            this.uiFinishPostionGroupBox.Controls.Add(this.uiFinishPositionX0Label);
            this.uiFinishPostionGroupBox.Controls.Add(this.uiFinishPositionX0TextBox);
            this.uiFinishPostionGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiFinishPostionGroupBox.Location = new System.Drawing.Point(0, 137);
            this.uiFinishPostionGroupBox.Name = "uiFinishPostionGroupBox";
            this.uiFinishPostionGroupBox.Size = new System.Drawing.Size(200, 131);
            this.uiFinishPostionGroupBox.TabIndex = 30;
            this.uiFinishPostionGroupBox.TabStop = false;
            this.uiFinishPostionGroupBox.Text = "Конечное положение";
            // 
            // uiFinishPositionDirectionCosineZValueLabel
            // 
            this.uiFinishPositionDirectionCosineZValueLabel.AutoSize = true;
            this.uiFinishPositionDirectionCosineZValueLabel.Location = new System.Drawing.Point(119, 114);
            this.uiFinishPositionDirectionCosineZValueLabel.Name = "uiFinishPositionDirectionCosineZValueLabel";
            this.uiFinishPositionDirectionCosineZValueLabel.Size = new System.Drawing.Size(10, 13);
            this.uiFinishPositionDirectionCosineZValueLabel.TabIndex = 29;
            this.uiFinishPositionDirectionCosineZValueLabel.Text = "-";
            // 
            // uiFinishPositionDirectionCosineYValueLabel
            // 
            this.uiFinishPositionDirectionCosineYValueLabel.AutoSize = true;
            this.uiFinishPositionDirectionCosineYValueLabel.Location = new System.Drawing.Point(61, 114);
            this.uiFinishPositionDirectionCosineYValueLabel.Name = "uiFinishPositionDirectionCosineYValueLabel";
            this.uiFinishPositionDirectionCosineYValueLabel.Size = new System.Drawing.Size(10, 13);
            this.uiFinishPositionDirectionCosineYValueLabel.TabIndex = 28;
            this.uiFinishPositionDirectionCosineYValueLabel.Text = "-";
            // 
            // uiFinishPositionDirectionCosineXValueLabel
            // 
            this.uiFinishPositionDirectionCosineXValueLabel.AutoSize = true;
            this.uiFinishPositionDirectionCosineXValueLabel.Location = new System.Drawing.Point(4, 114);
            this.uiFinishPositionDirectionCosineXValueLabel.Name = "uiFinishPositionDirectionCosineXValueLabel";
            this.uiFinishPositionDirectionCosineXValueLabel.Size = new System.Drawing.Size(10, 13);
            this.uiFinishPositionDirectionCosineXValueLabel.TabIndex = 27;
            this.uiFinishPositionDirectionCosineXValueLabel.Text = "-";
            // 
            // uiFinishPositionDirectionCosineZLabel
            // 
            this.uiFinishPositionDirectionCosineZLabel.AutoSize = true;
            this.uiFinishPositionDirectionCosineZLabel.Location = new System.Drawing.Point(133, 94);
            this.uiFinishPositionDirectionCosineZLabel.Name = "uiFinishPositionDirectionCosineZLabel";
            this.uiFinishPositionDirectionCosineZLabel.Size = new System.Drawing.Size(47, 13);
            this.uiFinishPositionDirectionCosineZLabel.TabIndex = 26;
            this.uiFinishPositionDirectionCosineZLabel.Text = "cos(k,k\')";
            // 
            // uiFinishPositionDirectionCosineYLabel
            // 
            this.uiFinishPositionDirectionCosineYLabel.AutoSize = true;
            this.uiFinishPositionDirectionCosineYLabel.Location = new System.Drawing.Point(75, 94);
            this.uiFinishPositionDirectionCosineYLabel.Name = "uiFinishPositionDirectionCosineYLabel";
            this.uiFinishPositionDirectionCosineYLabel.Size = new System.Drawing.Size(39, 13);
            this.uiFinishPositionDirectionCosineYLabel.TabIndex = 25;
            this.uiFinishPositionDirectionCosineYLabel.Text = "cos(j,j\')";
            // 
            // uiFinishPositionDirectionCosineXLabel
            // 
            this.uiFinishPositionDirectionCosineXLabel.AutoSize = true;
            this.uiFinishPositionDirectionCosineXLabel.Location = new System.Drawing.Point(18, 94);
            this.uiFinishPositionDirectionCosineXLabel.Name = "uiFinishPositionDirectionCosineXLabel";
            this.uiFinishPositionDirectionCosineXLabel.Size = new System.Drawing.Size(39, 13);
            this.uiFinishPositionDirectionCosineXLabel.TabIndex = 24;
            this.uiFinishPositionDirectionCosineXLabel.Text = "cos(i,i\')";
            // 
            // uiFinishPositionPsiLabel
            // 
            this.uiFinishPositionPsiLabel.AutoSize = true;
            this.uiFinishPositionPsiLabel.Location = new System.Drawing.Point(136, 55);
            this.uiFinishPositionPsiLabel.Name = "uiFinishPositionPsiLabel";
            this.uiFinishPositionPsiLabel.Size = new System.Drawing.Size(21, 13);
            this.uiFinishPositionPsiLabel.TabIndex = 23;
            this.uiFinishPositionPsiLabel.Text = "Psi";
            // 
            // uiFinishPositionPsiTextBox
            // 
            this.uiFinishPositionPsiTextBox.Location = new System.Drawing.Point(122, 71);
            this.uiFinishPositionPsiTextBox.Name = "uiFinishPositionPsiTextBox";
            this.uiFinishPositionPsiTextBox.Size = new System.Drawing.Size(52, 20);
            this.uiFinishPositionPsiTextBox.TabIndex = 22;
            this.uiFinishPositionPsiTextBox.Text = "20";
            this.uiFinishPositionPsiTextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiFinishPositionThetaLabel
            // 
            this.uiFinishPositionThetaLabel.AutoSize = true;
            this.uiFinishPositionThetaLabel.Location = new System.Drawing.Point(78, 55);
            this.uiFinishPositionThetaLabel.Name = "uiFinishPositionThetaLabel";
            this.uiFinishPositionThetaLabel.Size = new System.Drawing.Size(35, 13);
            this.uiFinishPositionThetaLabel.TabIndex = 21;
            this.uiFinishPositionThetaLabel.Text = "Theta";
            // 
            // uiFinishPositionThetaTextBox
            // 
            this.uiFinishPositionThetaTextBox.Location = new System.Drawing.Point(64, 71);
            this.uiFinishPositionThetaTextBox.Name = "uiFinishPositionThetaTextBox";
            this.uiFinishPositionThetaTextBox.Size = new System.Drawing.Size(52, 20);
            this.uiFinishPositionThetaTextBox.TabIndex = 20;
            this.uiFinishPositionThetaTextBox.Text = "50";
            this.uiFinishPositionThetaTextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiFinishPositionFiLabel
            // 
            this.uiFinishPositionFiLabel.AutoSize = true;
            this.uiFinishPositionFiLabel.Location = new System.Drawing.Point(21, 55);
            this.uiFinishPositionFiLabel.Name = "uiFinishPositionFiLabel";
            this.uiFinishPositionFiLabel.Size = new System.Drawing.Size(15, 13);
            this.uiFinishPositionFiLabel.TabIndex = 19;
            this.uiFinishPositionFiLabel.Text = "Fi";
            // 
            // uiFinishPositionFiTextBox
            // 
            this.uiFinishPositionFiTextBox.Location = new System.Drawing.Point(3, 71);
            this.uiFinishPositionFiTextBox.Name = "uiFinishPositionFiTextBox";
            this.uiFinishPositionFiTextBox.Size = new System.Drawing.Size(52, 20);
            this.uiFinishPositionFiTextBox.TabIndex = 18;
            this.uiFinishPositionFiTextBox.Text = "0";
            this.uiFinishPositionFiTextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiFinishPositionZ0Label
            // 
            this.uiFinishPositionZ0Label.AutoSize = true;
            this.uiFinishPositionZ0Label.Location = new System.Drawing.Point(136, 16);
            this.uiFinishPositionZ0Label.Name = "uiFinishPositionZ0Label";
            this.uiFinishPositionZ0Label.Size = new System.Drawing.Size(20, 13);
            this.uiFinishPositionZ0Label.TabIndex = 7;
            this.uiFinishPositionZ0Label.Text = "Z0";
            // 
            // uiFinishPositionZ0TextBox
            // 
            this.uiFinishPositionZ0TextBox.Location = new System.Drawing.Point(122, 32);
            this.uiFinishPositionZ0TextBox.Name = "uiFinishPositionZ0TextBox";
            this.uiFinishPositionZ0TextBox.Size = new System.Drawing.Size(52, 20);
            this.uiFinishPositionZ0TextBox.TabIndex = 6;
            this.uiFinishPositionZ0TextBox.Text = "200";
            this.uiFinishPositionZ0TextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiFinishPositionY0Label
            // 
            this.uiFinishPositionY0Label.AutoSize = true;
            this.uiFinishPositionY0Label.Location = new System.Drawing.Point(78, 16);
            this.uiFinishPositionY0Label.Name = "uiFinishPositionY0Label";
            this.uiFinishPositionY0Label.Size = new System.Drawing.Size(20, 13);
            this.uiFinishPositionY0Label.TabIndex = 5;
            this.uiFinishPositionY0Label.Text = "Y0";
            // 
            // uiFinishPositionY0TextBox
            // 
            this.uiFinishPositionY0TextBox.Location = new System.Drawing.Point(64, 32);
            this.uiFinishPositionY0TextBox.Name = "uiFinishPositionY0TextBox";
            this.uiFinishPositionY0TextBox.Size = new System.Drawing.Size(52, 20);
            this.uiFinishPositionY0TextBox.TabIndex = 4;
            this.uiFinishPositionY0TextBox.Text = "0";
            this.uiFinishPositionY0TextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiFinishPositionX0Label
            // 
            this.uiFinishPositionX0Label.AutoSize = true;
            this.uiFinishPositionX0Label.Location = new System.Drawing.Point(21, 16);
            this.uiFinishPositionX0Label.Name = "uiFinishPositionX0Label";
            this.uiFinishPositionX0Label.Size = new System.Drawing.Size(20, 13);
            this.uiFinishPositionX0Label.TabIndex = 3;
            this.uiFinishPositionX0Label.Text = "X0";
            // 
            // uiFinishPositionX0TextBox
            // 
            this.uiFinishPositionX0TextBox.Location = new System.Drawing.Point(3, 32);
            this.uiFinishPositionX0TextBox.Name = "uiFinishPositionX0TextBox";
            this.uiFinishPositionX0TextBox.Size = new System.Drawing.Size(52, 20);
            this.uiFinishPositionX0TextBox.TabIndex = 1;
            this.uiFinishPositionX0TextBox.Text = "50";
            this.uiFinishPositionX0TextBox.TextChanged += new System.EventHandler(this.uiParameters_TextChanged);
            // 
            // uiUpdateSceneTimer
            // 
            this.uiUpdateSceneTimer.Interval = 1;
            this.uiUpdateSceneTimer.Tick += new System.EventHandler(this.DrawHexapodTick);
            // 
            // uiMainPanel
            // 
            this.uiMainPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.uiMainPanel.Controls.Add(this.uiSettingsPanel);
            this.uiMainPanel.Controls.Add(this.uiSimpleOpenGlControl);
            this.uiMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiMainPanel.Location = new System.Drawing.Point(0, 0);
            this.uiMainPanel.Name = "uiMainPanel";
            this.uiMainPanel.Size = new System.Drawing.Size(784, 267);
            this.uiMainPanel.TabIndex = 52;
            this.uiMainPanel.SizeChanged += new System.EventHandler(this.uiMainPanel_SizeChanged);
            // 
            // uiSettingsPanel
            // 
            this.uiSettingsPanel.Controls.Add(this.trackBar1);
            this.uiSettingsPanel.Controls.Add(this.uiShowWayCheckBox);
            this.uiSettingsPanel.Controls.Add(this.uiSettingsVisibleButton);
            this.uiSettingsPanel.Controls.Add(this.uiMoveYUpButton);
            this.uiSettingsPanel.Controls.Add(this.uiMoveXDownButton);
            this.uiSettingsPanel.Controls.Add(this.uiShowRotateZUpButton);
            this.uiSettingsPanel.Controls.Add(this.uiMoveXUpButton);
            this.uiSettingsPanel.Controls.Add(this.uiShowRotateZDownButton);
            this.uiSettingsPanel.Controls.Add(this.uiMoveYDownButton);
            this.uiSettingsPanel.Controls.Add(this.uiShowRotateYUpButton);
            this.uiSettingsPanel.Controls.Add(this.uiShowRotateYDownButton);
            this.uiSettingsPanel.Controls.Add(this.uiMoveZDownButton);
            this.uiSettingsPanel.Controls.Add(this.uiShowRotateXUpButton);
            this.uiSettingsPanel.Controls.Add(this.uiMoveZUpButton);
            this.uiSettingsPanel.Controls.Add(this.uiShowRotateXDownButton);
            this.uiSettingsPanel.Controls.Add(this.uiShowZoomUpButton);
            this.uiSettingsPanel.Controls.Add(this.uiShowZoomDownButton);
            this.uiSettingsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiSettingsPanel.Location = new System.Drawing.Point(664, 0);
            this.uiSettingsPanel.Name = "uiSettingsPanel";
            this.uiSettingsPanel.Size = new System.Drawing.Size(120, 267);
            this.uiSettingsPanel.TabIndex = 52;
            // 
            // uiSettingsVisibleButton
            // 
            this.uiSettingsVisibleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uiSettingsVisibleButton.Location = new System.Drawing.Point(3, 0);
            this.uiSettingsVisibleButton.Name = "uiSettingsVisibleButton";
            this.uiSettingsVisibleButton.Size = new System.Drawing.Size(12, 267);
            this.uiSettingsVisibleButton.TabIndex = 54;
            this.uiSettingsVisibleButton.Text = "...";
            this.uiSettingsVisibleButton.UseVisualStyleBackColor = true;
            this.uiSettingsVisibleButton.Click += new System.EventHandler(this.uiSettingsVisibleButton_Click);
            // 
            // uiMoveYUpButton
            // 
            this.uiMoveYUpButton.Location = new System.Drawing.Point(46, 140);
            this.uiMoveYUpButton.Name = "uiMoveYUpButton";
            this.uiMoveYUpButton.Size = new System.Drawing.Size(26, 23);
            this.uiMoveYUpButton.TabIndex = 52;
            this.uiMoveYUpButton.Text = "y+";
            this.uiMoveYUpButton.UseVisualStyleBackColor = true;
            this.uiMoveYUpButton.Click += new System.EventHandler(this.uiMoveYUpButton_Click);
            // 
            // uiMoveXDownButton
            // 
            this.uiMoveXDownButton.Location = new System.Drawing.Point(17, 116);
            this.uiMoveXDownButton.Name = "uiMoveXDownButton";
            this.uiMoveXDownButton.Size = new System.Drawing.Size(26, 23);
            this.uiMoveXDownButton.TabIndex = 50;
            this.uiMoveXDownButton.Text = "x-";
            this.uiMoveXDownButton.UseVisualStyleBackColor = true;
            this.uiMoveXDownButton.Click += new System.EventHandler(this.uiMoveXDownButton_Click);
            // 
            // uiShowRotateZUpButton
            // 
            this.uiShowRotateZUpButton.Location = new System.Drawing.Point(75, 29);
            this.uiShowRotateZUpButton.Name = "uiShowRotateZUpButton";
            this.uiShowRotateZUpButton.Size = new System.Drawing.Size(26, 23);
            this.uiShowRotateZUpButton.TabIndex = 43;
            this.uiShowRotateZUpButton.Text = "z+";
            this.uiShowRotateZUpButton.UseVisualStyleBackColor = true;
            this.uiShowRotateZUpButton.Click += new System.EventHandler(this.uiShowRotateZUpButton_Click);
            // 
            // uiMoveXUpButton
            // 
            this.uiMoveXUpButton.Location = new System.Drawing.Point(17, 140);
            this.uiMoveXUpButton.Name = "uiMoveXUpButton";
            this.uiMoveXUpButton.Size = new System.Drawing.Size(26, 23);
            this.uiMoveXUpButton.TabIndex = 53;
            this.uiMoveXUpButton.Text = "x+";
            this.uiMoveXUpButton.UseVisualStyleBackColor = true;
            this.uiMoveXUpButton.Click += new System.EventHandler(this.uiMoveXUpButton_Click);
            // 
            // uiShowRotateZDownButton
            // 
            this.uiShowRotateZDownButton.Location = new System.Drawing.Point(75, 5);
            this.uiShowRotateZDownButton.Name = "uiShowRotateZDownButton";
            this.uiShowRotateZDownButton.Size = new System.Drawing.Size(26, 23);
            this.uiShowRotateZDownButton.TabIndex = 40;
            this.uiShowRotateZDownButton.Text = "z-";
            this.uiShowRotateZDownButton.UseVisualStyleBackColor = true;
            this.uiShowRotateZDownButton.Click += new System.EventHandler(this.uiShowRotateZDownButton_Click);
            // 
            // uiMoveYDownButton
            // 
            this.uiMoveYDownButton.Location = new System.Drawing.Point(46, 116);
            this.uiMoveYDownButton.Name = "uiMoveYDownButton";
            this.uiMoveYDownButton.Size = new System.Drawing.Size(26, 23);
            this.uiMoveYDownButton.TabIndex = 49;
            this.uiMoveYDownButton.Text = "y-";
            this.uiMoveYDownButton.UseVisualStyleBackColor = true;
            this.uiMoveYDownButton.Click += new System.EventHandler(this.uiMoveYDownButton_Click);
            // 
            // uiShowRotateYUpButton
            // 
            this.uiShowRotateYUpButton.Location = new System.Drawing.Point(46, 29);
            this.uiShowRotateYUpButton.Name = "uiShowRotateYUpButton";
            this.uiShowRotateYUpButton.Size = new System.Drawing.Size(26, 23);
            this.uiShowRotateYUpButton.TabIndex = 44;
            this.uiShowRotateYUpButton.Text = "y+";
            this.uiShowRotateYUpButton.UseVisualStyleBackColor = true;
            this.uiShowRotateYUpButton.Click += new System.EventHandler(this.uiShowRotateYUpButton_Click);
            // 
            // uiShowRotateYDownButton
            // 
            this.uiShowRotateYDownButton.Location = new System.Drawing.Point(46, 5);
            this.uiShowRotateYDownButton.Name = "uiShowRotateYDownButton";
            this.uiShowRotateYDownButton.Size = new System.Drawing.Size(26, 23);
            this.uiShowRotateYDownButton.TabIndex = 41;
            this.uiShowRotateYDownButton.Text = "y-";
            this.uiShowRotateYDownButton.UseVisualStyleBackColor = true;
            this.uiShowRotateYDownButton.Click += new System.EventHandler(this.uiShowRotateYDownButton_Click);
            // 
            // uiMoveZDownButton
            // 
            this.uiMoveZDownButton.Location = new System.Drawing.Point(75, 116);
            this.uiMoveZDownButton.Name = "uiMoveZDownButton";
            this.uiMoveZDownButton.Size = new System.Drawing.Size(26, 23);
            this.uiMoveZDownButton.TabIndex = 48;
            this.uiMoveZDownButton.Text = "z-";
            this.uiMoveZDownButton.UseVisualStyleBackColor = true;
            this.uiMoveZDownButton.Click += new System.EventHandler(this.uiMoveZDownButton_Click);
            // 
            // uiShowRotateXUpButton
            // 
            this.uiShowRotateXUpButton.Location = new System.Drawing.Point(17, 29);
            this.uiShowRotateXUpButton.Name = "uiShowRotateXUpButton";
            this.uiShowRotateXUpButton.Size = new System.Drawing.Size(26, 23);
            this.uiShowRotateXUpButton.TabIndex = 45;
            this.uiShowRotateXUpButton.Text = "x+";
            this.uiShowRotateXUpButton.UseVisualStyleBackColor = true;
            this.uiShowRotateXUpButton.Click += new System.EventHandler(this.uiShowRotateXUpButton_Click);
            // 
            // uiMoveZUpButton
            // 
            this.uiMoveZUpButton.Location = new System.Drawing.Point(75, 140);
            this.uiMoveZUpButton.Name = "uiMoveZUpButton";
            this.uiMoveZUpButton.Size = new System.Drawing.Size(26, 23);
            this.uiMoveZUpButton.TabIndex = 51;
            this.uiMoveZUpButton.Text = "z+";
            this.uiMoveZUpButton.UseVisualStyleBackColor = true;
            this.uiMoveZUpButton.Click += new System.EventHandler(this.uiMoveZUpButton_Click);
            // 
            // uiShowRotateXDownButton
            // 
            this.uiShowRotateXDownButton.Location = new System.Drawing.Point(17, 5);
            this.uiShowRotateXDownButton.Name = "uiShowRotateXDownButton";
            this.uiShowRotateXDownButton.Size = new System.Drawing.Size(26, 23);
            this.uiShowRotateXDownButton.TabIndex = 42;
            this.uiShowRotateXDownButton.Text = "x-";
            this.uiShowRotateXDownButton.UseVisualStyleBackColor = true;
            this.uiShowRotateXDownButton.Click += new System.EventHandler(this.uiShowRotateXDownButton_Click);
            // 
            // uiShowZoomUpButton
            // 
            this.uiShowZoomUpButton.Location = new System.Drawing.Point(17, 58);
            this.uiShowZoomUpButton.Name = "uiShowZoomUpButton";
            this.uiShowZoomUpButton.Size = new System.Drawing.Size(55, 23);
            this.uiShowZoomUpButton.TabIndex = 46;
            this.uiShowZoomUpButton.Text = "zoom+";
            this.uiShowZoomUpButton.UseVisualStyleBackColor = true;
            this.uiShowZoomUpButton.Click += new System.EventHandler(this.uiShowZoomUpButton_Click);
            // 
            // uiShowZoomDownButton
            // 
            this.uiShowZoomDownButton.Location = new System.Drawing.Point(17, 87);
            this.uiShowZoomDownButton.Name = "uiShowZoomDownButton";
            this.uiShowZoomDownButton.Size = new System.Drawing.Size(55, 23);
            this.uiShowZoomDownButton.TabIndex = 47;
            this.uiShowZoomDownButton.Text = "zoom-";
            this.uiShowZoomDownButton.UseVisualStyleBackColor = true;
            this.uiShowZoomDownButton.Click += new System.EventHandler(this.uiShowZoomDownButton_Click);
            // 
            // uiSimpleOpenGlControl
            // 
            this.uiSimpleOpenGlControl.AccumBits = ((byte)(0));
            this.uiSimpleOpenGlControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSimpleOpenGlControl.AutoCheckErrors = false;
            this.uiSimpleOpenGlControl.AutoFinish = false;
            this.uiSimpleOpenGlControl.AutoMakeCurrent = true;
            this.uiSimpleOpenGlControl.AutoSwapBuffers = true;
            this.uiSimpleOpenGlControl.BackColor = System.Drawing.Color.Black;
            this.uiSimpleOpenGlControl.ColorBits = ((byte)(32));
            this.uiSimpleOpenGlControl.DepthBits = ((byte)(16));
            this.uiSimpleOpenGlControl.Location = new System.Drawing.Point(454, 0);
            this.uiSimpleOpenGlControl.Name = "uiSimpleOpenGlControl";
            this.uiSimpleOpenGlControl.Size = new System.Drawing.Size(207, 267);
            this.uiSimpleOpenGlControl.StencilBits = ((byte)(0));
            this.uiSimpleOpenGlControl.TabIndex = 51;
            // 
            // uiPlatformPositionPanel
            // 
            this.uiPlatformPositionPanel.Controls.Add(this.uiFinishPostionGroupBox);
            this.uiPlatformPositionPanel.Controls.Add(this.uiStartPositionGroupBox);
            this.uiPlatformPositionPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiPlatformPositionPanel.Location = new System.Drawing.Point(136, 0);
            this.uiPlatformPositionPanel.Name = "uiPlatformPositionPanel";
            this.uiPlatformPositionPanel.Size = new System.Drawing.Size(200, 267);
            this.uiPlatformPositionPanel.TabIndex = 53;
            // 
            // uiHexapodPanel
            // 
            this.uiHexapodPanel.Controls.Add(this.uiHexapodGroupBox);
            this.uiHexapodPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiHexapodPanel.Location = new System.Drawing.Point(0, 0);
            this.uiHexapodPanel.Name = "uiHexapodPanel";
            this.uiHexapodPanel.Size = new System.Drawing.Size(136, 267);
            this.uiHexapodPanel.TabIndex = 22;
            // 
            // uiSelectTrackPanel
            // 
            this.uiSelectTrackPanel.Controls.Add(this.uiSelectTrackGroupBox);
            this.uiSelectTrackPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiSelectTrackPanel.Location = new System.Drawing.Point(336, 0);
            this.uiSelectTrackPanel.Name = "uiSelectTrackPanel";
            this.uiSelectTrackPanel.Size = new System.Drawing.Size(120, 267);
            this.uiSelectTrackPanel.TabIndex = 22;
            // 
            // uiShowWayCheckBox
            // 
            this.uiShowWayCheckBox.AutoSize = true;
            this.uiShowWayCheckBox.Checked = true;
            this.uiShowWayCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uiShowWayCheckBox.Location = new System.Drawing.Point(17, 169);
            this.uiShowWayCheckBox.Name = "uiShowWayCheckBox";
            this.uiShowWayCheckBox.Size = new System.Drawing.Size(100, 17);
            this.uiShowWayCheckBox.TabIndex = 55;
            this.uiShowWayCheckBox.Text = "Показать путь";
            this.uiShowWayCheckBox.UseVisualStyleBackColor = true;
            this.uiShowWayCheckBox.CheckedChanged += new System.EventHandler(this.uiShowWayCheckBox_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(13, 219);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 56;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.uiSelectTrackPanel);
            this.Controls.Add(this.uiPlatformPositionPanel);
            this.Controls.Add(this.uiHexapodPanel);
            this.Controls.Add(this.uiMainPanel);
            this.Controls.Add(this.uiPlayDataGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Гексапод";
            this.uiHexapodGroupBox.ResumeLayout(false);
            this.uiHexapodGroupBox.PerformLayout();
            this.uiSelectTrackGroupBox.ResumeLayout(false);
            this.uiSelectTrackGroupBox.PerformLayout();
            this.uiPlayDataGroupBox.ResumeLayout(false);
            this.uiPlayDataGroupBox.PerformLayout();
            this.uiPlayButtonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiTrackTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTrackDataGridView)).EndInit();
            this.uiStartPositionGroupBox.ResumeLayout(false);
            this.uiStartPositionGroupBox.PerformLayout();
            this.uiFinishPostionGroupBox.ResumeLayout(false);
            this.uiFinishPostionGroupBox.PerformLayout();
            this.uiMainPanel.ResumeLayout(false);
            this.uiSettingsPanel.ResumeLayout(false);
            this.uiSettingsPanel.PerformLayout();
            this.uiPlatformPositionPanel.ResumeLayout(false);
            this.uiHexapodPanel.ResumeLayout(false);
            this.uiSelectTrackPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox uiHexapodGroupBox;
        private System.Windows.Forms.Label uiRailsMinLengthLabel;
        private System.Windows.Forms.Label uiRailsRadiusLabel;
        public System.Windows.Forms.TextBox uiRailsMaxLengthTextBox;
        public System.Windows.Forms.TextBox uiRailsMinLengthTextBox;
        public System.Windows.Forms.TextBox uiRailsRadiusTextBox;
        private System.Windows.Forms.Label uiCardanHeightLabel;
        public System.Windows.Forms.TextBox uiCardanAngleTextBox;
        private System.Windows.Forms.Label uiCardanAngleLabel;
        public System.Windows.Forms.TextBox uiCardanHeightTextBox;
        private System.Windows.Forms.Label uiCardanToCenterLenghtLabel;
        private System.Windows.Forms.Label uiCardanRadiusLabel;
        public System.Windows.Forms.TextBox uiCardanRadiusTextBox;
        public System.Windows.Forms.TextBox uiCardanToCenterLenghtTextBox;
        private System.Windows.Forms.Label uiPlatformHeightLabel;
        public System.Windows.Forms.TextBox uiPlatformHeightTextBox;
        private System.Windows.Forms.Label uiPlatformLabel;
        public System.Windows.Forms.TextBox uiPlatformRadiusTextBox;
        private System.Windows.Forms.Label uiPlatformRadiusLabel;
        private System.Windows.Forms.Label uiСardanLabel;
        private System.Windows.Forms.Label uiRailsLabel;
        private System.Windows.Forms.GroupBox uiSelectTrackGroupBox;
        private System.Windows.Forms.RadioButton uiTrackByTurnRadioButton;
        private System.Windows.Forms.RadioButton uiTrackSimultaneouslyRadioButton;
        private System.Windows.Forms.Label uiTrackStepCountLabel;
        private System.Windows.Forms.Label uiTrackTimeLabel;
        private System.Windows.Forms.GroupBox uiPlayDataGroupBox;
        private System.Windows.Forms.Button uiTrackStartButton;
        private System.Windows.Forms.Button uiTrackPauseButton;
        private System.Windows.Forms.Button uiTrackBackStartButton;
        private System.Windows.Forms.Button uiTrackPlayToEndButton;
        private System.Windows.Forms.Button uiTrackPlayToStartButton;
        private System.Windows.Forms.TrackBar uiTrackTrackBar;
        private System.Windows.Forms.Label uiRailsMaxLengthLabel;
        public System.Windows.Forms.TextBox uiStartPositionX0TextBox;
        private System.Windows.Forms.Label uiStartPositionX0Label;
        public System.Windows.Forms.TextBox uiStartPositionY0TextBox;
        private System.Windows.Forms.Label uiStartPositionY0Label;
        public System.Windows.Forms.TextBox uiStartPositionZ0TextBox;
        private System.Windows.Forms.Label uiStartPositionZ0Label;
        private System.Windows.Forms.GroupBox uiStartPositionGroupBox;
        private System.Windows.Forms.Label uiStartPositionDirectionCosineZValueLabel;
        private System.Windows.Forms.Label uiStartPositionDirectionCosineYValueLabel;
        private System.Windows.Forms.Label uiStartPositionDirectionCosineXValueLabel;
        private System.Windows.Forms.Label uiStartPositionDirectionCosineZLabel;
        private System.Windows.Forms.Label uiStartPositionDirectionCosineYLabel;
        private System.Windows.Forms.Label uiStartPositionDirectionCosineXLabel;
        private System.Windows.Forms.Label uiStartPositionPsiLabel;
        private System.Windows.Forms.Label uiStartPositionThetaLabel;
        public System.Windows.Forms.TextBox uiStartPositionThetaTextBox;
        private System.Windows.Forms.Label uiStartPositionFiLabel;
        public System.Windows.Forms.TextBox uiStartPositionFiTextBox;
        private System.Windows.Forms.GroupBox uiFinishPostionGroupBox;
        private System.Windows.Forms.Label uiFinishPositionDirectionCosineZValueLabel;
        private System.Windows.Forms.Label uiFinishPositionDirectionCosineYValueLabel;
        private System.Windows.Forms.Label uiFinishPositionDirectionCosineXValueLabel;
        private System.Windows.Forms.Label uiFinishPositionDirectionCosineZLabel;
        private System.Windows.Forms.Label uiFinishPositionDirectionCosineYLabel;
        private System.Windows.Forms.Label uiFinishPositionDirectionCosineXLabel;
        private System.Windows.Forms.Label uiFinishPositionPsiLabel;
        public System.Windows.Forms.TextBox uiFinishPositionPsiTextBox;
        private System.Windows.Forms.Label uiFinishPositionThetaLabel;
        public System.Windows.Forms.TextBox uiFinishPositionThetaTextBox;
        private System.Windows.Forms.Label uiFinishPositionFiLabel;
        public System.Windows.Forms.TextBox uiFinishPositionFiTextBox;
        private System.Windows.Forms.Label uiFinishPositionZ0Label;
        public System.Windows.Forms.TextBox uiFinishPositionZ0TextBox;
        private System.Windows.Forms.Label uiFinishPositionY0Label;
        public System.Windows.Forms.TextBox uiFinishPositionY0TextBox;
        private System.Windows.Forms.Label uiFinishPositionX0Label;
        public System.Windows.Forms.TextBox uiFinishPositionX0TextBox;
        private System.Windows.Forms.ComboBox uiTrackAxeComboBox;
        public System.Windows.Forms.TextBox uiTrackTimeTextBox;
        public System.Windows.Forms.TextBox uiTrackStepCountTextBox;
        private System.Windows.Forms.Timer uiUpdateSceneTimer;
        public System.Windows.Forms.TextBox uiStartPositionPsiTextBox;
        private System.Windows.Forms.DataGridView uiTrackDataGridView;
        private System.Windows.Forms.Panel uiMainPanel;
        private System.Windows.Forms.Panel uiSettingsPanel;
        private System.Windows.Forms.Button uiSettingsVisibleButton;
        private System.Windows.Forms.Button uiMoveYUpButton;
        private System.Windows.Forms.Button uiMoveXDownButton;
        private System.Windows.Forms.Button uiShowRotateZUpButton;
        private System.Windows.Forms.Button uiMoveXUpButton;
        private System.Windows.Forms.Button uiShowRotateZDownButton;
        private System.Windows.Forms.Button uiMoveYDownButton;
        private System.Windows.Forms.Button uiShowRotateYUpButton;
        private System.Windows.Forms.Button uiShowRotateYDownButton;
        private System.Windows.Forms.Button uiMoveZDownButton;
        private System.Windows.Forms.Button uiShowRotateXUpButton;
        private System.Windows.Forms.Button uiMoveZUpButton;
        private System.Windows.Forms.Button uiShowRotateXDownButton;
        private System.Windows.Forms.Button uiShowZoomUpButton;
        private System.Windows.Forms.Button uiShowZoomDownButton;
        private Tao.Platform.Windows.SimpleOpenGlControl uiSimpleOpenGlControl;
        private System.Windows.Forms.Panel uiPlatformPositionPanel;
        private System.Windows.Forms.Panel uiHexapodPanel;
        private System.Windows.Forms.Panel uiSelectTrackPanel;
        private System.Windows.Forms.Panel uiPlayButtonsPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiX0DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiY0DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiZ0DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiFiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiThetaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiPsiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiRail1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiRail2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiRail3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiRail4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiRail5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uiRail6DataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox uiShowWayCheckBox;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

