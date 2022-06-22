namespace Labwork_6
{
    public class NaryTree
    {
        public Node Root { get; set; } = new Node();
        public List<Node> LeafList { get; } = new List<Node>();
        public List<Node> NodeList { get; } = new List<Node>();
        

        public NaryTree(int data)
        {
            Root = new Node(data, null);
            LeafList.Add(Root);
            NodeList.Add(Root);
        }

        // public int GetNumberOfNodes() 
        // {
        //     int numberOfNodes = 0;

        //     if (Root != null) 
        //     {
        //         numberOfNodes = AuxiliaryGetNumberOfNodes(Root) + 1;
        //     }

        //     return numberOfNodes;
        // }

        // private int AuxiliaryGetNumberOfNodes(Node node) 
        // {
        //     int numberOfNodes = node.GetChildren().Count;

        //     foreach (Node child in node.GetChildren()) 
        //     {
        //         numberOfNodes += AuxiliaryGetNumberOfNodes(child);
        //     }

        //     return numberOfNodes;
        // }

        // public bool Exists(int data)
        // {
        //     return Find(data) != null;
        // }

        // public Node Find(int data)
        // {
        //     Node result = new();

        //     if (Root != null)
        //     {
        //         result = AuxiliaryFind(Root, data);
        //     }

        //     return result;
        // }

        // private Node AuxiliaryFind(Node currentNode, int data)
        // {
        //     Node result = new();
        //     int i = 0;

        //     if (currentNode.Data == data)
        //     {
        //         result = currentNode;
        //     }
        //     else if (currentNode.GetChildren() != null)
        //     {
        //         i = 0;

        //         while (result == null && i < currentNode.GetChildren().Count)
        //         {
        //             result = AuxiliaryFind(currentNode.GetChildAt(i), data);
        //             i++;
        //         }
        //     }

        //     return result;
        // }

        // public List<Node> Build(TreeTraversalOrder traversalOrder)
        // {
        //     List<Node> result = new();

        //     if (Root != null)
        //     {
        //         result = Build(Root, traversalOrder);
        //     }

        //     return result;
        // }

        // public List<Node> Build(Node node, TreeTraversalOrder traversalOrder)
        // {
        //     List<Node> result = new();

        //     if (traversalOrder == TreeTraversalOrder.PreOrder)
        //     {
        //         BuildPreOrder(node, result);
        //     }
        //     else if (traversalOrder == TreeTraversalOrder.PostOrder)
        //     {
        //         BuildPostOrder(node, result);
        //     }

        //     return result;
        // }

        // private void BuildPreOrder(Node node, List<Node> traversalResult)
        // {
        //     traversalResult.Add(node);

        //     foreach (Node child in node.GetChildren())
        //     {
        //         BuildPreOrder(child, traversalResult);
        //     }
        // }

        // private void BuildPostOrder(Node node, List<Node> traversalResult)
        // {
        //     foreach (Node child in node.GetChildren())
        //     {
        //         BuildPostOrder(child, traversalResult);
        //     }

        //     traversalResult.Add(node);
        // }

        public static int GetDepth(Node node)
        {
            if (node == null)
            {
                return 0;
            }
        
            int maxdepth = 0;

            foreach (Node nodeFromList in node.GetChildren())
            {
                maxdepth = Math.Max(maxdepth, GetDepth(nodeFromList));
            }
        
            return maxdepth + 1;
        }

        public int GetLevelNumber(Node node)
        {
            int level = 0;

            while (node.Parent != null)
            {
                node = node.Parent;
                level++;
            }

            return level;
        }

        // public virtual void printLevelOrder()
        // {
        //     int levelNumber = GetLevelNumber(Root);

        //     for (var i = 1; i <= levelNumber; i++)
        //     {
        //         printCurrentLevel(Root, i);
        //     }
        // }

        // public virtual void printCurrentLevel(Node root, int level, int branchNumber = 2)
        // {
        //     if (root == null) 
        //     {
        //         return;
        //     }

        //     if (level > 1)
        //     {
        //         foreach (Node child in root.GetChildren())
        //         {
        //             child.BranchNumber = branchNumber;
        //             branchNumber++;
        //         }
        //     }

        //     if (level > 1) {
                
        //         printCurrentLevel(root.left, level - 1, branchNumber++);
        //         printCurrentLevel(root.right, level - 1);
        //     }
        // }

        public Node AddChildNode(int data, Node parent)
        {
            Node newNode = new Node(data, parent);

            if (parent == null)
            {
                Root = newNode;
            }
            else
            {
                parent.GetChildren().Add(newNode);
            }

            LeafList.Add(newNode);
            LeafList.Remove(newNode.Parent);
            NodeList.Add(newNode);

            return newNode;
        }

        public void RemoveNode(Node nodeToRemove)
        {
            LeafList.Add(nodeToRemove.Parent);
            LeafList.Remove(nodeToRemove);
            NodeList.Remove(nodeToRemove);
            nodeToRemove.Parent.GetChildren().Remove(nodeToRemove);
            nodeToRemove.Parent = null;

            if (nodeToRemove.GetChildren().Count > 0)
            {
                for (var i = 0; i < nodeToRemove.GetChildren().Count; i++)
                {
                    RemoveNode(nodeToRemove.GetChildren()[i]);
                }
            }
        }

        public List<int> TraverseNodes()
        {
            List<int> nodesData = new List<int>();

            foreach (Node node in NodeList)
            {
                nodesData.Add(node.Data);
                System.Console.Write(node.Data + ' ');
            }

            return nodesData;
        }

        public List<int> SumToLeafs(List<Node> leafList)
        {
            List<int> leafSums = null;
            Node root;

            for (var i = 0; i < leafList.Count; i++)
            {
                root = leafList[i];
                dynamic tempValue = root.Data;

                while (root.Parent != null)
                {
                    tempValue += root.Data;
                    root = root.Parent;
                }

                leafSums.Add(tempValue);
            }

            return leafSums;
        }
    }
}