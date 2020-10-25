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
            string a1 = sheetReader.readString(new CellAddress("A", 1));
            string b1 = sheetReader.readString(new CellAddress("B", 1));

            DependenciesInject.getDocIOOutput().createNewDocument()
                .writeLine(a1)
                .writeLine(b1)
                .save("/home/kocmuk/Downloads/test.docx")
                .close();
            Console.WriteLine("Done");

        }
    }
}
