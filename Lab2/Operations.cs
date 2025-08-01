﻿namespace Lab2;

public class Operations
{
    public static void Main()
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("===== ATV. 1 =====");
        Console.BackgroundColor = ConsoleColor.Black;

        Console.WriteLine("Digite uma frase para ser embaralhada:");
        var mixableContent = Console.ReadLine();
        if (mixableContent != null)
            DivideAndJoin(mixableContent);
        else
            Console.WriteLine("Não foi possível embaralhar, o conteúdo é nulo.");
        
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("===== ATV. 2 =====");
        Console.BackgroundColor = ConsoleColor.Black;

        Console.WriteLine("Digite uma frase:");
        var searchableContent = Console.ReadLine();

        Console.WriteLine("Digite uma substring para ser procurada na frase:");
        var substring = Console.ReadLine();

        if (searchableContent != null && substring != null)
            GetSubstring(searchableContent, substring);
        else
            Console.WriteLine("Não foi possível pesquisar, os valores passados são nulos.");
        
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("===== ATV. 3 =====");
        Console.BackgroundColor = ConsoleColor.Black;
        
        Console.WriteLine("Digite uma frase:");
        var searchableStringsContent = Console.ReadLine();
        
        Console.WriteLine("Digite as cadeias a serem procuradas na frase, separadas por ',' (vírgula):");
        var stringSearch = Console.ReadLine();

        if (searchableStringsContent != null && stringSearch != null)
        {
            var arraySearch = stringSearch.Split(",");
            SearchCharacters(searchableStringsContent, arraySearch);            
        }
        else
        {
            Console.WriteLine("Não foi possível pesquisar, os valores passados são nulos.");
            
        }
    }
    
    public static void DivideAndJoin(string content)
    {
        var charsArray = content.ToCharArray();
        var desorderedCharsArray = Desorder(charsArray).ToArray();
        var result = String.Join("", desorderedCharsArray);
        
        Console.WriteLine($"Frase original: {content}");
        Console.WriteLine($"Frase embaralhada: {result}");
    }

    public static IOrderedEnumerable<char> Desorder(char[] chars)
    {
        Random random = new Random();
        return chars.OrderBy(n => random.Next());
    }

    public static void GetSubstring(string content, string substring)
    {
        var result = content.IndexOf(substring, StringComparison.CurrentCulture);
        if (result == -1)
        {
            Console.WriteLine($"Substring não encontrada.");
        }
        else
        {
            Console.WriteLine($"A substring '{substring}' foi encontrada na posição {result}.");
        }
    }

    public static void SearchCharacters(string content, string[] search)
    {
        for (int i = 0; i < search.Length; i++)
        {
            var initialIndex = content.IndexOf(search[i], StringComparison.CurrentCulture);
            var lastIndex = initialIndex + search[i].Length - 1;
            if (initialIndex == -1 || lastIndex == -1)
                Console.WriteLine($"A cadeia '{search[i]}' não foi encontrada");
            else
                Console.WriteLine($"A cadeia '{search[i]}' foi encontrada entre os índices {initialIndex} e {lastIndex}.");
        }
    }
}