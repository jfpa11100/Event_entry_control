using System.Xml.Linq;

class Persona {
    string Nombre;
    string Edad;
    string Email;
    string Id;

    public Persona(string nombre, string edad, string email, string id) {

        Nombre = nombre;
        Edad = edad;
        Email = email;
        Id = id;
    }

    public string get_nombre()
    {
        return Nombre;
    }

    public string get_email()
    {
        return Email;
    }

    public int get_edad()
    {
        int edad = Convert.ToInt32(Edad);
        return edad;
    }

    public override string ToString()
    {
        return Nombre;
    }

}