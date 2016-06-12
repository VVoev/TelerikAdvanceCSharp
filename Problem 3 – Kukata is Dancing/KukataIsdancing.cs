using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class KukataIsdancing
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int currectPosition = 5;
        var colors = new List<string>();
        string kukataFace = "top";
        for (int i = 0; i < n; i++)
        {
            string comand = Console.ReadLine();
            for (int direction = 0; direction < comand.Length; direction++)
            {
                if (comand[direction] == 'R')
                {
                    if (kukataFace == "top")
                    {
                        kukataFace = "right";
                    }
                    else if (kukataFace == "right")
                    {
                        kukataFace = "bottom";
                    }
                    else if (kukataFace == "bottom")
                    {
                        kukataFace = "left";
                    }
                    else if (kukataFace == "left")
                    {
                        kukataFace = "top";
                    }
                }
                else if (comand[direction] == 'L')
                {
                    if (kukataFace == "top")
                    {
                        kukataFace = "left";
                    }
                    else if (kukataFace == "left")
                    {
                        kukataFace = "bottom";
                    }
                    else if (kukataFace == "bottom")
                    {
                        kukataFace = "right";
                    }
                    else if (kukataFace == "right")
                    {
                        kukataFace = "top";
                    }
                }
                else //catch W
                {
                    if (kukataFace == "top")
                    {
                        currectPosition -= 3;
                    }
                    else if (kukataFace == "right")
                    {
                        currectPosition += 1;
                    }
                    else if (kukataFace == "bottom")
                    {
                        currectPosition += 3;
                    }
                    else if (kukataFace == "left")
                    {
                        currectPosition -= 1;
                    }
                }
                if(currectPosition<=0)
                    currectPosition += 9;
                else if (currectPosition > 9)
                    currectPosition -= 9;
            }
        }     
    }
}   