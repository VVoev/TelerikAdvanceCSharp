using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Catastrophe
{
    static void Main()
    {
        List<string> methods = new List<string>();
        List<string> loops = new List<string>();
        List<string> conditional = new List<string>();
        string[] matchVariables = { "sbyte", "byte", "short", "ushort", "int",
                                    "uint", "long", "ulong", "float", "double",
                                    "decimal", "bool", "char", "string",
                                    "sbyte?", "byte?", "short?", "ushort?", "int?",
                                    "uint?", "long?", "ulong?", "float?", "double?",
                                    "decimal?", "bool?", "char?", "string?"};

        var matchList = matchVariables.ToList();
        int lengthOfCode = int.Parse(Console.ReadLine());
        int curlyBracketsLoop = 0;
        int curlyBracketsStatement = 0;
        bool methodStatement = false;
        bool conditionalStatement = false;
        bool loopStatement = false;
        string noResult = "None";
        for (int i = 0; i < lengthOfCode; i++)
        {
            string input = Console.ReadLine().TrimStart().TrimEnd();
            int result = CountCurlyBrackets(input);
            if (conditionalStatement)
            {
                curlyBracketsStatement += result;
                if (curlyBracketsStatement <= 0 && curlyBracketsLoop <= 0)
                {
                    SetStatementMethod(out methodStatement, out conditionalStatement, out loopStatement);
                    curlyBracketsStatement = 0;
                    curlyBracketsLoop = 0;
                }
                else if (curlyBracketsStatement < 0)
                {
                    curlyBracketsStatement = 0;
                    SetStatementCondition(out methodStatement, out conditionalStatement, out loopStatement);
                    curlyBracketsLoop += result;
                }
                else if (curlyBracketsStatement == 0 && curlyBracketsLoop > 0)
                {
                    SetStatementLoop(out methodStatement, out conditionalStatement, out loopStatement);
                }
            }
            else if (loopStatement)
            {
                curlyBracketsLoop += result;
                if (curlyBracketsStatement <= 0 && curlyBracketsLoop <= 0)
                {
                    SetStatementMethod(out methodStatement, out conditionalStatement, out loopStatement);
                    curlyBracketsStatement = 0;
                    curlyBracketsLoop = 0;
                }
                else if (curlyBracketsLoop < 0)
                {
                    curlyBracketsLoop = 0;
                    SetStatementLoop(out methodStatement, out conditionalStatement, out loopStatement);
                    curlyBracketsStatement += result;
                }
                else if (curlyBracketsLoop == 0 && curlyBracketsStatement > 0)
                {
                    SetStatementCondition(out methodStatement, out conditionalStatement, out loopStatement);
                }
            }

            // Change statement.
            if (input == string.Empty)
            {
                continue;
            }
            else if (input.StartsWith("static "))
            {
                string bracketInfo = GetStringInRoundBrackets(input);
                AddValues(methods, matchVariables, bracketInfo);
                SetStatementMethod(out methodStatement, out conditionalStatement, out loopStatement);
                continue;
            }
            else if (input.StartsWith("if ") || input.StartsWith("else "))
            {
                string bracketInfo = GetStringInRoundBrackets(input);
                AddValues(conditional, matchVariables, bracketInfo);
                SetStatementCondition(out methodStatement, out conditionalStatement, out loopStatement);
                continue;
            }
            else if (input.StartsWith("for ") || input.StartsWith("foreach ") || input.StartsWith("while "))
            {
                string bracketInfo = GetStringInRoundBrackets(input);
                AddValues(loops, matchVariables, bracketInfo);
                SetStatementLoop(out methodStatement, out conditionalStatement, out loopStatement);
                continue;
            }

            // Search for variables.
            if (methodStatement)
            {
                AddValues(methods, matchVariables, input);
            }
            else if (conditionalStatement)
            {
                AddValues(conditional, matchVariables, input);
            }
            else if (loopStatement)
            {
                AddValues(loops, matchVariables, input);
            }
        }
        PrintResult(methods, loops, conditional, noResult);
        Console.ReadLine();
    }

    static string GetStringInRoundBrackets(string input)
    {
        int openBracketIndex = input.IndexOf('(');
        int closeBracketIndex = input.LastIndexOf(')');
        string bracketInfo = input.Substring(openBracketIndex + 1, closeBracketIndex - openBracketIndex - 1);
        return bracketInfo;
    }

    static void SetStatementMethod(out bool methodStatement, out bool conditionalStatement, out bool loopStatement)
    {
        methodStatement = true;
        conditionalStatement = false;
        loopStatement = false;
    }

    static void SetStatementCondition(out bool methodStatement, out bool conditionalStatement, out bool loopStatement)
    {
        conditionalStatement = true;
        loopStatement = false;
        methodStatement = false;
    }

    static void SetStatementLoop(out bool methodStatement, out bool conditionalStatement, out bool loopStatement)
    {
        loopStatement = true;
        methodStatement = false;
        conditionalStatement = false;
    }

    static int CountCurlyBrackets(string input)
    {
        var open = input.Where(x => x == '{');
        var close = input.Where(x => x == '}');
        int result = open.Count() - close.Count();
        return result;
    }

    static void PrintResult(List<string> methods, List<string> loops, List<string> conditional, string noResult)
    {
        if (methods.Count == 0)
        {
            Console.WriteLine("Methods -> {0}", noResult);
        }
        else
        {
            Console.WriteLine("Methods -> {0} -> {1}", methods.Count, string.Join(", ", methods));
        }
        if (loops.Count == 0)
        {
            Console.WriteLine("Loops -> {0}", noResult);
        }
        else
        {
            Console.WriteLine("Loops -> {0} -> {1}", loops.Count, string.Join(", ", loops));
        }
        if (conditional.Count == 0)
        {
            Console.WriteLine("Conditional Statements -> {0}", noResult);
        }
        else
        {
            Console.WriteLine("Conditional Statements -> {0} -> {1}", conditional.Count, string.Join(", ", conditional));
        }
    }

    static void AddValues(List<string> statement, string[] matchVariables, string bracketInfo)
    {
        var values = bracketInfo.Split(new[] { ' ', }, StringSplitOptions.RemoveEmptyEntries).ToList();
        for (int j = 0; j < values.Count; j++)
        {
            if (matchVariables.Contains(values[j]))
            {
                if (values[j + 1].StartsWith("<") ||
                    values[j + 1].StartsWith("[") ||
                    values[j + 1].StartsWith("(") ||
                    values[j + 1].StartsWith(".") ||
                    values[j + 1].StartsWith(">"))
                {
                    continue;
                }
                else if (values[j + 1] == "?")
                {
                    statement.Add(values[j + 2].TrimEnd(',', '='));
                }
                else
                {
                    string wordVariable = values[j + 1];
                    if (wordVariable.Contains("="))
                    {
                        wordVariable = wordVariable.Substring(0, wordVariable.IndexOf("="));
                    }
                    statement.Add(wordVariable.TrimEnd(','));
                }
            }
        }
    }
}