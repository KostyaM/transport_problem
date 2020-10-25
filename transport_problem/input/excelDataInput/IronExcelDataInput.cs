using System;
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
            return sheet[address.toString()].IntValue;
        }

        public object readObject(CellAddress address)
        {
            return sheet[address.toString()].Value;
        }

        public string readString(CellAddress address)
        {
            return sheet[address.toString()].StringValue;
        }
    }

}
