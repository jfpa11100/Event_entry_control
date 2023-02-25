using System.Numerics;

class Evento
{
    static Taquillero Taquillero;
    static List<Visitante> Lista_invitados = new();

    public Evento() { }
    public static void generar_lista_invitados(List<Visitante> lista_visitantes)
    {
        foreach (Visitante visitante in lista_visitantes)
        {
            validar_visitante(visitante); 
        }
    }

    private static void set_Invitado(Visitante invitado)
    {
        Evento.Lista_invitados.Add(invitado);
    }
    public static void set_Taquillero(string nombre, string id, string email, string edad)
    {
        Taquillero = new Taquillero(nombre, id, email, edad);
        Gestor_archivos gestor = Gestor_archivos.cargar_archivo("Taller_herencia_.csv");
        gestor.extraer_informacion("Taller_herencia_.csv");
    }

    public static void validar_visitante(Visitante visitante)
    {
        bool emailValid = ValidEmail(visitante.get_email());
        if (visitante.get_edad() >= 18 && emailValid == true)
        {
            Taquillero.bienvenida_visitante(visitante);
            set_Invitado(visitante);
        }

    }
    private static bool ValidEmail(string email)
    {
        if (!char.IsLetter(email[0]))
            return false;
        int atIndex = email.IndexOf('@');
        if (atIndex <= 0 || atIndex >= email.Length - 1)
            return false;
        string domain = email.Substring(atIndex + 1);
        if (domain != "gmail.com" && domain != "hotmail.com" && domain != "live.com" && domain != "gmail.co" && domain != "hotmail.co" && domain != "live.co" && domain != "gmail.edu.co" && domain != "hotmail.edu.co" && domain != "live.edu.co" && domain != "gmail.org" && domain != "hotmail.org" && domain != "live.org")
            return false;
        if (!email.EndsWith(".com") && !email.EndsWith(".co") && !email.EndsWith(".edu.co") && !email.EndsWith(".org"))
            return false;
        return true;
    }
}
