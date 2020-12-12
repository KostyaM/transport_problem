using System;
using transport_problem.dependencies;
using transport_problem.input.excelDataInput;
using transport_problem.input;
using transport_problem.input.excelDataInput.model;
using transport_problem.model;
using transport_problem.domain;
using transport_problem.output.excellOutput;
using CellAddress = transport_problem.input.excelDataInput.model.CellAddress;
using transport_problem.input.problemInput;

namespace transport_problem
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            IProblemInput problemInput;
            ITransportProblem problemResolver;

            problemInput = getProblemInput();
            problemResolver = getProblemResolver();


            var problemTable = problemInput.getProblemTable();
            var result = problemResolver.calculate(problemTable).toPrettyResult();

            OutputTheme outputTheme = getOutputTheme();

            ExcelDataOutput output = new IronExcelDataOutput("/home/kocmuk/Downloads/output.xlsx");
            output.writeResult(0, result, outputTheme);           


        }


        private static IProblemInput getProblemInput() {
            Console.WriteLine("Каким способом вы хотите ввести данные? \n Доступные способы: \n \t1 - Через Excel файл\n\t9 - Закрыть программу");
            int inputType = Int32.Parse(Console.ReadLine());
            //На самом деле, тут может быть куча вариантов - главное их реализовать
            switch (inputType)
            {
                case 1:
                    return new ExcelSimpleProblemInput(new IronExcelDataInput());
                case 9:
                    Environment.Exit(0);
                    return null;
                default:
                    Console.WriteLine("Выбрано неизвестное значение. Попробуйте еще");
                    return getProblemInput();
            }
        }

        private static ITransportProblem getProblemResolver()
        {
            Console.WriteLine("Какой метод решения использовать? \n Доступные варианты \n \t1 - Метод поиска минимального значения\n\t9 - Закрыть программу");
            int resolverType = Int32.Parse(Console.ReadLine());
            switch (resolverType)
            {
                case 1:
                    return new PolarTransportProblemResolver();
                case 9:
                    Environment.Exit(0);
                    return null;
                default:
                    Console.WriteLine("Выбрано неизвестное значение. Попробуйте еще");
                    return getProblemResolver();
            }
        }

        private static OutputTheme getOutputTheme()
        {
            Console.WriteLine("Выберите цветовую раскраску таблицы с данными. \n Доступные варианты: \n\t1 - Классическая тема");
            int themeType = Int32.Parse(Console.ReadLine());
            switch(themeType)
            {
                case 1:
                    return new ClassicOutputTheme();
                default:
                    Console.WriteLine("Выбрана неизвестная опция. Применена тема по-умолчанию");
                    return new ClassicOutputTheme();
            }
        }
    }
}
