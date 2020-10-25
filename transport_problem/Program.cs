using System;
using transport_problem.dependencies;
using transport_problem.input.excelDataInput;
using transport_problem.input;
using transport_problem.input.excelDataInput.model;

namespace transport_problem
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ExcelDataInput excelDataReader = DependenciesInject.getIronExcelDataInput();
            ExcelSheetReader sheetReader = excelDataReader.openFile("/home/kocmuk/Downloads/test.xlsx").getSheet(0);
            String a1 = sheetReader.readString(new CellAddress("A", 1));
            String b1 = sheetReader.readString(new CellAddress("B", 1));
            Console.WriteLine($"TEsting excel reading. A1: \"{a1}\" B1: \"{b1}\"");
        }
    }
}
