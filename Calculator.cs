using System;
using System.Text;
namespace Calculator
{
    public class Calculator
    {
        public static string Calculate(StringBuilder equation)
        {
            const string operators = "+-*/^%=?><";
            for (int i = 0; i < equation.Length; i++)
            {
                if (!operators.Contains(equation[i]))
                    continue;
                string left = getleft(i, out int leftstart);
                string right = getright(i, out int rightend);
                if (left == "")
                    continue;
                if (right == "")
                    continue;
                switch (equation[i])
                {
                    case '+':
                        {
                            equation.Remove(leftstart, rightend - leftstart);
                            if (double.TryParse(left, out double dleft) && double.TryParse(right, out double dright))
                                equation.Insert(leftstart, dleft + dright);
                            else
                                equation.Insert(leftstart, left + right);
                        }
                        break;
                    case '-':
                        {
                            equation.Remove(leftstart, rightend - leftstart);
                            if (double.TryParse(left, out double dleft) && double.TryParse(right, out double dright))
                                equation.Insert(leftstart, dleft - dright);
                            else
                                equation.Insert(leftstart, "Error");
                        }
                        break;
                    case '*':
                        {
                            equation.Remove(leftstart, rightend - leftstart);
                            if (double.TryParse(left, out double dleft) && double.TryParse(right, out double dright))
                                equation.Insert(leftstart, dleft * dright);
                            else
                                equation.Insert(leftstart, "Error");
                        }
                        break;
                    case '/':
                        {
                            equation.Remove(leftstart, rightend - leftstart);
                            if (double.TryParse(left, out double dleft) && double.TryParse(right, out double dright))
                                equation.Insert(leftstart, dleft / dright);
                            else
                                equation.Insert(leftstart, "Error");
                        }
                        break;
                    case '^':
                        {
                            equation.Remove(leftstart, rightend - leftstart);
                            if (double.TryParse(left, out double dleft) && double.TryParse(right, out double dright))
                                equation.Insert(leftstart, Math.Pow(dleft, dright));
                            else
                                equation.Insert(leftstart, "Error");
                        }
                        break;
                    case '%':
                        {
                            equation.Remove(leftstart, rightend - leftstart);
                            if (double.TryParse(left, out double dleft) && double.TryParse(right, out double dright))
                                equation.Insert(leftstart, dleft % dright);
                            else
                                equation.Insert(leftstart, "Error");
                        }
                        break;
                    case '=':
                        {
                            equation.Remove(leftstart, rightend - leftstart);
                            equation.Insert(leftstart, (left == right) ? 1 : 0);
                        }
                        break;
                    case '>':
                        {
                            equation.Remove(leftstart, rightend - leftstart);
                            if (double.TryParse(left, out double dleft) && double.TryParse(right, out double dright))
                                equation.Insert(leftstart, dleft > dright ? 1 : 0);
                            else
                                equation.Insert(leftstart, left.Length > right.Length ? 1 : 0);
                        }
                        break;
                    case '<':
                        {
                            equation.Remove(leftstart, rightend - leftstart);
                            if (double.TryParse(left, out double dleft) && double.TryParse(right, out double dright))
                                equation.Insert(leftstart, dleft < dright ? 1 : 0);
                            else
                                equation.Insert(leftstart, left.Length < right.Length ? 1 : 0);
                        }
                        break;
                    case '?':
                        {
                            equation.Remove(leftstart, rightend - leftstart);
                            string[] rights = right.Split(':');
                            if (double.TryParse(left, out double dleft))
                                equation.Insert(leftstart, dleft != 0 ? rights[0] : rights[1]);
                            else
                                equation.Insert(leftstart, "Error");
                        }
                        break;
                }
            }

            for (int i = 0; i < equation.Length; i++)
            {
                if (!operators.Contains(equation[i]))
                    continue;
                string left = getleft(i, out int leftstart);
                string right = getright(i, out int rightend);
                if (left == "")
                    continue;
                if (right == "")
                    continue;
                switch (equation[i])
                {
                    case '+':
                        {
                            equation.Remove(leftstart, rightend - leftstart);
                            if (float.TryParse(left, out float fleft) && float.TryParse(right, out float fright))
                                equation.Insert(leftstart, fleft + fright);
                            else
                                equation.Insert(leftstart, left + right);
                        }
                        break;
                    case '-':
                        {
                            equation.Remove(leftstart, rightend - leftstart);
                            if (float.TryParse(left, out float fleft) && float.TryParse(right, out float fright))
                                equation.Insert(leftstart, fleft - fright);
                            else
                                equation.Insert(leftstart, left.Replace(right, ""));
                        }
                        break;
                }
            }



            return equation.ToString();

            string getleft(int i, out int start)
            {
                StringBuilder left = new StringBuilder();

                i--;
                for (; i > -1; i--)
                {
                    if (operators.Contains(equation[i]))
                    {
                        if (equation[i] == '-')
                        {
                            left.Insert(0, '-');
                        }
                        start = i;
                        return left.ToString();
                    }
                    left.Insert(0, equation[i]);
                }
                start = i + 1;
                return left.ToString();
            }

            string getright(int i, out int end)
            {
                StringBuilder right = new StringBuilder();

                i++;
                right.Append(equation[i]);
                i++;
                for (; i < equation.Length; i++)
                {
                    if (operators.Contains(equation[i]))
                    {
                        end = i;
                        return right.ToString();
                    }
                    right.Append(equation[i]);
                }
                end = i;
                return right.ToString();
            }
        }
        private static string ReplaceFirst(string original, string oldValue, string newValue)
        {
            int index = original.IndexOf(oldValue);
            if (index < 0)
                return original;
            return original.Substring(0, index) + newValue + original.Substring(index + oldValue.Length);
        }
    }
}