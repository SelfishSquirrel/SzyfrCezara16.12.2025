using System;
using System.Text;

class MainProgram
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Podaj tekst do zaszyfrowania:");
        string text = Console.ReadLine();
        Console.WriteLine("Podaj klucz szyfrowania (liczba całkowita):");
        int mover = int.Parse(Console.ReadLine());
        Console.WriteLine(MakeEncode(text, mover));
    }

    private static string MakeEncode(string text, int mover)
    {
        StringBuilder cypherText = new StringBuilder();
        char[] chars = text.ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            char currentChar = chars[i];
            int code = (int)currentChar;

            if (!((code >= 65 && code <= 90) || (code >= 97 && code <= 122)))
            {
                return "Błąd: tekst zawiera niedozwolone znaki.";
            }

            int baseCode = (code >= 65 && code <= 90) ? 65 : 97; 
            int shifted = (code - baseCode + mover) % 26;

            if (shifted < 0)
            {
                shifted += 26;
            }

            cypherText.Append((char)(baseCode + shifted));
        }

        return cypherText.ToString();
    }
}