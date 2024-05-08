namespace LambdaDelegat
{
    internal class Program
    {

        public delegate void DelegateDelegate(int a, int b);

        private static void Sum(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        private static void Min(int a, int b)
        {
            Console.WriteLine(a - b);
        }

        private static void Mul(int a, int b)
        {
            Console.WriteLine(a * b);
        }


        private static bool jeSudy(int a)
        {
            return a % 2 == 0;
        }

        static void Main(string[] args)
        {
            // nastaveni metod do promenne delegatu
            DelegateDelegate delSum = Sum ;
            delSum(3, 2);
            DelegateDelegate delMin = Min ;
            delMin(3, 1);


            // multicast - kombinace delegatu stejnych parametru
            // pusti se postupne podle serazeni
            DelegateDelegate del2 = delSum + delMin;
            try
            {
                del2.Invoke(5, 1);
                del2 = del2 - delMin;
            } 
            catch(Exception e)
            {
                Console.WriteLine(e);
            }


            // FUNC<>
            // hodne vstupu, 1 vystup
            Func<int, bool> func = jeSudy;
            Console.WriteLine("Func jeSudy: "+func.Invoke(4));

            // ACTION
            // 16 param, jen vstup, nevreati hodnotu
            Action<int, int> action = Sum;
            Console.Write("Action ");
            action(3, 2);

            // PREDICATE
            // vraci hodnotu true nebo false, prijma 1 pram
            Predicate<string> isLongEnough = delegate (string s)
            {
                return s.Length == 10 ? true : false;
            };

            Console.WriteLine("Predicate String is long enoigh: "+isLongEnough("Hello World"));


            // Anonymni metoda
            // metody bez hlavicky, bez nazvu
            // stejny jako normalni metoda, prijma vstupni parram
            // vytvorit pomoci klicoveho slova delegate
            // priklad

            DelegateDelegate anonymni = delegate (int a, int b) { Console.WriteLine(a / b); };
            anonymni(5, 5);

            //Lambda fkce
            //Lambda operator => hlavni cast cele lambda funkce

            Func<int, int, int> soucet = (int a, int b) => a + b;
            Action<string> vypis = msg => Console.WriteLine(msg);
            Predicate<string> check = s => s.Length == 10;

            Console.WriteLine(soucet(10, 14));
            vypis("asdf");
            Console.WriteLine(check("asdfsdfgfg"));
        }
    }
}