using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hur många koder vill du skriva in?");
        int numCodes = int.Parse(Console.ReadLine());

        Dictionary<char, char> codeMap = new Dictionary<char, char>();

        // Mata in koder
        Console.WriteLine("Ange koder på formen 'X Y', där X byts ut mot Y:");
        for (int i = 0; i < numCodes; i++)
        {
            string[] code = Console.ReadLine().Split(' ');
            char from = code[0][0];
            char to = code[1][0];
            codeMap[from] = to;
        }

        // Läs in det hemliga meddelandet
        Console.WriteLine("Skriv in ditt hemliga meddelande:");
        string secretMessage = Console.ReadLine();

        // Avkoda meddelandet
        string decodedMessage = DecodeMessage(secretMessage, codeMap);

        // Skriv ut det avkodade meddelandet
        Console.WriteLine("Här är ditt avkodade meddelande:");
        Console.WriteLine(decodedMessage);
    }

    static string DecodeMessage(string message, Dictionary<char, char> codeMap)
    {
        char[] decodedChars = new char[message.Length];

        for (int i = 0; i < message.Length; i++)
        {
            char currentChar = message[i];

            if (codeMap.ContainsKey(currentChar))
            {
                // Om koden finns, byt ut tecknet enligt koden
                char decodedChar = codeMap[currentChar];

                // Följ kedjan av koder om det behövs
                while (codeMap.ContainsKey(decodedChar))
                {
                    decodedChar = codeMap[decodedChar];
                }

                decodedChars[i] = decodedChar;
            }
            else
            {
                // Om koden inte finns, behåll tecknet
                decodedChars[i] = currentChar;
            }
        }

        return new string(decodedChars);
    }
}