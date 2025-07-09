// See https://aka.ms/new-console-template for more information

public class Program
{
    public static void Main(string[] args)
    {
        foreach (var arg in args)
        {
            Console.WriteLine(arg);
        }
        
        IntToShort(2);
        IntToDouble(20);
        IntToLong(100);
        FloatToInt(5);
        IntToFloat(10);
        IntToDouble(50);
        BoolToString(true);
        IntToString(500);
        
        BoxingValue(599);
        UnboxingValue<string>("100");
        UnboxingValue<string>(100); // Erro de incompatibilidade
    }

    public static void IntToShort(int value)
    {
        short shortValue;
        bool success = short.TryParse(value.ToString(), out shortValue);
        ShowMessage(success, shortValue);
    }

    public static void IntToLong(int value)
    {
        long longValue;
        bool success = long.TryParse(value.ToString(), out longValue);
        ShowMessage(success, longValue);
        
    }

    public static void FloatToInt(float value)
    {
        int intValue;
        bool success = int.TryParse(value.ToString(), out intValue);
        ShowMessage(success, intValue);
    }

    public static void IntToFloat(int value)
    {
        float floatValue;
        bool success = float.TryParse(value.ToString(), out floatValue);
        ShowMessage(success, floatValue);
    }

    public static void IntToDouble(int value)
    {
        double doubleValue;
        bool success = double.TryParse(value.ToString(), out doubleValue);
        ShowMessage(success, doubleValue);
    }

    public static void BoolToString(bool value)
    {
        string stringValue = value.ToString();
        ShowMessage(true, stringValue);
    }

    public static void IntToString(int value)
    {
        string stringValue = value.ToString();
        ShowMessage(true, stringValue);
    }

    public static void BoxingValue<T>(T value)
    {
        if (value != null)
        {
            object boxedValue = value;
            Console.WriteLine($"Valor após o boxing: {boxedValue}");    
        }
        else
        {
            Console.WriteLine("Não foi possível fazer boxing. O valor passado é nulo");
        }
        
    }

    public static void UnboxingValue<T>(object value)
    {
        if (value is T unboxedValue)
        {
            Console.WriteLine($"Valor após o unboxing: {unboxedValue}");
        }
        else
        {
            Console.WriteLine("Não foi possível fazer unboxing. O valor passado é incompatível");
        }
    }

    public static void ShowMessage<T>(bool success, T value)
    {
        if (success)
            Console.WriteLine($"Valor convertido para {typeof(T)}: {value}" );
        else 
            Console.WriteLine("Não foi possível converter.");
    }
}

