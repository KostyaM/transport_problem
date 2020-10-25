using System;
namespace transport_problem.input.excelDataInput.model
{
    public class CellAddress
    {
        public String column;
        public int row;

        public CellAddress(String column, int row) {
            this.column = column;
            this.row = row;
        }

        public String toString() {
            return $"{column}{row}";
        }
    }
}
