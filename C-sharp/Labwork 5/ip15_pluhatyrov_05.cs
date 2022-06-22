namespace Labwork_5
{
    class ip15_pluhatyrov_05
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("You are entering values for the double-tier list:");
            DoublyTierList<string> doubleTierList = CaptureDoubleTierList();
            PrintHorizontalRule();

            System.Console.WriteLine("The content of double-tier list:");
            foreach (var data in doubleTierList)
            {
                System.Console.WriteLine(data);
            }
            PrintHorizontalRule();

            int i = 1;
            System.Console.WriteLine("Words on even places of the double-tier list in forward:");
            foreach (string data in doubleTierList)
            {
                if ((i & 1) == 0)
                {
                    Console.WriteLine(data);
                }

                i++;
            }
            PrintHorizontalRule();

            i = doubleTierList.Count;
            System.Console.WriteLine("Words on odd places of the double-tier list in reverse:");
            foreach (string data in doubleTierList.BackEnumerator())
            {
                if ((i & 1) == 1)
                {
                    Console.WriteLine(data);
                }

                i--;
            }
            PrintHorizontalRule();
        }

        static DoublyTierList<string> CaptureDoubleTierList()
        {
            DoublyTierList<string> result = new DoublyTierList<string>();
            bool exceptionIsThrown;

            do
            {
                System.Console.Write("Enter the word: ");
                exceptionIsThrown = false;

                try
                {
                    result.Add(Console.ReadLine());
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    exceptionIsThrown = true;
                }

                if (!exceptionIsThrown)
                {
                    System.Console.WriteLine("Enter <Backspace> to end typing or any key to continue");
                }
            } while (exceptionIsThrown || Console.ReadKey().Key != ConsoleKey.Backspace);

            return result;
        }

        public static void ValidateData(object data)
        {
            if (data is string stringData && stringData == string.Empty)
            {
                throw new ArgumentException("The data isn't provided");
            }
        }

        static void PrintHorizontalRule()
        {
            System.Console.WriteLine(new string('-', 60));
        }
    }    
}