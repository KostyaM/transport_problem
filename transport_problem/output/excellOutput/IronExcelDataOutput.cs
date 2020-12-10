using System;
using IronXL;
using transport_problem.model;

namespace transport_problem.output.excellOutput
{
    public class IronExcelDataOutput : ExcelDataOutput
    {
        WorkBook wb;
        WorkSheet workSheet;

        public IronExcelDataOutput(String filePath, int sheetNumber) {
            wb = WorkBook.Load(filePath);
            workSheet = wb.WorkSheets[sheetNumber];
        }

        public void writeResult(int startRow, PrettyResult prettyResult, OutputTheme theme)
        {
            for(int i = 0; i < prettyResult.resultTable.GetLength(0); i++) { 
                for(int j = 0; j < prettyResult.resultTable.GetLength(1); j++) {
                    PrettyResultCell prettyCell = prettyResult.resultTable[i, j];
                    if (prettyCell != null)
                    {
                        workSheet.SetCellValue(startRow + i, j, prettyCell.value);
                        workSheet.GetCellAt(startRow + i, j).Style.SetBackgroundColor(theme.getColor(prettyResult.resultTable[i, j].type));
                    }
                }
            }
            wb.Save();
        }
    }
}
