using System;
using transport_problem.input.excelDataInput;
using transport_problem.input;
using transport_problem.output.docOutput.docIO;
using transport_problem.output.docOutput;

namespace transport_problem.dependencies
{
    public static class DependenciesInject
    {
        private static IronExcelDataInput excelDataInput = null;
        private static DocIOOutput docIOOutput = null;


        public static ExcelDataInput getIronExcelDataInput() {
            if (excelDataInput == null)
                excelDataInput = new IronExcelDataInput();
            return excelDataInput;
        }

        public static DocOutput getDocIOOutput() {
            if (docIOOutput == null)
                docIOOutput = new DocIOOutput();
            return docIOOutput;
        }
    }
}
