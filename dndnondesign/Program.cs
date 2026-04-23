// ============================================================
// CLASE BASE: Personaje
// Esta clase representa la idea general de un personaje del juego.
// Concepto: clase base o clase padre.
// Las demás clases heredan de aquí las características comunes.
// En este ejemplo NO es abstracta, así que podría instanciarse.
// ============================================================
class Personaje
{
    // Campo público que guarda el nombre del personaje.
    // Concepto: atributo o estado del objeto.
    public string Nombre;

    // Campo público que guarda la cantidad de vida del personaje.
    // Cada objeto tendrá su propio valor de vida.
    public int Vida;

    // Constructor de la clase base.
    // Concepto: método especial que se ejecuta al crear un objeto.
    // Recibe los valores iniciales y los asigna a los campos.
    public Personaje(string nombre, int vida)
    {
        // Se copia el parámetro recibido al campo del objeto actual.
        Nombre = nombre;

        // Se inicializa la vida del personaje con el valor recibido.
        Vida = vida;
    }

    // Método normal, no virtual.
    // Concepto: como NO tiene 'virtual', las clases hijas no lo
    // sobrescriben de forma polimórfica; solo pueden ocultarlo.
    public void Atacar()
    {
        // Interpolación de cadenas: inserta el valor de Nombre dentro del texto.
        Console.WriteLine($"{Nombre} ataca de forma básica");
    }

    // Método auxiliar para mostrar el estado actual del personaje.
    // También es un método normal heredable.
    public void MostrarEstado()
    {
        Console.WriteLine($"{Nombre} tiene {Vida} de vida");
    }
}

// ============================================================
// CLASE: Guerrero
// Concepto: herencia.
// 'Guerrero : Personaje' significa que Guerrero hereda de Personaje.
// Obtiene Nombre, Vida y MostrarEstado() desde la clase padre.
// ============================================================
// Importante: aquí NO se usa override. El método Atacar() de esta
// clase no reemplaza polimórficamente al del padre; lo oculta.
// ============================================================
class Guerrero : Personaje
{
    // Constructor de Guerrero.
    // ': base(nombre, 150)' llama al constructor de la clase padre.
    // Se reutiliza la lógica de inicialización y se fija la vida en 150.
    public Guerrero(string nombre) : base(nombre, 150) {}

    // Este método tiene el mismo nombre que Atacar() del padre,
    // pero como el del padre no es virtual y aquí no hay override,
    // esto es ocultamiento de método, no polimorfismo real.
    public void Atacar()
    {
        // Muestra el tipo de ataque propio del guerrero.
        Console.WriteLine($"{Nombre} ataca con espada");

        // Cambia temporalmente el color del texto en consola.
        Console.ForegroundColor = ConsoleColor.DarkRed;

        // Cadena verbatim (@) para imprimir varias líneas tal cual,
        // útil para dibujar ASCII art sin escapar tanto el texto.
        Console.WriteLine(@"
        />_________________________________
[########[]_________________________________>
        \>
        ");

        // Restaura el color original de la consola para no afectar
        // las siguientes impresiones en pantalla.
        Console.ResetColor();
    }
}

// ============================================================
// CLASE: Mago
// Hereda de Personaje y define su propia versión visible de Atacar().
// Igual que en Guerrero, aquí se oculta el método del padre.
// ============================================================
class Mago : Personaje
{
    // Llama al constructor de la clase base con una vida inicial de 80.
    public Mago(string nombre) : base(nombre, 80) {}

    // Método específico del mago.
    // Tiene el mismo nombre que el del padre, pero no usa override.
    public void Atacar()
    {
        // Cambia el color del texto para representar la magia.
        Console.ForegroundColor = ConsoleColor.DarkBlue;

        // Se imprime el mensaje de ataque usando el nombre heredado.
        Console.WriteLine($"{Nombre} lanza un hechizo");

        // Efecto visual del hechizo usando texto multilínea.
        Console.WriteLine(@"
              *
            *   *
          *  BOOM *
            *   *
              *
        ");

        // Se vuelve al color normal de la consola.
        Console.ResetColor();
    }
}

// ============================================================
// CLASE: Arquero
// También hereda de Personaje y define su propio ataque visible.
// ============================================================
class Arquero : Personaje
{
    // Se llama al constructor base y se asigna vida inicial de 100.
    public Arquero(string nombre) : base(nombre, 100) {}

    // Método específico del arquero.
    // De nuevo, no es override: solo oculta el Atacar() heredado.
    public void Atacar()
    {
        // Mensaje del ataque a distancia.
        Console.WriteLine($"{Nombre} dispara una flecha");

        // Color verde para diferenciar visualmente este personaje.
        Console.ForegroundColor = ConsoleColor.DarkGreen;

        // Dibujo ASCII de una flecha.
        Console.WriteLine(@"
            \\
             \\
              >>------>
             //
            //
        ");

        // Se restaura el color para evitar efectos colaterales.
        Console.ResetColor();
    }
}

// ============================================================
// MAIN
// Clase que contiene el punto de entrada del programa.
// Concepto: Main() es el método donde comienza la ejecución.
// ============================================================
class Program
{
    static void Main()
    {
        // Este comentario resume la idea central del ejemplo:
        // como Atacar() en Personaje no es virtual y en las clases hijas
        // no se usa override, aquí no se demuestra polimorfismo dinámico.
        // En su lugar, cada variable se usa con su tipo concreto.

        // Título inicial que explica que esta es una demostración
        // sin uso de polimorfismo real en la llamada a Atacar().
        Console.WriteLine("=== DEMO SIN POLIMORFISMO ===\n");

        // Se crean objetos concretos de cada clase hija.
        // Concepto: instanciación mediante 'new'.
        Guerrero g = new Guerrero("Thor");
        Mago m = new Mago("Merlin");
        Arquero a = new Arquero("Legolas");

        // Se llama al método Atacar() del objeto Guerrero.
        // Como la variable es de tipo Guerrero, se usa directamente
        // el método definido en esa clase.
        g.Atacar();

        // Línea en blanco para separar visualmente la salida.
        Console.WriteLine();

        // Se ejecuta el ataque propio del Mago.
        m.Atacar();

        // Otra separación visual.
        Console.WriteLine();

        // Se ejecuta el ataque propio del Arquero.
        a.Atacar();
    }
}