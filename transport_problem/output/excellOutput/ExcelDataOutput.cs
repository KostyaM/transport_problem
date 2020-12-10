using System;
using transport_problem.model;

namespace transport_problem.output.excellOutput
{
    public interface ExcelDataOutput
    {
        void writeResult(int startRow, PrettyResult prettyResult, OutputTheme theme);
    }
}
