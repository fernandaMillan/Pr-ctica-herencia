class Personaje
{
    public string Nombre;
    public int Vida;

    public Personaje(string nombre, int vida)
    {
        Nombre = nombre;
        Vida = vida;
    }

    public virtual void Atacar()
    {
        Console.WriteLine($"{Nombre} ataca de forma básica");
    }

    public void MostrarEstado()
    {
        Console.WriteLine($"{Nombre} tiene {Vida} de vida");
    }
}

class Guerrero : Personaje
{
    public Guerrero(string nombre) : base(nombre, 150) {}

    public override void Atacar()
    {
        Console.WriteLine($"{Nombre} ataca con espada");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(@"
        />_________________________________
[########[]_________________________________>
        \>
        ");
        Console.ResetColor();  
    }
}

class Mago : Personaje
{
    public Mago(string nombre) : base(nombre, 80) {}

    public override void Atacar()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine($"{Nombre} lanza un hechizo");
        Console.WriteLine(@"
              *
            *   *
          *  BOOM *
            *   *
              *
        ");
        Console.ResetColor();
    }
}

class Arquero : Personaje
{
    public Arquero(string nombre) : base(nombre, 100) {}

    public override void Atacar()
    {
        Console.WriteLine($"{Nombre} dispara una flecha");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(@"
            \\
             \\
              >>------>
             //
            //
        ");
        Console.ResetColor();
    }
}


class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        // LOGO INICIAL
        Console.WriteLine(@"
██████╗ ███╗   ██╗██████╗ 
██╔══██╗████╗  ██║██╔══██╗
██║  ██║██╔██╗ ██║██║  ██║
██║  ██║██║╚██╗██║██║  ██║
██████╔╝██║ ╚████║██████╔╝
╚═════╝ ╚═╝  ╚═══╝╚═════╝ 

        /\                 
       /  \    /\         
      / /\ \__/  \        
     / /  \      \        
     \ \  /      /        
      \ \/ /\   /         
       \  /  \ /          
        \/    V           

      DUNGEON MODE
");
        
        Console.ResetColor();  
        Console.WriteLine("Presiona una tecla para comenzar...");
        Console.ReadKey();

        while (true)
        {
            Console.Clear();

            Console.WriteLine("=== DUNGEON MENU ===");
            Console.WriteLine("1. Guerrero");
            Console.WriteLine("2. Mago");
            Console.WriteLine("3. Arquero");
            Console.WriteLine("4. Salir");
            Console.Write("Selecciona una opción: ");

            string opcion = Console.ReadLine();

            Personaje personaje = null;

            switch (opcion)
            {
                case "1":
                    personaje = new Guerrero("Thor");
                    break;

                case "2":
                    personaje = new Mago("Merlin");
                    break;

                case "3":
                    personaje = new Arquero("Legolas");
                    break;

                case "4":
                    Console.WriteLine("Saliendo del juego...");
                    return;

                default:
                    Console.WriteLine("Opción inválida");
                    Console.ReadKey();
                    continue;
            }

            Console.Clear();

            Console.WriteLine("=== PERSONAJE SELECCIONADO ===\n");

            personaje.Atacar();

            Console.WriteLine("\nPresiona una tecla para volver al menú...");
            Console.ReadKey();
        }
    }
}