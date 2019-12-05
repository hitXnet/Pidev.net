using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Windows;
using Microsoft.Office.Interop.Excel;

namespace Web.Models
{
    public class Excel
    {
        string path = "";
        _Excel.Application excel = new _Excel.Application();
        Workbook Workbook;
        Worksheet Worksheet;
        public Excel()
        {

            Workbook = excel.Workbooks.Add();
            Worksheet = Workbook.Worksheets[1];
            Worksheet.Cells[1, 1].value2 = "IdFrais ";
            Worksheet.Cells[1, 2].value2 = "NatureFrais";
            Worksheet.Cells[1, 3].value2 = "Descriptionfrais";
            Worksheet.Cells[1, 4].value2 = "MontantFrais";

        }

        public void saveAs(string path)
        {
            Workbook.SaveAs(path);
        }

        public void close()
        {
            Workbook.Close();
        }

        public void export(IEnumerable<notefraisemploye> timeSheets)
        {
            int j = 0;
            int i = 2;

            Worksheet.Name = "Vos Frais";
            Workbook.Title = "Vos Frais";
            foreach (var ts in timeSheets)
            {
                Worksheet.Cells[i, 1].Value2 = ts.idfraisem;
                Worksheet.Cells[i, 2].Value2 = ts.naturefraisem;
                Worksheet.Cells[i, 3].Value2 = ts.descriptionem;
                Worksheet.Cells[i, 4].Value2 = ts.montantfraisem;
                i++;
            }
            Worksheet.Cells.WrapText = true;
        }
    }
}