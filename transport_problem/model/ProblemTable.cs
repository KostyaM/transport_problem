using System;
using transport_problem.exceptions;
namespace transport_problem.model
{
    public class ProblemTable
    {
        readonly public double[,] prices;
        readonly public int[] warehouses;
        readonly public int[] consumers;

        public ProblemTable (
                double[,] prices,
                int[] warehouses,
                int[] consumer
            )
        {
            if (prices.Length == 0)
                throw new MalformedProblemTableException("Пустая ценовая таблица");
            if (prices.GetLength(0) != warehouses.Length)
                throw new MalformedProblemTableException("Количество \"складов\" и размеры ценовой таблицы не совпадают");

            int consumerLength = prices.GetLength(1);
            if (consumerLength == 0)
                throw new MalformedProblemTableException("Пустая ценновая таблица");

            if (prices.GetLength(1) != consumerLength)
                throw new MalformedProblemTableException("Количество \"потребителей\" и размеры ценовой таблицы не совпадают");

            this.prices = prices;
            this.warehouses = warehouses;
            this.consumers = consumer;
        }
    }
}
