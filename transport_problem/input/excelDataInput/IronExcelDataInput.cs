using System;
using System.Data;
using IronXL;
using transport_problem.input.excelDataInput;
using transport_problem.input.excelDataInput.model;

namespace transport_problem.input
{
    public class IronExcelDataInput: ExcelDataInput {


        ExcelFileReader ExcelDataInput.openFile(string filePath) {
            return new IronExcelFileReader(
                WorkBook.Load(filePath)
            );
        }
    }

    public class IronExcelFileReader : ExcelFileReader
    {
        WorkBook workBook;

        public IronExcelFileReader(WorkBook workBook) {
            this.workBook = workBook;
        }

        public ExcelSheetReader getSheet(int sheetNumber) {
            return new IronExcelSheetReader(
                workBook.WorkSheets[sheetNumber]
            );
        }
    }

    public class IronExcelSheetReader : ExcelSheetReader {
        WorkSheet sheet;
        public IronExcelSheetReader(WorkSheet sheet) {
            this.sheet = sheet;
        }

        public int readInt(CellAddress address)
        {
            return sheet[address.ToString()].IntValue;
        }

        public object readObject(CellAddress address)
        {
            return sheet[address.ToString()].Value;
        }

        public object[,] readRange(CellRange range)
        {
            var excelRange = sheet[range.ToString()].ToDataTable();
            object[,] result = new object[excelRange.Rows.Count, excelRange.Columns.Count];
            for(int i = 0; i < excelRange.Rows.Count; i++) {
                DataRow row = excelRange.Rows[i];
                for(int j = 0; j < excelRange.Columns.Count; j++) {
                    result[i, j] = row[j];
                }
            }
            return result;
        }

        public string readString(CellAddress address)
        {
            return sheet[address.ToString()].StringValue;
        }

    
    }

}
