using System;
using transport_problem.input.excelDataInput.model;
namespace transport_problem.input.excelDataInput
{
    public interface ExcelDataInput {
        ExcelFileReader openFile(String filePath);
    };

    public interface ExcelFileReader {
        ExcelSheetReader getSheet(int sheetNumber);
    };

    public interface ExcelSheetReader {
        int readInt(CellAddress address);
        String readString(CellAddress address);
        object readObject(CellAddress address);
    };
}
