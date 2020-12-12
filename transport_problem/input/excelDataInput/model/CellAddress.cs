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

        override public String ToString()
        {
            return $"{column}{row}";
        }
    }
}
