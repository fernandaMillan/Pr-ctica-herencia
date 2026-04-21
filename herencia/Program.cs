using System;

abstract class ComidaMexicana
{
    public void PrepararBase()
    {
        Console.WriteLine("Tortilla + salsa + pollo +ingredientes base");
    }

    public abstract void Servir();
}

class Taco : ComidaMexicana
{
    public override void Servir()
    {
        Console.WriteLine("Sirviendo taco");
    }
}

class Sope : ComidaMexicana
{
    public override void Servir()
    {
        Console.WriteLine("Sirviendo sope");
    }
}

class Program
{
    static void Main()
    {
        Taco taco = new Taco();
        taco.PrepararBase();
        taco.Servir();

        Console.WriteLine();

        Sope sope = new Sope();
        sope.PrepararBase();
        sope.Servir();
    }
}