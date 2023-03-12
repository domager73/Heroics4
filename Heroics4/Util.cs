using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroics4
{
    public static class Util
    {
        public static int InputInt(string msg, int max, int min)
        {
            bool inputReault;
            int number;

            Console.Write(msg);

            do
            {
                inputReault = int.TryParse(Console.ReadLine(), out number);

                if (min > number || number > max)
                {
                    inputReault = false;
                }
            } while (!inputReault);

            return number;
        }

        public static int InputInt(string msg)
        {
            bool inputReault;
            int number;

            Console.Write(msg);

            do
            {
                inputReault = int.TryParse(Console.ReadLine(), out number);
            } while (!inputReault);

            return number;
        }

        public static char InputChar(string msg)
        {
            bool inputReault;
            char chr;

            List<char> list = new List<char>(3) { 'a', 'k', 'g' };

            Console.Write(msg);

            do
            {
                inputReault = char.TryParse(Console.ReadLine(), out chr);

                if (!list.Contains(chr))
                {
                    inputReault = false;
                }
            } while (!inputReault);


            return chr;
        }
    }
}
