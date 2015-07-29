namespace Tree
{
    using System.Collections.Generic;

    public class TreeNode<T>
    {
        public TreeNode()
        {
            this.Value = default(T);
            this.Children = new List<TreeNode<T>>();
        }

        public TreeNode(T value)
        {
            this.Value = value;
            this.Children = new List<TreeNode<T>>();
        }

        public TreeNode(T value, IList<TreeNode<T>> children )
        {
            this.Value = value;
            this.Children = children;
        }

        public T Value { get; set; }

        public IList<TreeNode<T>> Children { get; set; }
    }
}
