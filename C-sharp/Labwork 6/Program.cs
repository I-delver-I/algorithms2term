using System.Linq;

namespace Labwork_6
{
    class Program
    {
        public static void Main(string[] args)
        {
            NaryTree boom = new NaryTree(5);
            Node node21 = boom.AddChildNode(4, boom.Root);
            Node node22 = boom.AddChildNode(1, boom.Root);
            Node node31 = boom.AddChildNode(45, node21);
            Node node32 = boom.AddChildNode(99, node21);
            Node node33 = boom.AddChildNode(100, node21);
            Node node34 = boom.AddChildNode(369, node21);

            List<Node> connectingVertices = boom.NodeList.Except(boom.LeafList).ToList();
            System.Console.WriteLine($"The count of connecting vertices is: {connectingVertices.Count}");

            System.Console.WriteLine("Nodes of tree:");
            boom.TraverseNodes();
        }

        static void PrintNodes(List<Node> nodes)
        {
            foreach (Node node in nodes)
            {
                System.Console.WriteLine(node);
            }
        }

        public static void PrintHorizontalRule()
        {
            System.Console.WriteLine(new string('-', 70));
        }

        private void PrintNaryTree(Node root)
        {
            if (root == null)
            {
                return;
            }

            Queue<Node> nodesQueue = new Queue<Node>();
            nodesQueue.Enqueue(root);

            while(nodesQueue.Count != 0) 
            {
                int len = nodesQueue.Count;

                for(int i = 0; i < len; i++) 
                {
                    Node node = nodesQueue.Dequeue();

                    if (node != null)
                    {
                        System.Console.WriteLine(root.Data + " ");
                    
                        foreach (Node treeNode in root.GetChildren()) 
                        {
                            nodesQueue.Enqueue(treeNode);
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("The node musn't be have null value");
                        return;
                    }
                    
                    
                }
                
                System.Console.WriteLine();
            }
        }
    }
}
