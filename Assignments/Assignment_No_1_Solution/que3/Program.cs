using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalCib;

namespace que3
{
    internal class Program
    {
        private static int choice;

        static void Main(string[] args)
        {
            do
            {

                Maths math = new Maths();
                Console.WriteLine("Choose one of the option below");
                Console.WriteLine("0. Exit ,1.Add , 2. sub, 3. multiply , 4. divide");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("press Enter to exit");
                        Console.ReadLine();
                        break;

                    case 1:
                        Console.WriteLine("adding...");
                        Console.WriteLine("Enter the two numbers to perform operation");
                        int x = Convert.ToInt32(Console.ReadLine());
                        int y = Convert.ToInt32(Console.ReadLine());
                        int sum = math.Add(x, y);
                        Console.WriteLine($"ans is {sum}");
                        break;
                    case 2:
                        Console.WriteLine("subing...");
                        Console.WriteLine("Enter the two numbers to perform operation");
                        //int x = Convert.ToInt32(Console.ReadLine());
                        //int y = Convert.ToInt32(Console.ReadLine());
                        int sub = math.Sub(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine($"ans is {sub}");
                        break;
                    case 3:
                        Console.WriteLine(@"Multi...Enter the two numbers to perform operation");
                        //Console.WriteLine("Enter the two numbers to perform operation");
                        int multi = math.Multiply(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine($"ans is {multi}");
                        break;
                    case 4:
                        Console.WriteLine(@"div...Enter the two numbers to perform operation");
                        //Console.WriteLine("Enter the two numbers to perform operation");
                        int div = math.Div(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine($"ans is {div}");

                        break;
                    default:
                        Console.WriteLine("Invalid choice ");
                        
                        break;
                }
            }while (choice!=0);

        }

    }
}

