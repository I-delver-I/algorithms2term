namespace Labwork_6
{
    public class Node
    {
        private int _data;
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int Data
        {
            get => _data;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The number musn't be less than 1");
                }

                _data = value;
            }
        }
        public Node Parent { get; set; }
        private List<Node> _children = new List<Node>();
        public int BranchNumber { get; set; } = 1;
        


        public Node(int data, Node parent)
        {
            Data = data;
            Parent = parent;
        }

        public Node()
        {
            
        }

        public void AddChild(Node child)
        {
            child.Parent = this;
            _children.Add(child);
        }

        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void AddChildAt(int index, Node child)
        {
            child.Parent = this;
            _children.Insert(index, child);
        }

        public void RemoveChildren()
        {
            _children = new List<Node>();
        }

        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void RemoveChildAt(int index)
        {
            _children.RemoveAt(index);
        }   

        public Node GetChildAt(int index)
        {
            return _children[index];
        }

        public List<Node> GetChildren()
        {
            return _children;
        }

        public override string ToString()
        {
            return $"Data - {Data}";
        }
    }
}