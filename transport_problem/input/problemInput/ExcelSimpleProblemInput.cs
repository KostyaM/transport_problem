using System;
using transport_problem.exceptions;
using transport_problem.input.excelDataInput;
using transport_problem.input.excelDataInput.model;
using transport_problem.model;

namespace transport_problem.input.problemInput
{
    public class ExcelSimpleProblemInput : IProblemInput
    {
        ExcelDataInput inputSource;

        public ExcelSimpleProblemInput(ExcelDataInput inputSource) {
            this.inputSource = inputSource;
        }

        public ProblemTable getProblemTable()
        { 
            Console.WriteLine("Укажите путь к файлу");
            string filePath = Console.ReadLine();

            Console.WriteLine("Укажите адрес левого верхнего угла таблицы задачи");
            string from = Console.ReadLine();
            Console.WriteLine("Укажите адрес правого нижнего угла таблицы задачи");
            string to = Console.ReadLine();
            object[,] readTable = inputSource.openFile(filePath).getSheet(0).readRange(new CellRange(from, to));

            //Строка на потребителей и как минимум 2 строки на цены, иначе, задача не имеет смысла
            if (readTable.GetLength(0) < 3)
                throw new InvalidTableRangeInput();

            //Столбец на склады и как минимум два столбца на цены, иначе задача смысла не имеет
            if (readTable.GetLength(1) < 3)
                throw new InvalidTableRangeInput();

            double[,] prices = new double[readTable.GetLength(0) - 1, readTable.GetLength(1) - 1];
            int[] warehouses = new int[readTable.GetLength(0) - 1];
            int[] consumers = new int[readTable.GetLength(1) - 1];
            for(int i = 0; i < readTable.GetLength(0); i++) { 
                for(int j = 0; j < readTable.GetLength(1); j++) {
                    // Это правый нижний угол, который пустой
                    if (i == readTable.GetLength(0) - 1 && j == readTable.GetLength(1) - 1)
                        continue;

                    //Столбец складов
                    if (j == readTable.GetLength(1) - 1)
                    {
                        warehouses[i] = Int32.Parse(readTable[i, j].ToString());
                        continue;
                    }

                    // Это ряд потребителей 
                    if (i == readTable.GetLength(0) - 1) 
                    {
                        consumers[j] = Int32.Parse(readTable[i, j].ToString());
                        continue;
                    }
                    prices[i, j] = Double.Parse(readTable[i, j].ToString());
                }
            }

            return new ProblemTable(prices, warehouses, consumers);
        }
    }
}
