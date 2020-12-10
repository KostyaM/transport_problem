using System;
using transport_problem.model;

namespace transport_problem.domain
{
    public class PolarTransportProblemResolver: ITransportProblem
    {

        ResolvedTable ITransportProblem.calculate(ProblemTable problemTable)
        {
            ResolvedTable resolvedTable = new ResolvedTable(problemTable);
            while(!resolvedTable.isResolved()) {
                CellAddress minAddress = findNextMinimum(problemTable, resolvedTable);
                int usage = Math.Min(
                    resolvedTable.warehouses[minAddress.row].getTotal(),
                    resolvedTable.consumers[minAddress.column].getRequired()
                );
                resolvedTable.consumed[minAddress.row, minAddress.column].setUsage(usage);
                resolvedTable.warehouses[minAddress.row].resolveByValue(usage);
                resolvedTable.consumers[minAddress.column].resolveByValue(usage);
            }
            return resolvedTable;
        }

        private CellAddress findNextMinimum(ProblemTable problemTable, ResolvedTable resolvedTable) {
            double minimum = Double.MaxValue;
            CellAddress minCellAddress = null;
            double[,] prices = problemTable.prices;

            for (int i = 0; i < prices.GetLength(0); i++)
            {
                if (resolvedTable.warehouses[i].getTotal() == 0)
                    continue;

                for (int j = 0; j < prices.GetLength(1); j++)
                {
                    if (resolvedTable.consumers[j].getRequired() == 0)
                        continue;

                    if(minimum > prices[i, j] && resolvedTable.consumed[i, j].getUsage() == 0) {
                        minimum = prices[i, j];
                        minCellAddress = new CellAddress(i, j);
                    }
                }
            }
            if (minCellAddress == null)
                throw new InvalidOperationException("The resolved table is full");
            return minCellAddress;
        }
    }
}
