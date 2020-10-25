using System;
using transport_problem.input.excelDataInput;
using transport_problem.input;
namespace transport_problem.dependencies
{
    public static class DependenciesInject
    {
        private static IronExcelDataInput excelDataInput = null;


        public static ExcelDataInput getIronExcelDataInput() {
            if (excelDataInput == null)
                excelDataInput = new IronExcelDataInput();
            return excelDataInput;
        }
    }
}
