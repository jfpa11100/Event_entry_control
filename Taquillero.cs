class Taquillero: Persona
{
    public Taquillero(string nombre, string id, string email, string edad):base(nombre, id, email, edad) { }

    public void bienvenida_visitante(Visitante visitante)
    {
        Console.WriteLine($"{visitante} bienvenido al evento");
    }

}
