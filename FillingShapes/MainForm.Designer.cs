
namespace FillingShapes
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.optionsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.createButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.colorButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.speedTrackBar = new System.Windows.Forms.TrackBar();
            this.speedLabel = new System.Windows.Forms.Label();
            this.solidColoringButton = new System.Windows.Forms.Button();
            this.interpolationColoringButton = new System.Windows.Forms.Button();
            this.textureColoringButton = new System.Windows.Forms.Button();
            this.lightButton = new System.Windows.Forms.Button();
            this.lightBox = new System.Windows.Forms.GroupBox();
            this.lightTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mLabel = new System.Windows.Forms.Label();
            this.KdLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.KsLabel = new System.Windows.Forms.Label();
            this.KdTrackBar = new System.Windows.Forms.TrackBar();
            this.KsTrackBar = new System.Windows.Forms.TrackBar();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.MTrackBar = new System.Windows.Forms.TrackBar();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.mainTableLayoutPanel.SuspendLayout();
            this.optionsTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).BeginInit();
            this.lightBox.SuspendLayout();
            this.lightTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KdTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KsTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.28095F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.71905F));
            this.mainTableLayoutPanel.Controls.Add(this.optionsTableLayoutPanel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.mainPictureBox, 1, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(984, 561);
            this.mainTableLayoutPanel.TabIndex = 2;
            // 
            // optionsTableLayoutPanel
            // 
            this.optionsTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsTableLayoutPanel.ColumnCount = 3;
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.47288F));
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.35309F));
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.17403F));
            this.optionsTableLayoutPanel.Controls.Add(this.createButton, 0, 7);
            this.optionsTableLayoutPanel.Controls.Add(this.deleteButton, 0, 8);
            this.optionsTableLayoutPanel.Controls.Add(this.addButton, 1, 8);
            this.optionsTableLayoutPanel.Controls.Add(this.colorButton, 0, 6);
            this.optionsTableLayoutPanel.Controls.Add(this.startButton, 0, 2);
            this.optionsTableLayoutPanel.Controls.Add(this.speedTrackBar, 0, 1);
            this.optionsTableLayoutPanel.Controls.Add(this.speedLabel, 0, 0);
            this.optionsTableLayoutPanel.Controls.Add(this.solidColoringButton, 1, 6);
            this.optionsTableLayoutPanel.Controls.Add(this.interpolationColoringButton, 0, 5);
            this.optionsTableLayoutPanel.Controls.Add(this.textureColoringButton, 1, 5);
            this.optionsTableLayoutPanel.Controls.Add(this.lightButton, 1, 7);
            this.optionsTableLayoutPanel.Controls.Add(this.lightBox, 0, 3);
            this.optionsTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.optionsTableLayoutPanel.Name = "optionsTableLayoutPanel";
            this.optionsTableLayoutPanel.RowCount = 9;
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.385206F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.385206F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.46137F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.46137F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.46137F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.46137F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.46137F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.46137F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.46137F));
            this.optionsTableLayoutPanel.Size = new System.Drawing.Size(193, 555);
            this.optionsTableLayoutPanel.TabIndex = 2;
            // 
            // createButton
            // 
            this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createButton.Location = new System.Drawing.Point(3, 418);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(91, 63);
            this.createButton.TabIndex = 3;
            this.createButton.Text = "Create Polygon";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.createButton_MouseDown);
            // 
            // deleteButton
            // 
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteButton.Location = new System.Drawing.Point(3, 487);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(91, 65);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.deleteButton_MouseDown);
            // 
            // addButton
            // 
            this.optionsTableLayoutPanel.SetColumnSpan(this.addButton, 2);
            this.addButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addButton.Location = new System.Drawing.Point(100, 487);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(90, 65);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.addButton_MouseDown);
            // 
            // colorButton
            // 
            this.colorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorButton.Location = new System.Drawing.Point(3, 349);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(91, 63);
            this.colorButton.TabIndex = 10;
            this.colorButton.Text = "Choose Color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorButton_MouseDown);
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsTableLayoutPanel.SetColumnSpan(this.startButton, 3);
            this.startButton.Location = new System.Drawing.Point(3, 73);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(187, 63);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.startButton_MouseDown);
            // 
            // speedTrackBar
            // 
            this.speedTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsTableLayoutPanel.SetColumnSpan(this.speedTrackBar, 3);
            this.speedTrackBar.Location = new System.Drawing.Point(3, 38);
            this.speedTrackBar.Maximum = 50;
            this.speedTrackBar.Minimum = 1;
            this.speedTrackBar.Name = "speedTrackBar";
            this.speedTrackBar.Size = new System.Drawing.Size(187, 29);
            this.speedTrackBar.TabIndex = 12;
            this.speedTrackBar.Value = 10;
            this.speedTrackBar.ValueChanged += new System.EventHandler(this.speedTrackBar_ValueChanged);
            // 
            // speedLabel
            // 
            this.speedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedLabel.AutoSize = true;
            this.optionsTableLayoutPanel.SetColumnSpan(this.speedLabel, 3);
            this.speedLabel.Location = new System.Drawing.Point(3, 0);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(187, 35);
            this.speedLabel.TabIndex = 13;
            this.speedLabel.Text = "Speed";
            this.speedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // solidColoringButton
            // 
            this.solidColoringButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsTableLayoutPanel.SetColumnSpan(this.solidColoringButton, 2);
            this.solidColoringButton.Location = new System.Drawing.Point(100, 349);
            this.solidColoringButton.Name = "solidColoringButton";
            this.solidColoringButton.Size = new System.Drawing.Size(90, 63);
            this.solidColoringButton.TabIndex = 14;
            this.solidColoringButton.Text = "Solid Coloring";
            this.solidColoringButton.UseVisualStyleBackColor = true;
            this.solidColoringButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.solidColoringButton_MouseDown);
            // 
            // interpolationColoringButton
            // 
            this.interpolationColoringButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.interpolationColoringButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.interpolationColoringButton.Location = new System.Drawing.Point(3, 280);
            this.interpolationColoringButton.Name = "interpolationColoringButton";
            this.interpolationColoringButton.Size = new System.Drawing.Size(91, 63);
            this.interpolationColoringButton.TabIndex = 15;
            this.interpolationColoringButton.Text = "Interpolation Coloring";
            this.interpolationColoringButton.UseVisualStyleBackColor = true;
            this.interpolationColoringButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.interpolationColoringButton_MouseDown);
            // 
            // textureColoringButton
            // 
            this.textureColoringButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsTableLayoutPanel.SetColumnSpan(this.textureColoringButton, 2);
            this.textureColoringButton.Location = new System.Drawing.Point(100, 280);
            this.textureColoringButton.Name = "textureColoringButton";
            this.textureColoringButton.Size = new System.Drawing.Size(90, 63);
            this.textureColoringButton.TabIndex = 11;
            this.textureColoringButton.Text = "Texture Coloring";
            this.textureColoringButton.UseVisualStyleBackColor = true;
            this.textureColoringButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textureColoringButton_MouseDown);
            // 
            // lightButton
            // 
            this.lightButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsTableLayoutPanel.SetColumnSpan(this.lightButton, 2);
            this.lightButton.Location = new System.Drawing.Point(100, 418);
            this.lightButton.Name = "lightButton";
            this.lightButton.Size = new System.Drawing.Size(90, 63);
            this.lightButton.TabIndex = 3;
            this.lightButton.Text = "Add Light";
            this.lightButton.UseVisualStyleBackColor = true;
            this.lightButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lightButton_MouseDown);
            // 
            // lightBox
            // 
            this.lightBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsTableLayoutPanel.SetColumnSpan(this.lightBox, 3);
            this.lightBox.Controls.Add(this.lightTableLayoutPanel);
            this.lightBox.Location = new System.Drawing.Point(3, 142);
            this.lightBox.Name = "lightBox";
            this.optionsTableLayoutPanel.SetRowSpan(this.lightBox, 2);
            this.lightBox.Size = new System.Drawing.Size(187, 132);
            this.lightBox.TabIndex = 16;
            this.lightBox.TabStop = false;
            this.lightBox.Text = "Light";
            // 
            // lightTableLayoutPanel
            // 
            this.lightTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lightTableLayoutPanel.ColumnCount = 2;
            this.lightTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.95506F));
            this.lightTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.04494F));
            this.lightTableLayoutPanel.Controls.Add(this.mLabel, 0, 3);
            this.lightTableLayoutPanel.Controls.Add(this.KdLabel, 0, 1);
            this.lightTableLayoutPanel.Controls.Add(this.HeightLabel, 0, 0);
            this.lightTableLayoutPanel.Controls.Add(this.KsLabel, 0, 2);
            this.lightTableLayoutPanel.Controls.Add(this.KdTrackBar, 1, 1);
            this.lightTableLayoutPanel.Controls.Add(this.KsTrackBar, 1, 2);
            this.lightTableLayoutPanel.Controls.Add(this.HeightTextBox, 1, 0);
            this.lightTableLayoutPanel.Controls.Add(this.MTrackBar, 1, 3);
            this.lightTableLayoutPanel.Location = new System.Drawing.Point(3, 23);
            this.lightTableLayoutPanel.Name = "lightTableLayoutPanel";
            this.lightTableLayoutPanel.RowCount = 4;
            this.lightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.lightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.lightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.lightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.lightTableLayoutPanel.Size = new System.Drawing.Size(178, 100);
            this.lightTableLayoutPanel.TabIndex = 0;
            // 
            // mLabel
            // 
            this.mLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mLabel.AutoSize = true;
            this.mLabel.Location = new System.Drawing.Point(3, 75);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(58, 25);
            this.mLabel.TabIndex = 8;
            this.mLabel.Text = "M";
            this.mLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KdLabel
            // 
            this.KdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KdLabel.AutoSize = true;
            this.KdLabel.Location = new System.Drawing.Point(3, 25);
            this.KdLabel.Name = "KdLabel";
            this.KdLabel.Size = new System.Drawing.Size(58, 25);
            this.KdLabel.TabIndex = 2;
            this.KdLabel.Text = "Kd";
            this.KdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HeightLabel
            // 
            this.HeightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(3, 0);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(58, 25);
            this.HeightLabel.TabIndex = 0;
            this.HeightLabel.Text = "Height";
            this.HeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KsLabel
            // 
            this.KsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KsLabel.AutoSize = true;
            this.KsLabel.Location = new System.Drawing.Point(3, 50);
            this.KsLabel.Name = "KsLabel";
            this.KsLabel.Size = new System.Drawing.Size(58, 25);
            this.KsLabel.TabIndex = 1;
            this.KsLabel.Text = "Ks";
            this.KsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KdTrackBar
            // 
            this.KdTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KdTrackBar.Location = new System.Drawing.Point(67, 28);
            this.KdTrackBar.Maximum = 100;
            this.KdTrackBar.Name = "KdTrackBar";
            this.KdTrackBar.Size = new System.Drawing.Size(108, 19);
            this.KdTrackBar.TabIndex = 4;
            this.KdTrackBar.Value = 100;
            this.KdTrackBar.ValueChanged += new System.EventHandler(this.KdTrackBar_ValueChanged);
            // 
            // KsTrackBar
            // 
            this.KsTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KsTrackBar.Location = new System.Drawing.Point(67, 53);
            this.KsTrackBar.Maximum = 100;
            this.KsTrackBar.Name = "KsTrackBar";
            this.KsTrackBar.Size = new System.Drawing.Size(108, 19);
            this.KsTrackBar.TabIndex = 5;
            this.KsTrackBar.Value = 50;
            this.KsTrackBar.ValueChanged += new System.EventHandler(this.KsTrackBar_ValueChanged);
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HeightTextBox.Location = new System.Drawing.Point(67, 3);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(108, 27);
            this.HeightTextBox.TabIndex = 6;
            this.HeightTextBox.Text = "1000";
            this.HeightTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HeightTextBox_KeyDown);
            // 
            // MTrackBar
            // 
            this.MTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MTrackBar.Location = new System.Drawing.Point(67, 78);
            this.MTrackBar.Maximum = 100;
            this.MTrackBar.Name = "MTrackBar";
            this.MTrackBar.Size = new System.Drawing.Size(108, 19);
            this.MTrackBar.TabIndex = 7;
            this.MTrackBar.Value = 50;
            this.MTrackBar.ValueChanged += new System.EventHandler(this.MTrackBar_ValueChanged);
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainPictureBox.Location = new System.Drawing.Point(204, 5);
            this.mainPictureBox.Margin = new System.Windows.Forms.Padding(5);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(775, 551);
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseDown);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseMove);
            this.mainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseUp);
            // 
            // timer
            // 
            this.timer.Interval = 5;
            this.timer.Tick += new System.EventHandler(this.CountDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Name = "MainForm";
            this.Text = "Filling Shapes";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.optionsTableLayoutPanel.ResumeLayout(false);
            this.optionsTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).EndInit();
            this.lightBox.ResumeLayout(false);
            this.lightTableLayoutPanel.ResumeLayout(false);
            this.lightTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KdTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KsTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel optionsTableLayoutPanel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button textureColoringButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TrackBar speedTrackBar;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Button solidColoringButton;
        private System.Windows.Forms.Button interpolationColoringButton;
        private System.Windows.Forms.Button lightButton;
        private System.Windows.Forms.GroupBox lightBox;
        private System.Windows.Forms.TableLayoutPanel lightTableLayoutPanel;
        private System.Windows.Forms.Label KdLabel;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label KsLabel;
        private System.Windows.Forms.TrackBar KdTrackBar;
        private System.Windows.Forms.TrackBar KsTrackBar;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.Label mLabel;
        private System.Windows.Forms.TrackBar MTrackBar;
    }
}

