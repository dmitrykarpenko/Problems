using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Logic.NaturalNumbers.BinaryOperatorsAdder
{
    public class GfgBinaryOperatorsAdder : IBinaryOperatorsAdder
    {
        public IList<string> AddOperators(string input, int target)
        {
            _input = input;
            _target = target; // target could also be long (as _target)
            _results = new List<string>();

            AddExpressions("", 0, 0, 0);

            return _results;
        }

        private string _input;
        private long _target;

        /// <summary> expressions that match to target </summary>
        private List<string> _results;

        /// <summary>
        /// Recursive, fills the _results collection
        /// </summary>
        /// <param name="currentExpression">
        /// the expression to become a result candidate
        /// after current set of operations
        /// is recursively inserted to it
        /// </param>
        /// <param name="pos">
        /// Ferst index of the current number to make the next operation with
        /// </param>
        /// <param name="currentValue"> calculated value of currentExpression </param>
        /// <param name="last"> last summand </param>
        private void AddExpressions(
            string currentExpression,
            int pos,
            long currentValue, long last)
        {
            // true if whole input is processed with some
            // operators
            if (pos == _input.Length)
            {
                // if current value is equal to target
                //  then only add to final solution
                // if the question was to find all possible operations
                //  then would just add without condition
                if (currentValue == _target)
                    _results.Add(currentExpression);

                return;
            }

            // loop to put operator at all positions
            for (int i = pos; i < _input.Length; i++)
            {
                // ignoring case which start with 0 as they
                // are useless for evaluation
                if (i != pos && _input[pos] == '0')
                    break;

                // take part of _input from pos to i
                string part = _input.Substring(pos, i + 1 - pos);

                // take numeric value of part
                long current = long.Parse(part);

                if (pos == 0)
                {
                    // if pos is 0 then just send numeric value
                    // for next recurion
                    AddExpressions(currentExpression + part,
                        i + 1,
                        current, current);
                }
                else
                {
                    // next last summand
                    long nextLast;

                    // try all given binary operator for evaluation

                    nextLast = current;
                    AddExpressions(
                        currentExpression + "+" + part,
                        i + 1,
                        currentValue + nextLast, nextLast);

                    nextLast = -current;
                    AddExpressions(
                        currentExpression + "-" + part,
                        i + 1,
                        currentValue + nextLast, nextLast);

                    nextLast = last * current;
                    AddExpressions(
                        currentExpression + "*" + part,
                        i + 1,
                        currentValue - last + nextLast, nextLast);
                }
            }
        }
    }
}
