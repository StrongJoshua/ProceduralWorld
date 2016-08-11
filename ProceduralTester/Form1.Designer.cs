namespace ProceduralTester {
	partial class Form1 {
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.equationComboBox = new System.Windows.Forms.ComboBox();
			this.GenerateButton = new System.Windows.Forms.Button();
			this.worldPanel = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.parameter1 = new System.Windows.Forms.NumericUpDown();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.worldPanel)).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.parameter1)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.worldPanel, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 436);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.equationComboBox);
			this.flowLayoutPanel1.Controls.Add(this.parameter1);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(691, 76);
			this.flowLayoutPanel1.TabIndex = 1;
			// 
			// equationComboBox
			// 
			this.equationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.equationComboBox.FormattingEnabled = true;
			this.equationComboBox.Location = new System.Drawing.Point(3, 3);
			this.equationComboBox.Name = "equationComboBox";
			this.equationComboBox.Size = new System.Drawing.Size(121, 21);
			this.equationComboBox.TabIndex = 0;
			this.equationComboBox.SelectedValueChanged += new System.EventHandler(this.equationComboBox_SelectedValueChanged);
			// 
			// GenerateButton
			// 
			this.GenerateButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GenerateButton.Location = new System.Drawing.Point(700, 3);
			this.GenerateButton.Name = "GenerateButton";
			this.GenerateButton.Size = new System.Drawing.Size(75, 76);
			this.GenerateButton.TabIndex = 1;
			this.GenerateButton.Text = "Generate";
			this.GenerateButton.UseVisualStyleBackColor = true;
			this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
			// 
			// worldPanel
			// 
			this.worldPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.worldPanel.Location = new System.Drawing.Point(3, 3);
			this.worldPanel.Name = "worldPanel";
			this.worldPanel.Size = new System.Drawing.Size(778, 342);
			this.worldPanel.TabIndex = 2;
			this.worldPanel.TabStop = false;
			this.worldPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.worldPanel_Paint);
			this.worldPanel.Resize += new System.EventHandler(this.worldPanel_Resize);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.GenerateButton, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 351);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(778, 82);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// parameter1
			// 
			this.parameter1.DecimalPlaces = 1;
			this.parameter1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.parameter1.InterceptArrowKeys = false;
			this.parameter1.Location = new System.Drawing.Point(130, 3);
			this.parameter1.Name = "parameter1";
			this.parameter1.Size = new System.Drawing.Size(120, 20);
			this.parameter1.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 436);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.KeyPreview = true;
			this.Name = "Form1";
			this.Text = "Procedural World Generation";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.worldPanel)).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.parameter1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.ComboBox equationComboBox;
		private System.Windows.Forms.Button GenerateButton;
		private System.Windows.Forms.PictureBox worldPanel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.NumericUpDown parameter1;
	}
}

