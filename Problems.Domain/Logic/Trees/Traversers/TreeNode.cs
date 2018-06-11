using Problems.Domain.Logic.Trees.Base;

namespace Problems.Domain.Logic.Trees.Traversers
{
    public class TreeNode : IBinaryTreeNode<int>
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }

        public int Value { get => val; set => val = value; }
        public IBinaryTreeNode<int> Left { get => left; set => left = (TreeNode)value; }
        public IBinaryTreeNode<int> Right { get => right; set => right = (TreeNode)value; }
    }
}
