using System;

namespace Метод_Наименьших_Квадратов
{
    public class laba
    {
        double[] x_yzlu, y_yzlu;
        double[] N1, N3, N6;
        double a = -5, b = 5;
        //double a = 1, b = 3;
        int setka = 50, yzlu = 11, level = 7;
        double[] dy, dy2, dy3, dy4, dy5, dy6;

        public int get_setka()
        {
            return setka;
        }

        public double get_F(double x)
        {
            return Math.Log(x + Math.Sqrt(Math.Pow(x, 2) + 1));
            //return Math.Pow(x,2/3)*Math.Pow(Math.E,-x);
        }

        public double get_a()
        {
            return a;
        }

        public double get_b()
        {
            return b;
        }

        public double get_x(int i)
        {
            return x_yzlu[i];
        }

        public double get_y(int i)
        {
            return y_yzlu[i];
        }

        public double get_P(int size, int i)
        {
            switch (size)
            {
                case 1: return N1[i];
                case 3: return N3[i];
                case 6: return N6[i];
            }
            return 0;
        }

        public void init()
        {
            x_yzlu = new double[yzlu];
            y_yzlu = new double[yzlu];
            dy = new double[level - 1];
            dy2 = new double[level - 2];
            dy3 = new double[level - 3];
            dy4 = new double[level - 4];
            dy5 = new double[level - 5];
            dy6 = new double[level - 6];


            double h = (b - a) / (yzlu - 1);
            x_yzlu[0] = a;
            y_yzlu[0] = get_F(x_yzlu[0]);
            for (int i = 1; i < yzlu; i++)
            {
                x_yzlu[i] = h + x_yzlu[i - 1];
                y_yzlu[i] = get_F(x_yzlu[i]);
            }

            for (int i = 0; i < level - 1; i++)
                dy[i] = y_yzlu[i + 1] - y_yzlu[i];

            for (int i = 0; i < level - 2; i++)
                dy2[i] = dy[i + 1] - dy[i];

            for (int i = 0; i < level - 3; i++)
                dy3[i] = dy2[i + 1] - dy2[i];

            for (int i = 0; i < level - 4; i++)
                dy4[i] = dy3[i + 1] - dy3[i];

            for (int i = 0; i < level - 5; i++)
                dy5[i] = dy4[i + 1] - dy4[i];

            for (int i = 0; i < level - 6; i++)
                dy6[i] = dy5[i + 1] - dy5[i];

            N1_full();
            N3_full();
            N6_full();

        }

        void N1_full()
        {
            N1 = new double[setka];

            double step_x = a, h = (b - a) / setka;

            //вычисление многочлена N1 
            for (int i = 0; i < setka; i++)
            {
                N1[i] = y_yzlu[0] + h * i * dy[0];
            }
        }

        void N3_full()
        {
            N3 = new double[setka];

            double step_x = a, h = (b - a) / setka;

            //вычисление многочлена N3 
            for (int i = 0; i < setka; i++)
            {
                N3[i] = y_yzlu[0] + h * i * dy[0] + ((h * i * (h * i - 1)) / 2.0) * dy2[0] + ((h * i * (h * i - 1) * (h * i - 2)) / 6.0) * dy3[0];
            }
        }

        void N6_full()
        {
            N6 = new double[setka];

            double step_x = a, h = (b - a) / setka;

            //вычисление многочлена N6 
            for (int i = 0; i < setka; i++)
            {
                N6[i] = y_yzlu[0] + h * i * dy[0] + ((h * i * (h * i - 1)) / 2.0) * dy2[0] + ((h * i * (h * i - 1) * (h * i - 2)) / 6.0) * dy3[0] + ((h * i * (h * i - 1) * (h * i - 2) * (h * i - 3)) / 24.0) * dy4[0] + ((h * i * (h * i - 1) * (h * i - 2) * (h * i - 3) * (h * i - 4) / 120.0)) * dy5[0] + ((h * i * (h * i - 1) * (h * i - 2) * (h * i - 3) * (h * i - 4) * (h * i - 5) / 720.0)) * dy6[0];
            }
        }

        public void print_table()
        {
            Console.WriteLine("Начальные узлы");
            Console.WriteLine("      xk             yk");
            for (short i = 0; i < yzlu; i++)
                Console.WriteLine("{0,2}.{1,15:F5}{2,15:F5}", i + 1, x_yzlu[i], y_yzlu[i]);

            double[,] razn_table = new double[level, level];
            for (int i = 0; i < level - 1; i++)
                razn_table[0, i] = dy[i];
            for (int i = 0; i < level - 2; i++)
                razn_table[1, i] = dy2[i];
            for (int i = 0; i < level - 3; i++)
                razn_table[2, i] = dy3[i];
            for (int i = 0; i < level - 4; i++)
                razn_table[3, i] = dy4[i];
            for (int i = 0; i < level - 5; i++)
                razn_table[4, i] = dy5[i];
            for (int i = 0; i < level - 6; i++)
                razn_table[5, i] = dy6[i];

            Console.WriteLine("Таблица Конечных разностей " + Environment.NewLine);
            Console.WriteLine("|   x[i]  |   y[i] |  dy[i] | dy2[i] | dy3[i] | dy4[i] | dy5[i] | dy6[i] |");
            Console.WriteLine("|---------|--------|--------|--------|--------|--------|--------|--------|");
            for (int i = 0; i < level; i++)
            {
                Console.WriteLine("|{0,9:F4}|{1,8:F4}|{2,8:F4}|{3,8:F4}|{4,8:F4}|{5,8:F4}|{6,8:F4}|{7,8:F4}| ", x_yzlu[i], y_yzlu[i], razn_table[0, i], razn_table[1, i], razn_table[2, i], razn_table[3, i], razn_table[4, i], razn_table[5, i]);//1
            }
            Console.WriteLine(Environment.NewLine);

            double step_x = a, h = (b - a) / setka;

            Console.WriteLine("Таблица значений функций и интерполяционых многочленов");
            Console.WriteLine("   xk           yk           N1          N3          N6");
            for (short i = 0; i < setka; i++)
            {
                Console.WriteLine("{0,2}.{1,9:F5}{2,13:F5}{3,12:F5}{4,12:F5}{5,13:F5}", i + 1, step_x, get_F(step_x), N1[i], N3[i], N6[i]);
                step_x = step_x + h;
            }
        }

        public int get_yzlu()
        {
            return yzlu;
        }
    }
}
