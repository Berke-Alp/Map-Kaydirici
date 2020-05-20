namespace MapKaydirici
{
	partial class mainForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
			this.label1 = new System.Windows.Forms.Label();
			this.nupX = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.nupY = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.nupZ = new System.Windows.Forms.NumericUpDown();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnKaydir = new System.Windows.Forms.Button();
			this.txtMap = new FastColoredTextBoxNS.FastColoredTextBox();
			((System.ComponentModel.ISupportInitialize)(this.nupX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nupY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nupZ)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtMap)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(241, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Kaydırmak istediğiniz haritanın .pwn dosyası içeriği";
			// 
			// nupX
			// 
			this.nupX.DecimalPlaces = 4;
			this.nupX.Location = new System.Drawing.Point(9, 44);
			this.nupX.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.nupX.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
			this.nupX.Name = "nupX";
			this.nupX.Size = new System.Drawing.Size(120, 20);
			this.nupX.TabIndex = 2;
			this.nupX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "X Pos";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 84);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Y Pos";
			// 
			// nupY
			// 
			this.nupY.DecimalPlaces = 4;
			this.nupY.Location = new System.Drawing.Point(9, 100);
			this.nupY.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.nupY.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
			this.nupY.Name = "nupY";
			this.nupY.Size = new System.Drawing.Size(120, 20);
			this.nupY.TabIndex = 4;
			this.nupY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.nupY.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 138);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Z Pos";
			// 
			// nupZ
			// 
			this.nupZ.DecimalPlaces = 4;
			this.nupZ.Location = new System.Drawing.Point(9, 154);
			this.nupZ.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.nupZ.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
			this.nupZ.Name = "nupZ";
			this.nupZ.Size = new System.Drawing.Size(120, 20);
			this.nupZ.TabIndex = 6;
			this.nupZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnKaydir);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.nupX);
			this.groupBox1.Controls.Add(this.nupZ);
			this.groupBox1.Controls.Add(this.nupY);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(651, 25);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(139, 238);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Kaydırılacak Değerler";
			// 
			// btnKaydir
			// 
			this.btnKaydir.Location = new System.Drawing.Point(9, 194);
			this.btnKaydir.Name = "btnKaydir";
			this.btnKaydir.Size = new System.Drawing.Size(120, 30);
			this.btnKaydir.TabIndex = 8;
			this.btnKaydir.Text = "KAYDIR";
			this.btnKaydir.UseVisualStyleBackColor = true;
			this.btnKaydir.Click += new System.EventHandler(this.btnKaydir_Click);
			// 
			// txtMap
			// 
			this.txtMap.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
			this.txtMap.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
			this.txtMap.AutoScrollMinSize = new System.Drawing.Size(27, 14);
			this.txtMap.BackBrush = null;
			this.txtMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
			this.txtMap.CaretColor = System.Drawing.Color.Coral;
			this.txtMap.CharHeight = 14;
			this.txtMap.CharWidth = 8;
			this.txtMap.CurrentPenSize = 3;
			this.txtMap.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtMap.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.txtMap.DocumentPath = null;
			this.txtMap.ForeColor = System.Drawing.Color.White;
			this.txtMap.IndentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
			this.txtMap.IsReplaceMode = false;
			this.txtMap.LeftBracket = '(';
			this.txtMap.LeftBracket2 = '{';
			this.txtMap.LineNumberColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.txtMap.Location = new System.Drawing.Point(12, 26);
			this.txtMap.Name = "txtMap";
			this.txtMap.Paddings = new System.Windows.Forms.Padding(0);
			this.txtMap.RightBracket = ')';
			this.txtMap.RightBracket2 = '}';
			this.txtMap.SelectionChangedDelayedEnabled = false;
			this.txtMap.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.txtMap.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtMap.ServiceColors")));
			this.txtMap.Size = new System.Drawing.Size(633, 412);
			this.txtMap.TabIndex = 9;
			this.txtMap.Zoom = 100;
			this.txtMap.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctxtMap_TextChanged);
			this.txtMap.Pasting += new System.EventHandler<FastColoredTextBoxNS.TextChangingEventArgs>(this.txtMap_Pasting);
			this.txtMap.TextChanging += new System.EventHandler<FastColoredTextBoxNS.TextChangingEventArgs>(this.txtMap_Pasting);
			this.txtMap.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctxtMap_TextChanged);
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.txtMap);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "mainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SAMP Harita Kaydırıcı";
			((System.ComponentModel.ISupportInitialize)(this.nupX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nupY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nupZ)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtMap)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown nupX;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown nupY;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nupZ;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnKaydir;
		private FastColoredTextBoxNS.FastColoredTextBox txtMap;
	}
}