using System;
namespace transport_problem.model
{

    public enum SellType { 
        HEADER,
        DATA,
        ERROR,
        SUCCESS,
        TOTAL
    }

    public class PrettyResult
    {
        public PrettyResultCell[,] resultTable;

        public PrettyResult(PrettyResultCell[,] resultTable)
        {
            this.resultTable = resultTable;
        }
    }

    public class PrettyResultCell {
        readonly String value;
        readonly SellType type;

        public PrettyResultCell(String value, SellType type) {
            this.value = value;
            this.type = type;
        }
    }
}
