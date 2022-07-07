using System;


namespace Chords
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите многочлен P:");
                Console.Write("Введите степень n многочлена P - целое число: ");
                int nP = Convert.ToInt32(Console.ReadLine());
                nP++; // Количество коэффициентов
                int[] arrP = new int[nP];
                for (int i = 0; i < nP; ++i)
                {
                    Console.Write($"Введите коэффициент перед x^{nP - i - 1} - int число: ");
                    arrP[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.Write("Введите значение левой границы промежутка - десятичная дробь: ");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите значение правой границы промежутка - десятичная дробь: ");
                double b = Convert.ToDouble(Console.ReadLine());
                if (a > b)
                {
                    Console.Write("Значение правой границы дожно быть больше");
                    return;
                }
                Console.WriteLine("Введите погрешность - десятичная дробь: ");
                double e = Convert.ToDouble(Console.ReadLine());

                Equation equation = new Equation(nP, a, b, e, arrP);
                double x = chords_method(equation);
                Console.WriteLine("Решение");
                Console.WriteLine(x);
                Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.Write("Введите число в правильном формате");
            }
        }

        public static double chords_method(Equation equation)
        {
            double x = 0; // то, что ищем
            do
            {
                x = equation.a - Gorner(equation.nP, equation.a, equation.arrP) * (equation.b - equation.a) /
                    (Gorner(equation.nP, equation.b, equation.arrP) - Gorner(equation.nP, equation.a, equation.arrP));
                x = Math.Round(x, 4);
                if (Gorner(equation.nP, x, equation.arrP) == 0)
                    return x;
                if ((Gorner(equation.nP, x, equation.arrP) * (Gorner(equation.nP, equation.b, equation.arrP)) > 0))
                    equation.b = x;
                else
                    equation.a = x;

            } while (Math.Abs(x - equation.b) > equation.e);
            return x;
        }

        private static double Gorner(int n, double x, int[] arr)
        {
            double s = arr[0];
            for (int i = 1; i < n; ++i)
                s = s * x + arr[i];
            s = Math.Round(s, 4);
            return s;
        }
    }
}