using System;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

class Program
{
    static void Main()
    {
        string excelFilePath = "D:\\Nam3\\Semester 5\\SWT\\L1\\Lab1.xlsx";
        Excel.Application excelApp = new Excel.Application();
        Excel.Workbook workbook = excelApp.Workbooks.Open(excelFilePath);

        try
        {
            if (workbook.Sheets.Count >= 1)
            {
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

                int lastRow = worksheet.UsedRange.Rows.Count;

                for (int row = 2; row <= lastRow; row++)
                {
                    object cellValue1 = ((Excel.Range)worksheet.Cells[row, 1]).Value2;
                    object cellValue2 = ((Excel.Range)worksheet.Cells[row, 2]).Value2;
                    Console.WriteLine($"v1 = {cellValue1}, v2 = {cellValue2}");

                    int e = 0;
                    int a = 0;
                    int b = 0;

                    if (cellValue1 != null && cellValue2 != null)
                    {
                        if (int.TryParse(cellValue1.ToString(), out a) && int.TryParse(cellValue2.ToString(), out b))
                        {
                            Console.WriteLine($"a = {a}, b = {b}");

                            // Thực hiện phép toán
                            int x = 0;
                            for (int i = 0; i < 10000; i++)
                            {
                                for (int j = 0; j < 10000; j++)
                                {
                                    x = x + a + b;
                                }
                            }
                            Console.WriteLine($"x = {x}");

                            worksheet.Cells[row, 3].Value = x;
                        }
                        else
                        {
                            Console.WriteLine("Invalid int value - special sign");
                            worksheet.Cells[row, 3].Value = "Invalid int value - special sign";
                        }
                    }
                    else
                    {
                        Console.WriteLine("Blank");
                        worksheet.Cells[row, 3].Value = "Invalid int value - Blank";
                    }
                }
            }
            else
            {
                Console.WriteLine("Workbook không có sheets.");
            }
        }
        finally
        {
            workbook.Save();
            workbook.Close();
            excelApp.Quit();

            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);
        }

        Console.WriteLine("Xử lý thành công.");
    }
}
