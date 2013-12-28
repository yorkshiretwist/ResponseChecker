namespace ResponseCheckerGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.topPanelOuter = new System.Windows.Forms.Panel();
            this.topPanelInner = new System.Windows.Forms.Panel();
            this.cbFailedOnly = new System.Windows.Forms.CheckBox();
            this.startButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.testTitle = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ItemTemplate = new Microsoft.VisualBasic.PowerPacks.DataRepeaterItem();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.testGrid = new System.Windows.Forms.DataGridView();
            this.testIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.topPanelOuter.SuspendLayout();
            this.topPanelInner.SuspendLayout();
            this.dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 501);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(747, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip";
            // 
            // topPanelOuter
            // 
            this.topPanelOuter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topPanelOuter.BackColor = System.Drawing.Color.White;
            this.topPanelOuter.Controls.Add(this.topPanelInner);
            this.topPanelOuter.Location = new System.Drawing.Point(0, 0);
            this.topPanelOuter.Name = "topPanelOuter";
            this.topPanelOuter.Size = new System.Drawing.Size(747, 85);
            this.topPanelOuter.TabIndex = 2;
            // 
            // topPanelInner
            // 
            this.topPanelInner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topPanelInner.BackColor = System.Drawing.Color.White;
            this.topPanelInner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.topPanelInner.Controls.Add(this.cbFailedOnly);
            this.topPanelInner.Controls.Add(this.startButton);
            this.topPanelInner.Location = new System.Drawing.Point(8, 11);
            this.topPanelInner.Name = "topPanelInner";
            this.topPanelInner.Size = new System.Drawing.Size(727, 71);
            this.topPanelInner.TabIndex = 2;
            // 
            // cbFailedOnly
            // 
            this.cbFailedOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFailedOnly.AutoSize = true;
            this.cbFailedOnly.Location = new System.Drawing.Point(401, 29);
            this.cbFailedOnly.Name = "cbFailedOnly";
            this.cbFailedOnly.Size = new System.Drawing.Size(102, 17);
            this.cbFailedOnly.TabIndex = 1;
            this.cbFailedOnly.Text = "Only failed items";
            this.cbFailedOnly.UseVisualStyleBackColor = true;
            this.cbFailedOnly.Visible = false;
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.BackColor = System.Drawing.Color.YellowGreen;
            this.startButton.Enabled = false;
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(529, 16);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(196, 39);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Test";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.Image = ((System.Drawing.Image)(resources.GetObject("loadButton.Image")));
            this.loadButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadButton.Location = new System.Drawing.Point(672, 91);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(63, 23);
            this.loadButton.TabIndex = 4;
            this.loadButton.Text = "Load";
            this.loadButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // testTitle
            // 
            this.testTitle.AutoSize = true;
            this.testTitle.Location = new System.Drawing.Point(5, 96);
            this.testTitle.Name = "testTitle";
            this.testTitle.Size = new System.Drawing.Size(186, 13);
            this.testTitle.TabIndex = 5;
            this.testTitle.Text = "No tests loaded, please load a test file";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "testFile";
            // 
            // ItemTemplate
            // 
            this.ItemTemplate.Size = new System.Drawing.Size(719, 100);
            // 
            // dataPanel
            // 
            this.dataPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataPanel.Controls.Add(this.testGrid);
            this.dataPanel.Location = new System.Drawing.Point(8, 120);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(727, 367);
            this.dataPanel.TabIndex = 3;
            // 
            // testGrid
            // 
            this.testGrid.AllowUserToAddRows = false;
            this.testGrid.AllowUserToDeleteRows = false;
            this.testGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.testGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.testGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.testIndex,
            this.checkDescription,
            this.checkStatus});
            this.testGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.testGrid.GridColor = System.Drawing.SystemColors.Control;
            this.testGrid.Location = new System.Drawing.Point(4, 3);
            this.testGrid.MultiSelect = false;
            this.testGrid.Name = "testGrid";
            this.testGrid.ReadOnly = true;
            this.testGrid.RowHeadersVisible = false;
            this.testGrid.ShowEditingIcon = false;
            this.testGrid.Size = new System.Drawing.Size(720, 361);
            this.testGrid.TabIndex = 0;
            // 
            // testIndex
            // 
            this.testIndex.HeaderText = "Test";
            this.testIndex.Name = "testIndex";
            this.testIndex.ReadOnly = true;
            this.testIndex.Width = 117;
            // 
            // checkDescription
            // 
            this.checkDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.checkDescription.HeaderText = "Check";
            this.checkDescription.Name = "checkDescription";
            this.checkDescription.ReadOnly = true;
            // 
            // checkStatus
            // 
            this.checkStatus.HeaderText = "Status";
            this.checkStatus.Name = "checkStatus";
            this.checkStatus.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 523);
            this.Controls.Add(this.testTitle);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.topPanelOuter);
            this.Controls.Add(this.statusStrip);
            this.MinimumSize = new System.Drawing.Size(755, 550);
            this.Name = "Form1";
            this.Text = "Response Checker";
            this.topPanelOuter.ResumeLayout(false);
            this.topPanelInner.ResumeLayout(false);
            this.topPanelInner.PerformLayout();
            this.dataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.testGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Panel topPanelOuter;
        private System.Windows.Forms.Panel topPanelInner;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.CheckBox cbFailedOnly;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label testTitle;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private Microsoft.VisualBasic.PowerPacks.DataRepeaterItem ItemTemplate;
        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.DataGridView testGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn testIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkStatus;
    }
}

