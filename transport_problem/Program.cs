using System;
using transport_problem.dependencies;
using transport_problem.input.excelDataInput;
using transport_problem.input;
using transport_problem.input.excelDataInput.model;
using transport_problem.model;
using transport_problem.domain;
using transport_problem.output.excellOutput;

namespace transport_problem
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ExcelDataInput excelDataReader = DependenciesInject.getIronExcelDataInput();
            ExcelSheetReader sheetReader = excelDataReader.openFile("/home/kocmuk/Downloads/test.xlsx").getSheet(0);


            ProblemTable problemTable = new ProblemTable(
                new double[,] { { 2, 7, 8, 1 }, { 3, 7, 2, 4 }, { 9, 5, 1, 3 } },
                new int[] { 30, 70, 50 },
                new int[] { 60, 40, 20, 30 }
            );
            ITransportProblem problemResolver = new PolarTransportProblemResolver();
            PrettyResult pResult = problemResolver.calculate(problemTable).toPrettyResult();
            ExcelDataOutput dataOutput = new IronExcelDataOutput("/home/kocmuk/Downloads/test.xlsx", 0);
            dataOutput.writeResult(0, pResult, new ClassicOutputTheme());

        }
    }
}
