namespace Lab2;

public class Operations
{
    public static void Main()
    {
        DivideAndJoin("A Terra é o terceiro planeta do sistema solar.");
        DivideAndJoin("O Corinthians é o maior clube do Brasil.");
        
        GetSubstring("Eu estou estudando RabbitMQ", "estudando");
        
        SearchCharacters("Eu estou no terceiro semestre de Engenharia de Software", 
            new string[] { "estou", "semestre", "Software", "teste" });
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