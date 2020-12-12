using System;
namespace transport_problem.input.excelDataInput.model
{
    public class CellRange
    {
        private String from, to;

        public CellRange(CellAddress from, CellAddress to)
        {
            this.from = from.ToString();
            this.to = to.ToString();
        }

        public CellRange(String from, String to)
        {
            this.from = from;
            this.to = to;
        }


        override public String ToString()
        {
            return $"{from}:{to}";
        }
    }
}
