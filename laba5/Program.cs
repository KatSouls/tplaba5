using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите строку: ");
        string inputString = Convert.ToString(Console.ReadLine());

        string len = inputString.Trim();
        int lenSize = len.Length;

        if (len[lenSize-1] != '.' && len[lenSize-1] != '!' && len[lenSize-1] != '?')
        {
            Console.Write("ОШИБКА: предложение не кочнается знаком препинания");
            System.Environment.Exit(1);
        }

        if (inputString.Length > 200)
        {
            Console.Write("ОШИБКА: длинна строки больше 200");
            System.Environment.Exit(1);
        }

        for (int i = 0; i < lenSize; i++)
        {
            if(inputString[0] == ' ')
            {
                Console.Write("ОШИБКА: каждому слову, кроме первого, предшествует 1 пробел ");
                System.Environment.Exit(1);
            }
            if (len[i] == ' ' && len[i+1] == ' ')
            {
                Console.Write("ОШИБКА: каждому слову, кроме первого, предшествует 1 пробел");
                System.Environment.Exit(1);
            }
            if(len[i] == '.' || len[i] == '!' || len[i] == '?' || len[i] == ',')
            { 
                if(len[i-1] == ' ')
                {
                    Console.Write("ОШИБКА: перед знаком препинания стоит пробел");
                    System.Environment.Exit(1);
                }
            }
        }

        string[] sentences = inputString.Split('.', '!', '?');

        for (int i = 0; i < sentences.Length - 1; i++)
        {
            string sentence = sentences[i].Trim();
            if (char.IsUpper(sentence[0])) { continue; }
            else
            {
                Console.Write("ОШИБКА: после знака препинания первая буква слова должна быть в верхнем регистре");
                System.Environment.Exit(1);
            }
        }

        Console.WriteLine("Исходная строка:");
        Console.WriteLine(inputString);

        

        if (sentences.Length <= 3)
        {
            Console.Write("ОШИБКА: количество предложений меньше 3");
            System.Environment.Exit(1);
        }
        Console.WriteLine("Длинна строки: " + lenSize);
        if (lenSize % 5 == 0)
        { 
            for (int i = 0; i < sentences.Length - 1; i++)
            {
                Console.WriteLine(i + 1 + ") Предложение: ");
                for (int j = 0; j < sentences[i].Length; ++j)
                {
                    if((sentences[i][j] >= 'а' && sentences[i][j] <= 'д') || (sentences[i][j] >= 'А' && sentences[i][j] <= 'Д'))
                    {
                        Console.Write(sentences[i][j]);
                    }
                }
                Console.Write("\n");
            }
        }
        else
        {
            for (int i = 0; i < sentences.Length - 1; i++)
            {
                Console.WriteLine(i + 1 + ") Предложение: " + sentences[i]);
            }
        }
    }
}