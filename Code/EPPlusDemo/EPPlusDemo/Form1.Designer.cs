namespace EPPlusDemo
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
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnImportExcel = new System.Windows.Forms.ToolStripButton();
			this.excelGridView = new System.Windows.Forms.DataGridView();
			this.dialogOpenExcel = new System.Windows.Forms.OpenFileDialog();
			this.btnExportExcel = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.excelGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImportExcel,
            this.btnExportExcel});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(451, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnImportExcel
			// 
			this.btnImportExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnImportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnImportExcel.Image")));
			this.btnImportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImportExcel.Name = "btnImportExcel";
			this.btnImportExcel.Size = new System.Drawing.Size(76, 22);
			this.btnImportExcel.Text = "Import Excel";
			this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
			// 
			// excelGridView
			// 
			this.excelGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.excelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.excelGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.excelGridView.Location = new System.Drawing.Point(0, 25);
			this.excelGridView.Name = "excelGridView";
			this.excelGridView.Size = new System.Drawing.Size(451, 237);
			this.excelGridView.TabIndex = 1;
			// 
			// dialogOpenExcel
			// 
			this.dialogOpenExcel.FileName = "openFileDialog1";
			// 
			// btnExportExcel
			// 
			this.btnExportExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.Image")));
			this.btnExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExportExcel.Name = "btnExportExcel";
			this.btnExportExcel.Size = new System.Drawing.Size(136, 22);
			this.btnExportExcel.Text = "Export Sample Excel File";
			this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(451, 262);
			this.Controls.Add(this.excelGridView);
			this.Controls.Add(this.toolStrip1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "EPPlus Demo";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.excelGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnImportExcel;
		private System.Windows.Forms.DataGridView excelGridView;
		private System.Windows.Forms.OpenFileDialog dialogOpenExcel;
		private System.Windows.Forms.ToolStripButton btnExportExcel;
	}
}

