﻿using System;
using transport_problem.exceptions;

namespace transport_problem.model
{
    public class ResolvedTable
    {
        ResolvedDataSell[,] consumed;
        readonly ResolvedConsumer[] consumers;
        readonly ResolvedWarehouse[] warehouses;

        /*
        public ResolvedTable(int[] consumers, int[] warehouses)
        {
            consumed = new int[warehouses.Length, consumers.Length];
            this.consumers = new ResolvedConsumer[consumers.Length];
            for (int i = 0; i < this.consumers.Length; i++)
                this.consumers[i] = new ResolvedConsumer(consumers[i]);
            this.warehouses = new ResolvedWarehouse[warehouses.Length];
            for (int i = 0; i < this.warehouses.Length; i++)
                this.warehouses[i] = new ResolvedWarehouse(warehouses[i]);
        }*/

        public ResolvedTable(ProblemTable problemTable) {

            consumed = new ResolvedDataSell[problemTable.prices.GetLength(0), problemTable.prices.GetLength(1)];
            for(int i = 0; i < problemTable.prices.GetLength(0); i++) { 
                for(int j = 0; j < problemTable.prices.GetLength(1); j ++) {
                    consumed[i, j] = new ResolvedDataSell(problemTable.prices[i, j]);
                }
            }
            this.consumers = new ResolvedConsumer[problemTable.consumers.Length];
            for (int i = 0; i < consumers.Length; i++)
                this.consumers[i] = new ResolvedConsumer(problemTable.consumers[i]);
            this.warehouses = new ResolvedWarehouse[problemTable.warehouses.Length];
            for (int i = 0; i < warehouses.Length; i++)
                this.warehouses[i] = new ResolvedWarehouse(problemTable.warehouses[i]);
        }

        /*
         * this.warehouses.Length + 4 - 
         * 1 строка на шапку, 
         * 1 строка на результат, 
         * 1 строка на сообщение об ошибке, если таковое имеется, 
         * 1 строка на конечную стоимость
         * 
         * this.consumers.Length + 2
         * 1 строка на шапку
         * 1 строка на результат
        */
        public PrettyResult toPrettyResult() {
            PrettyResultCell[,] resultTable = new PrettyResultCell[this.warehouses.Length + 4, this.consumers.Length + 2];
            //Рисуем легенду и результаты
            for (int i = 1; i < resultTable.GetLength(1) - 2; i++) {
                resultTable[0, i] = new PrettyResultCell($"Потребитель {i}", SellType.HEADER);
                ResolvedConsumer consumer = consumers[i - 1];
                SellType consumerSellType = SellType.SUCCESS;
                if (!consumer.isSatisfied())
                    consumerSellType = SellType.ERROR;
                resultTable[resultTable.GetLength(0) - 3, i] = new PrettyResultCell($"{consumer.getDelivered()} / {consumer.getRequired()}", consumerSellType);
            }


            for(int i = 1; i < resultTable.GetLength(0) - 3; i++) {
                resultTable[i, 0] = new PrettyResultCell($"Склад {i}", SellType.HEADER);
                ResolvedWarehouse warehouse = warehouses[i - 1];
                resultTable[i, resultTable.GetLength(1) - 1] = new PrettyResultCell($"{warehouse.getUsed()} / {warehouse.getTotal()}", SellType.HEADER);
            }

            //Заполняем данные
            double sum = 0;
            for (int i = 1; i < resultTable.GetLength(0) - 3; i++) { 
                for(int j = 1; j < resultTable.GetLength(1) - 2; j++) {
                    resultTable[i, j] = new PrettyResultCell($"{consumed[i - 1, j - 1].getUsage()} / {consumed[i - 1, j - 1].getPrice()}", SellType.DATA);
                    sum += consumed[i - 1, j - 1].getUsagePrice();
                }
            }

            //Указываем общую стоимость 
            resultTable[resultTable.GetLength(0) - 1, 0] = new PrettyResultCell("ИТОГО: ", SellType.TOTAL);
            resultTable[resultTable.GetLength(0) - 1, 1] = new PrettyResultCell($"{sum}", SellType.TOTAL);

            return new PrettyResult(resultTable);

        }
    }

    public class ResolvedConsumer {
        private int required;
        private int delivered = 0;

        public ResolvedConsumer(int required) {
            this.required = required;
        }

        public void setRequired(int required) {
            if (required < 0)
                throw new InvalidValueSpecified();
            this.required = required;
        }

        public int getRequired() {
            return required;
        }

        public int getDelivered() {
            return this.delivered;
        }

        public void resolveByValue(int value) {
            this.required -= value;
            if (required < 0)
                throw new InternalCalculationError();
            this.delivered += value;
        }

        public bool isSatisfied() {
            return required == 0;
        }
    }

    public class ResolvedWarehouse {
        private int total;
        private int used = 0;

        public ResolvedWarehouse(int total) {
            this.total = total;
        }

        public int getTotal() {
            return total;
        }

        public int getUsed() {
            return this.used;
        }

        public void setTotal(int total) {
            if (total < 0)
                throw new InvalidValueSpecified();
            this.total = total;
        }

        public void resolveByValue(int value) {
            this.total -= value;
            if (total < 0)
                throw new InternalCalculationError();
            this.used += value;
        }
    }

    public class ResolvedDataSell {
        private readonly double price;
        private int usage = 0;

        public ResolvedDataSell(double price) {
            this.price = price;
        }

        public double getPrice() {
            return price;
        }

        public int getUsage() {
            return usage;
        }

        public void setUsage(int value)
        {
            if (usage != 0)
                throw new InternalCalculationError();
            this.usage = value;
        }

        public double getUsagePrice() {
            return price * usage;
        }
    }
}
