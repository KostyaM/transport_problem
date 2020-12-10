using System;
namespace transport_problem.model
{

    public enum CellType
    {
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

    public class PrettyResultCell
    {
        public readonly String value;
        public readonly CellType type;

        public PrettyResultCell(String value, CellType type)
        {
            this.value = value;
            this.type = type;
        }
    }

    public interface OutputTheme
    {
        String getColor(CellType cellType);
    }

    public class CustomOutputTheme : OutputTheme
    {
        String headerColor = "";
        String dataColor = "";
        String errorColor = "";
        String successColor = "";
        String totalColor = "";


        public CustomOutputTheme(
                String headerColor,
                String dataColor,
                String errorColor,
                String successColor,
                String totalColor)
        {
            this.headerColor = headerColor;
            this.dataColor = dataColor;
            this.errorColor = errorColor;
            this.successColor = successColor;
            this.totalColor = totalColor;
        }

        public string getColor(CellType cellType)
        {
            switch (cellType)
            {
                case CellType.HEADER:
                    return headerColor;
                case CellType.DATA:
                    return dataColor;
                case CellType.ERROR:
                    return errorColor;
                case CellType.SUCCESS:
                    return successColor;
                case CellType.TOTAL:
                    return totalColor;

            }
            throw new InvalidOperationException();
        }
    }

    public class ClassicOutputTheme : CustomOutputTheme
    {

        public ClassicOutputTheme() : base("#828282", "#c6c6c6", "#e90046", "#006800", "#006800")
        {
        }
    }
}
