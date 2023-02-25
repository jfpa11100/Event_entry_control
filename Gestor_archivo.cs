using System.IO;
using System.Text;

abstract class Gestor_archivos
{
    public static Gestor_archivos cargar_archivo(string archivo)
    {
        FileInfo fi = new FileInfo(archivo);
        string extension = fi.Extension;

        if (extension == ".txt")
        {
            Gestor_archivos_txt gestor = new();
            return gestor;
        }
        else if (extension == ".csv")
        {
            Gestor_archivos_csv gestor = new();
            return gestor;
        }
        else
        {
            Console.WriteLine("No se pudo leer archivo de personas");
            Environment.Exit(0);
            return null;
        }
    }

    public abstract void extraer_informacion(string archivo);
}



class Gestor_archivos_txt:Gestor_archivos
{
    public override void extraer_informacion(string archivo)
    {
        string[] lines = File.ReadAllLines(archivo);
        List<Visitante> lista_visitantes = new List<Visitante>();
        int cont = 0;
        foreach (string line in lines)
        {
            if (cont != 0)
            {
                string[] parts = line.Split("\t");
                lista_visitantes.Add(new Visitante(parts[0], parts[1], parts[2], parts[3]));
            }
            cont++;
        }
        Evento.generar_lista_invitados(lista_visitantes);
    }
}
    
class Gestor_archivos_csv : Gestor_archivos
{
    public override void extraer_informacion(string archivo)
    {
        List<Visitante> lista_visitantes = new List<Visitante>();
        int cont = 0;
        using (var reader = new StreamReader(archivo))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (cont != 0)
                {
                    var parts = line.Split(',');
                    if (parts.Length  == 4)
                    {
                    lista_visitantes.Add(new Visitante(parts[0], parts[1], parts[2], parts[3]));
                    }
                    else
                    {
                        var values = line.Split("**");
                        lista_visitantes.Add(new Visitante(values[0], values[1], values[2], values[3]));
                    }
                }
                cont++;
            }
            Evento.generar_lista_invitados(lista_visitantes);
        }
    }
}
    
