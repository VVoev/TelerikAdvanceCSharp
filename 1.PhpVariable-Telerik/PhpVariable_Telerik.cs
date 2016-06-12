using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PhpVariable_Telerik
{
    public static string ReadInput()
    {
        string currentline = Console.ReadLine();
        StringBuilder phpcode = new StringBuilder();
        while (currentline != "?>")
        {
            phpcode.Append(currentline);
            currentline = Console.ReadLine().Trim();
        }
        return  phpcode.ToString();
    }
    public static void ExtractWords(string InputCode)
    {
        HashSet<string> allvariable = new HashSet<string>();
        bool inOneLineCode = false;
        bool multiLineCode = false;
        bool InsingleQuoteString = false;
        bool inDoubleQuoteString = false;
        bool InVariable = false;
        StringBuilder currentvariable = new StringBuilder();
        for (int i = 0; i < InputCode.Length; i++)
        {
            char currentSymbol = InputCode[i];
            //we are in oneline comment
            if (inOneLineCode)
            {
                if (currentSymbol == '\n')
                {
                    //one line comment end here 
                    inOneLineCode = false;
                    continue;
                }
                else
                {
                    // we are still in one line coment
                    continue;
                }
            }
            //we are in multiline cooment
            if (multiLineCode)
            {
                if (currentSymbol == '*'
                  && i + 1 < InputCode.Length
                  && InputCode[i + 1] == '/')
                {
                    multiLineCode = false;
                    i++; //next symbol is checked we do not needed it
                    continue;
                }
                else
                {
                    continue;
                }
            }
            if (InVariable)
            {
                if (IsvalidVariableSymbol(currentSymbol))
                {
                    currentvariable.Append(currentSymbol);
                    continue;
                }
                else
                {
                    if (currentvariable.Length > 0)
                    {
                        allvariable.Add(currentvariable.ToString());

                    }
                    currentvariable.Clear();
                    InVariable = false;
                    continue;
                }
            }
            if(InsingleQuoteString)
            {
                if(currentSymbol=='\'')
                {
                    InsingleQuoteString = false;
                    continue;
                }
                else
                {
                    continue;
                }
            }
            if(inDoubleQuoteString)
            {
                if (currentSymbol == '\'')
                {
                    InsingleQuoteString = false;
                    continue;
                }
                else
                {
                    continue;
                }
            }
            if(!InsingleQuoteString && !inDoubleQuoteString)
            {
                if(currentSymbol=='#')
                {
                    inOneLineCode = true;
                    continue;
                }
                if(currentSymbol=='/' 
                    && i+1<InputCode.Length 
                    && InputCode[i+1]=='/')
                {
                    inOneLineCode = true;
                    i++;
                    continue;
                }
                if(currentSymbol=='/'
                    && i+1<InputCode.Length
                    && InputCode[i+1]=='*')
                {
                    multiLineCode = true;
                    i++;
                    continue;
                }
            }
            else
            {
                if(currentSymbol=='\\')
                {
                    i++;
                    continue;
                }

            }


        }
    }
    public static bool IsvalidVariableSymbol(char symbol)
    {
        if(!char.IsLetterOrDigit(symbol) ||symbol=='_')
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    static void Main()
    {
        string inputcode = ReadInput();
    }
}