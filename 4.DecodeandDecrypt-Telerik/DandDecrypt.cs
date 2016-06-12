using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
   public class DandDecrypt
    {
       public static void Main()
        {
        var input = Console.ReadLine();
        //Console.WriteLine(Decode("aa4b2c") == ("aabbbbcc")); Testring decode method
        var digits = new List<int>();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            if(char.IsDigit(input[i]))
            {
                digits.Add(input[i] - '0');
            }
            else
            {
                break;
            }
        }
        digits.Reverse();

        int lenghtofCypher = 0;
        foreach (var digit in digits)
        {
            lenghtofCypher *= 10;
            lenghtofCypher += digit;
        }
        //Console.WriteLine(lenghtofCypher); 




        //(Encode(Encrypt(message,cypher)+cypher)
        var encodedMessage = input.Substring(0, input.Length - digits.Count);


        //Encrype(message,cypher)+cypher
        var decodedMessage=Decode(encodedMessage);


        //Encrype (message,cypher)
        var encryptedMessage = decodedMessage.Substring(0, decodedMessage.Length - lenghtofCypher);


        //cypher
        var cypher = decodedMessage.Substring(decodedMessage.Length - lenghtofCypher, lenghtofCypher);
        //Console.WriteLine(encryptedMessage);
        //Console.WriteLine(cypher


        var message = Encrypt(encryptedMessage, cypher);

        Console.WriteLine(message);







        }
    public static  string Encrypt(string message,string cypher)
    {
        var steps = Math.Max(message.Length, cypher.Length);
        var result = new StringBuilder(message);
        for (int step = 0; step < steps; step++)
        {
            var messageIndex = step % message.Length;
            var cypherIndex = step % cypher.Length;
            result[messageIndex] =
                (char)(((result[messageIndex] - 'A') ^ (cypher[cypherIndex] - 'A')) + 'A');

        }
        return result.ToString();
    }
    private static string Decode(string encodedMessage)
    {
        var result = new StringBuilder();
        var count = 0;
        foreach (var ch in encodedMessage)
        {
            if(char.IsDigit(ch))
            {
                count *= 10;
                count += int.Parse(ch.ToString());
            }
            else
            {
                if(count==0)
                {
                    result.Append(ch);
                }
                else
                {
                    result.Append(ch, count);
                    count = 0;
                }
            }
        }



        return result.ToString();
    }
}
