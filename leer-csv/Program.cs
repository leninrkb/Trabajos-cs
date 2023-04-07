using System.IO;
public class Program
{
    public static void Main(String[] args)
    {
        String ruta = "./IngresosEgresos.csv";
        StreamReader reader = new StreamReader(ruta);
        List<Persona> personas = new List<Persona>();
        Boolean primera_linea = true;
        String linea = "";
        String[] datos;
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
        Console.WriteLine("total datos: " + personas.Count);
    }
}
