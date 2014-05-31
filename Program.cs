using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Метод_Наименьших_Квадратов
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Численные Методы Лаба 2 Вариант 1 Номер в бригаде 1 ");
            laba lab = new laba();
            lab.init();
            //lab.fromFile();
            lab.print_table();
            GraphicShower form1 = new GraphicShower(lab);
            form1.ShowDialog();
            Console.ReadLine();
            

            //Console.WriteLine("Численные Методы Лаба 1 Вариант 1 Номер в бригаде 1 ");
            //laba obj = new laba();
            //obj.print_table();
            //GraphicShower form1 = new GraphicShower(obj);
            //form1.ShowDialog();
            //Console.ReadLine();
        }
    }
}
