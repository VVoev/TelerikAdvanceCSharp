using System;
using System.Collections.Generic;
using System.Linq;
    class Digits_Telerik
    {
    static int[,] digits;
    public static List<bool[,]> InnitializeListofPatterns()
    {

        var list = new List<bool[,]>();
        list.Add(new bool[,]
            {
                                         // 0

            });

        list.Add(new bool[,]
       {
           {false,false,true,},
           {false,true,true,},
           {true,false,true,},          //   1
           {false,false,true,},
           {false,false,true,}

       });
        list.Add(new bool[,]
       {
           {false,true,false,},                         
           {true,false,true,},                          
           {false,false,true,},          //   2         
           {false,true,false,},                         
           {true,true,true,}                            

       });

        list.Add(new bool[,]
      {
           {true,true,true,},                        
           {false,false,true,},                        
           {false,true,true,},          //   3        
           {false,false,true,},                        
           {true,true,true,}                         
                                                                                                 
      });
        list.Add(new bool[,]
    {
           {true,false,true},
           {true,false,true,},
           {true,true,true},          //   4      
           {false,false,true,},
           {false,false,true}

    });
        list.Add(new bool[,]
{
           {true,true,true},
           {true,false,false,},
           {true,true,true},          //   5    
           {false,false,true,},
           {true,true,true}

});
        list.Add(new bool[,]
{
           {true,true,true},
           {true,false,false},
           {true,true,true},          //   6
           {true,false,true,},
           {true,true,true}

});
        list.Add(new bool[,]
{
           {true,true,true},
           {false,false,true,},
           {false,true,false},          //   7
           {false,true,false,},
           {false,true,false}

});
        list.Add(new bool[,]
{
           {true,true,true},
           {true,false,true,},
           {false,true,false},          //   8
           {true,false,true,},
           {true,true,true}

});
        list.Add(new bool[,]
{
           {true,true,true},
           {true,false,true,},
           {false,true,true},          //   9
           {false,false,true,},
           {true,true,true}

});
        return list;

    }
    static bool checkPattern(bool [,] pattern,int digit,int row,int col)
    {
        for (int i = 0; i < pattern.GetLength(0); i++)
        {
            for (int j = 0; j < pattern.GetLength(1); j++)
            {
                if(pattern[i,j]) 
                {
                     if(digits[row+i,col+j] != digit)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    static void Main()
    {
        var patterns = InnitializeListofPatterns();
        int n = int.Parse(Console.ReadLine());
        digits = new int[n, n];
        for (int row = 0; row < n; row++)
        {
            string[] currentline = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int col = 0; col < currentline.Length; col++)
            {
                digits[row, col] = int.Parse(currentline[col]);   
            }
        }
        int sum = 0;
        for (int row = 0; row <= n-5; row++)
        {
            for (int col = 0; col <= n-3; col++)
            {

                if (digits[row + 2, col] == 1)
                {
                    if (checkPattern(patterns[1], 1, row, col))
                    {
                        sum += 1;
                        continue;

                    }

                }
                if (digits[row+1,col]==2)
                {
                    if (checkPattern(patterns[2],2,row,col))
                    {
                        sum += 2;
                        continue;

                    }
                }
                int currentDigit = digits[row, col];
                if(checkPattern(patterns[currentDigit],currentDigit,row,col))
                {
                    sum += currentDigit;
                }

            }
        }
        Console.WriteLine(sum);

    }
}