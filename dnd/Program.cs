// ============================================================
// CLASE BASE: Personaje
// Concepto: CLASE BASE (superclase / clase padre)
// Define los atributos y comportamientos comunes a todos los
// tipos de personaje. Las clases derivadas heredarán de esta.
// ============================================================
class Personaje
{
    // Concepto: CAMPOS PÚBLICOS
    // Almacenan el estado del objeto (nombre y puntos de vida).
    public string Nombre;
    public int Vida;

    // Concepto: CONSTRUCTOR
    // Método especial que se ejecuta al crear una instancia.
    // Inicializa los campos con los valores recibidos como parámetros.
    public Personaje(string nombre, int vida)
    {
        Nombre = nombre;
        Vida = vida;
    }

    // Concepto: MÉTODO VIRTUAL
    // El modificador 'virtual' permite que las clases derivadas
    // sobreescriban (override) este método con su propia versión.
    // Esto es la base del POLIMORFISMO en C#.
    public virtual void Atacar()
    {
        Console.WriteLine($"{Nombre} ataca de forma básica");
    }

    // Concepto: MÉTODO NO VIRTUAL (comportamiento heredado sin cambios)
    // Las clases hijas heredan este método tal cual, sin necesidad
    // de redefinirlo. Ejemplo de REUTILIZACIÓN DE CÓDIGO.
    public void MostrarEstado()
    {
        Console.WriteLine($"{Nombre} tiene {Vida} de vida");
    }
}

// ============================================================
// CLASE DERIVADA: Guerrero
// Concepto: HERENCIA
// 'Guerrero : Personaje' significa que Guerrero hereda todos
// los campos y métodos públicos de Personaje.
// ============================================================
class Guerrero : Personaje
{
    // Concepto: CONSTRUCTOR CON LLAMADA A BASE
    // ': base(nombre, 150)' llama al constructor de la clase padre
    // pasándole el nombre y un valor de vida fijo (150).
    public Guerrero(string nombre) : base(nombre, 150) {}

    // Concepto: SOBREESCRITURA DE MÉTODO (override / polimorfismo)
    // Reemplaza la implementación de Atacar() de la clase base
    // con el comportamiento específico del Guerrero.
    public override void Atacar()
    {
        Console.WriteLine($"{Nombre} ataca con espada");
        Console.ForegroundColor = ConsoleColor.DarkRed; // Cambia el color de la consola
        Console.WriteLine(@"
        />_________________________________
[########[]_________________________________>
        \>
        ");
        Console.ResetColor(); // Restaura el color original de la consola
    }
}

// ============================================================
// CLASE DERIVADA: Mago
// Concepto: HERENCIA
// Hereda de Personaje con vida más baja (80) que el Guerrero,
// representando un personaje frágil pero poderoso.
// ============================================================
class Mago : Personaje
{
    // Constructor que fija la vida del Mago en 80 mediante 'base'.
    public Mago(string nombre) : base(nombre, 80) {}

    // Concepto: SOBREESCRITURA DE MÉTODO (override / polimorfismo)
    // Comportamiento de ataque exclusivo del Mago.
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

// ============================================================
// CLASE DERIVADA: Arquero
// Concepto: HERENCIA
// Hereda de Personaje con un nivel de vida intermedio (100).
// ============================================================
class Arquero : Personaje
{
    // Constructor que fija la vida del Arquero en 100 mediante 'base'.
    public Arquero(string nombre) : base(nombre, 100) {}

    // Concepto: SOBREESCRITURA DE MÉTODO (override / polimorfismo)
    // Comportamiento de ataque exclusivo del Arquero.
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


// ============================================================
// CLASE PRINCIPAL: Program
// Contiene el punto de entrada de la aplicación (método Main).
// ============================================================
class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        // LOGO INICIAL: arte ASCII decorativo para la pantalla de bienvenida
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
        Console.ReadKey(); // Pausa hasta que el usuario presione cualquier tecla

        // Concepto: BUCLE INFINITO con salida controlada (return / break)
        // El juego sigue corriendo hasta que el usuario elija "Salir".
        while (true)
        {
            Console.Clear(); // Limpia la pantalla antes de mostrar el menú

            Console.WriteLine("=== DUNGEON MENU ===");
            Console.WriteLine("1. Guerrero");
            Console.WriteLine("2. Mago");
            Console.WriteLine("3. Arquero");
            Console.WriteLine("4. Salir");
            Console.Write("Selecciona una opción: ");

            string opcion = Console.ReadLine(); // Lee la opción ingresada por el usuario

            // Concepto: VARIABLE DE TIPO BASE (Personaje)
            // Se declara como tipo 'Personaje' para poder almacenar
            // cualquier clase derivada (Guerrero, Mago o Arquero).
            // Esto es POLIMORFISMO: una variable de tipo padre referencia
            // objetos de tipos hijos.
            Personaje personaje = null;

            // Concepto: SWITCH para selección múltiple
            // Según la opción ingresada, se instancia la clase derivada
            // correspondiente y se asigna a la variable de tipo base.
            switch (opcion)
            {
                case "1":
                    // Concepto: INSTANCIACIÓN de clase derivada
                    // 'new Guerrero("Thor")' crea un objeto Guerrero y lo
                    // asigna a una variable de tipo Personaje (polimorfismo).
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
                    return; // Termina el programa

                default:
                    Console.WriteLine("Opción inválida");
                    Console.ReadKey();
                    continue; // Vuelve al inicio del bucle while
            }

            Console.Clear();

            Console.WriteLine("=== PERSONAJE SELECCIONADO ===\n");

            // Concepto: POLIMORFISMO EN ACCIÓN
            // Aunque 'personaje' es de tipo Personaje, C# ejecuta
            // la versión sobreescrita de Atacar() según el tipo real
            // del objeto (Guerrero, Mago o Arquero). Esto se llama
            // DISPATCH DINÁMICO o ENLACE TARDÍO (late binding).
            personaje.Atacar();

            Console.WriteLine("\nPresiona una tecla para volver al menú...");
            Console.ReadKey();
        }
    }
}




