// namespace Labwork_6
// {
//     public class Tree
//     {
//         public Node Root { get; set; }
 
//         public void Add(int number)
//         {
//             Node previous = new();
//             Node next = Root;
    
//             while (next != null)
//             {
//                 previous = next;

//                 if (number < next.Data)
//                 {
//                     next = next.LeftNode; 
//                 }
//                 else if (number >= next.Data)
//                 {
//                     next = next.RightNode;
//                 }
//             }
    
//             Node newNode = new(number);
    
//             if (Root == null)
//             {
//                 Root = newNode;
//             }
//             else
//             {
//                 if (number.Price < previous.Data.Price)
//                 {
//                     previous.LeftNode = newNode;
//                 }
//                 else
//                 {
//                     previous.RightNode = newNode;
//                 }
//             }
//         }
 
//         public Node Find(decimal price)
//         {
//             return Find(price, Root);            
//         }
    
//         public void Remove(int value)
//         {
//             Root = Remove(Root, value);
//         }
    
//         private Node Remove(Node parent, decimal price)
//         {
//             if (parent == null)
//             {
//                 return parent;
//             }
    
//             if (price < parent.Data.Price)
//             {
//                 parent.LeftNode = Remove(parent.LeftNode, price);
//             }
//             else if (price > parent.Data.Price)
//             {
//                 parent.RightNode = Remove(parent.RightNode, price);
//             }
    
//             else
//             {
//                 if (parent.LeftNode == null)
//                 {
//                     return parent.RightNode;
//                 }
//                 else if (parent.RightNode == null)
//                 {
//                     return parent.LeftNode;
//                 }
    
//                 parent.Data.Price = GetMinValue(parent.RightNode);
//                 parent.RightNode = Remove(parent.RightNode, parent.Data.Price);
//             }
    
//             return parent;
//         }
    
//         private decimal GetMinValue(Node node)
//         {
//             decimal minPrice = node.Data.Price;
    
//             while (node.LeftNode != null)
//             {
//                 minPrice = node.LeftNode.Data.Price;
//                 node = node.LeftNode;
//             }
    
//             return minPrice;
//         }
    
//         private Node Find(decimal price, Node parent)
//         {
//             if (parent != null)
//             {
//                 if (price == parent.Data.Price)
//                 {
//                     return parent;
//                 }
//                 else if (price < parent.Data.Price)
//                 {
//                     return Find(price, parent.LeftNode);
//                 }
//                 else
//                 {
//                     return Find(price, parent.RightNode);
//                 }
//             }
    
//             return null;
//         }
    
//         public int GetTreeDepth()
//         {
//             return GetTreeDepth(Root);
//         }
    
//         private int GetTreeDepth(Node parent)
//         {
//             return (parent == null) ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), 
//                 GetTreeDepth(parent.RightNode)) + 1;
//         }

//         public decimal GetTotalPrice(Node parent)
//         {
//             decimal totalPrice = parent.Data.GetTotalPrice();

//             if (parent.LeftNode != null)
//             {
//                 totalPrice += GetTotalPrice(parent.LeftNode);
//             }

//             if (parent.RightNode != null)
//             {
//                 totalPrice += GetTotalPrice(parent.RightNode);
//             }

//             return totalPrice;
//         }
    
//         public void TraversePreOrder(Node parent)
//         {
//             if (parent != null)
//             {
//                 Console.WriteLine(parent.Data);
//                 TraversePreOrder(parent.LeftNode);
//                 TraversePreOrder(parent.RightNode);
//             }
//         }
    
//         public void TraverseInOrder(Node parent)
//         {
//             if (parent != null)
//             {
//                 TraverseInOrder(parent.LeftNode);
//                 Console.WriteLine(parent.Data);
//                 TraverseInOrder(parent.RightNode);
//             }
//         }
    
//         public void TraversePostOrder(Node parent)
//         {
//             if (parent != null)
//             {
//                 TraversePostOrder(parent.LeftNode);
//                 TraversePostOrder(parent.RightNode);
//                 Console.WriteLine(parent.Data);
//             }
//         }
//     }
// }