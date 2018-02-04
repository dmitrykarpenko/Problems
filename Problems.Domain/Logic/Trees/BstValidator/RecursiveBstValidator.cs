using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNode = Problems.Domain.Logic.Trees.BstValidator.BstValidatorTreeNode;

namespace Problems.Domain.Logic.Trees.BstValidator
{
    public class RecursiveBstValidator : IBstValidator
    {
        public bool IsValidBST(TreeNode root)
        {
            return IsValidBst(root);
        }

        public static bool IsValidBst(TreeNode current, int? leftBound = null, int? rightBound = null)
        {
            if (current == null)
                return true;
            if (leftBound.HasValue && current.val <= leftBound.Value)
                return false;
            if (rightBound.HasValue && current.val >= rightBound.Value)
                return false;

            return
                IsValidBst(current.left, leftBound, current.val) &&
                IsValidBst(current.right, current.val, rightBound);
        }
    }
}
