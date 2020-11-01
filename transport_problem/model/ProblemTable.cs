using System;
using transport_problem.exceptions;
namespace transport_problem.model
{
    public class ProblemTable
    {
        readonly public int[,] prices;
        readonly public int[] warehouses;
        readonly public int[] consumers;

        public ProblemTable (
                int[,] prices,
                int[] warehouses,
                int[] consumer
            )
        {
            if (prices.Length == 0)
                throw new MalformedProblemTableException("Пустая ценовая таблица");
            if (prices.Length != warehouses.Length)
                throw new MalformedProblemTableException("Количество \"складов\" и размеры ценовой таблицы не совпадают");

            int consumerLength = prices[0].Length;
            if (consumerLength == 0)
                throw new MalformedProblemTableException("Пустая ценновая таблица");

            foreach (int[] priceRow in prices) {
                if (priceRow.Length != consumerLength)
                    throw new MalformedProblemTableException("Введенные ценовые данные не являются таблицей");
            }

            if (prices.Length != consumerLength)
                throw new MalformedProblemTableException("Количество \"потребителей\" и размеры ценовой таблицы не совпадают");

            this.prices = prices;
            this.warehouses = warehouses;
            this.consumers = consumer;
        }
    }
}
