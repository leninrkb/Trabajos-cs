public class Herramientas
{

    public static List<Persona> LeerCSV(string path){
        StreamReader reader = new StreamReader(path);
        List<Persona> personas = new List<Persona>(); // guardar las personas
        Boolean primera_linea = true; //para ignorar la primera linea
        String linea = ""; //guardar la linea leida
        String[] datos; //guardar el split de la linea
        while (!reader.EndOfStream)
        {
            linea = reader.ReadLine();
            if (primera_linea)
            {
                primera_linea = false;
                continue;
            }
            datos = linea.Split(',');
            Persona p = new Persona();
            p.id = datos[0];
            p.nombre = datos[1];
            p.apellido = datos[2];
            p.ciudad = datos[3];
            p.genero = datos[4];
            p.ingresos = int.Parse(datos[5]);
            p.egresos = int.Parse(datos[6]);
            personas.Add(p);
            // Console.WriteLine(p.ToString());
        }
        reader.Close();
        return personas;
    }
    public static void AvgDescendienteIngresosCiudades(List<Persona> lista)
    {
        //primero agrupo por ciudades 
        var ciudades = lista.GroupBy(p => p.ciudad).Select(g => new{
            g_ciudad = g.Key,
            g_ingresos = g.Average(p => p.ingresos)
        }).OrderByDescending(p => p.g_ingresos);

        foreach (var ciudad in ciudades)
        {
            Console.WriteLine($"{ciudad.g_ciudad} : {ciudad.g_ingresos}");   
        }
        Console.WriteLine("\n");
    }

    public static void AvgIngresosGenero(List<Persona> lista)
    {
        var generos = lista.GroupBy(p => p.genero).Select(g => new{
            g_genero = g.Key,
            g_ingresos = g.Average(p => p.ingresos)
        });
        foreach (var genero in generos)
        {
            Console.WriteLine($"{genero.g_genero} : {genero.g_ingresos}");   
            
        }
        Console.WriteLine("\n");
    }
}