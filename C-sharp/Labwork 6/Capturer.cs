namespace Labwork_6
{
    public class Capturer
    {
        // public static void CaptureTree(NaryTree tree)
        // {
        //     System.Console.WriteLine("-------You are capturing tree-------");
        //     bool exceptionIsCaught = true;
        //     Node parent = null;

        //     System.Console.Write("Please, enter the data for root: ");
        //     CaptureNode(tree, parent);

        //     do
        //     {
        //         exceptionIsCaught = false;

        //         try
        //         {
        //             CaptureNode(tree, parent);

        //             tree.Add(product);
        //             PrintHorizontalRule();
        //         }
        //         catch (ArgumentException ex)
        //         {
        //             System.Console.WriteLine(ex.Message);
        //             exceptionIsCaught = true;
        //         }
        //         catch (FormatException ex)
        //         {
        //             System.Console.WriteLine(ex.Message);
        //             exceptionIsCaught = true;
        //         }

        //         if (!exceptionIsCaught)
        //         {
        //             System.Console.WriteLine("Press <Backspace> if you want to end typing or any key to continue");
        //         }
        //     } while (exceptionIsCaught || Console.ReadKey().Key != ConsoleKey.Backspace);
        // }

        // private static void CaptureNode(NaryTree tree, Node parent)
        // {
        //     System.Console.WriteLine("You are forming a node:");
        //     bool exceptionIsCaught = true;

        //     do
        //     {
        //         Node node = new();
        //         exceptionIsCaught = false;

        //         try
        //         {
        //             System.Console.Write("Please, enter the data: ");
        //             node.Data = int.Parse(Console.ReadLine());

        //             tree.AddChildNode(node.Data, parent);
        //             tree.
        //             Program.PrintHorizontalRule();
        //         }
        //         catch (ArgumentOutOfRangeException ex)
        //         {
        //             System.Console.WriteLine(ex.Message);
        //             exceptionIsCaught = true;
        //         }
        //         catch (ArgumentException ex)
        //         {
        //             System.Console.WriteLine(ex.Message);
        //             exceptionIsCaught = true;
        //         }
        //         catch (FormatException ex)
        //         {
        //             System.Console.WriteLine(ex.Message);
        //             exceptionIsCaught = true;
        //         }

        //         if (!exceptionIsCaught)
        //         {
        //             System.Console.WriteLine("Press <Backspace> if you want to end typing or any key to continue");
        //         }
        //     } while (exceptionIsCaught || Console.ReadKey().Key != ConsoleKey.Backspace);
        // }
    }
}