class Program
{
    private static void Main(string[] args)
    {
        try
        {
            double a, b, c;
            Console.Write("Nhap a: ");
            string s = Console.ReadLine();
            a = double.Parse(s);

            Console.Write("Nhap so b: ");
            s = Console.ReadLine();
            b = double.Parse(s);

            c = a + b;
            Console.WriteLine("{0}  + {1} = {2} ", a, b, c);
        }
        catch (FormatException e) { 
            Console.WriteLine(e.Message);
        }
        
        // Hoc ve Catch try va double.parse
        // co 3 loi xay ra khi xai parse, s = Null ,  s does not .... , NET framework.....
        //

    }
}