using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.Strings.LrStringTransformer
{
    public interface ILrStringTransformer
    {
        /// <summary>
        /// https://leetcode.com/problems/swap-adjacent-in-lr-string/description/
        /// 777. Swap Adjacent in LR String
        /// 
        /// In a string composed of 'L', 'R', and 'X' characters, like "RXXLRXRXL",
        /// a move consists of either replacing one occurrence of "XL" with "LX",
        /// or replacing one occurrence of "RX" with "XR".
        /// 
        /// Given the starting string start and the ending string end,
        /// return True if and only if there exists a sequence of moves
        /// to transform one string to the other.
        /// 
        /// Example:
        /// Input: start = "RXXLRXRXL", end = "XRLXXRRLX"
        /// Output: True
        /// Explanation:
        /// We can transform start to end following these steps:
        /// RXXLRXRXL ->
        /// XRXLRXRXL ->
        /// XRLXRXRXL ->
        /// XRLXXRRXL ->
        /// XRLXXRRLX
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        bool CanTransform(string start, string end);
    }
}
