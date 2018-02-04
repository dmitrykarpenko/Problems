using Problems.Domain.Logic.Trees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Trees.BstValidator
{
    public class BstValidatorTreeNode
    {
        public BstValidatorTreeNode()
        {
        }
        public BstValidatorTreeNode(int x)
        {
            val = x;
        }
        public int val { get; set; }
        public BstValidatorTreeNode left { get; set; }
        public BstValidatorTreeNode right { get; set; }
    }
}
