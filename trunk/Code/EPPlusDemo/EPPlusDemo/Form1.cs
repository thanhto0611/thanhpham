using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Drawing;
using System.Diagnostics;

namespace EPPlusDemo
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnImportExcel_Click(object sender, EventArgs e)
		{
			string filePath = null;
			string sheetName = null;
			dialogOpenExcel.Filter = "Excel 2007 Files|*.xlsx";
			if (dialogOpenExcel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				filePath = dialogOpenExcel.FileName;
			else return;
			using (ExcelPackage excelPkg = new ExcelPackage())
			using (FileStream stream = new FileStream(filePath, FileMode.Open))
			{
				excelPkg.Load(stream);
				using (FormSheetName frmSheetName = new FormSheetName())
				{
					if (frmSheetName.ShowDialog() == System.Windows.Forms.DialogResult.OK)
						sheetName = frmSheetName.Tag.ToString();
					else return;
				}
				ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets[sheetName];
				excelGridView.DataSource = WorksheetToDataTable(oSheet);
			}
		}

		private void btnExportExcel_Click(object sender, EventArgs e)
		{
			ExportSampleExcel();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////
		// Example shows you:
		// 1. Setting Excel Workbook properties
		// 2. Merge Excel Columns
		// 3. Setting Excel Cell background color
		// 4. Setting Excel Cell Border
		// 5. Setting Excel Formula
		// 6. Add Comments in Excel Cell
		// 7. Add Image in Excel Sheet
		// 8. Add Custom objects in Excel Sheet
		////////////////////////////////////////////////////////////////////////////////////////////
		private void ExportSampleExcel()
		{
			using (ExcelPackage excelPkg = new ExcelPackage())
			{
				// 1. Setting Excel Workbook Properties
				excelPkg.Workbook.Properties.Author = "Debopam Pal";
				excelPkg.Workbook.Properties.Title = "EPPlus Sample";

				// Creating Excel Worksheet
				ExcelWorksheet oSheet = CreateSheet(excelPkg, "Sample Sheet");

				// Sample DataTable
				DataTable dt = CreateDataTable();

				// 2. Merge Excel Columns: Merging cells and create a center heading for our table
				oSheet.Cells[1, 1].Value = "Sample DataTable Export";
				oSheet.Cells[1, 1, 1, dt.Columns.Count].Merge = true;
				// Setting Font and Alignment for Header
				oSheet.Cells[1, 1, 1, dt.Columns.Count].Style.Font.Bold = true;
				oSheet.Cells[1, 1, 1, dt.Columns.Count].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

				int rowIndex = 2;

				// 3. Setting Excel Cell Backgournd Color during Header Creation
				// 4. Setting Excel Cell Border during Header Creation
				// Creating Header
				CreateHeader(oSheet, ref rowIndex, dt);

				// Putting Data into Cells
				CreateData(oSheet, ref rowIndex, dt);

				// 5. Setting Excel Formula during Footer Creation
				// Creating Footer
				CreateFooter(oSheet, ref rowIndex, dt);

				// 6. Add Comments in Excel Cell
				AddComment(oSheet, 5, 5, "Sample Comment", "Debopam Pal");

				// 7. Add Image in Excel Sheet
				string imagePath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath)), "debopam.jpg");
				AddImage(oSheet, 1, 10, imagePath);

				// 8. Add Custom Objects in Excel Sheet
				AddCustomObject(oSheet, 7, 10, eShapeStyle.Ellipse, "Text inside Ellipse");

				// Writting bytes by bytes in Excel File
				Byte[] content = excelPkg.GetAsByteArray();
				string fileName = "Sample Excel using EPPlus.xlsx";
				string filePath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath)), fileName);
				File.WriteAllBytes(filePath, content);

				// Openning the created excel file using MS Excel Application
				ProcessStartInfo pi = new ProcessStartInfo(filePath);
				Process.Start(pi);
			}
		}

		// Reading a simple excel sheet that contains only text and numbers into DataTable...
		private DataTable WorksheetToDataTable(ExcelWorksheet oSheet)
		{
			int totalRows = oSheet.Dimension.End.Row;
			int totalCols = oSheet.Dimension.End.Column;
			DataTable dt = new DataTable(oSheet.Name);
			DataRow dr = null;
			for (int i = 1; i <= totalRows; i++)
			{
				if (i > 1) dr = dt.Rows.Add();
				for (int j = 1; j <= totalCols; j++)
				{
					if (i == 1)
						dt.Columns.Add(oSheet.Cells[i, j].Value.ToString());
					else
						dr[j - 1] = oSheet.Cells[i, j].Value.ToString();
				}
			}
			return dt;
		}

		// Creating Excel Worksheet
		private ExcelWorksheet CreateSheet(ExcelPackage excelPkg, string sheetName)
		{
			ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets.Add(sheetName);
			// Setting default font for whole sheet
			oSheet.Cells.Style.Font.Name = "Calibri";
			// Setting font size for whole sheet
			oSheet.Cells.Style.Font.Size = 11;
			return oSheet;
		}

		// Creating DataTable with Some Dummy Data
		private DataTable CreateDataTable()
		{
			DataTable dt = new DataTable();
			for (int i = 0; i < 10; i++)
				dt.Columns.Add(i.ToString());
			for (int i = 0; i < 10; i++)
			{
				DataRow dr = dt.Rows.Add();
				foreach (DataColumn dc in dt.Columns)
					dr[dc.ColumnName] = i;
			}

			return dt;
		}

		/// <summary>
		/// Creating formatted header of excel sheet
		/// </summary>
		/// <param name="oSheet">The ExcelWorksheet object</param>
		/// <param name="rowIndex">The row number where the header will put</param>
		/// <param name="dt">The DataTable object from where header values will come</param>
		private void CreateHeader(ExcelWorksheet oSheet, ref int rowIndex, DataTable dt)
		{
			int colIndex = 1;
			foreach (DataColumn dc in dt.Columns)
			{
				var cell = oSheet.Cells[rowIndex, colIndex];

				// Setting the background color of header cells to Gray
				var fill = cell.Style.Fill;
				fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
				fill.BackgroundColor.SetColor(Color.Gray);

				// Setting top/left, right/bottom border of header cells
				var border = cell.Style.Border;
				border.Top.Style = border.Left.Style = border.Bottom.Style = border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

				// Setting value in cell
				cell.Value = "Heading " + dc.ColumnName;

				colIndex++;
			}
		}

		/// <summary>
		/// Putting Data into Excel Cells
		/// </summary>
		/// <param name="oSheet">The ExcelWorksheet object</param>
		/// <param name="rowIndex">The row number from where data will put</param>
		/// <param name="dt">The DataTable object from where data will come</param>
		private void CreateData(ExcelWorksheet oSheet, ref int rowIndex, DataTable dt)
		{
			int colIndex = 0;
			foreach (DataRow dr in dt.Rows)
			{
				colIndex = 1;
				rowIndex++;

				foreach (DataColumn dc in dt.Columns)
				{
					var cell = oSheet.Cells[rowIndex, colIndex];

					// Setting value in the cell
					cell.Value = Convert.ToInt32(dr[dc.ColumnName]);

					// Setting border of the cell
					var border = cell.Style.Border;
					border.Left.Style = border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

					colIndex++;
				}
			}
		}

		/// <summary>
		/// Creating formatted footer in the excel sheet
		/// </summary>
		/// <param name="oSheet">The ExcelWorksheet object</param>
		/// <param name="rowIndex">The row number where the footer will put</param>
		/// <param name="dt">The DataTable object from where footer values will come</param>
		private void CreateFooter(ExcelWorksheet oSheet, ref int rowIndex, DataTable dt)
		{
			int colIndex = 0;
			// Creating Formula in Footer
			foreach (DataColumn dc in dt.Columns)
			{
				colIndex++;
				var cell = oSheet.Cells[rowIndex, colIndex];

				// Setting Sum Formula for each cell
				// Usage: Sum(From_Addres:To_Address)
				// e.g. - Sum(A3:A6) -> Sums the value of Column 'A' From Row 3 to Row 6
				cell.Formula = "Sum(" + oSheet.Cells[3, colIndex].Address + ":" + oSheet.Cells[rowIndex - 1, colIndex].Address + ")";

				// Setting Background Fill color to Gray
				cell.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
				cell.Style.Fill.BackgroundColor.SetColor(Color.Gray);
			}
		}

		/// <summary>
		/// Adding custom comment in specified cell of specified excel sheet
		/// </summary>
		/// <param name="oSheet">The ExcelWorksheet object</param>
		/// <param name="rowIndex">The row number of the cell where comment will put</param>
		/// <param name="colIndex">The column number of the cell where comment will put</param>
		/// <param name="comment">The comment text</param>
		/// <param name="author">The author name</param>
		private void AddComment(ExcelWorksheet oSheet, int rowIndex, int colIndex, string comment, string author)
		{
			// Adding a comment to a Cell
			oSheet.Cells[rowIndex, colIndex].AddComment(comment, author);
		}

		/// <summary>
		/// Adding custom image in spcified cell of specified excel sheet
		/// </summary>
		/// <param name="oSheet">The ExcelWorksheet object</param>
		/// <param name="rowIndex">The row number of the cell where the image will put</param>
		/// <param name="colIndex">The column number of the cell where the image will put</param>
		/// <param name="imagePath">The path of the image file</param>
		private void AddImage(ExcelWorksheet oSheet, int rowIndex, int colIndex, string imagePath)
		{
			Bitmap image = new Bitmap(imagePath);
			ExcelPicture excelImage = null;
			if (image != null)
			{
				excelImage = oSheet.Drawings.AddPicture("Debopam Pal", image);
				excelImage.From.Column = colIndex;
				excelImage.From.Row = rowIndex;
				excelImage.SetSize(100, 100);
				// 2x2 px space for better alignment
				excelImage.From.ColumnOff = Pixel2MTU(2);
				excelImage.From.RowOff = Pixel2MTU(2);
			}
		}

		/// <summary>
		/// Adding custom shape or object in specifed cell of specified excel sheet
		/// </summary>
		/// <param name="oSheet">The ExcelWorksheet object</param>
		/// <param name="rowIndex">The row number of the cell where the object will put</param>
		/// <param name="colIndex">The column number of the cell where the object will put</param>
		/// <param name="shapeStyle">The style of the shape of the object</param>
		/// <param name="text">Text inside the object</param>
		private void AddCustomObject(ExcelWorksheet oSheet, int rowIndex, int colIndex, eShapeStyle shapeStyle, string text)
		{
			ExcelShape excelShape = oSheet.Drawings.AddShape("Custom Object", shapeStyle);
			excelShape.From.Column = colIndex;
			excelShape.From.Row = rowIndex;
			excelShape.SetSize(100, 100);
			// 5x5 px space for better alignment
			excelShape.From.RowOff = Pixel2MTU(5);
			excelShape.From.ColumnOff = Pixel2MTU(5);
			// Adding text into the shape
			excelShape.RichText.Add(text);
		}

		public int Pixel2MTU(int pixels)
		{
			int mtus = pixels * 9525;
			return mtus;
		}
	}
}
