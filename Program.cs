DataBase database = new DataBase();

int index = 0;
ConsoleKey key;
string[] opciones = { "Ver vehiculos","Agregar","Borrar por ID", "Actualizar propiedades"};



while (true)
{
    Console.Clear();
    for (int i = 0; i < opciones.Length; i++)
    {
        if (index == i)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($">>{opciones[i]}<<");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine(opciones[i]);
        }
    }

    key = Console.ReadKey(true).Key;


    if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
    {
        index--;
        if (index < 0)
        {
            index = opciones.Length - 1;
        }
    }
    else if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
    {
        index++;
        if (index >= opciones.Length)
        {
            index = 0;
        }
    }

    if (key == ConsoleKey.Enter && index == 0)
    {
        database.Test();
        Console.WriteLine("Pulse una tecla para continuar...");
        Console.ReadKey();
    }
    else if (key == ConsoleKey.Enter && index == 1)
    {
        database.agregar();
        Console.WriteLine("Pulse una tecla para continuar...");
        Console.ReadKey();
    }
    else if (key == ConsoleKey.Enter && index == 2)
    {
        database.borrar();
        Console.WriteLine("Pulse una tecla para continuar...");
        Console.ReadKey();
    }
    else if (key == ConsoleKey.Enter && index == 3)
    {
        database.update();
        Console.WriteLine("Pulse una tecla para continuar");
        Console.ReadKey();
    }

}