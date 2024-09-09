using polymorphism;
using System;
class Program
{
    static void Main(string[] args)
    {
        CustomConverter converter = new CustomConverter();

        string v = "123";
        int intv;
        converter.Convert1(v, out intv);
        Console.WriteLine($"Целое число: {intv}");

        string doublev = "123,45";
        double doubler;
        converter.Convert1(doublev, out doubler);
        Console.WriteLine($"Дабл: {doubler}");

        string fv = "123,5";
        double fr;
        converter.Convert1(fv, out fr);
        Console.WriteLine($"Флоат: {fr}");

        string boolv = "True";
        bool boolr;
        converter.Convert1(boolv, out boolr);
        Console.WriteLine($"Правда или неправда: {boolr}");
    }
}